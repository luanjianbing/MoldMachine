// Adam5017UH.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "ADSDIO.h"

//////////////////////////////////////////////
//2008/04/08 Tim.Lin
//Take ADAM-5017UH for example
//Slot : 4
//Get/Set Range, Get/Set ChannelEnable, GetValues

//Note: You have mark the module definition or change slot index
///////////////////////module definition
#define ADAM5017UH
//#define ADAM5017P
//#define ADAM5018P
////////////////////////////////////////

//////////////////////////////slot index
USHORT iSlot = 4; 
////////////////////////////////////////

#if defined ADAM5017UH
			int m_iChTotal = 8;	//For 5017UH
#elif defined ADAM5017P
			int m_iChTotal = 8; //For 5017+
#elif defined ADAM5018P
			int m_iChTotal = 7;	//For 5018+
#endif
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

void GetAdam5017UHRange(BYTE i_byRange)
{
	if (i_byRange == 0x07)	//mA_4To20
		printf("4~20 mA\n");
	else if (i_byRange == 0x08)//V_Neg10To10
		printf("+/- 10 V\n");
	else if (i_byRange == 0x43)//mV_0To500
		printf("0~500mV\n");
	else if (i_byRange == 0x46)//mA_0To20
		printf("0~20mA\n");
	else if (i_byRange == 0x48)//V_0To10
		printf("0~10V\n");
	else
		printf("Unknown\n");
}

void GetAdam5017PRange(BYTE i_byRange)
{
	if (i_byRange == 0x07)	//mA_4To20
		printf("4~20 mA\n");
	else if (i_byRange == 0x08)//V_Neg10To10
		printf("+/- 10 V\n");
	else if (i_byRange == 0x09)//V_Neg5To5
		printf("+/- 5 V\n");
	else if (i_byRange == 0x0A)//V_Neg1To1
		printf("+/- 1 V\n");
	else if (i_byRange == 0x0B)//mV_Neg500To500
		printf("+/- 500 mV\n");
	else if (i_byRange == 0x0C)//mV_Neg150To150
		printf("+/- 150 mV\n");
	else if (i_byRange == 0x0D)//mA_Neg20To20
		printf("+/- 20 mA\n");
	else if (i_byRange == 0x15)//V_Neg15To15
		printf("+/- 15 V\n");
	else if (i_byRange == 0x48)//V_0To10
		printf("0~10 V\n");
	else if (i_byRange == 0x49)//V_0To5
		printf("0~5 V\n");
	else if (i_byRange == 0x4A)//V_0To1
		printf("0~1 V\n");
	else if (i_byRange == 0x4B)//mV_0To500
		printf("0~500 mV\n");
	else if (i_byRange == 0x4C)//mV_0To150
		printf("0~150 mV\n");
	else if (i_byRange == 0x4D)//mA_0To20
		printf("0~20 mA\n");
	else if (i_byRange == 0x55)//V_0To15
		printf("0~15 V\n");
	else
		printf("Unknown\n");
}

void GetAdam5018PRange(BYTE i_byRange)
{
	if (i_byRange == 0)			//mV_Neg15To15
		printf("+/- 15 mV\n");
	else if (i_byRange == 1)	//mV_Neg50To50
		printf("+/- 50 mV\n");
	else if (i_byRange == 2)	//mV_Neg100To100
		printf("+/- 100 mV\n");
	else if (i_byRange == 3)	//mV_Neg500To500
		printf("+/- 500 mV\n");
	else if (i_byRange == 4)	//V_Neg1To1
		printf("+/- 1 V\n");
	else if (i_byRange == 5)	//V_Neg2AndHalfTo2AndHalf
		printf("+/- 2.5 V\n");
	else if (i_byRange == 6)	//mA_Neg20To20
		printf("+/- 20 mA\n");
	else if (i_byRange == 7)	//mA_4To20
		printf("4~20 mA\n");
	else if (i_byRange == 14)	//Jtype_0To760C
		printf("T/C J type 0~760 'C\n");
	else if (i_byRange == 15)	//Ktype_0To1370C
		printf("T/C K type 0~1370 'C\n");
	else if (i_byRange == 16)	//Ttype_Neg100To400C
		printf("T/C T type -100~400 'C\n");
	else if (i_byRange == 17)	//Etype_0To1000C
		printf("T/C E type 0~1000 'C\n");
	else if (i_byRange == 18)	//Rtype_500To1750C
		printf("T/C R type 500~1750 'C\n");
	else if (i_byRange == 19)	//Stype_500To1750C
		printf("T/C S type 500~1750 'C\n");
	else if (i_byRange == 20)	//Btype_500To1800C
		printf("T/C B type 500~1800 'C\n");
	else
		printf("Unknown\n");
}

void GetRange()
{
	BYTE byRange;
	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
	{
		if(AI_GetInputRange(myprocHandle, iSlot, iChannel, &byRange) == ADV_SUCCESS)
		{
			printf("Range AI%d:", iChannel);
#if defined ADAM5017UH
			GetAdam5017UHRange(byRange);
#elif defined ADAM5017P
			GetAdam5017PRange(byRange);
#elif defined ADAM5018P
			GetAdam5018PRange(byRange);
#endif
		}
		else
			printf("AI_GetInputRange(ch%d) failed.\n", iChannel);
	}
}

void GetValues()
{
	FLOAT* fVal = new FLOAT[m_iChTotal];
	BOOL* bChEnabled = new BOOL[16];

	if(AI_GetChannelEnabled(myprocHandle, iSlot, bChEnabled) == ADV_SUCCESS)
	{
		if(AI_GetValues(myprocHandle, iSlot, fVal) == ADV_SUCCESS)
		{
			for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
			{
				if(bChEnabled[iChannel])
					printf("AI%d : %f\n", iChannel, fVal[iChannel]);
				else
					printf("AI%d : Disable\n", iChannel);
			}
		}
		else
		{
			printf("AI_GetValues failed.\n");
		}
	}
	else
	{
		printf("AI_GetChannelEnabled failed.\n");
	}
}

void SetRange()
{
	BYTE byRange;

#if defined ADAM5017UH
			byRange = 0x08;		//for 5017UH	V_Neg10To10
#elif defined ADAM5017P
			byRange = 0x08;		//for 5017P	    V_Neg10To10
#elif defined ADAM5018P
			byRange = 5;		//for 5018P 	V_Neg2AndHalfTo2AndHalf
#endif

	for(int iChannel=0;iChannel<m_iChTotal;iChannel++)
	{
		if(AI_SetInputRange(myprocHandle, iSlot, iChannel, byRange) != ADV_SUCCESS)
			printf("AI_SetInputRange(ch%d) failed.\n", iChannel);
	}
}

void SetChannelEnable()
{
	BOOL* bChEnabled = new BOOL[m_iChTotal];
	for(int iChannel = 0;iChannel<m_iChTotal;iChannel++)
	{
		if(iChannel%2==0)
			bChEnabled[iChannel] = true;
		else
			bChEnabled[iChannel] = false;
	}

	if(AI_SetChannelEnabled(myprocHandle, iSlot, bChEnabled) == ADV_SUCCESS)
		printf("AI_SetChannelEnabled done.\n");
	else
		printf("AI_SetChannelEnabled failed.\n");
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
	bool bValue = false;
	bool setValue = true;

 	printf("/*** Adam5017UH_17P_18P sample ***/ \n");

	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
	{
		//Get current channel status
		GetRange();
		GetValues();

		//Set channel enable and range
		SetChannelEnable();
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

