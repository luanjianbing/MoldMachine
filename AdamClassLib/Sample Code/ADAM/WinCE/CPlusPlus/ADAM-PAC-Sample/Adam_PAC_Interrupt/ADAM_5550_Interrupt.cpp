// ADAM_5550_Interrupt.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include <stdio.h>
#include "ADSDIO.h"
#include "ADAM_5550_AutoPolling.h"


void AioChangeEventHandler(int i_iSlot, DWORD i_dwChannelChangedMask, FLOAT *i_fValues, SYSTEMTIME *i_timeStamp);
void DioChangeEventHandler(int i_iSlot, DWORD i_dwChannelChangedMask, DWORD i_dwValues, SYSTEMTIME *i_timeStamp);

int iCount = 0;


#ifdef WINCE
int _tmain(int argc, char* argv[])
#else
int WINAPI WinMain(	HINSTANCE hInstance,
					HINSTANCE hPrevInstance,
					LPTSTR    lpCmdLine,
					int       nCmdShow)
#endif
{
 	// TODO: Place code here.
	LONG lHandle;

	// open the I/O driver first
	ADAMDrvOpen(&lHandle);
	// register the AIO/DIO callback function, and start the data polling
	if (AutoPolling_StartPolling(lHandle, AioChangeEventHandler, 50, DioChangeEventHandler, 5) == TRUE)
	{
		printf("Press <ESC> to stop...\n");
		while ((GetAsyncKeyState(VK_ESCAPE) & 0x8000) == 0)
		{
			Sleep(5);
		}
		AutoPolling_StopPolling();
	}
	ADAMDrvClose(&lHandle);
	
	return 0;
}

// AIO callback function
void AioChangeEventHandler(int i_iSlot, DWORD i_dwChannelChangedMask, FLOAT *i_fValues, SYSTEMTIME *i_timeStamp)
{
	printf("Slot[%d], Mask = 0x%04X, timestamp=%02d:%02d.%03d\n", i_iSlot, i_dwChannelChangedMask, i_timeStamp->wMinute, i_timeStamp->wSecond, i_timeStamp->wMilliseconds);
	printf("Values = %.3f, %.3f, %.3f, %.3f, %.3f, %.3f, %.3f, %.3f\n", 
		i_fValues[0], i_fValues[1], i_fValues[2], i_fValues[3], 
		i_fValues[4], i_fValues[5], i_fValues[6], i_fValues[7]);
}

// DIO callback function
void DioChangeEventHandler(int i_iSlot, DWORD i_dwChannelChangedMask, DWORD i_dwValues, SYSTEMTIME *i_timeStamp)
{
	iCount++;
	printf("%d. Slot[%d], Mask = 0x%08X, timestamp=%02d:%02d.%03d\n", iCount, i_iSlot, i_dwChannelChangedMask, i_timeStamp->wMinute, i_timeStamp->wSecond, i_timeStamp->wMilliseconds);
	printf("Values = 0x%08X\n", i_dwValues);
}

