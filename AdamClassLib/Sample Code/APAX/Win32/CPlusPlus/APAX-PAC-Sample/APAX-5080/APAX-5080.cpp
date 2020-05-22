// APAX-5080.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"

const int g_ChannelDINum = 4; //the DI channel number of APAX_5080 is 4
const int g_ChannelDONum = 4; //the DO channel number of APAX_5080 is 4
const int g_ChannelCNTNum = 8; //the CNT channel number of APAX_5080 is 8

//APAX 5080	range table
#define BI_DIRECTION	0x01C0
#define UP_AND_DOWN		0x01C1
#define UP				0x01C2
#define HIGH_FREQUENCY	0x01C3	
#define AB_1X			0x01C4
#define AB_2X			0x01C5
#define AB_4X			0x01C6
#define LOW_FREQUENCY	0x01C7
#define WAVE_WIDTH		0x01C8


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
void EX_SetCntChannelMode(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wModes[g_ChannelCNTNum] = {0}; //the channel ID from 0 to 7	
	// Note: Bi-direction mode, Up/Down mode and A/B phase mode must be set in pairs
	wModes[0] = UP_AND_DOWN; 
	wModes[1] = UP_AND_DOWN; 
	
	wModes[2] = AB_1X;
	wModes[3] = AB_1X;

	wModes[4] = UP;	 			
	wModes[5] = HIGH_FREQUENCY;

	wModes[6] = UP;
	wModes[7] = UP;

	BOOL lSetCNTModsResult = CNT_SetRanges(i_lDriverHandle, i_wSlotID, g_ChannelCNTNum, wModes);
	if (ERR_SUCCESS == lSetCNTModsResult)
	{
		printf("Succeed to set CNT modes.\n");
	}
	else
		printf("Fail to set CNT modes, error code = %d.\n", lSetCNTModsResult);
		
	Sleep(1000);
}

void EX_GetCntChannelMode(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo *i_SlotInfo)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dModes[g_ChannelCNTNum] = {0}; //the channel ID from 0 to 7
	LONG lGetCNTModsResult = SYS_GetSlotInfo(i_lDriverHandle,i_wSlotID,i_SlotInfo);
	WORD wModeType = 0;
	int iCnt = 0;

	if (ERR_SUCCESS == lGetCNTModsResult)
	{
		printf("Succeed to get CNT modes.\n");
		for(iCnt = 0; iCnt < g_ChannelCNTNum; iCnt++)
		{
			wModeType=*(i_SlotInfo->wChRange + iCnt);

			switch (wModeType)
			{
				case BI_DIRECTION: 
					printf("The CNT mode of channel %d is Bi-direction.\n", iCnt);
					break;
			
				case UP_AND_DOWN: 
					printf("The CNT mode of channel %d is Up/Down.\n", iCnt);
					break;

				case UP:
					printf("The CNT mode of channel %d is Up.\n", iCnt);
					break;

				case HIGH_FREQUENCY:
					printf("The CNT mode of channel %d is High Frequency.\n", iCnt);
					break;
				
				case AB_1X:
					printf("The CNT mode of channel %d is A/B - 1X.\n", iCnt);
					break;

				case AB_2X:
					printf("The CNT mode of channel %d is A/B - 2X.\n", iCnt);
					break;

				case AB_4X:
					printf("The CNT mode of channel %d is A/B - 4X.\n", iCnt);
					break;

				case LOW_FREQUENCY:
					printf("The CNT mode of channel %d is Low Frequency.\n", iCnt);
					break;
				
				case WAVE_WIDTH:
					printf("The CNT mode of channel %d is Wave Width.\n", iCnt);
					break;

				default:
					printf("The CNT mode of channel %d is unknown.\n", iCnt);
					break;
			}
		}
	}
	else
		printf("Fail to get CNT modes, error code = %d.\n", lGetCNTModsResult);
		
	Sleep(1000);
}

void EX_SetCntStartUpValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dStartValues[g_ChannelCNTNum] = {0}; //the channel ID from 0 to 8
	dStartValues[0] = 0x0010;
	dStartValues[1] = 0x0010;
	dStartValues[2] = 0x0020;
	dStartValues[3] = 0x0020;
	dStartValues[4] = 0x0030;
	dStartValues[5] = 0x0030;
	dStartValues[6] = 0x0040;
	dStartValues[7] = 0x0040;	

	BOOL lSetStartValueResult = CNT_SetStartupValues(i_lDriverHandle, i_wSlotID, g_ChannelCNTNum, dStartValues);
	if (ERR_SUCCESS == lSetStartValueResult)
	{
		printf("Succeed to set CNT startup values.\n");
	}
	else
		printf("Fail to set CNT startup values, error code = %d.\n", lSetStartValueResult);
		
	Sleep(1000);
}
void EX_GetCntStartUpValue(LONG i_lDriverHandle,WORD i_wSlotID)
{

	DWORD dStartValues[g_ChannelCNTNum] = {0}; //the channel ID from 0 to 7
	int iCnt = 0;

	BOOL lGetStartValueResult = CNT_GetStartupValues(i_lDriverHandle, i_wSlotID, g_ChannelCNTNum, dStartValues);
	if (ERR_SUCCESS == lGetStartValueResult)
	{
		printf("Succeed to get CNT startup values.\n");
		for (iCnt = 0; iCnt < g_ChannelCNTNum; iCnt++)
		{
			printf("The CNT startup value of channel %d is %d.\n",iCnt,dStartValues[iCnt]);
			Sleep(1000);		
		}
	}
	else
		printf("Fail to get CNT startup values, error code = %d.\n", lGetStartValueResult);
}

void EX_GetCntValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2;//the channel ID which is ranged from 0 to 7
	DWORD dValue = 0; // the variable to hold the counter value

	BOOL lGetValueResult = CNT_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &dValue);
	if (ERR_SUCCESS == lGetValueResult)
	{
		printf("The value of CNT channle %d is %d.\n",wChannel,dValue);
	}
	else
		printf("Fail to get CNT channel value, error code = %d.\n", lGetValueResult);
		
	Sleep(1000);
}

void EX_GetCntMultiValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dValues[g_ChannelCNTNum] = {0}; //the variables array to get the counter values
	int iCnt = 0;

	BOOL lGetValuesResult = CNT_GetValues(i_lDriverHandle, i_wSlotID, dValues);
	if (ERR_SUCCESS == lGetValuesResult)
	{
		for (iCnt = 0; iCnt < g_ChannelCNTNum; iCnt++)
		{
			printf("The value of CNT channle %d is %d.\n",iCnt,dValues[iCnt]);
			Sleep(1000);
		}
	}
	else
		printf("Fail to get CNT channel value, error code = %d.\n", lGetValuesResult);
		
	Sleep(1000);
}

void EX_ClearCntValues(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dValues[g_ChannelCNTNum] = {0}; //the channel ID from 0 to 7
	DWORD dMask = 0xFFFF; //the channels mask. In this example, we clear all CNT channel values. 
	
	BOOL lClearValueResult = CNT_ClearValues(i_lDriverHandle, i_wSlotID, dMask);
	if (ERR_SUCCESS == lClearValueResult)
	{
		printf("Succeed to clear CNT channel values.\n");
	}
	else
		printf("Fail to clear CNT channel values, error code = %d.\n", lClearValueResult);
		
	Sleep(1000);
}

void EX_SetCntChMask(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwMask = 0x0000FFFF; //the enabled counter channel mask to be set. If the bit is 1, it means that the channel started.

	LONG lSetMaskResult = CNT_SetChannelMask(i_lDriverHandle, i_wSlotID, dwMask);
	if (ERR_SUCCESS == lSetMaskResult)
	{	
		printf("Succeed to set CNT channel mask.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set CNT channel mask, error code = %d.\n", lSetMaskResult);
}

void EX_GetCntChMask(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo *i_SlotInfo)
{
	
	DWORD dwMask = 0; 
	int iCnt = 0;

	LONG lGetMaskResult = SYS_GetSlotInfo(i_lDriverHandle,i_wSlotID,i_SlotInfo);
	dwMask = i_SlotInfo->dwChMask;
	if (ERR_SUCCESS == lGetMaskResult)
	{	
		printf("Succeed to get CNT channel mask.\n");
		for (iCnt = 0; iCnt<g_ChannelCNTNum; iCnt++)
		{
			if (dwMask & (0x01 << iCnt))
			{
				printf("The CNT channel %d is enabled.\n", iCnt);
				Sleep(100);
			}
			else
				printf("The CNT channel %d is disabled.\n", iCnt);
		}
	}
	else
		printf("Fail to get CNT channel mask, error code = %d.\n", lGetMaskResult);
}

void EX_SetCntFilterWidth(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwWidth = 1000 ; //counter filter width is ranging from 0 to 40000 (us) 

	LONG lSetFilterResult = CNT_SetFilter(i_lDriverHandle, i_wSlotID,dwWidth);
	if (ERR_SUCCESS == lSetFilterResult)
	{	
		printf("Succeed to set CNT filter width.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set CNT filter width, error code = %d.\n", lSetFilterResult);
}

void EX_GetCntFilterWidth(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwWidth = 0; //counter filter width 

	LONG lGetFilterResult = CNT_GetFilter(i_lDriverHandle, i_wSlotID, &dwWidth);
	if (ERR_SUCCESS == lGetFilterResult)
	{	
		printf("The CNT filter width is %d (us).\n",dwWidth);
		Sleep(1000);
	}
	else
		printf("Fail to get CNT filter width, error code = %d.\n", lGetFilterResult);
}

void EX_ClearCntOverFlows(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwMask = 0xFFFF; //counter channel mask to be set

	LONG lClearOverFlowsResult = CNT_ClearOverflows(i_lDriverHandle, i_wSlotID,dwMask);
	if (ERR_SUCCESS == lClearOverFlowsResult)
	{	
		printf("Succeed to clear CNT overflows.\n");
		Sleep(1000);
	}
	else
		printf("Fail to clear CNT overflows, error code = %d.\n", lClearOverFlowsResult);
}

void EX_SetAlarmConfig(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 3
	BOOL bEnabled = true; //set enabled
	BOOL bAutoReload = true; //set auto reload
	BYTE byAlarmType = 1; //set 0 for "Low alarm"; set 1 for "High alarm" 
	BYTE byMapChannel = 5;//the counter channel that the alarm mapped to. The range is from 0 to 7
	DWORD dwLimitValue = 100; //the counter limit which will fire the alarm
	
	//the option for setting DO type
	//set 0  for Low level
	//set 1  for High level
	//set 2  for Low pulse
	//set 3  for High pulse
	BYTE byDoType = 2;//Low pulse	

	DWORD dwDoPulseWidth = 500; //the DO pulse width to be set (ms)

	LONG lSetConfigResult = CNT_SetAlarmConfig(i_lDriverHandle, i_wSlotID, wChannel,bEnabled,bAutoReload,byAlarmType,byMapChannel,dwLimitValue,byDoType,dwDoPulseWidth);
	if (ERR_SUCCESS == lSetConfigResult)
	{	
		printf("Succeed to set CNT alarm configuration.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set CNT alarm configuration, error code = %d.\n", lSetConfigResult);
}

void EX_GetAlarmConfig(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 3

	BOOL bEnabled = false; //set enabled
	BOOL bAutoReload = false; //set auto reload
	BYTE byAlarmType = 0; //set 0 for "Low alarm"; set 1 for "High alarm" 
	BYTE byMapChannel = 0;//the counter channel that the alarm mapped to (ranged from 0 to 7)
	DWORD dwLimitValue = 0; //the counter limit which will fire the alarm
	BYTE byDoType = 0;// DO type
	DWORD dwDoPulseWidth = 0; //the DO pulse width to be set (ms)

	CHAR *szEnabledStatus[] = {"false","true"};
	CHAR *szAlarmType[] = {"low alarm","high alarm"};
	CHAR *szDoType[] = {"low level","high level","low pulse","high pulse"};
	
	LONG lGetConfigResult = CNT_GetAlarmConfig(i_lDriverHandle, i_wSlotID, wChannel,&bEnabled,&bAutoReload,&byAlarmType,&byMapChannel,&dwLimitValue,&byDoType,&dwDoPulseWidth);
	if (ERR_SUCCESS == lGetConfigResult)
	{	
		printf("Succeed to get CNT alarm configuration.\n");
		printf("The alarm configuration of channel %d is shown below:\n",wChannel);
		printf("The alarm enabled status is %s.\n",szEnabledStatus[bEnabled]);
		printf("The auto reload status is %s.\n",szEnabledStatus[bAutoReload]);
		printf("The alarm type is %s.\n",szAlarmType[byAlarmType]);
		printf("The CNT channel %d is mapped.\n",byMapChannel);
		printf("The counter limit value is %d.\n",dwLimitValue);
		printf("The DO type is %s.\n",szDoType[byDoType]);
		printf("The DO pulse width is %d(ms).\n",dwDoPulseWidth);
		Sleep(1000);
	}
	else
		printf("Fail to get CNT alarm configuration, error code = %d.\n", lGetConfigResult);
}

void EX_SetGateConfig(LONG i_lDriverHandle,WORD i_wSlotID)
{
	
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 7
	BOOL byGateEnabled = true;// gate enabled status
	
	//the option for setting trigger mode
	//set 0  for Non re-trigger
	//set 1  for Re-trigger
	//set 2  for Edge start
	BYTE byTriggerMode = 2;//Edge start
	
	//the option for setting gate active type
	//set 0  for Low level
	//set 1  for Falling edge
	//set 2  for High level
	//set 3  for Rising edge
	BYTE byGateActiveType = 2;//High level

	BYTE byMapGate = 2; //the gate that the counter mapped to. The range is from 0 to 3
	
	LONG lSetConfigResult = CNT_SetGateConfig(i_lDriverHandle,i_wSlotID,wChannel,byGateEnabled,byTriggerMode,byGateActiveType,byMapGate);

	if (ERR_SUCCESS == lSetConfigResult)
	{	
		printf("Succeed to set CNT gate configuration.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set CNT gate configuration, error code = %d.\n", lSetConfigResult);
}

void EX_GetGateConfig(LONG i_lDriverHandle,WORD i_wSlotID)
{
	
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 7

	BOOL byGateEnabled = false;// gate enabled status
	BYTE byTriggerMode = 0;//Edge start
	BYTE byGateActiveType = 0;//High level
	BYTE byMapGate = 0; //hold the gate that the counter mapped to

	CHAR *szEnabledStatus[] = {"false","true"};
	CHAR *szTriggerMode[] = {"non re-trigger","re-trigger","edge start"};
	CHAR *szActiveType[] = {"low level","falling edge","high level","rising edge"};
	
	LONG lGetConfigResult = CNT_GetGateConfig(i_lDriverHandle,i_wSlotID,wChannel,&byGateEnabled,&byTriggerMode,&byGateActiveType,&byMapGate);

	if (ERR_SUCCESS == lGetConfigResult)
	{	
		printf("Succeed to get CNT gate configuration.\n");
		printf("The gate configuration of channel %d is shown below:\n",wChannel);
		printf("The gate enabled status is %s.\n",szEnabledStatus[byGateEnabled]);
		printf("The trigger mode is %s.\n",szTriggerMode[byTriggerMode]);
		printf("The gate active type is %s.\n",szActiveType[byGateActiveType]);
		printf("The CNT channel %d is mapped.\n",byMapGate);

		Sleep(1000);
	}
	else
		printf("Fail to get CNT gate configuration, error code = %d.\n", lGetConfigResult);
}

void EX_SetCntTypeConfig(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 7
	BOOL byRepeatEnabled = 1; //repeat enabled status
	BOOL byReloadEnabled = 1; //reload to startup enabled status

	LONG lSetConfigResult = CNT_SetCntTypeConfig(i_lDriverHandle,i_wSlotID,wChannel,byRepeatEnabled,byReloadEnabled);
	if (ERR_SUCCESS == lSetConfigResult)
	{
		printf("Succeed to set CNT type configuration.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set CNT type configuration, error code = %d.\n", lSetConfigResult);
}

void EX_GetCntTypeConfig(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 2; //channel ID which is ranged from 0 to 7

	BOOL byRepeatEnabled = 0; //repeat enabled status
	BOOL byReloadEnabled = 0; //reload to startup enabled status

	CHAR *szEnabledStatus[] = {"false","true"};

	LONG lGetConfigResult = CNT_GetCntTypeConfig(i_lDriverHandle,i_wSlotID,wChannel,&byRepeatEnabled,&byReloadEnabled);
	if (ERR_SUCCESS == lGetConfigResult)
	{
		printf("Succeed to get CNT type configuration of channel %d.\n",wChannel);
		printf("The repeat enabled status is %s.\n",szEnabledStatus[byRepeatEnabled]);
		printf("The reload enabled status is %s.\n",szEnabledStatus[byReloadEnabled]);
		Sleep(1000);
	}
	else
		printf("Fail to get CNT type configuration, error code = %d.\n", lGetConfigResult);
}

void EX_GetCntStatus(LONG i_lDriverHandle,WORD i_wSlotID)
{
	BYTE bChStatus [32] = {0};//variables array to hold the channels status
	int iCnt = 0;

	LONG lGetStatusResult = CNT_GetChannelStatus(i_lDriverHandle, i_wSlotID, bChStatus);
	if (ERR_SUCCESS == lGetStatusResult)	
	{	
		printf("Succeed to get CNT channel status.\n");
	
		for(iCnt = 0; iCnt < g_ChannelCNTNum ; iCnt++)
		{
			switch(bChStatus[iCnt])
			{
				case 0:
					printf("The status of channel %d is \"None.\"\n",iCnt);
					break;
				case 1:
					printf("The status of channel %d is \"Normal.\"\n",iCnt);
					break;
				case 8:
					printf("The status of channel %d is \"Over flow.\"\n",iCnt);
					break;
				case 9:
					printf("The status of channel %d is \"Under flow.\"\n",iCnt);
					break;
				case 10:
					printf("The status of channel %d is \"Over and Under flow.\"\n",iCnt);
					break;
				default:
					printf("The status of channel %d is \"Unknown.\"\n",iCnt);
					break;
			}
		}

		Sleep(100);
	}
	else
		printf("Fail to get CNT channel status, error code = %d.\n", lGetStatusResult);
}

void EX_SetCntFreqAcqTime(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwFreqAcqTime = 1000; //the frequency acquisition time which is ranged from 0 to 10000 (ms)

	LONG lSetTimeResult = CNT_SetFreqAcqTime(i_lDriverHandle, i_wSlotID, dwFreqAcqTime);
	if (ERR_SUCCESS == lSetTimeResult)	
	{	
		printf("Succeed to set CNT frequency acquisition time.\n");
	}
	else
		printf("Fail to set CNT frequency acquisition time, error code = %d.\n", lSetTimeResult);

}

void EX_GetDIValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 1;// the channel ID from 0 to 3 
	BOOL bHoldValue = false;//hold the DI value of single channel 
	
	int iCnt = 0;

	LONG lGetDIValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &bHoldValue);

	if (ERR_SUCCESS == lGetDIValueResult)
	{
		//check all DI channels (there are 4 channels in Apax-5080)
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
	int iCnt = 0;
	
	BOOL lGetDIMultiValueResult = DIO_GetValues(i_lDriverHandle, i_wSlotID, &dHiValue, &dLowValue);
	if (ERR_SUCCESS == lGetDIMultiValueResult)
	{
		//show all DI channels (there are 4 channels in Apax-5080)
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
	WORD wChannel = 1; //the channel ID from 0 to 3 	
	BOOL bSetValue = true; // DO value to be set	

	BOOL lSetValueResult = DO_SetValue(i_lDriverHandle, i_wSlotID, wChannel , bSetValue);
	if (ERR_SUCCESS == lSetValueResult )
		printf("Channel %d is %s.\n", wChannel,(bSetValue) ? "true (light on)":"false (light off)");	
	else
		printf("Fail to set the DO value of channel %d.\n", wChannel);
		
	Sleep(3000);
}

void EX_GetDOValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 1;// the channel ID from 0 to 3
	BOOL bHoldValue = false;//hold the DO value of single channel 
	
	int iCnt = 0;

	LONG lGetValueResult = DIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel + g_ChannelDINum, &bHoldValue);

	if (ERR_SUCCESS == lGetValueResult)
	{
		//check all channels (there are 4 channels in Apax-5080)
		for (iCnt = 0; iCnt < g_ChannelDONum ; iCnt++)
		{
			if (iCnt== wChannel)
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
	DWORD dLowValue = 0x000F;	//the lower DO value from channel 0 to 31
	
    LONG lSetMultiValueResult= DO_SetValues(i_lDriverHandle, i_wSlotID, dHiValue, dLowValue);
	if (ERR_SUCCESS == lSetMultiValueResult )
	{
		printf("Succeed to set DO multiple channel values.\n");
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
		//show all channels (there are 4 DO-channels in Apax-5080)
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

int main(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//==============================
	WORD wSlotID = 4; //the slot ID which is ranged from 0 to 31
	
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
        
		//the moduleID for Apax-5080 is 0x50800000
		//dHiWord is 5080, dLoWord is 0000
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
	
	//get DI single channel value example
	if (bAdvStatus)
	{
		printf("\n*** Get DI single channel value ***\n");
        EX_GetDIValue(lDriverHandle, wSlotID);
	}

	//get DI multiple channel value example (single slot)
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
	
	//set DO single  channel example
	if (bAdvStatus)
	{
		printf("\n*** Set DO single channel value ***\n");		
		EX_SetDOValue(lDriverHandle, wSlotID);
	}

	//get DO single channel example
	if (bAdvStatus)
	{
		printf("\n*** Get DO single channel value ***\n");
        EX_GetDOValue(lDriverHandle, wSlotID);
	}
	
	//set DO multiple channel values example 
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

	//=================================================================================
	//	
	//		functions for CNT(counter) module
	//
	//=================================================================================
	
	// set enabled counter channel mask
	if (bAdvStatus)
	{
		printf("\n*** Set CNT channel mask ***\n");
        EX_SetCntChMask(lDriverHandle, wSlotID);
	}	

	// get enabled counter channel mask
	if (bAdvStatus)
	{
		printf("\n*** Get CNT channel mask ***\n");
        EX_GetCntChMask(lDriverHandle, wSlotID, &sSlotInfo);
	}
	
	
	//set CNT channel mode example
	if (bAdvStatus)
	{
		printf("\n*** Set CNT channel mode ***\n");
        EX_SetCntChannelMode(lDriverHandle, wSlotID);
	}

	//get CNT channel mode example
	if (bAdvStatus)
	{
		printf("\n*** Get CNT channel mode ***\n");
        EX_GetCntChannelMode(lDriverHandle, wSlotID,&sSlotInfo);
	}

	//set CNT startup values example
	if (bAdvStatus)
	{
		printf("\n*** Set CNT startup values ***\n");
        EX_SetCntStartUpValue(lDriverHandle, wSlotID);
	}

	//get CNT startup values example
	if (bAdvStatus)
	{
		printf("\n*** Get CNT startup values ***\n");
        EX_GetCntStartUpValue(lDriverHandle, wSlotID);
	}

	//set CNT type configuration example
	if (bAdvStatus)
	{
		printf("\n*** Set CNT type ***\n");
        EX_SetCntTypeConfig(lDriverHandle, wSlotID);
	}

	//get CNT type configuration example
	if (bAdvStatus)
	{
		printf("\n*** Get CNT type ***\n");
        EX_GetCntTypeConfig(lDriverHandle, wSlotID);
	}

	//set CNT gate setting example
	if (bAdvStatus)
	{
		printf("\n*** Set CNT gate configuration ***\n");
        EX_SetGateConfig(lDriverHandle, wSlotID);
	}

	//get CNT gate setting example
	if (bAdvStatus)
	{
		printf("\n*** Get CNT gate configuration ***\n");
        EX_GetGateConfig(lDriverHandle, wSlotID);
	}

	//set the counter frequency acquisition time
	if (bAdvStatus)
	{
		printf("\n*** Set CNT frequency acquisition time ***\n");
        EX_SetCntFreqAcqTime(lDriverHandle, wSlotID);
	}

	//set CNT filter width
	if (bAdvStatus)
	{
		printf("\n*** Set CNT filter width ***\n");
		EX_SetCntFilterWidth(lDriverHandle, wSlotID);
	}

	//get CNT filter width
	if (bAdvStatus)
	{
		printf("\n*** Get CNT filter width ***\n");
		EX_GetCntFilterWidth(lDriverHandle, wSlotID);
	}

	//clear CNT overflow
	if (bAdvStatus)
	{
		printf("\n*** Clear CNT overflow ***\n");
		EX_ClearCntOverFlows(lDriverHandle, wSlotID);
	}

	//get CNT channel status
	if (bAdvStatus)
	{
		printf("\n*** Get CNT channel status ***\n");
		EX_GetCntStatus(lDriverHandle, wSlotID);
	}

	//get CNT single channel value
	if (bAdvStatus)
	{
		printf("\n*** Get CNT single channel value ***\n");
		EX_GetCntValue(lDriverHandle, wSlotID);
	}

	//clear CNT multiple channel values
	if (bAdvStatus)
	{
		printf("\n*** Clear CNT multiple channel values ***\n");
		EX_ClearCntValues(lDriverHandle, wSlotID);
	}

	//get CNT multiple channel values
	if (bAdvStatus)
	{
		printf("\n*** Get CNT multiple channel values ***\n");
		EX_GetCntMultiValue(lDriverHandle, wSlotID);
	}

	//set CNT alarm configuration example
	if (bAdvStatus)
	{
		printf("\n*** Set CNT alarm configuration ***\n");
        EX_SetAlarmConfig(lDriverHandle, wSlotID);
	}

	//get CNT alarm configuration example
	if (bAdvStatus)
	{
		printf("\n*** Get CNT alarm configuration ***\n");
        EX_GetAlarmConfig(lDriverHandle, wSlotID);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	system("pause");

	return 0;
}

