// APAX-5082.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
 
const int g_ChannelDINum = 6; //the DI channel number of APAX_5082 is 6
const int g_ChannelDONum = 6; //the DO channel number of APAX_5082 is 6
const int g_ChannelPWMNum = 8; //the CNT channel number of APAX_5082 is 8

bool EX_OpenLib(LONG *o_lDriverHandle)
{
	DWORD dVersion = 0; //the version of ADSIO.lib

	//initialize the driver
	if(ERR_SUCCESS != ADAMDrvOpen(o_lDriverHandle))
		return false;
		
	if (ERR_SUCCESS == SYS_GetVersion(*o_lDriverHandle, &dVersion))
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

void EX_SetPwmChMask(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwMask = 0x0000FFFF; //the enabled counter channel mask to be set. If the bit is 1, it means that the channel started.

	LONG lSetMaskResult = PWM_SetChannelMask(i_lDriverHandle, i_wSlotID, dwMask);
	if (ERR_SUCCESS == lSetMaskResult)
	{	
		printf("Succeed to set PWM channel mask.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set PWM channel mask, error code = %d.\n", lSetMaskResult);
}

void EX_GetPwmChMask(LONG i_lDriverHandle,WORD i_wSlotID)
{
	
	DWORD dwMask = 0; 
	int iCnt = 0;

	LONG lGetMaskResult = PWM_GetChannelMask(i_lDriverHandle, i_wSlotID, &dwMask );
	
	if (ERR_SUCCESS == lGetMaskResult)
	{	
		printf("Succeed to get PWM channel mask.\n");
		for (iCnt = 0; iCnt<g_ChannelPWMNum; iCnt++)
		{
			if (dwMask & (0x01 << iCnt))
			{
				printf("The PWM channel %d is enabled.\n", iCnt);
				Sleep(100);
			}
			else
				printf("The PWM channel %d is disabled.\n", iCnt);
		}
	}
	else
		printf("Fail to get PWM channel mask, error code = %d.\n", lGetMaskResult);
}

void EX_SetPwmChConfig(LONG i_lDriverHandle, WORD i_wSlotID)
{	
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 5; //the channel ID from 0 to 7 
	DWORD dwFreq = 1000;//the channel's frequency, ranging from 1 to 30K Hz
	float fDuty = 66.5; //the channel's duty cycle, ranging from 0.1 to 99.9 %

	LONG lSetConfigResult = PWM_SetConfig(i_lDriverHandle, i_wSlotID, wChannel, dwFreq, fDuty);
	if (ERR_SUCCESS == lSetConfigResult)	
		printf("Succeed to set PWM channel configuration.\n");
	else
		printf("Fail to set PWM channel configuration, error code = %d\n", lSetConfigResult);

	Sleep(3000);
}

void EX_GetPwmChConfig(LONG i_lDriverHandle, WORD i_wSlotID)
{	
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 5; //the channel ID from 0 to 7 
	DWORD dwFreq = 0;//the channel's frequency
	float fDuty = 0.0; //the channel's duty cycle

	LONG lGetConfigResult = PWM_GetConfig(i_lDriverHandle, i_wSlotID, wChannel, &dwFreq, &fDuty);
	if (ERR_SUCCESS == lGetConfigResult)
	{
		printf("Succeed to get PWM channel configuration.\n");
		printf("The frequency of PWM channel %d is %d (Hz) and duty cycle is %2.2f %%.\n", wChannel, dwFreq, fDuty); 
	}
	else
		printf("Fail to get PWM channel configuration, error code = %d\n", lGetConfigResult);

	Sleep(3000);
}

void EX_SetDIFilter(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwHighMask = 0x0; //the Higher DI filter mask from channel 32 to 63
	DWORD dwLowMask = 0x00FF; //the Lower DI filter mask from channel 0 to 31
	DWORD dwWidth = 300;  //input filter width is ranging from 5 to 400 (0.1 ms)

	LONG lSetFilterResult = DI_SetFilters(i_lDriverHandle, i_wSlotID, dwHighMask, dwLowMask, dwWidth);
	if (ERR_SUCCESS == lSetFilterResult)	
		printf("Succeed to set filter mask and width.\n");
	else
		printf("Fail to set DI filter mask and width, error code = %d\n", lSetFilterResult);

	Sleep(3000);
}

void EX_GetDIFilter(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwHighMask = 0; //the higher DI filter mask from channel 32 to 63
	DWORD dwLowMask = 0;  //the lower DI filter mask from channel 0 to 31
	DWORD dwWidth = 0;    //input filter width is ranging from 5 to 400 (0.1 ms)
	
	int iCnt = 0;
	
	LONG lGetFilterResult = DI_GetFilters(i_lDriverHandle, i_wSlotID, &dwHighMask, &dwLowMask, &dwWidth);
	if (ERR_SUCCESS == lGetFilterResult)
	{	
		printf("Slot %d filter width is %d (0.1 ms).\n", i_wSlotID, dwWidth);

		for (iCnt = 0; iCnt < g_ChannelDINum ; iCnt++)
		{
			if (dwLowMask & (0x0001 << iCnt))
				printf("Channel %d filter mask is true.\n", iCnt); 
			else
				printf("Channel %d filter mask is false.\n", iCnt); 
		}
	}
	else
		printf("Fail to get DI filter mask and width, error code = %d\n", lGetFilterResult);

	Sleep(3000);

}

void EX_GetDIValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 1;// the channel ID from 0 to 5 
	BOOL bHoldValue = false;//hold the DI value of single channel 
	
	int iCnt;

	LONG lGetDIValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &bHoldValue);

	if (ERR_SUCCESS == lGetDIValueResult)
	{
		//check all DI channels (there are 6 channels in Apax-5082)
		for (iCnt = 0; iCnt < g_ChannelDINum ; iCnt++)
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
		printf("Fail to get DI single channel value, error code = %d\n", lGetDIValueResult);

	Sleep(3000);
}

void EX_GetDIMultiValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DI value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower DI value from channel 0 to 31
	int iCnt=0;
	
	BOOL lGetDIMultiValueResult = DIO_GetValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetDIMultiValueResult)
	{
		//show all DI channels (there are 6 channels in Apax-5082)
		for (iCnt = 0; iCnt < g_ChannelDINum ; iCnt++)
		{
			if (dLowValue & (0x0001 << iCnt) ) 
				printf("Channel %d is true.\n", iCnt); //LED light on
			else
				printf("Channel %d is false.\n", iCnt); //LED light off
		}
	}
	else
		printf("Fail to get DI multiple channel values, error code = %d.\n", lGetDIMultiValueResult);

}

void EX_SetDOValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 1; //the channel ID from 0 to 5 	
	BOOL bSetValue = true; // DO value to be set	

	BOOL lSetValueResult = DO_SetValue(i_lDriverHandle, i_wSlotID, wChannel , bSetValue);
	if (ERR_SUCCESS == lSetValueResult )
		printf("Channel %d is %s.\n", wChannel,(bSetValue) ? "true":"false");	
	else
		printf("Fail to set the DO value of channel %d.\n", wChannel);
		
	Sleep(3000);
}

void EX_GetDOValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 1;// the channel ID from 0 to 5
	BOOL bHoldValue = false;//hold the DO value of single channel 
	
	int iCnt = 0;
	LONG lGetValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel + g_ChannelDINum, &bHoldValue);

	if (ERR_SUCCESS == lGetValueResult)
	{
		//check all channels (there are 6 channels in Apax-5082)
		for (iCnt = 0; iCnt < g_ChannelDONum ; iCnt++)
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
		printf("Fail to get DO single channel value, error code = %d.\n", lGetValueResult);

	Sleep(3000);
}


void EX_SetDOMultiValue(LONG i_lDriverHandle,WORD i_wSlotID) 
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dHiValue = 0x0;	//the higher DO value from channel 32 to 63
	DWORD dLowValue = 0x00FF;	//the lower DO value from channel 0 to 31
	
    LONG lSetMultiValueResult= DO_SetValues(i_lDriverHandle, i_wSlotID, dHiValue, dLowValue);
	if (ERR_SUCCESS == lSetMultiValueResult )
	{
		printf("Succeed to set DO multiple channels.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set DO multiple channel values, error code = %d.\n", lSetMultiValueResult);
}


void EX_GetDOMultiValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DO value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower  DO value from channel 0 to 31
	int iCnt = 0;
	
	BOOL lGetMultiValueResult = DIO_GetValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetMultiValueResult)
	{
		//show all channels (there are 6 DO-channels in Apax-5082)
		for (iCnt = 0; iCnt < g_ChannelDONum ; iCnt++)
		{
			if (dLowValue & (0x0001 << (iCnt + g_ChannelDINum))) 
				printf("Channel %d is true.\n", iCnt); //LED light on
			else
				printf("Channel %d is false.\n", iCnt); //LED light off
		}
	}
	else
		printf("Fail to get DO multiple channel values, error code = %d.\n", lGetMultiValueResult);

}

void EX_SetDOSafetyEnabled(LONG i_lDriverHandle,WORD i_wSlotID)
{
	BOOL bEnabled = true;//set D0 safety function status

	LONG lSetSafetyEnabledResult= OUT_SetSaftyEnable(i_lDriverHandle, i_wSlotID, bEnabled);
	if (ERR_SUCCESS == lSetSafetyEnabledResult)
	{
		printf("Succeed to set DO safety function status.\n");		
	}
	else
		printf("Fail to set DO safety function status, error code = %d\n", lSetSafetyEnabledResult);
}

void EX_GetDOSafetyEnabled(LONG i_lDriverHandle,WORD i_wSlotID)
{
	BOOL bEnabled = false;//set D0 safety function status

	LONG lGetSafetyEnabledResult= OUT_GetSaftyEnable(i_lDriverHandle, i_wSlotID, &bEnabled);
	if (ERR_SUCCESS == lGetSafetyEnabledResult)
	{
		if (bEnabled)
		{
			printf("The DO safety function is enabled.\n");
		}
		else
			printf("The DO safety function is disabled.");
	}
	else
		printf("Fail to get DO safety function status, error code = %d\n", lGetSafetyEnabledResult);
}

void EX_SetDOMultiSafetyValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dHiValue = 0x0;	//the higher DO safety value from channel 32 to 63
	DWORD dLowValue = 0x00000F;	//the lower DO safety value from channel 0 to 31
	
    LONG lSetMultiSafetyValueResult = DIO_SetSaftyValues(i_lDriverHandle, i_wSlotID, dHiValue, dLowValue);
	if (ERR_SUCCESS == lSetMultiSafetyValueResult )
	{
		printf("Succeed to set DO safety values.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set DO safety values, error code = %d\n", lSetMultiSafetyValueResult);
}

void EX_GetDOMultiSafetyValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dHiValue = 0x0;	//the higher DO safety value from channel 32 to 63
	DWORD dLowValue = 0x0;	//the lower DO safety value from channel 0 to 31
	int iCnt = 0;
	
	BOOL lGetMultiSafetyValueResult = DIO_GetSaftyValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetMultiSafetyValueResult)
	{
		//show all channels (there are 6 DO channels in Apax-5082)
		for (iCnt = 0; iCnt < g_ChannelDONum ; iCnt++)
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

int _tmain(int argc, char* argv[])
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wSlotID = 5; //the slot ID which is ranged from 0 to 31
	
	//system parameters 
	bool bAdvStatus = false;//the loading status of ADSDIO.lib    
	LONG lDriverHandle = NULL;//driver handler
	struct SlotInfo sSlotInfo; //slot information including channel number, type, value and range 
	memset(&sSlotInfo, 0, sizeof(struct SlotInfo));

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
        
		//the moduleID for Apax-5080 is 0x50820000
		//dHiWord is 5082, dLoWord is 0000
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

	if (bAdvStatus)
	{

		LONG lGetSlotInfo = SYS_GetSlotInfo(lDriverHandle,wSlotID, &sSlotInfo);
		if (ERR_SUCCESS != lGetSlotInfo)
			printf("Fail to get slot information, error code = %d\n", lGetSlotInfo);
			Sleep(100);
	}

	//=================================================================================
	//	
	//		functions for DI module
	//
	//=================================================================================
	
	//set DI filters example
	if (bAdvStatus)
	{
		printf("\n*** Set DI filters ***\n");
		EX_SetDIFilter(lDriverHandle, wSlotID);
	}

	//get DI filters example  
	if (bAdvStatus)
	{
		printf("\n*** Get DI filters ***\n");
		EX_GetDIFilter(lDriverHandle, wSlotID);
	}
	
	
	//get DI single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Get DI single channel value ***\n");
        EX_GetDIValue(lDriverHandle, wSlotID);
	}

	//get DI multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DI multiple channel values ***\n");
		EX_GetDIMultiValue(lDriverHandle, wSlotID);
	}

	//=================================================================================
	//	
	//		functions for DO module
	//
	//=================================================================================
	
	//set DO single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Set DO single channel value ***\n");		
		EX_SetDOValue(lDriverHandle, wSlotID);
	}

	//get DO single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Get DO single channel value ***\n");
        EX_GetDOValue(lDriverHandle, wSlotID);
	}
	
	//Set DO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Set DO multiple channel values ***\n");
        EX_SetDOMultiValue(lDriverHandle, wSlotID);
	}
	
	//get DO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DO multiple channel values ***\n");
		EX_GetDOMultiValue(lDriverHandle, wSlotID);
	}

	//set DO safety function status example
	if (bAdvStatus)
	{
		printf("\n*** Set DO safety function status ***\n");		
		EX_SetDOSafetyEnabled(lDriverHandle, wSlotID);
	}

	//get DO safety function status example
	if (bAdvStatus)
	{
		printf("\n*** Get DO safety function status ***\n");		
		EX_GetDOSafetyEnabled(lDriverHandle, wSlotID);
	}
	

	//set DO safety values example 
	if (bAdvStatus)
	{
		printf("\n*** Set DO safety values ***\n");
		EX_SetDOMultiSafetyValue(lDriverHandle, wSlotID);
	}

	//get DO safety values example 
	if (bAdvStatus)
	{
		printf("\n*** Get DO safety values ***\n");
		EX_GetDOMultiSafetyValue(lDriverHandle, wSlotID);
	}

	//=================================================================================
	//	
	//		functions for PWM module
	//
	//=================================================================================
	// set enabled PWM channel mask
	if (bAdvStatus)
	{
		printf("\n*** Set PWM channel mask ***\n");
        EX_SetPwmChMask(lDriverHandle, wSlotID);
	}	

	// get enabled PWM channel mask
	if (bAdvStatus)
	{
		printf("\n*** Get PWM channel mask ***\n");
        EX_GetPwmChMask(lDriverHandle, wSlotID);
	}

	// set PWM channel configuration
	if (bAdvStatus)
	{
		printf("\n*** Set PWM channel configuration ***\n");
        EX_SetPwmChConfig(lDriverHandle, wSlotID);
	}

	// get PWM channel configuration
	if (bAdvStatus)
	{
		printf("\n*** Get PWM channel configuration ***\n");
        EX_GetPwmChConfig(lDriverHandle, wSlotID);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	

}


