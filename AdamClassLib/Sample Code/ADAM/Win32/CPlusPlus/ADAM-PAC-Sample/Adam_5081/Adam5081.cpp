// Adam5081.cpp : Defines the entry point for the application.
//
#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>
//////////////////////////////////////////////
//Take ADAM-5081 for example
//Slot : 6
//Get/Set Range, GetValues
 
//Note: You have to change the slot index
//////////////////////////////slot index
USHORT iSlot = 6; 
//////////////////////////////////////// 

int m_iChTotal = 8;		//For 5081
//////////////////////////////////////////////

int ADV_SUCCESS = 0;

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

void GetAdam5081Range(BYTE i_byRange)
{
	if (i_byRange == 0)						
		printf("Bi_Direction\n");
	else if (i_byRange == 1)				
		printf("Up_Down\n");
	else if (i_byRange == 2)				
		printf("Up\n");
	else if (i_byRange == 3)				
		printf("Frequency\n");
	else if (i_byRange == 4)				
		printf("AB1X\n");
	else if (i_byRange == 5)				
		printf("AB2X\n");
	else if (i_byRange == 6)				
		printf("AB4X\n");
	else 
		printf("Unknown\n");
}

void GetRange()
{
	BYTE byRange;

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
	{
		if(CNT_GetRange(myprocHandle, iSlot, iChannel, &byRange) == ADV_SUCCESS)
		{
			printf("Counter Mode:");
			GetAdam5081Range(byRange);
		}
		else
			printf("CNT_GetRange(ch%d) failed.\n", iChannel);
	}
}

void GetValues()
{
	ULONG lVal;

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)	
	{
		if(CNT_GetValue(myprocHandle, iSlot, iChannel, &lVal) == ADV_SUCCESS)
		{
			printf("Cnt%d : %ld\n", iChannel, lVal);
		}
		else
		{
			printf("CNT_GetValue(ch%d) failed.\n", iChannel);
		}
	}
}

void SetRange()
{
	BYTE byRange;
	byRange = 2;	//for 5081 Up mode

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)	
	{
		if(CNT_SetRange(myprocHandle, iSlot, iChannel, byRange) == ADV_SUCCESS)
			printf("CNT_SetRange(ch%d) done.\n", iChannel);
		else
			printf("CNT_SetRange failed.\n");
	}
}

int main(int argc, char* argv[])
{
	int iRet;
	bool bValue = false;
	bool setValue = true;

 	printf("/*** Adam5081 Sample ***/ \n");

	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
	{
		//Get current channel status
		GetRange();
		GetValues();

		//Set channel range
		SetRange();

		//Check result
		GetRange();
		GetValues();
	}
	else
		printf("OpenLib(%d) failed.\n", iRet);

	CloseLib();
	printf("/***        END         ***/ \n");
	getchar();
	return 0;
}
