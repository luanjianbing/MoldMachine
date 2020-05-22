#ifndef __AdsInclude_TRANINFO__
#define __AdsInclude_TRANINFO__
// #############################################################################
// *****************************************************************************
//                  Copyright (c) 2003, Advantech Automation Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//               INFORMATION WHICH IS THE PROPERTY OF ADVANTECH AUTOMATION CORP.
//
//    ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//               ADVANTECH AUTOMATION CORP., IS STRICTLY PROHIBITED.
// *****************************************************************************
// #############################################################################
//
// File:    TRANINFO.H
// Author:  Mickle.ding
// Created: 9/17/2003
//
// Description:  Transfer data between the Kernel mode and the User mode.
// -----------------------------------------------------------------------------

#define ADS_WATCHDOG_CHIPSET_UNKNOWN   0        // Unknown Watchodg type
#define ADS_WATCHDOG_CHIPSET_SOM443    1        // Original SOM4472 Watchodg
#define ADS_WATCHDOG_CHIPSET_W83977AF  2        // Original SOM2353 Watchdog
#define ADS_WATCHDOG_CHIPSET_W83627HF  3        // Winbond W83627HF
#define ADS_WATCHDOG_CHIPSET_SOM5780   4        // Original SOM5780 Watchdog
//Add by liukun
#define ADS_WATCHDOG_CHIPSET_SCH3114   5        // SCH311X: 3112,3114,3116
#define ADS_WATCHDOG_CHIPSET_NCT6776F  6        // Nuvoton NCT6776F
#define ADS_WATCHDOG_CHIPSET_EC        7        // EC Watchodg

#ifndef WORD
  typedef unsigned short      WORD;
#endif

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
typedef struct _WatchdogStatus
{
   BOOLEAN           m_bLogEvent;             // Log Event into system Event Base
   BOOLEAN           m_bEnabled;              // Watchdog Enabled or Disabled
   ULONG             m_ulTimerSpanIndex;      // The watchdog timer span index
   ULONG             m_ulTimerSpanValue;      // The watchdog timer span value
   BOOLEAN           m_bWatchSystem;          // Watch the system or an application
   BOOLEAN           m_bReboot;               // Reboot the machine now
   BOOLEAN           m_bInitialized;          // Watchdog has been initialized
   BOOLEAN           m_bDeInitialized;        // Watch dog has been deinitialized
   ULONG             m_ulChipsetType;         // SOM Board Number of the watchdog
   LARGE_INTEGER     m_llSysCounter;          // Watchdog Start up time
} WatchdogStatus, *LPWatchdogStatus;

#endif // __AdsInclude_TRANINFO__
