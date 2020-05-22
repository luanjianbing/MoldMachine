// GetSlotInfo.cpp : Defines the entry point for the application.
//

#include "stdafx.h"

//////////////////////////////////////////////
//2008/04/08 Tim.Lin
//Take ADAM-5550 for example
//Get the slot information of ADAM-5550


#define ADAM5550	1  //Note: if you run on ADAM-5560, please mark this definition

#ifdef ADAM5550
	#define ADAM_SLOT_NUM	8
#endif

#ifndef ADAM5550
	#define ADAM_SLOT_NUM	7
#endif

int ADV_SUCCESS = 0;

typedef int (*MYPROC_ADAMDrvOpen)(LONG*);
typedef int (*MYPROC_ADAMDrvClose)(LONG*);
typedef int (*MYPROC_SYS_GetModuleID)(LONG,USHORT,USHORT*);
typedef int (*MYPROC_SYS_GetModuleName)(LONG,USHORT,BYTE*);

MYPROC_ADAMDrvOpen			ProcAdd_ADAMDrvOpen;
MYPROC_ADAMDrvClose			ProcAdd_ADAMDrvClose;
MYPROC_SYS_GetModuleID		ProcAdd_SYS_GetModuleID;
MYPROC_SYS_GetModuleName	ProcAdd_SYS_GetModuleName;

HMODULE libHandle;
LONG myprocHandle;

int OpenLib()
{
	libHandle = NULL;
	myprocHandle = NULL;

	LPCWSTR strLib = _T("ads5550dio.dll");
	LPCWSTR strFcn = _T("");

	libHandle = LoadLibrary(strLib);
	if(NULL == libHandle)
	{
		printf("LoadLibrary() failed.\n");
		return -1;
	}

	strFcn = _T("ADAMDrvOpen");
	ProcAdd_ADAMDrvOpen = (MYPROC_ADAMDrvOpen) GetProcAddress(libHandle, strFcn);
	if(NULL == ProcAdd_ADAMDrvOpen)
		return -2;

	strFcn = _T("SYS_GetModuleID");
	ProcAdd_SYS_GetModuleID = (MYPROC_SYS_GetModuleID) GetProcAddress(libHandle, strFcn); 
	if(NULL == ProcAdd_SYS_GetModuleID)
		return -3;

	strFcn = _T("ADAMDrvClose");
	ProcAdd_ADAMDrvClose = (MYPROC_ADAMDrvClose) GetProcAddress(libHandle, strFcn); 
	if(NULL == ProcAdd_ADAMDrvClose)
		return -4;

	strFcn = _T("SYS_GetModuleName");
	ProcAdd_SYS_GetModuleName = (MYPROC_SYS_GetModuleName) GetProcAddress(libHandle, strFcn); 
	if(NULL == ProcAdd_SYS_GetModuleName)
		return -17;
	//OpenDeviceLib
	if(((ProcAdd_ADAMDrvOpen) (&myprocHandle)) == ADV_SUCCESS)
		return ADV_SUCCESS;
	else
		return -99;
}

void CloseLib()
{
	//Close device library
	if(myprocHandle!=NULL)
		(ProcAdd_ADAMDrvClose) (&myprocHandle);
	if(libHandle!=NULL)
		FreeLibrary(libHandle);
}

void GetSlotName(USHORT i_iID, char* i_ch)
{
	if (i_iID == 0x0004)
		sprintf (i_ch, "5017");
	else if (i_iID == 0x0005)
		sprintf (i_ch, "5018");
	else if (i_iID == 0x0008)
		sprintf (i_ch, "5013");
	else if (i_iID == 0x0009)
		sprintf (i_ch, "5013");
	else if (i_iID == 0x000C)
		sprintf (i_ch, "5017H");
	else if (i_iID == 0x000F)
		sprintf (i_ch, "5052");
	else if (i_iID == 0x0010)
		sprintf (i_ch, "5050");
	else if (i_iID == 0x0011)
		sprintf (i_ch, "5051");
	else if (i_iID == 0x0012)
		sprintf (i_ch, "5056");
	else if (i_iID == 0x0013)
		sprintf (i_ch, "5068");
	else if (i_iID == 0x0014)
		sprintf (i_ch, "5060");
	else if (i_iID == 0x0015)
		sprintf (i_ch, "5055");
	else if (i_iID == 0x0017)
		sprintf (i_ch, "5017UH");
	else if (i_iID == 0x0018)
		sprintf (i_ch, "5024");
	else if (i_iID == 0x001E)
		sprintf (i_ch, "5080");
	else if (i_iID == 0x0038)		//5017P/5018P
		sprintf (i_ch, "AI");
	else if (i_iID == 0x0069)
		sprintf (i_ch, "5069");
	else if (i_iID == 0x0002)
		sprintf (i_ch, "5202");
	else if (i_iID == 0x0048)
		sprintf (i_ch, "5240");
	else if (i_iID == 0x0001)
		sprintf (i_ch, "5081");
	else if (i_iID == 0x0053)
		sprintf (i_ch, "5053");
	else if (i_iID == 0x0091)
		sprintf (i_ch, "5091");
	else
		sprintf (i_ch, "N/A");		//show noModule
}

void GetSlotInfo()
{
	USHORT iSlot = 0;
	USHORT id = NULL;
	char chSlotID[10];
	BYTE byName[8];

	//GetSlotInformation
	for(iSlot=0; iSlot < ADAM_SLOT_NUM;iSlot++)
	{
		if(((ProcAdd_SYS_GetModuleID) (myprocHandle, iSlot, &id)) == ADV_SUCCESS)
		{
			if (id == 0x0038)
			{
				if(((ProcAdd_SYS_GetModuleName) (myprocHandle, iSlot, byName)) == ADV_SUCCESS)
				{
					if(byName[0]=='7' && byName[1]=='P')
						sprintf (chSlotID, "5017P");
					else if(byName[0]=='8' && byName[1]=='P')
						sprintf (chSlotID, "5018P");
					else
						sprintf (chSlotID, "AI");
				}
				else
					printf("Slot %d: Failed to get getModuleName.\n", iSlot);
			}
			else
				GetSlotName(id, chSlotID);
			printf("Slot %d: %s\n", iSlot, chSlotID);
		}
		else
		{
			printf("Slot %d: Failed to get.\n", iSlot);
		}
	}
}

#ifdef WINCE
int _tmain(int argc, char* argv[])
#else
int WINAPI WinMain(	HINSTANCE hInstance,
					HINSTANCE hPrevInstance,
					LPTSTR    lpCmdLine,
					int       nCmdShow)
#endif
{
	int iRet;
 	printf("/*** GetSlotInfo Sample ***/ \n");
	
	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
	{
		GetSlotInfo();
	}
	else
		printf("OpenLib(%d) failed.\n", iRet);

	CloseLib();
	printf("/***        END         ***/ \n");
	getchar();
	return 0;
}
