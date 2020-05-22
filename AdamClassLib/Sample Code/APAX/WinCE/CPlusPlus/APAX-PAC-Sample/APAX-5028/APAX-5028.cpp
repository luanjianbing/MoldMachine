// APAX-5028.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>

const int g_ChannelNum = 8; //the channel number of APAX-5028 is 8

//APAX 5028 range table
#define NEG_2P5_TO_2P5_V	0x0141
#define NEG_5_TO_5_V		0x0142
#define NEG_10_TO_10_V		0x0143
#define ZERO_TO_2P5_V		0x0146
#define ZERO_TO_5_V			0x0147
#define ZERO_TO_10_V		0x0148
#define _4_TO_20_MA			0x0180
#define ZERO_TO_20_MA		0x0182


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

void EX_SetSafetyEnable(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameter below
	//==============================
	BOOL bSafetyEnable = true ;//set the safety value enabled status 

    LONG lSetSafetyEnableResult = OUT_SetSaftyEnable(i_lDriverHandle,i_wSlotID,bSafetyEnable);
	if (ERR_SUCCESS ==lSetSafetyEnableResult)
	{
		printf("Succeed to set safety value status.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set safety value status, error code = %d\n", lSetSafetyEnableResult);
}

void EX_SetRange(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChRange[g_ChannelNum] = {0};
	wChRange[0] = NEG_2P5_TO_2P5_V;	
	wChRange[1] = NEG_5_TO_5_V;		
	wChRange[2] = NEG_10_TO_10_V;		
	wChRange[3] = ZERO_TO_2P5_V;		
	wChRange[4] = ZERO_TO_5_V;			
	wChRange[5] = ZERO_TO_10_V;		
	wChRange[6] = _4_TO_20_MA;			
	wChRange[7] = ZERO_TO_20_MA;
	

	LONG lSetRangeResult = AIO_SetRanges(i_lDriverHandle,i_wSlotID,g_ChannelNum,wChRange);
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
				case  NEG_2P5_TO_2P5_V: 
					printf("The range of channel %d is +/- 2.5 V.\n", iCnt);
					break;

				case NEG_5_TO_5_V:
					printf("The range of channel %d is +/- 5 V.\n", iCnt);
					break;

				case NEG_10_TO_10_V:
					printf("The range of channel %d is +/- 10 V.\n", iCnt);
					break;
				
				case ZERO_TO_2P5_V:
					printf("The range of channel %d is 0 ~ 2.5 V.\n", iCnt);
					break;

				case ZERO_TO_5_V:
					printf("The range of channel %d is 0 ~ 5 V.\n", iCnt);
					break;

				case ZERO_TO_10_V:
					printf("The range of channel %d is 0 ~ 10 V.\n", iCnt);
					break;

				case _4_TO_20_MA:
					printf("The range of channel %d is 4 ~ 20 mA.\n", iCnt);
					break;

				case ZERO_TO_20_MA:
					printf("The range of channel %d is 0 ~ 20 mA.\n", iCnt);
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
	BYTE bChStatus [32] = {0};//variable array to hold the channel status
	int iCnt = 0;

	LONG lGetStatusResult = AIO_GetChannelStatus(i_lDriverHandle, i_wSlotID, bChStatus);
	if (ERR_SUCCESS == lGetStatusResult)	
	{	
		printf("Succeed to get channel status.\n");
	
		for(iCnt = 0; iCnt < g_ChannelNum ; iCnt++)
		{
			switch( bChStatus[iCnt] )
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

void EX_ScaleRawValue(WORD i_wRangeType, WORD i_wRawValue, double *o_dScaledValue, char *o_cUnit)
{
	switch(i_wRangeType)
	{		
		case NEG_2P5_TO_2P5_V:
		*o_dScaledValue = -2.5 + (i_wRawValue / 65535.0) * 5.0;
		strcpy(o_cUnit,"V");
		    break;

		case NEG_5_TO_5_V:
		*o_dScaledValue = -5.0 + (i_wRawValue / 65535.0) * 10.0;
		strcpy(o_cUnit,"V");
		    break;	
	
		case NEG_10_TO_10_V:
		*o_dScaledValue = -10.0 + (i_wRawValue / 65535.0) * 20.0;
		strcpy(o_cUnit,"V");
		    break;

		case ZERO_TO_2P5_V:
		*o_dScaledValue = (i_wRawValue / 65535.0) * 2.5;
		strcpy(o_cUnit,"V");
		    break;

		case ZERO_TO_5_V:
		*o_dScaledValue = (i_wRawValue / 65535.0) * 5.0;
		strcpy(o_cUnit,"V");
		    break;

		case ZERO_TO_10_V:
		*o_dScaledValue = (i_wRawValue / 65535.0) * 10.0;
		strcpy(o_cUnit,"V");
			break;

		case _4_TO_20_MA:
		*o_dScaledValue = 4.0 + (i_wRawValue / 65535.0) * 16.0;
		strcpy(o_cUnit,"mA");
			break;

		case ZERO_TO_20_MA:
		*o_dScaledValue = (i_wRawValue / 65535.0) * 20.0;
		strcpy(o_cUnit,"mA");
			break;

		default:  
		strcpy(o_cUnit,"UN");
			break;
	}
}

void EX_SetStartValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wStartValue[g_ChannelNum] = {0};
	wStartValue[0] = 0x1000;	
	wStartValue[1] = 0x2000;		
	wStartValue[2] = 0x3000;		
	wStartValue[3] = 0x4000;		
	wStartValue[4] = 0x5000;			
	wStartValue[5] = 0x6000;		
	wStartValue[6] = 0x7000;			
	wStartValue[7] = 0x8000;

	LONG lSetStartValueResult = AO_SetStartupValues(i_lDriverHandle, i_wSlotID, g_ChannelNum, wStartValue);
	if (ERR_SUCCESS == lSetStartValueResult)
	{
		printf("Succeed to set startup values.\n");	
	}
	else
		printf("Fail to set startup values, error code = %d\n", lSetStartValueResult);
}

void EX_GetStartValue(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo &i_SlotInfo)
{
	WORD wRawStartValues [g_ChannelNum] = {0}; //raw data
	double dScaledValues = 0.0;//scaled value
	WORD wRangeType = 0;
	char cUnit[3] = {0};
	int iCnt = 0;

	LONG lGetStartValueResult = AO_GetStartupValues(i_lDriverHandle, i_wSlotID, g_ChannelNum, wRawStartValues);
	
	if (ERR_SUCCESS == lGetStartValueResult)
	{
		for (iCnt = 0; iCnt < g_ChannelNum; iCnt++)
		{
			wRangeType = *((i_SlotInfo.wChRange) + iCnt); //get range type
			EX_ScaleRawValue(wRangeType, wRawStartValues[iCnt], &dScaledValues, cUnit);//get scale value
			if (strcmp(cUnit,"UN") != 0)
			{
				printf("Channel %d raw data is 0x%04X, scaled value is %.4f %s.\n", iCnt, wRawStartValues[iCnt], dScaledValues,cUnit);
				Sleep(3000);
			}
			else
				printf("Channel %d range is unknown.\n", iCnt);	
		}

	}
	else
		printf("Fail to get startup values, error code = %d\n", lGetStartValueResult);
	
	
}

void EX_SetSafteyValue(LONG i_lDriverHandle, WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wSafteyValue[g_ChannelNum] = {0};
	wSafteyValue[0] = 0xFFFF;	
	wSafteyValue[1] = 0xFFFF;		
	wSafteyValue[2] = 0xFFFF;		
	wSafteyValue[3] = 0xFFFF;		
	wSafteyValue[4] = 0x0000;			
	wSafteyValue[5] = 0x0000;		
	wSafteyValue[6] = 0x0000;			
	wSafteyValue[7] = 0x0000;
	

	LONG lSetSafteyResult = AO_SetSaftyValues(i_lDriverHandle, i_wSlotID, g_ChannelNum, wSafteyValue);
	if (ERR_SUCCESS == lSetSafteyResult)
	{
		printf("Succeed to set saftey values.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set saftey values, error code = %d\n", lSetSafteyResult);
}

void EX_GetSafetyValues(LONG i_lDriverHandle,WORD i_wSlotID,struct SlotInfo &i_SlotInfo)
{
	WORD wRawSafetyValues [g_ChannelNum] = {0}; //raw data
	double dScaledValues = 0.0;//scaled value
	WORD wRangeType = 0;
	char cUnit[3] = {0};
	int iCnt = 0;

	LONG lGetSafetyValueResult = AO_GetSaftyValues(i_lDriverHandle, i_wSlotID, g_ChannelNum, wRawSafetyValues);
	
	if (ERR_SUCCESS == lGetSafetyValueResult)
	{
		for (iCnt = 0; iCnt < g_ChannelNum; iCnt++)
		{
			wRangeType = *((i_SlotInfo.wChRange) + iCnt); //get range type
			EX_ScaleRawValue(wRangeType, wRawSafetyValues[iCnt], &dScaledValues, cUnit);//get scale value
			if (strcmp(cUnit,"UN") != 0)
			{
				printf("The safety value of channel %d is %.4f %s.\n", iCnt, dScaledValues, cUnit);
				Sleep(1000);
			}
			else
				printf("Channel %d range is unknown.\n", iCnt);	
		}

	}
	else
		printf("Fail to get safety values, error code = %d\n", lGetSafetyValueResult);	
	
}

void EX_SetValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wChannel = 7; //the channel ID from 0 to 7 	
	WORD wSetValue = 0xFFFF; // AO value to be set
	

	LONG lSetValueResult = AO_SetValue(i_lDriverHandle,i_wSlotID,wChannel,wSetValue);
	if (ERR_SUCCESS == lSetValueResult)
	{
		printf("Succeed to set the value of channel %d.\n",wChannel);
		Sleep(3000);
	}
	else
		printf("Fail to set single channel value, error code = %d\n", lSetValueResult);	
}
void EX_SetMultiValue(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wValue[g_ChannelNum] = {0};
	wValue[0] = 0xFFFF;	
	wValue[1] = 0xFFFF;		
	wValue[2] = 0xFFFF;		
	wValue[3] = 0xFFFF;		
	wValue[4] = 0xFFFF;			
	wValue[5] = 0xFFFF;		
	wValue[6] = 0xFFFF;			
	wValue[7] = 0xFFFF;
	DWORD dwMask = 0xFFFF; //the channels mask. If the bit is 1, it means that the channel must change value.
	

	LONG lSetValuesResult = AO_SetValues(i_lDriverHandle, i_wSlotID, dwMask, wValue);
	if (ERR_SUCCESS == lSetValuesResult)
	{
		printf("Succeed to set multiple channel values.\n");
		Sleep(1000);
	}
	else
		printf("Fail to set multiple channel values, error code = %d\n", lSetValuesResult);

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
		printf("Fail to get the single channel value, error code = %d\n", lGetValueResult);


}
void EX_GetMultiValue(LONG i_lDriverHandle, WORD i_wSlotID, struct SlotInfo &i_SlotInfo)
{
	WORD wRawValue[g_ChannelNum] = {0}; //raw data
	double dScaledValue = 0.0;//scaled value
	WORD wRangeType = 0;
	char cUnit[3] = {0};
	int iCnt = 0;

	LONG lGetMultiValueResult = AIO_GetValues(i_lDriverHandle,i_wSlotID,wRawValue); //get raw value
	if (ERR_SUCCESS == lGetMultiValueResult)	
	{
		for (iCnt =0; iCnt < g_ChannelNum ; iCnt++)
		{
			wRangeType = *(i_SlotInfo.wChRange + iCnt); //get range type
			EX_ScaleRawValue(wRangeType, wRawValue[iCnt], &dScaledValue,cUnit);//get scale value
			if (strcmp(cUnit,"UN") != 0)
			{
				printf("Channel %d raw data is 0x%04X, scaled value is %.4f %s.\n", iCnt, wRawValue[iCnt], dScaledValue,cUnit);
				Sleep(3000);
			}
			else
				printf("Channel %d range is unknown.\n", iCnt);		
		}
	}
	else
		printf("Fail to get value, error code = %d\n", lGetMultiValueResult);

}

void EX_BufferValues(LONG i_lDriverHandle,WORD i_wSlotID)
{
	//==============================
	// user can set parameters below
	//==============================
	WORD wValue[g_ChannelNum]={0};
	wValue[0] = 0x5555;	
	wValue[1] = 0x5555;		
	wValue[2] = 0x5555;		
	wValue[3] = 0x5555;		
	wValue[4] = 0x5555;			
	wValue[5] = 0x5555;		
	wValue[6] = 0x5555;			
	wValue[7] = 0x5555;
	DWORD dwMask = 0xFFFF; //the channels mask. If the bit is 1, it means that the channel must change value.
	
	LONG lBufValuesResult = AO_BufValues(i_lDriverHandle,i_wSlotID,dwMask,wValue);
	if (ERR_SUCCESS == lBufValuesResult)
	{
		printf("Succeed to buffer values.\n");
		Sleep(1000);
	}
	else
		printf("Fail to buffer values, error code = %d\n", lBufValuesResult);

}

void EX_FlushBuffer(LONG i_lDriverHandle,WORD i_wSlotID)
{
	DWORD dwMask = 0x01<< i_wSlotID; //the mask for flush enable slot 
	LONG lFlushBufResult = OUT_FlushBufValues(i_lDriverHandle,dwMask);
	if (ERR_SUCCESS ==lFlushBufResult)
	{
		printf("Succeed to flush buffers.\n");
		Sleep(3000);
	}
	else
		printf("Fail to flush buffers, error code = %d\n", lFlushBufResult);
}

int _tmain(int argc, char* argv[])
{
	//==============================
	// user can set SlotID below
	//==============================
	WORD wSlotID = 3; //the slot ID which is ranged from 0 to 31

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
        
		//the moduleID for Apax-5028 is 0x50280000
		//dHiWord is 5028, dLoWord is 0000
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

	//set AO startup values example
	if (bAdvStatus)
	{
		printf("\n*** Set AO startup values ***\n");
		EX_SetStartValue(lDriverHandle, wSlotID);
	}

	//get AO startup values example
	if (bAdvStatus)
	{
		printf("\n*** Get AO startup values ***\n");
		EX_GetStartValue(lDriverHandle, wSlotID,sSlotInfo);
	}


	//set the safety value enabled status 
	if (bAdvStatus)
	{
		printf("\n*** Set AO safety value status ***\n");
		EX_SetSafetyEnable(lDriverHandle, wSlotID);
	}


	//set the safety values
	if (bAdvStatus)
	{
		printf("\n*** Set AO safety values ***\n");
		EX_SetSafteyValue(lDriverHandle, wSlotID);
	}

	//get the safety values
	if (bAdvStatus)
	{
		printf("\n*** Get AO safety values ***\n");
		EX_GetSafetyValues(lDriverHandle, wSlotID,sSlotInfo);
	}

	//get AO channel status example 
	if (bAdvStatus)
	{
		printf("\n*** Get AO channel status ***\n");
		EX_GetStatus(lDriverHandle, wSlotID);
	}	
	
	//set AO channel ranges example 
	if (bAdvStatus)
	{
		printf("\n*** Set AO channel ranges ***\n");
		EX_SetRange(lDriverHandle, wSlotID);
	}

	//get AO channel ranges example 
	if (bAdvStatus)
	{
		printf("\n*** Get AO channel ranges ***\n");
		EX_GetRange(lDriverHandle, wSlotID, &sSlotInfo);
	}
	
	//set AO single channel value example 
	if (bAdvStatus)
	{
		printf("\n*** Set AO single channel value ***\n");
		EX_SetValue(lDriverHandle, wSlotID);
	}
	
	
	//get AO single channel value example 
	if (bAdvStatus)
	{
		printf("\n*** Get AO single channel value ***\n");
		EX_GetValue(lDriverHandle, wSlotID, sSlotInfo);
	}

	//set AO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Set AO multiple channel values ***\n");
		EX_SetMultiValue(lDriverHandle, wSlotID);
	}
	
	
	//get AO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get AO multiple channel values ***\n");
		EX_GetMultiValue(lDriverHandle, wSlotID, sSlotInfo);
	}

	//another method for setting multiple channel values by calling EX_BufferValues() and EX_FlushBuffer() function.	
	
	//buffer AO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Buffer AO multiple channel values ***\n");
		EX_BufferValues(lDriverHandle, wSlotID);
	}
	
	//flush AO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Flush AO multiple channel values ***\n");
		EX_FlushBuffer(lDriverHandle, wSlotID);
	}

	//get AO multiple channel values example 
	if (bAdvStatus)
	{
		printf("\n*** Get AO multiple channel values ***\n");
		EX_GetMultiValue(lDriverHandle, wSlotID,sSlotInfo);
	}

	//close library
	EX_CloseLib(&lDriverHandle);
	printf("\n/***        END         ***/ \n\n");
	
	return 0;
}

