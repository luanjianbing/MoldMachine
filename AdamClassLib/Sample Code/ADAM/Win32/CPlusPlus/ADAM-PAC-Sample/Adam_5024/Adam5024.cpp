// Adam5024.cpp : Defines the entry point for the application.
//
#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>

//////////////////////////////////////////////
//Take ADAM-5024 for example
//Slot : 5

//Note: You have to change the slot index
//////////////////////////////slot index
USHORT iSlot = 5; 
//////////////////////////////////////// 

int m_iChTotal = 4;
//////////////////////////////////////////////

int ADV_SUCCESS = 0;
//BYTE mA_0To20 = 0x30;	
//BYTE mA_4To20 = 0x31;	
//BYTE V_0To10  = 0x32;	

LONG myprocHandle;

int OpenLib()
{
	myprocHandle = NULL;

	//OpenDeviceLib
	if(ADAMDrvOpen(&myprocHandle) == ADV_SUCCESS)
		return ADV_SUCCESS;
	else
		return -99;
}

void CloseLib()
{
	//Close device library
	if(myprocHandle!=NULL)
		ADAMDrvClose(&myprocHandle);
}

void GetValueRanges()
{
	FLOAT fVal;
	BYTE byRange;

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
	{
		if(AO_GetValue(myprocHandle, iSlot, iChannel, &fVal) == ADV_SUCCESS)
		{
			printf("AO%d : %f\n", iChannel, fVal);
			
			if(AO_GetOutputRange(myprocHandle, iSlot, iChannel, &byRange) == ADV_SUCCESS)
			{

				if(byRange == mA_0To20)
					printf("Range%d : %s\n", iChannel, "0~20mA");
				else if(byRange == mA_4To20)
					printf("Range%d : %s\n", iChannel, "4~20mA");
				else if(byRange == V_0To10)
					printf("Range%d : %s\n", iChannel, "0~10V");
				else
					printf("Range%d : %s(%X)\n", iChannel, "Unknown", byRange);
			}
			else
				printf("AO_GetOutputRange(ch%d) failed.\n", iChannel);
		}
		else
		{
			printf("AO_GetValue(ch%d) failed.\n", iChannel);
		}
	}
}

void SetValueRanges()
{
	FLOAT fVal;

	//BYTE byRange = mA_0To20;
	//BYTE byRange = mA_4To20;
	BYTE byRange = V_0To10;

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
	{
		if(AO_SetOutputRange(myprocHandle, iSlot, iChannel, byRange) == ADV_SUCCESS)
		{
			fVal = (float)(iChannel * 2);
			if(AO_SetValue(myprocHandle, iSlot, iChannel, fVal) == ADV_SUCCESS)
			{
				printf("Set AO%d: %f\n", iChannel, fVal);
			}
			else
			{
				printf("AO_SetValue(ch%d) failed.\n", iChannel);
			}
		}
		else
			printf("AO_SetOutputRange(ch%d) failed.\n", iChannel);

	}
}

int main(int argc, char* argv[])
{
	int iRet;
 	printf("/*** Adam5024 Sample ***/ \n");

	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
	{
		printf("Get Current Status.\n");
		printf("========\n");
		GetValueRanges();
		printf("\n");
		
		//Change AO ranges and set AO values
		SetValueRanges();
		printf("\n");

		//Check result
		printf("Check Result.\n");
		printf("========\n");
		GetValueRanges();
		printf("\n");
	}
	else
		printf("OpenLib(%d) failed.\n", iRet);

	CloseLib();
	printf("/***        END         ***/ \n");
	getchar();
	return 0;
}



