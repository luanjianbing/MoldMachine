#ifndef AdsWatchdog_INC
#   define AdsWatchdog_INC

// #############################################################################
// *****************************************************************************
//                  Copyright (c) 2003, Advantech Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//               INFORMATION WHICH IS THE PROPERTY OF ADVANTECH CORP.
//
//    ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//               ADVANTECH CORP., IS STRICTLY PROHIBITED.
// *****************************************************************************
// #############################################################################
//
// File:    AdsWatchdog.h
// Author:  Mickle.ding
// Created: 7/9/2003
//
// Description:  Define the class AdsWatchdog
// -----------------------------------------------------------------------------

#include "Tchar.h"
#include "wtypes.h"

#ifdef __AMD64
typedef LONGLONG _LONG;
#else
typedef LONG _LONG;
#endif // __AMD64

#define ADS_API __declspec(dllexport)

#define ADS_WATCHDOG_CHIPSET_UNKNOWN	0        // Unknown Watchdog type
#define ADS_WATCHDOG_CHIPSET_SOM443		1        // Original SOM4472 Watchdog
#define ADS_WATCHDOG_CHIPSET_W83977AF	2        // Original SOM2353 Watchdog
#define ADS_WATCHDOG_CHIPSET_W83627HF	3        // Winbond W83627HF
#define ADS_WATCHDOG_CHIPSET_SOM5780	4        // Original SOM5780 Watchdog
//Add by liukun
#define ADS_WATCHDOG_CHIPSET_SCH3114	5        // SCH311X: 3112,3114,3116
#define ADS_WATCHDOG_CHIPSET_NCT6776F	6        // Nuvoton NCT6776F
#define ADS_WATCHDOG_CHIPSET_EC			7        // EC Watchdog

// -----------------------------------------------------------------------------
// DESCRIPTION: The Notification Event for Watchdog status changed
// -----------------------------------------------------------------------------
#define ADS_WATCHDOG_STATUS_CHANGED_EVENT    _T("ADS.Watchdog.Status.Changed")

// -----------------------------------------------------------------------------
// DESCRIPTION: Define Status Code
// -----------------------------------------------------------------------------
#define WDT_SUCCESS                  0
#define WDT_DevErrorCode             500

#define ADS_WATCHDOG_ERROR_SUCCESS           ( WDT_DevErrorCode + 0 ) 
#define ADS_WATCHDOG_ERROR_INITFAILED        ( WDT_DevErrorCode + 1 )
#define ADS_WATCHDOG_ERROR_DEINITFAILED      ( WDT_DevErrorCode + 2 )
#define ADS_WATCHDOG_ERROR_INVALID_HANDLE    ( WDT_DevErrorCode + 3 )
#define ADS_WATCHDOG_ERROR_INVALID_PARAMETER ( WDT_DevErrorCode + 4 )
#define ADS_WATCHDOG_ERROR_WDT_RUNNING       ( WDT_DevErrorCode + 5 )
#define ADS_WATCHDOG_ERROR_WDT_NOTRUNNING    ( WDT_DevErrorCode + 6 )
#define ADS_WATCHDOG_ERROR_WDT_REBOOTTING    ( WDT_DevErrorCode + 7 )
#define ADS_WATCHDOG_ERROR_DEUBG_CODE        ( WDT_DevErrorCode + 1000 )

// -----------------------------------------------------------------------------
// DESCRIPTION: The watch mode of the watchdog
// -----------------------------------------------------------------------------
enum WatchMode { 
   WATCH_MODE_SYSTEM = 0,              // Watch the whole system
   WATCH_MODE_APPLICATION  = 1 };      // Watch a specified application

// -----------------------------------------------------------------------------
// DESCRIPTION: This watchdog type may be extended with out any modification
//    of the application source code
// -----------------------------------------------------------------------------
enum WatchdogType { 
   WATCHDOG_TYPE_UNKNOWN	= ADS_WATCHDOG_CHIPSET_UNKNOWN,
   WATCHDOG_TYPE_W83977AF	= ADS_WATCHDOG_CHIPSET_W83977AF,		// Advantech SOM2353 Watchdog
   WATCHDOG_TYPE_W83627HF	= ADS_WATCHDOG_CHIPSET_W83627HF,		// Winbond W83627HF Watchdog
   WATCHDOG_TYPE_SOM443		= ADS_WATCHDOG_CHIPSET_SOM443,			// Advantech SOM4472 Watchdog
   WATCHDOG_TYPE_SOM5780	= ADS_WATCHDOG_CHIPSET_SOM5780,			// Advantech F75111 (SOM5780) Watchdog
   // Add by Liukun
   WATCHDOG_TYPE_SCH3114	= ADS_WATCHDOG_CHIPSET_SCH3114,			// SCH3114 Watchdog
   WATCHDOG_TYPE_NCT6776F	= ADS_WATCHDOG_CHIPSET_NCT6776F,		// NCT6776F Watchdog
   WATCHDOG_TYPE_EC			= ADS_WATCHDOG_CHIPSET_EC				// EC Watchdog
};  

// -----------------------------------------------------------------------------
// DESCRIPTION: Initialize the watchdog
// -----------------------------------------------------------------------------
LONG ADS_API WDT_Init ( _LONG * o_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: De-Initialize the watchdog
// -----------------------------------------------------------------------------
LONG ADS_API WDT_DeInit ( _LONG * io_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: Enable the watchdog
// -----------------------------------------------------------------------------
LONG ADS_API WDT_Enable ( _LONG i_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: Disable the watchdog
// -----------------------------------------------------------------------------
LONG ADS_API WDT_Disable ( _LONG i_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: Set the watchdog watch mode
// -----------------------------------------------------------------------------
LONG ADS_API WDT_SetMode( _LONG i_hHandle, WatchMode i_WatchMode );

// -----------------------------------------------------------------------------
// DESCRIPTION: Get the watchdog watch mode
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetMode ( _LONG i_hHandle, WatchMode * o_pWatchMode );

// -----------------------------------------------------------------------------
// DESCRIPTION: Set the watchdog timer span index
// -----------------------------------------------------------------------------
LONG ADS_API WDT_SetTimerSpan ( _LONG i_hHandle, DWORD i_dwIndex );

// -----------------------------------------------------------------------------
// DESCRIPTION: Get the watchdog timer span index
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetTimerSpan ( 
   _LONG    i_hHandle,
   DWORD * o_pIndex, 
   DWORD * o_pValue );

// -----------------------------------------------------------------------------
// DESCRIPTION: Reboot the machine by the watchdog
// -----------------------------------------------------------------------------
LONG ADS_API WDT_Reboot ( _LONG i_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
LONG ADS_API WDT_IsEnabled( _LONG i_hHandle, BOOL * o_bEnabled );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
LONG ADS_API WDT_LogEvent( _LONG i_hHandle, BOOL i_bLog );


// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
LONG ADS_API WDT_IsLogged( _LONG i_hHandle, BOOL * o_bLogged );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
LONG ADS_API WDT_IsReadyToReboot( _LONG i_hHandle, BOOL * o_bReboot );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetStartupTime ( _LONG i_hHandle, LARGE_INTEGER * o_pSartupTime );

// -----------------------------------------------------------------------------
// DESCRIPTION: Strobe the watchdog once
// -----------------------------------------------------------------------------
LONG ADS_API WDT_Strobe ( _LONG i_hHandle );

// -----------------------------------------------------------------------------
// DESCRIPTION: Set the watchdog type. In current version this function is 
// is reserved for further extension and no implementation is available
// -----------------------------------------------------------------------------
LONG ADS_API WDT_SetType ( _LONG i_hHandle, WatchdogType i_type );

// -----------------------------------------------------------------------------
// DESCRIPTION: Get the watchdog chip type.
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetType ( _LONG i_hHandle, WatchdogType * o_pType );

// -----------------------------------------------------------------------------
// DESCRIPTION: Get the description of the specified timer span index.
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetTimerSpanDescription ( 
   _LONG i_hHandle,
   DWORD i_dwIndex, 
   LPTSTR o_pDescription );

// -----------------------------------------------------------------------------
// DESCRIPTION: Get the error messsage of a specified error code.
// -----------------------------------------------------------------------------
LONG ADS_API WDT_GetErrMsg ( 
   _LONG i_hHandle, 
   LONG i_lErrCode, 
   LPTSTR o_pErrMsg );

#endif // #ifndef AdsWatchdog_INC
