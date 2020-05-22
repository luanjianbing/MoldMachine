// Adam5013_17_18.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "ADSDIO.h"

//////////////////////////////////////////////
//2008/04/08 Tim.Lin
//Take ADAM-5017 for example
//Slot : 3
//Get/Set Range, Get/Set ChannelEnable, GetValues

//Note: You have mark the module definition or change slot index
///////////////////////module definition
#define ADAM5013
//#define ADAM5017
//#define ADAM5018 
////////////////////////////////////////

//////////////////////////////slot index
USHORT iSlot = 3; 
////////////////////////////////////////

#if defined ADAM5013
	int m_iChTotal = 3;	//For 5013
#elif defined ADAM5017
	int m_iChTotal = 8;	//For 5017
#elif defined ADAM5018
	int m_iChTotal = 7;	//For 5018
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

void GetAdam5013Range(BYTE i_byRange)
{
	if (i_byRange == 32)					//Pt385_Neg100To100
		printf("Pt385 -100~100 'C\n");
	else if (i_byRange == 33)				//Pt385_0To100
		printf("Pt385 0~100 'C\n");
	else if (i_byRange == 34)				//Pt385_0To200
		printf("Pt385 0~200 'C\n");
	else if (i_byRange == 35)				//Pt385_0To600
		printf("Pt385 0~600 'C\n");
	else if (i_byRange == 36)				//Pt392_Neg100To100
		printf("Pt392 -100~100 'C\n");
	else if (i_byRange == 37)				//Pt392_0To100
		printf("Pt392 0~100 'C\n");
	else if (i_byRange == 38)				//Pt392_0To200
		printf("Pt392 0~200 'C\n");
	else if (i_byRange == 39)				//Pt392_0To600
		printf("Pt392 0~600 'C\n");
	else if (i_byRange == 40)				//Ni518_Neg80To100
		printf("Ni518 -80~100 'C\n");
	else if (i_byRange == 41)				//Ni518_0To100
		printf("Ni518 0~100 'C\n");
	else 
		printf("Unknown\n");
}

void GetAdam5017Range(BYTE i_byRange)
{
	if (i_byRange == 8)						//V_Neg10To10
		printf("+/- 10 V\n");
	else if (i_byRange == 9)				//V_Neg5To5
		printf("+/- 5 V\n");
	else if (i_byRange == 10)				//V_Neg1To1
		printf("+/- 1 V\n");
	else if (i_byRange == 11)				//mV_Neg500To500
		printf("+/- 500 mV\n");
	else if (i_byRange == 12)				//mV_Neg150To150
		printf("+/- 150 mV\n");
	else if (i_byRange == 13)				//mA_Neg20To20
		printf("+/- 20 mA\n");
	else if (i_byRange == 7)				//mA_4To20
		printf("4~20 mA\n");
	else
		printf("Unknown\n");
}

void GetAdam5018Range(BYTE i_byRange)
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

	if(AI_GetInputRange(myprocHandle, iSlot, 0, &byRange) == ADV_SUCCESS)
	{
		printf("InputRange:");
#if defined ADAM5013
		GetAdam5013Range(byRange);
#elif defined ADAM5017
		GetAdam5017Range(byRange);
#elif defined ADAM5018
		GetAdam5018Range(byRange);
#endif
	}
	else
		printf("AI_GetInputRange failed.\n");
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
#if defined ADAM5013
		byRange = 32;	//for 5013	Pt385_Neg100To100
#elif defined ADAM5017
		byRange = 8;	//for 5017	V_Neg10To10
#elif defined ADAM5018
		byRange = 0;	//for 5018	mV_Neg15To15
#endif

	if(AI_SetInputRange(myprocHandle, iSlot, 0, byRange) == ADV_SUCCESS)
		printf("AI_SetInputRange done.\n");
	else
		printf("AI_SetInputRange failed.\n");
}

void SetChannelEnable()
{
	BOOL* bChEnabled = new BOOL[m_iChTotal];
	for(int iChannel = 0;iChannel<m_iChTotal;iChannel++)
		bChEnabled[iChannel] = true;

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

 	printf("/*** Adam5013_17_18 Sample ***/ \n");

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

