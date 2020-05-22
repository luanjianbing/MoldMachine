// ADAM_5550_SYSTEM.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "ADSDIO.h"

#define ADAM5550	1  //Note: if you run on ADAM-5560, please mark this definition

#ifdef ADAM5550
	#define ADAM_SLOT_NUM	8
#endif

#ifndef ADAM5550
	#define ADAM_SLOT_NUM	7
#endif


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
	LONG lErr;
	USHORT iNodeID, iMoudleID;
	BOOL bLed;
	int iSlot, iTry;

	// =====================================================================
	// Try to open the driver
	if ((lErr = ADAMDrvOpen(&lHandle)) != SUCCESS)
	{
		printf("ADAMDrvOpen failed (%d)!\n", lErr);
		return -1;
	}

	// =====================================================================
	// Get the DIP switch setting of NODE ID
	if ((lErr = SYS_GetNodeID(lHandle, &iNodeID)) == SUCCESS)
		printf("Node ID = 0x%04X\n", iNodeID);
	else
		printf("SYS_GetNodeID failed (%d)!\n", lErr);

	// =====================================================================
	// Get the module ID for each slot
	for (iSlot = 0; iSlot < ADAM_SLOT_NUM; iSlot++)
	{
		if ((lErr = SYS_GetModuleID(lHandle, iSlot, &iMoudleID)) == SUCCESS)
			printf("Slot[%d] = 0x%04X\n", iSlot, iMoudleID);
		else
			printf("SYS_GetModuleID failed (%d)!\n", lErr);
	}

	// =====================================================================
	// Contrl the PWR LED
	if ((lErr = SYS_GetPWRLED(lHandle, &bLed)) == SUCCESS)
	{
		if (bLed == TRUE)
			printf("PWR LED is ON\n");
		else
			printf("PWR LED is OFF\n");
	}
	for (iTry = 0; iTry < 10; iTry++)
	{
		// switch the LED
		if (bLed == TRUE)
			bLed = FALSE;
		else
			bLed = TRUE;
		if ((lErr = SYS_SetPWRLED(lHandle, bLed)) == SUCCESS)
		{
			if (bLed == TRUE)
				printf("PWR LED is set to ON\n");
			else
				printf("PWR LED is set to OFF\n");
		}
		else
			printf("SYS_SetPWRLED failed (%d)!\n", lErr);
		Sleep(500);
	}

	// =====================================================================
	// Contrl the RUN LED
	if ((lErr = SYS_GetRUNLED(lHandle, &bLed)) == SUCCESS)
	{
		if (bLed == TRUE)
			printf("RUN LED is ON\n");
		else
			printf("RUN LED is OFF\n");
	}
	for (iTry = 0; iTry < 10; iTry++)
	{
		// switch the LED
		if (bLed == TRUE)
			bLed = FALSE;
		else
			bLed = TRUE;
		if ((lErr = SYS_SetRUNLED(lHandle, bLed)) == SUCCESS)
		{
			if (bLed == TRUE)
				printf("RUN LED is set to ON\n");
			else
				printf("RUN LED is set to OFF\n");
		}
		else
			printf("SYS_SetRUNLED failed (%d)!\n", lErr);
		Sleep(500);
	}

	// =====================================================================
	// Try to close the driver
	ADAMDrvClose(&lHandle);
	return 0;
}

