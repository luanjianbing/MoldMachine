#include "stdafx.h"
#include <windows.h>
#include <conio.h>
#include <stdio.h>

#include "Interactive.h"
#include "WatchdogCmd.h"
#include "WatchdogGet.h"
#include "WatchdogHlp.h"
#include "WatchdogSet.h"



// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
LONG	g_lDeviceHandle;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
int main (int argumentCount, char *argumentVector[] )
{
	printf("/*** Watchdog Sample ***/ \n");

   // Initialize watchdog
   LONG status = WDT_Init( &g_lDeviceHandle );
   if ( status != ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Can not Initialize Advantech Watchdog Device!\n" );
      return 1;
   }
   else
   {
      printf( "Initialize Advantech Watchdog Succeed!\n\n" );
   } 
   if ( argumentCount == 1 )
   {
      g_RunMode = INTERACTIVE_MODE;
      InterActive_Main();
   }
   else
   {
      g_RunMode = NON_INTERACTIVE_MODE;
      // Skip the file name in the command line
      argumentVector++;
      argumentCount--;

      // Parse user command line 
      ParseCommandLine( 
         argumentCount, 
         argumentVector, 
         g_CmdOperation,
         g_WatchMode, 
         g_dwTimerSpanIndex,
         g_bLogEvent ); 

      // Actual user operations
      ProcessCommandLine( 
         g_CmdOperation, 
         g_WatchMode, 
         g_dwTimerSpanIndex,
         g_bLogEvent );
   }

   return 0;
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void ProcessCommandLine(
   WDT_Operation  operation,         // Operation type
   WatchMode      mode,              // Watch Mode
   DWORD          index,             // Timer Span Index
   BOOL           log )
{
  switch( operation )
   {
   case WDT_ENABLE:
      {
         Watchdog_Enable();
      }
      break;
      
   case WDT_DISABLE:
      {
         Watchdog_Disable();
      }
      break;

   case WDT_REBOOT:
      {
         Watchdog_Reboot();
      }
      break;

   case WDT_STROBE:
      {
         Watchdog_Strobe();
      }
      break;

   case WDT_DEINIT_WATCHDOG:
      {
         Watchdog_DeInit();
      }
      break;

   case WDT_HELP_ALL:
      {
         Watchdog_Help_All();
      }
      break;

   case WDT_SET_TIMERSPAN:
      {
         Watchdog_SetTimerSpan( index );
      }
      break;

   case WDT_SET_WATCHMODE:
      {
         Watchdog_SetMode( mode );
      }
      break;

   case WDT_SET_LOGSTATUS:
      {
         Watchdog_SetLogStatus( log );
      }
      break;

   case WDT_GET_TIMERSPAN:
      {
         Watchdog_GetTimerSpan( index );
      }
      break;

   case WDT_GET_WATCHMODE:
      {
         Watchdog_GetMode( mode );
      }
      break;

   case WDT_GET_LOGSTATUS:
      {
         Watchdog_GetLogStatus( log );
      }
      break;

   case WDT_HELP_SET:
      {
         Watchdog_Help_Set();
      }
      break;

   case WDT_HELP_GET:
      {
         Watchdog_Help_Get();
      }
      break;
   
   case WDT_HELP_SET_TIMER:
      {
         Watchdog_Help_Set_TimerSpan();
      }
      break;

   case WDT_HELP_SET_MODE:
      {
         Watchdog_Help_Set_Mode();
      }
      break;

   case WDT_HELP_SET_LOG:
      {
         Watchdog_Help_Set_LogStatus();
      }
      break;

   default:
      {
         printf( "\nInvalid Operation Mode\n" );
      }
   }
}





















