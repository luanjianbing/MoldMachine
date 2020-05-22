// GetSlotInfo.cpp : Defines the entry point for the application.
//
#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include <string.h>

//Get the slot information of ADAM-5560

#define ADAM5560	1  

#ifdef ADAM5560
	#define ADAM_SLOT_NUM	7
#endif

#ifndef ADAM5560
	#define ADAM_SLOT_NUM	8
#endif

int ADV_SUCCESS = 0;
#define MAX_ID_SIZE 7

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

void EX_GetSlotName(USHORT i_iID, char* i_ch)
{
	if (i_iID == 0x0004)
		sprintf_s(i_ch, MAX_ID_SIZE,"5017");
	else if (i_iID == 0x0005)
		sprintf_s(i_ch, MAX_ID_SIZE, "5018");
	else if (i_iID == 0x0008)
		sprintf_s(i_ch, MAX_ID_SIZE, "5013");
	else if (i_iID == 0x0009)
		sprintf_s(i_ch, MAX_ID_SIZE, "5013");
	else if (i_iID == 0x000C)
		sprintf_s(i_ch, MAX_ID_SIZE, "5017H");
	else if (i_iID == 0x000F)
		sprintf_s(i_ch, MAX_ID_SIZE, "5052");
	else if (i_iID == 0x0010)
		sprintf_s(i_ch, MAX_ID_SIZE, "5050");
	else if (i_iID == 0x0011)
		sprintf_s(i_ch, MAX_ID_SIZE, "5051");
	else if (i_iID == 0x0012)
		sprintf_s(i_ch, MAX_ID_SIZE, "5056");
	else if (i_iID == 0x0013)
		sprintf_s(i_ch, MAX_ID_SIZE, "5068");
	else if (i_iID == 0x0014)
		sprintf_s(i_ch, MAX_ID_SIZE, "5060");
	else if (i_iID == 0x0015)
		sprintf_s(i_ch, MAX_ID_SIZE, "5055");
	else if (i_iID == 0x0017)
		sprintf_s(i_ch, MAX_ID_SIZE, "5017UH");
	else if (i_iID == 0x0018)
		sprintf_s(i_ch, MAX_ID_SIZE, "5024");
	else if (i_iID == 0x001E)
		sprintf_s(i_ch, MAX_ID_SIZE, "5080");
	else if (i_iID == 0x0038)		//5017P/5018P
		sprintf_s(i_ch, MAX_ID_SIZE, "AI");
	else if (i_iID == 0x0069)
		sprintf_s(i_ch, MAX_ID_SIZE, "5069");
	else if (i_iID == 0x0002)
		sprintf_s(i_ch, MAX_ID_SIZE, "5202");
	else if (i_iID == 0x0048)
		sprintf_s(i_ch, MAX_ID_SIZE, "5240");
	else if (i_iID == 0x0001)
		sprintf_s(i_ch, MAX_ID_SIZE, "5081");
	else if (i_iID == 0x0053)
		sprintf_s(i_ch, MAX_ID_SIZE, "5053");
	else if (i_iID == 0x0091)
		sprintf_s(i_ch, MAX_ID_SIZE, "5091");
	else
		sprintf_s(i_ch, MAX_ID_SIZE, "N/A");		//show noModule
}

void EX_GetSlotInfo()
{
	USHORT iSlot = 0;
	USHORT id = NULL;
	char chSlotID[10];
	char byName[8];

	//GetSlotInformation
	for(iSlot = 0; iSlot < ADAM_SLOT_NUM;iSlot++)
	{
		if(SYS_GetModuleID(myprocHandle, iSlot, &id) == ADV_SUCCESS)
		{
			if (id == 0x0038)
			{
				if(SYS_GetModuleName(myprocHandle, iSlot, byName) == ADV_SUCCESS)
				{
					if(byName[0]=='7' && byName[1]=='P')
						sprintf_s(chSlotID, MAX_ID_SIZE, "5017P");
					else if(byName[0]=='8' && byName[1]=='P')
						sprintf_s(chSlotID, MAX_ID_SIZE, "5018P");
					else
						sprintf_s(chSlotID, MAX_ID_SIZE, "AI");
				}
				else
					printf("Slot %d: Failed to get getModuleName.\n", iSlot);
			}
			else
				EX_GetSlotName(id, chSlotID);
			printf("Slot %d: %s\n", iSlot, chSlotID);
		}
		else
		{
			printf("Slot %d: Failed to get.\n", iSlot);
		}
	}
}

int main(int argc, char* argv[])
{
	int iRet;
 	printf("/*** GetSlotInfo Sample ***/ \n");
	
	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
		EX_GetSlotInfo();
	else
		printf("OpenLib(%d) failed.\n", iRet);

	CloseLib();
	printf("/***        END         ***/ \n");
	getchar();
	return 0;
}
