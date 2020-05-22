// Adam50XXDIO.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "ADSDIO.h"

//////////////////////////////////////////////
//2008/04/08 Tim.Lin
//Take ADAM-5056 for example
//Slot : 0
//Reverse channel0 value 
USHORT iSlot = 0; 
USHORT iChannel = 0;
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
	ULONG dVal;
	bool bValue = false;
	bool setValue = true;

 	printf("/*** Adam50XXDIO Sample ***/ \n");

	iRet = OpenLib();
	if(iRet == ADV_SUCCESS)
	{
		//Get dio module values
		if((DI_GetValues(myprocHandle, iSlot, &dVal)) == ADV_SUCCESS)
		{
			printf("GetValues: %lx\n", dVal);
			bValue = ((dVal & (0x00000001<<iChannel)) > 0);
			if(bValue)
			{
				printf("Ch%d:True\n", iChannel);
				setValue = false;
			}
			else
			{
				printf("Ch%d:False\n", iChannel);
				setValue = true;
			}

			//Set DO value 
			if((DO_SetValue(myprocHandle, iSlot, iChannel, setValue) == ADV_SUCCESS))
			{
				printf("SetValue done.\n", dVal);
				
				//Check value
				if((DI_GetValues(myprocHandle, iSlot, &dVal)) == ADV_SUCCESS)
				{
					printf("GetValues: %lx\n", dVal);
					bValue = ((dVal & (0x00000001<<iChannel)) > 0);
					if(bValue)
						printf("Ch%d:True\n", iChannel);
					else
						printf("Ch%d:False\n", iChannel);
				}
			}
			else
				printf("SetValue() failed.");
		}
		else
			printf("GetValues() failed.");
	}
	else
		printf("OpenLib(%d) failed.\n", iRet);

	CloseLib();
	printf("/***        END         ***/ \n");
	getchar();
	return 0;
}

