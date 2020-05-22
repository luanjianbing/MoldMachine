// APAX-5017H.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>

const int g_ChannelNum = 12; //the channel number of APAX-5017H is 12

//APAX 5017H range table
#define ZERO_TO_500_MV	    0x0106 
#define NEG_10_TO_10_V		0x0143
#define _4_TO_20_MA			0x0180
#define ZERO_TO_20_MA		0x0182
#define ZERO_TO_10_V		0x0148


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

void EX_SetRange(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChRange[g_ChannelNum]={0};	
	wChRange[0] =  ZERO_TO_500_MV;
	wChRange[1] =  ZERO_TO_500_MV;
	wChRange[2] =  ZERO_TO_500_MV;
	wChRange[3] = NEG_10_TO_10_V;
	wChRange[4] = NEG_10_TO_10_V;
	wChRange[5] =  _4_TO_20_MA;
	wChRange[6] =  _4_TO_20_MA;
	wChRange[7] =  _4_TO_20_MA;
	wChRange[8] = ZERO_TO_20_MA;
	wChRange[9] = ZERO_TO_20_MA;
	wChRange[10] = ZERO_TO_10_V;
	wChRange[11] = ZERO_TO_10_V;

	LONG lSetRangeResult = AIO_SetRanges(i_lDriverHandle,i_wSlotID,g_ChannelNum,wChRange);
	if (ERR_SUCCESS == lSetRangeResult)
	{
		printf("Succeed to set ranges.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set ranges, error code = %d\n", lSetRangeResult);
}
void EX_GetRange(LONG i_lDriverHandle, WORD i_wSlotID, struct SlotInfo *i_SlotInfo)
{
	LONG lGetRangeResult = SYS_GetSlotInfo(i_lDriverHandle,i_wSlotID,i_SlotInfo);
	WORD wRangeType = 0;
	int iCnt = 0;

	if (ERR_SUCCESS ==lGetRangeResult)
	{
		printf("Succeed to get ranges.\n");
		for(iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			wRangeType = *(i_SlotInfo->wChRange + iCnt);

			switch (wRangeType)
			{
				case  ZERO_TO_500_MV: 
					printf("The range of channel %d is 0 ~ 500 mV.\n", iCnt);
					break;

				case NEG_10_TO_10_V:
					printf("The range of channel %d is +/- 10 V.\n", iCnt);
					break;

				case _4_TO_20_MA:
					printf("The range of channel %d is 4 ~ 20 mA.\n", iCnt);
					break;

				case ZERO_TO_20_MA:
					printf("The range of channel %d is 0 ~ 20 mA.\n", iCnt);
					break;

				case ZERO_TO_10_V:
					printf("The range of channel %d is 0 ~ 10 V.\n", iCnt);
					break;

				default:
					printf("The range of channel %d is unknown.\n", iCnt);
					break;
			}
		}
	}
	else
	{
		printf("Fail to get ranges, error code = %d\n", lGetRangeResult);
	}

	Sleep(3000);
}

void EX_GetStatus(LONG i_lDriverHandle,WORD i_wSlotID)
{
	BYTE bChStatus [32] ={0};//variable array to hold the channel status
	int iCnt = 0;

	LONG lGetStatusResult = AIO_GetChannelStatus(i_lDriverHandle, i_wSlotID, bChStatus);
	if (ERR_SUCCESS == lGetStatusResult)	
	{	
		printf("Succeed to get channel status.\n");
	
		for(iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			switch(bChStatus[iCnt])
			{
				case 0:
					printf("The status of channel %d is \"None\"\n",iCnt);
					break;
				case 1:
					printf("The status of channel %d is \"Normal\"\n",iCnt);
					break;
				case 2:
					printf("The status of channel %d is \"Over Current\"\n",iCnt);
					break;
				case 3:
					printf("The status of channel %d is \"Under Current\"\n",iCnt);
					break;
				case 4:
					printf("The status of channel %d is \"Burn Out\"\n",iCnt);
					break;
				case 5:
					printf("The status of channel %d is \"Open Loop\"\n",iCnt);
					break;
				case 6:
					printf("The status of channel %d is \"Not Ready\"\n",iCnt);
					break;
				default:
					printf("The status of channel %d is \"Unknown\"\n",iCnt);
					break;
			}
		}

		Sleep(100);
	}
	else
		printf("Fail to get channel status, error code = %d\n", lGetStatusResult);
}

void EX_SetBurnoutMode(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	//set dwBurnoutMode = 0      for "down scale"
	//set dwBurnoutMode = 0xFFFF for "up scale"

	DWORD dwBurnoutMode = 0xFFFF; //up scale

	LONG lSetBurnoutModeResult = AI_SetBurnoutValue(i_lDriverHandle, i_wSlotID, dwBurnoutMode);
	if (ERR_SUCCESS == lSetBurnoutModeResult)	
	{	
		printf("Succeed to set burnout detect mode.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set burnout detect mode, error code = %d\n", lSetBurnoutModeResult);

}

void EX_GetBurnoutMode(LONG i_lDriverHandle,WORD i_wSlotID)
{

	DWORD dwBurnoutMode = 0; 

	LONG lGetBurnoutModeResult = AI_GetBurnoutValue(i_lDriverHandle, i_wSlotID, &dwBurnoutMode);
	if (ERR_SUCCESS == lGetBurnoutModeResult)	
	{	
		if (dwBurnoutMode > 0)
		{
			printf("The burnout detect mode is \" %s \".\n","Up Scale");
		}
		else
			printf("The burnout detect mode is \" %s \".\n","Down Scale");
		
		Sleep(3000);
	}
	else
		printf("Fail to get burnout detect mode, error code = %d\n", lGetBurnoutModeResult);

}


void EX_SetSamplingRate(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameter below
	//==============================
	DWORD dwSampleRate = 1000; //in (Hz/Ch)

	LONG lSetSamplingRateResult = AI_SetSampleRate(i_lDriverHandle, i_wSlotID, dwSampleRate);
	if (ERR_SUCCESS == lSetSamplingRateResult)	
	{	
		printf("Succeed to set sampling rate.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set sampling rate, error code = %d\n", lSetSamplingRateResult);

}

void EX_GetSamplingRate(LONG i_lDriverHandle,WORD i_wSlotID)
{
	
	DWORD dwSampleRate = 0;

	LONG lGetSamplingRateResult = AI_GetSampleRate(i_lDriverHandle, i_wSlotID, &dwSampleRate);
	if (ERR_SUCCESS == lGetSamplingRateResult)	
	{	
		printf("The sampling rate is %d (Hz/Ch).\n",dwSampleRate);
		Sleep(3000);
	}
	else
		printf("Fail to get sampling rate, error code = %d\n", lGetSamplingRateResult);

}

void EX_ScaleRawValue(WORD i_wRangeType, WORD i_wRawValue,double *o_dScaledValue,char *o_cUnit)
{
	switch(i_wRangeType)
	{
		case  ZERO_TO_500_MV:
		*o_dScaledValue = (i_wRawValue / 4095.0) * 500.0;
		strcpy(o_cUnit,"mV");
			break;

		case NEG_10_TO_10_V:
		*o_dScaledValue = -10.0 + (i_wRawValue / 4095.0) * 20.0;
		strcpy(o_cUnit,"V");
		    break;

		case ZERO_TO_10_V:
		*o_dScaledValue = (i_wRawValue / 4095.0) * 10.0;
		strcpy(o_cUnit,"V");
		    break;

		case _4_TO_20_MA:
		*o_dScaledValue = 4.0 + (i_wRawValue / 4095.0) * 16.0;
		strcpy(o_cUnit,"mA");
			break;

		case ZERO_TO_20_MA:
		*o_dScaledValue = (i_wRawValue / 4095.0) * 20.0;
		strcpy(o_cUnit,"mA");
			break;

		default: 
		strcpy(o_cUnit,"UN");
			break;
	}
}

void EX_GetValue(LONG i_lDriverHandle,WORD i_wSlotID, struct SlotInfo &i_SlotInfo)
{
	//==============================
	// user can set parameter below
	//==============================
	WORD wChannel = 7;// the channel ID from 0 to 11 

	WORD wRawValue = 0; //raw data
	double dScaledValue = 0.0;//scaled value
	WORD wRangeType = 0;
	char cUnit[3] = {0};

	wRangeType = *(i_SlotInfo.wChRange + wChannel); //get range type	
	LONG lGetValueResult = AIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &wRawValue); //get raw value
	if (ERR_SUCCESS == lGetValueResult)	
	{	
		EX_ScaleRawValue(wRangeType, wRawValue, &dScaledValue, cUnit);//get scale value
		if (strcmp(cUnit,"UN") != 0)
		{
			printf("Channel %d raw data is 0x%04X, scaled value is %.4f %s.\n", wChannel, wRawValue, dScaledValue, cUnit);
			Sleep(3000);
		}
		else
			printf("Channel %d range is unknown.\n", wChannel);
	}
	else
		printf("Fail to get value, error code = %d\n", lGetValueResult);


}
void EX_GetMultiValue(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo &i_SlotInfo)
{
	WORD wRawValue[g_ChannelNum] = {0}; //raw data
	double dScaledValue = 0.0;//scaled value
	WORD wRangeType = 0;
	char cUnit[3] = {0};
	int iCnt = 0;

	LONG lGetMultiValueResult = AIO_GetValues(i_lDriverHandle, i_wSlotID, wRawValue); //get raw value
	if (ERR_SUCCESS == lGetMultiValueResult)	
	{
		for (iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			wRangeType = *(i_SlotInfo.wChRange + iCnt); //get range type
			EX_ScaleRawValue(wRangeType, wRawValue[iCnt], &dScaledValue, cUnit);//get scale value
			if (strcmp(cUnit,"UN") != 0)
			{
				printf("Channel %d raw data is 0x%04X, scaled value is %.4f %s.\n", iCnt, wRawValue[iCnt], dScaledValue,cUnit);
				Sleep(1000);
			}
			else
				printf("Channel %d range is unknown.\n", iCnt);		
		}
	}
	else
		printf("Fail to get value, error code = %d\n", lGetMultiValueResult);

}

int _tmain(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//==============================
	WORD wSlotID = 1; //the slot ID which is ranged from 0 to 31

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
        
		//the moduleID for Apax-5017H is 0x50174800
		//dHiWord is 5017, dLoWord is 4800
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

	// get slot info
	if (bAdvStatus)
	{

		LONG lGetSlotInfo = SYS_GetSlotInfo(lDriverHandle,wSlotID, &sSlotInfo);
		if (ERR_SUCCESS != lGetSlotInfo)
			printf("Fail to get slot information, error code = %d\n", lGetSlotInfo);
			Sleep(100);
	}

	//set AI burnout detection mode
	if (bAdvStatus)
	{
		printf("\n*** Set AI burnout detection mode ***\n");
		EX_SetBurnoutMode(lDriverHandle, wSlotID);
	}
	
	//get AI burnout detection mode
	if (bAdvStatus)
	{
		printf("\n*** Get AI burnout detection mode ***\n");
		EX_GetBurnoutMode(lDriverHandle, wSlotID);
	}
	
	//set AI sampling rate
	if (bAdvStatus)
	{
		printf("\n*** Set AI sampling rate ***\n");
		EX_SetSamplingRate(lDriverHandle, wSlotID);
	}

	//get AI sampling rate
	if (bAdvStatus)
	{
		printf("\n*** Get AI sampling rate ***\n");
		EX_GetSamplingRate(lDriverHandle, wSlotID);
	}
	
	//set AI channel ranges example 
	if (bAdvStatus)
	{
		printf("\n*** Set AI channel ranges ***\n");
		EX_SetRange(lDriverHandle, wSlotID);
	}

	//get AI channel ranges example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI channel ranges ***\n");
		EX_GetRange(lDriverHandle, wSlotID,&sSlotInfo);
	}

	//get AI channel status example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI channel status ***\n");
		EX_GetStatus(lDriverHandle, wSlotID);
	}

	//get AI single channel value example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI single channel value ***\n");
		EX_GetValue(lDriverHandle, wSlotID, sSlotInfo);
	}
	
	//get AI multiple channel value example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI multiple channel values ***\n");
		EX_GetMultiValue(lDriverHandle, wSlotID, sSlotInfo);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	
	return 0;
}

