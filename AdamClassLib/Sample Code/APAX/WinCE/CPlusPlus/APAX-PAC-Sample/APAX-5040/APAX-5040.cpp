// APAX-5040.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"

const int g_ChannelNum = 24; //the channel number of APAX_5040 is 24



bool EX_OpenLib(LONG *o_lDriverHandle)
{
	DWORD dVersion = 0; //the version of ADSIO.lib

	//initialize the driver
	if(ERR_SUCCESS != ADAMDrvOpen(o_lDriverHandle))
		return false;
		
	if (ERR_SUCCESS == SYS_GetVersion(*o_lDriverHandle, &dVersion) )
		printf("ADSDIO.lib version is %d\n\n", dVersion);
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

void EX_SetFilter(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================

	DWORD dwHighMask = 0x0; //the higher DI filter mask from channel 32 to 63
	DWORD dwLowMask = 0x00FF; //the lower DI filter mask from channel 0 to 31
	DWORD dwWidth = 300; //input filter width is ranging from 5 to 400 (0.1 ms)

	LONG lSetFilterResult = DI_SetFilters (i_lDriverHandle, i_wSlotID, dwHighMask, dwLowMask, dwWidth);
	if (ERR_SUCCESS == lSetFilterResult)	
		printf("Succeed to set filter mask and width.\n");
	else
		printf("Fail to set filter mask, error code = %d.\n", lSetFilterResult);

	Sleep(3000);
}

void EX_GetFilter(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwHighMask = 0; //the higher DI filter mask from channel 32 to 63
	DWORD dwLowMask = 0;  //the lower DI filter mask from channel 0 to 31
	DWORD dwWidth = 0;    //input filter width (0.1 ms)
	
	int iCnt = 0;
	
	LONG lGetFilterResult = DI_GetFilters(i_lDriverHandle, i_wSlotID, &dwHighMask, &dwLowMask, &dwWidth);
	if (ERR_SUCCESS == lGetFilterResult)
	{	
		printf("The filter width is %d (0.1 ms).\n", dwWidth);

		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			if (dwLowMask & (0x0001 << iCnt))
				printf("Channel %d filter mask is true.\n", iCnt); 
			else
				printf("Channel %d filter mask is false.\n", iCnt); 
		}
	}
	else
		printf("Fail to get filter mask, error code = %d\n", lGetFilterResult);

	Sleep(3000);

}
void EX_GetValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 7;// the channel ID from 0 to 23 
	BOOL bHoldValue = false;//hold the DI value of single channel 
	
	int iCnt = 0;

	LONG lGetValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &bHoldValue);

	if (ERR_SUCCESS == lGetValueResult)
	{
		//check all channels (there are 24 channels in Apax-5040)
		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			if (iCnt == wChannel)
			{
				if (bHoldValue)
					printf("Channel %d is true.\n", wChannel); //LED light on
				else
					printf("Channel %d is false.\n", wChannel); //LED light off
			}
		}
	}
	else
		printf("Fail to get DI single channel value, error code = %d\n", lGetValueResult);

	Sleep(3000);
}

void EX_GetMultiValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DI value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower DI value from channel 0 to 31
	int iCnt = 0;
	
	BOOL lGetMultiValueResult = DIO_GetValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetMultiValueResult)
	{
		//show all channels (there are 24 channels in Apax-5040)
		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			if (dLowValue & (0x0001 << iCnt) ) 
				printf("Channel %d is true.\n", iCnt); //LED light on
			else
				printf("Channel %d is false.\n", iCnt); //LED light off
		}
	}
	else
		printf("Fail to get DI multiple channel values, error code = %d\n", lGetMultiValueResult);

}

int _tmain(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//==============================
	WORD wSlotID = 0; //the slot ID which is ranged from 0 to 31

	//system parameters 
	bool bAdvStatus = false;//the loading status of ADSDIO.lib    
	LONG lDriverHandle = NULL;//driver handler
	
	//module ID parameters
	DWORD	dModuleID = 0;
	DWORD	dHiWord = 0x0;
	DWORD	dLoWord = 0x0;
	LONG	lGetModuleResult = 0;

	//load library
	if (bAdvStatus = EX_OpenLib(&lDriverHandle))
	{
		printf("The slot ID setting in the sample code is %d.\n", wSlotID);
		
		//get module ID
		lGetModuleResult = SYS_GetModuleID(lDriverHandle, wSlotID, &dModuleID);
        
		//the moduleID for Apax-5040 is 0x50400000
		//dHiWord is 5040, dLoWord is 0000
		if (ERR_SUCCESS == lGetModuleResult)
		{
			dHiWord = (dModuleID & 0xFFFF0000) >> 16;
			dLoWord =  dModuleID & 0x0000FFFF;

			if (0 == dLoWord)
				printf("/*** APAX %x Module Sample Code ***/\n\n", dHiWord);
			else if (0 != (dLoWord & 0x0000FF00) && (dLoWord & 0x000000FF) )
				printf("/*** APAX %x%c%c Module Sample Code ***/\n\n", dHiWord, dLoWord >> 8, (dLoWord & 0x000000FF) );
			else
				printf("/*** APAX %x%c Module Sample Code ***/\n\n", dHiWord, dLoWord >> 8 );
		}
		else
			printf("Fail to get module ID, error code = %d\n", lGetModuleResult);

		Sleep(100);
	}
	else
	{
		printf("Fail to load ADSDIO library.\n");
	}

	//=================================================================================
	//	
	//		functions for getting or setting multiple filters
	//
	//=================================================================================

	//set DI filters example
	if (bAdvStatus)
	{
		printf("\n*** Set DI filters ***\n");
		EX_SetFilter(lDriverHandle, wSlotID);
	}

	//get DI filters example  
	if (bAdvStatus)
	{
		printf("\n*** Get DI filters ***\n");
		EX_GetFilter(lDriverHandle, wSlotID);
	}
	//=================================================================================
	//	
	//		functions for getting single or multiple channel values
	//
	//=================================================================================

	//get DI single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Get DI single channel value ***\n");
        EX_GetValue(lDriverHandle, wSlotID);
	}

	//get DI multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DI multiple channel values ***\n");
		EX_GetMultiValue (lDriverHandle, wSlotID);
	}
	
	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	

	return 0;
}

