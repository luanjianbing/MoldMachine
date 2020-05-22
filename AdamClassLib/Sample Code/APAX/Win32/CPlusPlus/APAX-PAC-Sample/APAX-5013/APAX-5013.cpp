// APAX-5013.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>

const int g_ChannelNum = 8; //the channel number of APAX-5013 is 8

//APAX 5013 range table
#define PT100_3851_NEG_200_TO_850_C		0x0200
#define PT100_3851_NEG_120_TO_130_C		0x0201
#define PT200_3851_NEG_200_TO_850_C		0x0220
#define PT200_3851_NEG_120_TO_130_C		0x0221
#define PT500_3851_NEG_200_TO_850_C		0x0240
#define PT500_3851_NEG_120_TO_130_C		0x0241
#define PT1000_3851_NEG_200_TO_850_C	0x0260
#define PT1000_3851_NEG_120_TO_130_C	0x0261
#define PT100_3916_NEG_200_TO_850_C		0x0280
#define PT100_3916_NEG_120_TO_130_C		0x0281
#define PT200_3916_NEG_200_TO_850_C		0x02A0
#define PT200_3916_NEG_120_TO_130_C		0x02A1
#define PT500_3916_NEG_200_TO_850_C		0x02C0
#define PT500_3916_NEG_120_TO_130_C		0x02C1
#define PT1000_3916_NEG_200_TO_850_C	0x02E0
#define PT1000_3916_NEG_120_TO_130_C	0x02E1
#define BALCON_NEG_30_TO_120_C			0x0300
#define NI_NEG_80_TO_100_C				0x0320
#define NI_ZERO_TO_100_C				0x0321


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

void EX_SetIntegrationTime(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dIntegration = 0; 

	LONG lSetIntegrationTimeResult = AI_SetIntegrationTime(i_lDriverHandle, i_wSlotID, dIntegration);
	if (ERR_SUCCESS == lSetIntegrationTimeResult)	
	{	
		printf("Succeed to set integration time.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set integation time, error code = %d\n", lSetIntegrationTimeResult);

}

void EX_SetChMask(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwMask = 0x0000FFFF; //enable all channels
	
	LONG lSetMaskResult = AI_SetChannelMask(i_lDriverHandle, i_wSlotID, dwMask);
	if (ERR_SUCCESS == lSetMaskResult)
	{	
		printf("Succeed to set channel mask.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set channel mask, error code = %d.\n", lSetMaskResult);
}

void EX_GetChMask(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo *i_SlotInfo)
{
	
	DWORD dwMask = 0; 
	int iCnt = 0;

	LONG lGetMaskResult = SYS_GetSlotInfo(i_lDriverHandle,i_wSlotID,i_SlotInfo);
	dwMask = i_SlotInfo->dwChMask;
	if (ERR_SUCCESS == lGetMaskResult)
	{	
		printf("Succeed to get channel mask.\n");
		for (iCnt = 0; iCnt < g_ChannelNum; iCnt++)
		{
			if (dwMask & (0x01 << iCnt))
			{
				printf("Channel %d is enabled.\n", iCnt);
				Sleep(100);
			}
			else
				printf("Channel %d is disabled.\n", iCnt);
		}
	}
	else
		printf("Fail to get channel mask, error code = %d.\n", lGetMaskResult);
}

void EX_SetBurnoutFun(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	DWORD dwEnableMask = 0xFFFF; //enable all channels

	LONG lSetBurnoutFunResult = AI_SetBurnoutFunEnable(i_lDriverHandle, i_wSlotID, dwEnableMask);
	if (ERR_SUCCESS == lSetBurnoutFunResult)	
	{	
		printf("Succeed to set burnout detect function.\n");
		Sleep(3000);
	}
	else
		printf("Fail to set burnout detect function, error code = %d\n", lSetBurnoutFunResult);
}

void EX_GetBurnoutFun(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwEnableMask = 0; 
	int iCnt = 0;
	LONG lGetBurnoutFunResult = AI_GetBurnoutFunEnable(i_lDriverHandle, i_wSlotID, &dwEnableMask);
	if (ERR_SUCCESS == lGetBurnoutFunResult)	
	{	
		printf("Succeed to get burnout detect function.\n");
		for (iCnt = 0; iCnt < g_ChannelNum; iCnt++)
		{
			if (dwEnableMask & (0x01 << iCnt))
			{
				printf("The burnout detect function of channel %d is enabled.\n", iCnt);
				Sleep(100);
			}
			else
				printf("The burnout detect function of channel %d is disabled.\n", iCnt);
		}
	}
	else
		printf("Fail to get burnout detect function, error code = %d\n", lGetBurnoutFunResult);
}


void EX_SetBurnoutMode(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================

	//set dwBurnoutMode = 0      for "Down Scale"
	//set dwBurnoutMode = 0xFFFF for "Up Scale"

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

void EX_SetRange(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChRange[g_ChannelNum]={0};
	wChRange[0] = PT100_3851_NEG_200_TO_850_C;	
	wChRange[1] = PT100_3851_NEG_120_TO_130_C;		
	wChRange[2] = PT200_3851_NEG_200_TO_850_C;		
	wChRange[3] = PT200_3851_NEG_120_TO_130_C;		
	wChRange[4] = PT500_3851_NEG_200_TO_850_C;			
	wChRange[5] = PT500_3851_NEG_120_TO_130_C;		
	wChRange[6] = PT1000_3851_NEG_200_TO_850_C;			
	wChRange[7] = PT1000_3851_NEG_120_TO_130_C;
	

	LONG lSetRangeResult = AIO_SetRanges(i_lDriverHandle, i_wSlotID, g_ChannelNum, wChRange);
	if (ERR_SUCCESS == lSetRangeResult)
	{
		printf("Succeed to set ranges.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set ranges, error code = %d\n", lSetRangeResult);
}
void EX_GetRange(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo *i_SlotInfo)
{
	LONG lGetRangeResult = SYS_GetSlotInfo(i_lDriverHandle,i_wSlotID,i_SlotInfo);
	WORD wRangeType = 0;
	int iCnt = 0;
	
	if (ERR_SUCCESS == lGetRangeResult)
	{
		printf("Succeed to get ranges.\n");
		for(iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			wRangeType = *(i_SlotInfo->wChRange + iCnt);

			switch (wRangeType)
			{
				case PT100_3851_NEG_200_TO_850_C: 
					printf("The type of channel %d is Pt100(3851), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT100_3851_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt100(3851), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case PT200_3851_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt200(3851), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT200_3851_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt200(3851), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case PT500_3851_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt500(3851), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT500_3851_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt500(3851), with a range of -120 ~ 130 'C.\n", iCnt);
					break;
				
				case PT1000_3851_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt1000(3851), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT1000_3851_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt1000(3851), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case PT100_3916_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt100(3916), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT100_3916_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt100(3916), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case PT200_3916_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt200(3916), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT200_3916_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt200(3916), with a range of -120 ~ 130 'C.\n", iCnt);
					break;
				
				case PT500_3916_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt500(3916), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT500_3916_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt500(3916), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case PT1000_3916_NEG_200_TO_850_C:
					printf("The type of channel %d is Pt1000(3916), with a range of -200 ~ 850 'C.\n", iCnt);
					break;

				case PT1000_3916_NEG_120_TO_130_C:
					printf("The type of channel %d is Pt1000(3916), with a range of -120 ~ 130 'C.\n", iCnt);
					break;

				case BALCON_NEG_30_TO_120_C:
					printf("The type of channel %d is Balcon(500), with a range of -30 ~ 120 'C.\n", iCnt);
					break;

				case NI_NEG_80_TO_100_C:
					printf("The type of channel %d is Ni(518), with a range of -80 ~ 100 'C.\n", iCnt);
					break;

				case NI_ZERO_TO_100_C:
					printf("The type of channel %d is Ni(518), with a range of 0 ~ 100 'C.\n", iCnt);
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
	BYTE bChStatus [32] ={0}; //variable array to hold the channel status
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

void EX_ScaleRawValue(WORD i_wRangeType, WORD i_wRawValue,double *o_dScaledValue,bool *o_bUnknowRange)
{
	switch(i_wRangeType)
	{
		*o_bUnknowRange = false;

		case PT100_3851_NEG_200_TO_850_C:
		case PT200_3851_NEG_200_TO_850_C:
		case PT500_3851_NEG_200_TO_850_C:
		case PT1000_3851_NEG_200_TO_850_C:
		case PT100_3916_NEG_200_TO_850_C:
		case PT200_3916_NEG_200_TO_850_C:
		case PT500_3916_NEG_200_TO_850_C:
		case PT1000_3916_NEG_200_TO_850_C:			
		*o_dScaledValue = -200.0 + (i_wRawValue / 65535.0) * 1050.0;
			break;

		case PT100_3851_NEG_120_TO_130_C:
		case PT200_3851_NEG_120_TO_130_C:
		case PT500_3851_NEG_120_TO_130_C:
		case PT1000_3851_NEG_120_TO_130_C:	
		case PT100_3916_NEG_120_TO_130_C:
		case PT200_3916_NEG_120_TO_130_C:
		case PT500_3916_NEG_120_TO_130_C:
		case PT1000_3916_NEG_120_TO_130_C:
		*o_dScaledValue = -120.0 + (i_wRawValue / 65535.0) * 250.0;
			break;

		case BALCON_NEG_30_TO_120_C:
		*o_dScaledValue = -30.0 + (i_wRawValue / 65535.0) * 150.0;
			break;

		case NI_NEG_80_TO_100_C:
		*o_dScaledValue = -80.0 + (i_wRawValue / 65535.0) * 180.0;
			break;

		case NI_ZERO_TO_100_C:
		*o_dScaledValue = (i_wRawValue / 65535.0) * 100.0;
			break;

		default: 
		*o_bUnknowRange = true;
			break;
	}
}

void EX_GetValue(LONG i_lDriverHandle,WORD i_wSlotID, struct SlotInfo &i_SlotInfo)
{
	//==============================
	// user can set parameter below
	//============================== 
	WORD wChannel = 7;// the channel ID from 0 to 7 

	WORD wRawValue = 0; //raw data
	double dScaledValue = 0.0;//scaled value
	WORD wRangeType = 0;
	bool bUnknowRange = false; //the channel range is unknown  

	wRangeType = *(i_SlotInfo.wChRange + wChannel); //get range type	
	LONG lGetValueResult = AIO_GetValue(i_lDriverHandle, i_wSlotID, wChannel, &wRawValue); //get raw value
	if (ERR_SUCCESS == lGetValueResult)	
	{	
		EX_ScaleRawValue(wRangeType,wRawValue,&dScaledValue,&bUnknowRange);//get scale value
		if (!bUnknowRange)
		{
			printf("Channel %d raw data is 0x%04X, scaled value is %.4f 'C.\n", wChannel, wRawValue, dScaledValue);
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
	double dScaledValue = 0.0; //scaled value
	WORD wRangeType = 0;
	bool bUnknowRange = false; //the channel range is unknown
	int iCnt = 0;

	LONG lGetMultiValueResult = AIO_GetValues(i_lDriverHandle, i_wSlotID, wRawValue); //get raw value
	if (ERR_SUCCESS == lGetMultiValueResult)	
	{
		for (iCnt =0; iCnt < g_ChannelNum ; iCnt++)
		{
			wRangeType = *(i_SlotInfo.wChRange + iCnt); //get range type
			EX_ScaleRawValue(wRangeType, wRawValue[iCnt], &dScaledValue, &bUnknowRange);//get scale value
			if (!bUnknowRange)
			{
				printf("Channel %d raw data is 0x%04X, scaled value is %.4f 'C.\n", iCnt, wRawValue[iCnt], dScaledValue);
				Sleep(3000);
			}
			else
				printf("Channel %d range is unknown.\n", iCnt);		
		}
	}
	else
		printf("Fail to get value, error code = %d\n", lGetMultiValueResult);

}

int main(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//==============================
	WORD wSlotID = 0; //the slot ID which is ranged from 0 to 31

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
        
		//the moduleID for Apax-5013 is 0x50130000
		//dHiWord is 5013, dLoWord is 0000
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
		
	//=================================================================================
	//	
	//		Selected items functions
	//
	//=================================================================================
	
	//set AI channel mask example (set channel enable or disable)
	if (bAdvStatus)
	{
		printf("\n*** Set AI channel mask ***\n");
		EX_SetChMask(lDriverHandle, wSlotID);
	}

	//get AI channel mask example
	if (bAdvStatus)
	{
		printf("\n*** Get AI channel mask ***\n");
		EX_GetChMask(lDriverHandle, wSlotID, &sSlotInfo);
	}

	//set AI channel burnout detect function enabled 
	if (bAdvStatus)
	{
		printf("\n*** Set AI burnout detect function ***\n");
		EX_SetBurnoutFun(lDriverHandle, wSlotID);
	}

	//get AI channel burnout detect function status
	if (bAdvStatus)
	{
		printf("\n*** Get AI burnout detect function ***\n");
		EX_GetBurnoutFun(lDriverHandle, wSlotID);
	}
	
	//=================================================================================
	//	
	//		Module setting functions
	//
	//=================================================================================
	//set AI integation time
	if (bAdvStatus)
	{
		printf("\n*** Set AI integation time ***\n");
		EX_SetIntegrationTime(lDriverHandle, wSlotID);
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

	//get AI channel status example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI channel status ***\n");
		EX_GetStatus(lDriverHandle, wSlotID);
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
		EX_GetRange(lDriverHandle, wSlotID, &sSlotInfo);
	}
	
	//get AI single channel value example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI single channel value ***\n");
		EX_GetValue(lDriverHandle, wSlotID, sSlotInfo);
	}

	//get AI multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get AI multiple channel values ***\n");
		EX_GetMultiValue(lDriverHandle, wSlotID, sSlotInfo);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	system("pause");
	return 0;
}

