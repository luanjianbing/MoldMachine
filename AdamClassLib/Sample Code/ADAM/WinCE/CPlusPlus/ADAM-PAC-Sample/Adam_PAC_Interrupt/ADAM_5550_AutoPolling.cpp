#include "stdafx.h"
#include "ADSDIO.h"
#include "pkfuncs.h"
#include "ADAM_5550_AutoPolling.h"

#define ADAM_INTERRUPT 71
#define ADAM_BUFMAX 100
// define data structure for SLOT
typedef struct tagADAM5550_SLOTINFO
{
	int							iSlotID;
	int							iIoType; // 1: AIO module; 2: DIO module
	SYSTEMTIME					tTimeStamp;
	DWORD						dwMask;
	FLOAT						fDeadband;
	FLOAT						fPreValues[8];
	FLOAT						fNowValues[8];
	DWORD						dwPreValues;
	DWORD						dwNowValues;
//	void						*callbackParam;
	struct tagADAM5550_SLOTINFO	*nextPtr;
} ADAM5550_SLOTINFO;

// the deadband of the AI value
FLOAT m_fDeadband = 0.5f;
// event buffer
int m_iWriteIndex = 0;
int m_iReadIndex = 0;
ADAM5550_SLOTINFO	evtBuffer[ADAM_BUFMAX];
CRITICAL_SECTION	m_criticalSectionEvtBuffer; 
HANDLE				m_hFireEvent = NULL;

// define global variable
OnAioChangeEvent	m_callbackAioChanged;
OnDioChangeEvent	m_callbackDioChanged;
int					m_iAioRate;
int					m_iDioRate;
int					m_iAioPollingCount;
int					m_iDioPollingCount;
HANDLE				m_hInterruptEvent = NULL;
BOOL				m_bRunning = FALSE;
ADAM5550_SLOTINFO	*m_slotListHead = NULL;
ADAM5550_SLOTINFO	*m_slotListTail = NULL;
LONG				m_lHandle;
HANDLE				m_pollingThread = NULL;
HANDLE				m_fireThread = NULL;

// define global functions
BOOL TOOL_HookInterrupt();
BOOL TOOL_UnHookInterrupt();
BOOL TOOL_InitSlotInfo(OnAioChangeEvent i_aioEventHandle, int i_iAioRate, OnDioChangeEvent i_dioEventHandl, int i_iDioRate);
BOOL TOOL_ReleaseSlotInfo();

DWORD PollingThreadProc(DWORD *pThreadId);
DWORD FireThreadProc(DWORD *pThreadId);

BOOL AutoPolling_StartPolling(LONG i_lHandle, OnAioChangeEvent i_aioEventHandle, int i_iAioRate, OnDioChangeEvent i_dioEventHandl, int i_iDioRate)
{
	m_lHandle = i_lHandle;
	m_hFireEvent = CreateEvent(NULL, FALSE, FALSE, NULL);

	if (i_lHandle > 0 && 
		TOOL_InitSlotInfo(i_aioEventHandle, i_iAioRate, i_dioEventHandl, i_iDioRate) == TRUE)
	{
		// try to hook the system interrupt
		if (TOOL_HookInterrupt() == TRUE)
		{
			m_bRunning = TRUE;
			m_fireThread = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)FireThreadProc, 0, CREATE_SUSPENDED, NULL);
			if (m_fireThread != NULL)
			{
				printf("FireThreadProc created, now starting...\n");
				ResumeThread(m_fireThread); 
				//
				m_pollingThread = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)PollingThreadProc, 0, CREATE_SUSPENDED, NULL);
				if (m_pollingThread != NULL)
				{
					InitializeCriticalSection(&m_criticalSectionEvtBuffer);
					// start the polling thread
					printf("PollingThreadProc created, now starting...\n");
					ResumeThread(m_pollingThread); 
					return TRUE;
				}
				else
					printf("Create PollingThreadProc failed!\n");
				// create PollingThreadProc failed, terminate FireThreadProc
				m_bRunning = FALSE;
				WaitForSingleObject (m_fireThread, 5000); //INFINITE);
				m_fireThread = NULL;
			}
			else
				printf("Create FireThreadProc failed!\n");
			// function failed, unhook
			TOOL_UnHookInterrupt();
		}
		// function fail, so release resource
		TOOL_ReleaseSlotInfo();
	}
	return FALSE;
}

void AutoPolling_StopPolling()
{
	if (m_pollingThread != NULL)
	{
		// stop the polling thread first
		m_bRunning = FALSE;
		WaitForSingleObject (m_pollingThread, 5000); //INFINITE);
		m_pollingThread = NULL;
		//
		DeleteCriticalSection(&m_criticalSectionEvtBuffer);
		// unhook interrupt
		TOOL_UnHookInterrupt();
	}
	TOOL_ReleaseSlotInfo();
	if (m_hFireEvent != NULL)
		CloseHandle(m_hFireEvent);
}

// ================================================================================
// Method: TOOL_HookInterrupt
// action: Hook on the ADAM-5550 system 1ms interrupt
// pre   : 
// post  : If hookup succeeded, function returns TRUE.
//         Otherwise, function returns FALSE.
BOOL TOOL_HookInterrupt()
{
	m_hInterruptEvent = CreateEvent(NULL, FALSE, FALSE, NULL);
	if (m_hInterruptEvent == NULL)
	{
		printf("CreateEvent failed!\n");
		return FALSE;
	}
	if (InterruptInitialize(ADAM_INTERRUPT, m_hInterruptEvent, NULL, 0) == FALSE)
	{
		CloseHandle(m_hInterruptEvent);
		m_hInterruptEvent = NULL;
		printf("InterruptInitialize failed!\n");
		return FALSE;
	}
	printf("TOOL_HookInterrupt done\n");
	return TRUE;
}

// ================================================================================
// Method: TOOL_UnHookInterrupt
// action: UnHook on the ADAM-5550 system interrupt
// pre   : 
// post  : If unhookup succeeded, function returns TRUE.
//         Otherwise, function returns FALSE.
BOOL TOOL_UnHookInterrupt()
{
	if (m_hInterruptEvent != NULL)
	{
		InterruptDisable(ADAM_INTERRUPT);
		CloseHandle(m_hInterruptEvent);
		m_hInterruptEvent = NULL;
		return TRUE;
	}
	return FALSE;
}

// ================================================================================
// Method: TOOL_InitSlotInfo
// action: Scan all slots and create structure for slot with module
// pre   : i_aioEventHandle = the callback function for AI/AO changed
//         i_iAioRate = AIO polling rate, range from 10~100 ms, default is 50 ms
//         i_dioEventHandl = the callback function for DI/DO changed
//         i_iDioRate = DIO polling rate, range from 2~10 ms, default is 5 ms
// post  : If at least one module found, function returns TRUE.
//         Otherwise, function returns FALSE.
BOOL TOOL_InitSlotInfo(OnAioChangeEvent i_aioEventHandle, int i_iAioRate, OnDioChangeEvent i_dioEventHandl, int i_iDioRate)
{
	int iSlot, iCh;
	USHORT iModuleID;
	ADAM5550_SLOTINFO *newSlot;

	m_callbackAioChanged = i_aioEventHandle;
	m_callbackDioChanged = i_dioEventHandl;
	//
	if (i_iAioRate >= 10 && i_iAioRate <= 100)
		m_iAioRate = i_iAioRate;
	else
		m_iAioRate = 50;
	//
	if (i_iDioRate >= 2 && i_iDioRate <= 10)
		m_iDioRate = i_iDioRate;
	else
		m_iDioRate = 5;
	m_slotListHead = NULL;
	m_slotListTail = NULL;
	for (iSlot = 0; iSlot < 8; iSlot++)
	{
		if (SYS_GetModuleID(m_lHandle, iSlot, &iModuleID) == SUCCESS)
		{
			newSlot = NULL;
			if (iModuleID == ADAM5013A_ID || iModuleID == ADAM5013B_ID ||
				iModuleID == ADAM5017_ID || iModuleID == ADAM5018_ID ||
				iModuleID == ADAM5017H_ID || iModuleID == ADAM5017UH_ID ||
				iModuleID == ADAM5018P_ID || iModuleID == ADAM5024_ID)
			{
				newSlot = (ADAM5550_SLOTINFO*)LocalAlloc(LPTR, sizeof(ADAM5550_SLOTINFO));
				newSlot->iIoType = 1;
			}
			else if (iModuleID == ADAM5050_ID || iModuleID == ADAM5051_ID ||
					 iModuleID == ADAM5052_ID || iModuleID == ADAM5053_ID ||
					 iModuleID == ADAM5055_ID || iModuleID == ADAM5056_ID ||
					 iModuleID == ADAM5057_ID || iModuleID == ADAM5060_ID ||
					 iModuleID == ADAM5068_ID || iModuleID == ADAM5069_ID)
			{
				newSlot = (ADAM5550_SLOTINFO*)LocalAlloc(LPTR, sizeof(ADAM5550_SLOTINFO));
				newSlot->iIoType = 2;
			}
			// add structure to list
			if (newSlot != NULL)
			{
				// init the other fields
				newSlot->iSlotID = iSlot;
				GetLocalTime(&newSlot->tTimeStamp);
				newSlot->dwMask = 0;
				newSlot->fDeadband = m_fDeadband;
				for (iCh = 0; iCh < 8; iCh++)
				{
					newSlot->fPreValues[iCh] = 0;
					newSlot->fNowValues[iCh] = 0;
				}
				newSlot->dwPreValues = 0;
				newSlot->dwNowValues = 0;
				newSlot->nextPtr = NULL;
				if (m_slotListHead == NULL) // no data in the list
				{
					m_slotListHead = newSlot;
					m_slotListTail = newSlot;
				}
				else
				{
					m_slotListTail->nextPtr = newSlot;
					m_slotListTail = newSlot;
				}
				//
				printf("TOOL_InitSlotInfo : Slot=%d, Type=%d\n", newSlot->iSlotID, newSlot->iIoType);
			}
		}
	}
	if (m_slotListHead == NULL)
		printf("No module found...\n");

	return (m_slotListHead != NULL);
}

// ================================================================================
// Method: TOOL_ReleaseSlotInfo
// action: Release the resource allocated by TOOL_InitSlotInfo
// pre   : 
// post  : Always return TRUE.
BOOL TOOL_ReleaseSlotInfo()
{
	ADAM5550_SLOTINFO *curSlot;

	while (m_slotListHead != NULL)
	{
		curSlot = m_slotListHead;
		m_slotListHead = m_slotListHead->nextPtr;
		LocalFree(curSlot);
	}
	return TRUE;
}

// ================================================================================
// Method: PollingThreadProc
// action: The polling thread polls
DWORD PollingThreadProc(DWORD *pThreadId)
{
	int iCh;
	FLOAT fBuf[8];
	DWORD dwBuf, dwMask;
	BOOL bFire;
	ADAM5550_SLOTINFO *pollingSlot;

	int iCnt, iPwr;
	BOOL bLED;

	printf("PollingThreadProc start...\n");

	CeSetThreadPriority(GetCurrentThread(), 25);

	m_iAioPollingCount = 0;
	m_iDioPollingCount = 0;
	iCnt = 0;
	iPwr = 0;
	bLED = TRUE;
	while(m_bRunning)
	{
		if (WaitForSingleObject(m_hInterruptEvent, 2) == WAIT_OBJECT_0)
		{
			iCnt++;
			// flash the RUN LED
			if (iCnt >= 500) // flash the RUN LED
			{
				if (bLED == TRUE)
					bLED = FALSE;
				else
					bLED = TRUE; 
				SYS_SetRUNLED(m_lHandle, bLED);
				iCnt = 0;
			}
			//
			pollingSlot = m_slotListHead;
			m_iAioPollingCount++;
			m_iDioPollingCount++;
			while (1)
			{
				if (pollingSlot->iIoType == 1 && // AIO
					m_callbackAioChanged != NULL &&
					m_iAioPollingCount >= m_iAioRate)
				{
					if (AI_GetValues(m_lHandle, pollingSlot->iSlotID, (FLOAT*)fBuf) == SUCCESS)
					{
						dwMask = 0;
						bFire = FALSE;
						for (iCh = 0; iCh < 8; iCh++)
						{
							if (pollingSlot->fNowValues[iCh] - fBuf[iCh] > pollingSlot->fDeadband ||
								fBuf[iCh] - pollingSlot->fNowValues[iCh] > pollingSlot->fDeadband)
							{
								pollingSlot->fPreValues[iCh] = pollingSlot->fNowValues[iCh];
								pollingSlot->fNowValues[iCh] = fBuf[iCh];
								dwMask |= (0x0001 << iCh);
								bFire = TRUE;
							}
						}
						if (bFire == TRUE)
						{
							pollingSlot->dwMask = dwMask;
							GetLocalTime(&pollingSlot->tTimeStamp);
							// copy data to buffer
							//EnterCriticalSection(&m_criticalSectionEvtBuffer);
							memcpy(&evtBuffer[m_iWriteIndex], pollingSlot, sizeof(ADAM5550_SLOTINFO));
							//LeaveCriticalSection(&m_criticalSectionEvtBuffer);
							//
							if (m_iWriteIndex < ADAM_BUFMAX - 1)
								m_iWriteIndex++;
							else
								m_iWriteIndex = 0;
							SetEvent(m_hFireEvent);
						}
					}
				}
				else if (pollingSlot->iIoType == 2 && // DIO
						 m_callbackDioChanged != NULL &&
						 m_iDioPollingCount >= m_iDioRate)
				{
					if (DI_GetValues(m_lHandle, pollingSlot->iSlotID, &dwBuf) == SUCCESS)
					{
						if (dwBuf != pollingSlot->dwNowValues)
						{
							pollingSlot->dwPreValues = pollingSlot->dwNowValues;
							pollingSlot->dwNowValues = dwBuf;
							pollingSlot->dwMask = pollingSlot->dwPreValues ^ pollingSlot->dwNowValues;
							GetLocalTime(&pollingSlot->tTimeStamp);
							// copy data to buffer
							//EnterCriticalSection(&m_criticalSectionEvtBuffer);
							memcpy(&evtBuffer[m_iWriteIndex], pollingSlot, sizeof(ADAM5550_SLOTINFO));
							//LeaveCriticalSection(&m_criticalSectionEvtBuffer);
							//
							if (m_iWriteIndex < ADAM_BUFMAX - 1)
								m_iWriteIndex++;
							else
								m_iWriteIndex = 0;
							SetEvent(m_hFireEvent);
						}
					}
				}
				//
				if (pollingSlot->nextPtr != NULL)
					pollingSlot = pollingSlot->nextPtr;
				else
					break;
			}
			if (m_iAioPollingCount >= m_iAioRate)
				m_iAioPollingCount = 0;
			if (m_iDioPollingCount >= m_iDioRate)
				m_iDioPollingCount = 0;
		}
		/*
		else
		{
			iPwr++;
			if (iPwr > 500) // flash the PWR LED
			{
				if (bPwr == TRUE)
					bPwr = FALSE;
				else
					bPwr = TRUE; 
				SYS_SetPWRLED(m_lHandle, bPwr);
				iPwr = 0;
			}
		}
		*/
		InterruptDone(ADAM_INTERRUPT);
	}
	printf("PollingThreadProc exit!\n");
	return 0;
}

DWORD FireThreadProc(DWORD *pThreadId)
{
	ADAM5550_SLOTINFO bufSlot;

	printf("FireThreadProc start...\n");

	while(m_bRunning)
	{
		WaitForSingleObject(m_hFireEvent, 2); // if no event fired, will delay for a while
		// make a copy of the structure
		if (m_iReadIndex != m_iWriteIndex)
		{
			//EnterCriticalSection(&m_criticalSectionEvtBuffer);
			memcpy(&bufSlot, &evtBuffer[m_iReadIndex], sizeof(ADAM5550_SLOTINFO));
			//LeaveCriticalSection(&m_criticalSectionEvtBuffer);
			//
			if (m_iReadIndex < ADAM_BUFMAX - 1)
				m_iReadIndex++;
			else
				m_iReadIndex = 0;
			// execute the callback
			if (bufSlot.iIoType == 1) // AIO
				m_callbackAioChanged(bufSlot.iSlotID, bufSlot.dwMask, bufSlot.fNowValues, &bufSlot.tTimeStamp);
			else if (bufSlot.iIoType == 2) // DIO
				m_callbackDioChanged(bufSlot.iSlotID, bufSlot.dwMask, bufSlot.dwNowValues, &bufSlot.tTimeStamp);
		}
	}
	printf("FireThreadProc exit!\n");
	return 0;
}
