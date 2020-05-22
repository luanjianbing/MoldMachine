// BackupSystem.cpp : Defines the entry point for the console application.

// 1. Use an Ethernet switch and Ethernet cables to connect two APAX-controllers and APAX-5000 I/O modules.
//    (Refer to setup.jpg)
//
//    NOTE: The switch for backup system should be a local network, NOT to connect with other external network(such as enterprise network, Internet)       
// 
// 2. Use Advantech APAX.NET Utility to configured controller ID
//    Execute Utility and click the Enable check box to enable backup function in the "Backup System Setting" area.
//    Define the controller ID for the APAX-controllers by the controller ID selector. (The ID can only be "0" or "1")
//    Please set different ID for two APAX-controllers. After completing the configuration, click the "Apply" button to save the configuration.
//    (Refer to config.jpg) 
//
//	  NOTE: The system will automatically decide which one is the master controller.
//
// 3. Power cycle the whole system to run the backup functionality.
//
// 4. Complier this sample code and run the execution file ( BackupSystem.exe ) in two APAX-controllers.
//    The program will print the current status on console. For the master controller, it shows "This controller is running as Master" and executes the control function(EX_IOModuleControl)
//    For the slave controller, it shows "This controller is running as Slave" and be put on standby. 
//    Once the master controller crash or disconnect with Ethernet switch, the slave controller will replace master immediately and continue to execute the control function.   
#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include "ADSDIO.h"
#include "AdvAdsdioGlobal.h"

bool EX_OpenLib(LONG *o_lDriverHandle)
{
	DWORD dVersion = 0; //the library version 

	//initialize the APAX driver
	if(ERR_SUCCESS != ADAMDrvOpen(o_lDriverHandle))
		return false;
		
	if (ERR_SUCCESS == SYS_GetVersion(*o_lDriverHandle, &dVersion) )
		printf("ADSDIO.lib version is %x\n\n", dVersion);
	else
		return false;
		
	return true;	
}

void EX_CloseLib(LONG *o_lDriverHandle)
{
	//terminate the APAX driver
	if(NULL != o_lDriverHandle)
	{
		ADAMDrvClose(o_lDriverHandle);
		o_lDriverHandle = NULL;
	}
}

void EX_IOModuleControl(LONG i_lDriverHandle)
{
	//printf("start to run IO Module Control\n");

	//Here, we take APAX-5060 as example and set DO channels cyclically	
	/*
	int idx = 0;
	WORD wSlotID = 0;
	WORD wChNum = 12; //the totoal DO channel number of APAX-5060 
	DWORD dwValue = 0;
	BOOL lSetValueResult = 0;
	for(idx = 0;idx < wChNum;idx++)
	{
		dwValue = (1 << idx);
		lSetValueResult = DO_SetValues(i_lDriverHandle, wSlotID, 0, dwValue);
		if (ERR_SUCCESS != lSetValueResult)
		{
			return;
		}
		Sleep(100);		
	}
	*/
}
int _tmain(int argc, _TCHAR* argv[])
{
	LONG lDriverHandle = NULL;	//driver handler
	WORD wMaster = 0;			//1: master , 0: slave
	int iStatus = -1;           //record system status 
	WORD wDelayCnt = 0;         //interval delay counter
		
	if ( EX_OpenLib(&lDriverHandle))
	{
		// Enable the system to run heartbeat 
		if(ERR_SUCCESS != SYS_SetHeartbeatRun(lDriverHandle, TRUE))
		{
			printf("SYS_SetHeartbeatRun failed!\n");
			return 0;
		}
		// Polling the system status (master or slave)
		while(1)
		{		
			// Get global active status	
			if( ERR_SUCCESS !=  SYS_GetGlobalActive(lDriverHandle, &wMaster))
			{
				printf("SYS_GetGlobalActive failed!\n");
				return 0;
			}
			
			if(wMaster)
			{
				//the controller is running as master 
				if(iStatus != wMaster)
				{
					printf("This controller is running as Master\n");
					iStatus = wMaster;
				}
						
				// refresh Global heartbeat
				// NOTE: You have to refresh global heartbeat in less than 500 milliseconds. Otherwise, the master will be replace by backup system.
				if( ERR_SUCCESS != SYS_SetGlobalHeartbeat(lDriverHandle))
				{
					printf("SYS_SetGlobalHeartbeat() failed!\n");
					return 0;
				}  
				//================ Please replace EX_IOModuleControl with your control function ================
				if(wDelayCnt > 30) //execute to read/write IO in 30 loops
				{
					EX_IOModuleControl(lDriverHandle);
					wDelayCnt = 0;
				}

			}
			else
			{
				//the controller is running as slave
				if(iStatus != wMaster)
				{
					printf("This controller is running as Slave\n");
					iStatus = wMaster;
				}	
			}
			wDelayCnt++;
			Sleep(1);
		}
	}
	else
	{
		printf("Fail to load ADSDIO library.\n");
	}
	return 0;
}

