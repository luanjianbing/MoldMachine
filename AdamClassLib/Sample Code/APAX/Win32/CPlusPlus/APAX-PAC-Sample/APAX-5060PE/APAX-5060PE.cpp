// APAX-5060PE.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"

const int g_ChannelNum = 12; //the channel number of APAX_5060PE is 12

bool EX_OpenLib(LONG *o_lDriverHandle)
{
	DWORD dVersion = 0; //the version of ADSIO.lib

	//initialize the driver
	if(ERR_SUCCESS != ADAMDrvOpen(o_lDriverHandle))
		return false;
		
	if (ERR_SUCCESS == SYS_GetVersion(*o_lDriverHandle, &dVersion) )
		printf("ADSDIO.lib version is %d.\n\n", dVersion);
	else
		return false;
		
	return true;	
}
void EX_CloseLib(LONG *o_lDriverHandle)
{
	//terminate the driver
	if(NULL != o_lDriverHandle)
	{
		ADAMDrvClose(o_lDriverHandle);
		o_lDriverHandle = NULL;
	}
}

void EX_SetValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 7; //the channel ID from 0 to 11 	
	BOOL bSetValue = true; // DO value to be set	

	BOOL lSetValueResult = DO_SetValue(i_lDriverHandle, i_wSlotID, wChannel, bSetValue);
	if (ERR_SUCCESS == lSetValueResult )
		printf("Channel %d is %s.\n", wChannel,(bSetValue) ? "true":"false");	
	else
		printf("Fail to set the DO value of channel %d.\n", wChannel);
		
	Sleep(3000);
}

void EX_GetValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	
	//==============================
	// user can set parameters below
	//============================== 
	WORD wChannel = 7;// the channel ID from 0 to 23 
	BOOL bHoldValue = false;//hold the DO value of single channel 
	
	int iCnt = 0;
	LONG lGetValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &bHoldValue);

	if (ERR_SUCCESS == lGetValueResult)
	{
		//check all channels (there are 12 channels in Apax-5060)
		for (iCnt = 0; iCnt < g_ChannelNum; iCnt++)
		{
			if (iCnt == wChannel)
			{
				if (bHoldValue)
					printf("Channel %d is true.\n", wChannel); //LED light on
				else
					printf("Channel %d is false.\n",wChannel); //LED light off
			}
		}
	}
	else
		printf("Fail to get DO single channel, error code = %d\n", lGetValueResult);

	Sleep(3000);
}

//single slot
void EX_SetMultiValue(LONG i_lDriverHandle,WORD i_wSlotID) 
{
	
	//==============================
	// user can set parameters below
	//==============================
	DWORD dHiValue = 0x0;	//the higher DO value from channel 32 to 63
	DWORD dLowValue = 0x0000F0F;	//the lower DO value from channel 0 to 31
	
    LONG lSetMultiValueResult = DO_SetValues(i_lDriverHandle, i_wSlotID, dHiValue, dLowValue);
	if (ERR_SUCCESS == lSetMultiValueResult)
	{
		printf("Succeed to set DO multiple channel values.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set DO multiple channel values, error code = %d\n", lSetMultiValueResult);


}

//multiple slots
void EX_SetMultiValue(LONG i_lDriverHandle,WORD i_wSlotID1,WORD i_wSlotID2)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wSlotID[2] = {0};
	DWORD dHiValue[2] = {0};
	DWORD dLowValue[2] ={0};	
	
	wSlotID[0] = i_wSlotID1; //Slot_1_ID
	dHiValue[0] = 0x0; //the higher DI value of slot1 from channel 32 to 63
	dLowValue[0] = 0x000F0F0F; //the lower DI value of slot1 from channel 0 to 31

	wSlotID[1] = i_wSlotID2; //Slot_2_ID
	dHiValue[1] = 0x0; //the higher DI value of slot2 from channel 32 to 63
	dLowValue[1] = 0x00F0F0F0; //the lower DI value of slot2 from channel 0 to 31
    
	DWORD dSlotMask = ( (0x01 << wSlotID[0]) | (0x01 << wSlotID[1]) ); // record the slot positions
	LONG lDOBufValues[2] = {0};// record returns of DO_BufValues
	LONG lFlushBufValues = 0;// record returns of OUT_FlushBufValues
	
	int iCnt = 0;

	//buffer values
	for (iCnt = 0; iCnt < 2 ; iCnt++ )
	{
		lDOBufValues[iCnt] = DO_BufValues(i_lDriverHandle, wSlotID[iCnt], dHiValue[iCnt], dLowValue[iCnt]);
		if (ERR_SUCCESS == lDOBufValues[iCnt])
			printf("Succeed to buffer values of slot %d.\n",wSlotID[iCnt]);
		else
			printf("Fail to buffer values of slot %d, error code = %d\n", wSlotID[iCnt], lDOBufValues[iCnt]);
	}

	//flush buffers
	if(lDOBufValues[0] == ERR_SUCCESS && lDOBufValues[1] == ERR_SUCCESS)
	{
		
		lFlushBufValues = OUT_FlushBufValues(i_lDriverHandle, dSlotMask);
		if (ERR_SUCCESS == lFlushBufValues )
		{
			printf("Succeed to flush buffered values.\n");
			Sleep(3000);
		}
		else
			printf("Fail to flush buffered values, error code = %d\n", lFlushBufValues );
	}
	
}

//single slot
void EX_GetMultiValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DO value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower DO value from channel 0 to 31
	int iCnt=0;
	
	BOOL lGetMultiValueResult = DIO_GetValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetMultiValueResult)
	{
		//show all channels (there are 12 channels in Apax-5060)
		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			if (dLowValue & (0x0001 << iCnt) ) 
				printf("Channel %d is true.\n", iCnt); //LED light on
			else
				printf("Channel %d is false.\n", iCnt); //LED light off
		}
	}
	else
		printf("Fail to get DO multiple channel values, error code = %d\n", lGetMultiValueResult);

}

void EX_SetMultiSafetyValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dHiValue = 0x0;	//the higher DO safety value from channel 32 to 63
	DWORD dLowValue = 0x0000F0F0;	//the lower DO safety value from channel 0 to 31
	
    LONG lSetMultiSafetyValueResult= DIO_SetSaftyValues(i_lDriverHandle, i_wSlotID, dHiValue, dLowValue);
	if (ERR_SUCCESS == lSetMultiSafetyValueResult )
	{
		printf("Succeed to set DO safety values.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set DO safety values, error code = %d\n", lSetMultiSafetyValueResult);
}

void EX_GetMultiSafetyValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DO safety value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower DO safety value from channel 0 to 31
	int iCnt = 0;
	
	BOOL lGetMultiSafetyValueResult = DIO_GetSaftyValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetMultiSafetyValueResult)
	{
		//show all channels (there are 12 channels in Apax-5060)
		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			if (dLowValue & (0x0001 << iCnt) ) 
				printf("The safety value of channel %d is true.\n", iCnt); //LED light on
			else
				printf("The safety value of channel %d is false.\n", iCnt); //LED light off
		}
	}
	else
		printf("Fail to get DO safety values, error code = %d\n", lGetMultiSafetyValueResult);

}

int main(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//============================== 
	WORD wSlotID = 3; //the slot ID which is ranged from 0 to 31
	//multiple slots 
	WORD wSlotID_2 = 4; //the slot ID which is ranged from 0 to 31

	//system parameters 
	bool bAdvStatus = false;//the loading status of ADSDIO.lib    
	LONG lDriverHandle = NULL;//driver handler
	
	//module ID parameters
	DWORD	dModuleID[2] = {0};
	DWORD	dHiWord = 0x0;
	DWORD	dLoWord = 0x0;
	LONG	lGetModuleResult[2] = {0};
	
	//load library
	if (bAdvStatus = EX_OpenLib(&lDriverHandle))
	{
		printf("The slot ID setting in the sample code is %d.\n", wSlotID);
		
		//get module ID
		lGetModuleResult[0] = SYS_GetModuleID(lDriverHandle, wSlotID, &dModuleID[0]);
        lGetModuleResult[1] = SYS_GetModuleID(lDriverHandle, wSlotID_2, &dModuleID[1]);

		//the moduleID for Apax-5060 is 0x50605045
		//dHiWord is 5060, dLoWord is 5045
		if (ERR_SUCCESS == lGetModuleResult[0])
		{
			dHiWord = (dModuleID[0] & 0xFFFF0000) >> 16;
			dLoWord =  dModuleID[0] & 0x0000FFFF;

			if (0 == dLoWord)
				printf("/*** APAX %x Module Sample Code ***/\n\n", dHiWord);
			else if (0 != (dLoWord & 0x0000FF00) && (dLoWord & 0x000000FF) )
				printf("/*** APAX %x%c%c Module Sample Code ***/\n\n", dHiWord, dLoWord >> 8, (dLoWord & 0x000000FF) );
			else
				printf("/*** APAX %x%c Module Sample Code ***/\n\n", dHiWord, dLoWord >> 8 );
		}
		else
			printf("Fail to get module ID, error code = %d\n", lGetModuleResult[0]);

		Sleep(100);
	}
	else
	{
		printf("Fail to load ADSDIO library.\n");
	}

	//=================================================================================
	//	
	//		functions for getting or setting single or multiple channel values
	//
	//=================================================================================
	
	//set DO single channel value example
	if (bAdvStatus)
	{
		printf("*** Set DO single channel value ***\n");
		
		EX_SetValue(lDriverHandle, wSlotID);
	}

	//get DO single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Get DO single channel value ***\n");
        EX_GetValue(lDriverHandle, wSlotID);
	}
	
	//set DO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Set DO multiple channel values ***\n");
        EX_SetMultiValue(lDriverHandle, wSlotID);
	}

	//set DO multiple channel values example (multiple slots)
	if (bAdvStatus && lGetModuleResult[0] == ERR_SUCCESS && lGetModuleResult[1] == ERR_SUCCESS && dModuleID[0] == dModuleID[1])
	{
		printf("\n*** Set DO multiple channel values (multiple slots) ***\n");
		EX_SetMultiValue(lDriverHandle, wSlotID,wSlotID_2);
	}
    
	//get DO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DO multiple channel values ***\n");
		EX_GetMultiValue(lDriverHandle, wSlotID);
	}

	//=================================================================================
	//	
	//		functions for getting or setting safety values
	//
	//=================================================================================
	
	//set DO safety values example 
	if (bAdvStatus)
	{
		printf("\n*** Set DO safety values  ***\n");
		EX_SetMultiSafetyValue(lDriverHandle, wSlotID);
	}

	//get DO safety values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DO safety values ***\n");
		EX_GetMultiSafetyValue(lDriverHandle, wSlotID);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	system("pause");

	return 0;
}


