// Description:  Define the class ParseCmdLine
// -----------------------------------------------------------------------------

#include "AdsWatchdogUtil.h"

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
WDT_Operation  g_CmdOperation = WDT_HELP_ALL;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
DWORD          g_dwTimerSpanIndex = 0;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
WatchMode      g_WatchMode = WATCH_MODE_SYSTEM;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
RUN_Mode       g_RunMode;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
BOOL           g_bLogEvent;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
INT ParseCommandLine ( 
   int            & argumentCount,     // Arg count in main
   char           * argumentVector[],  // Arg Vector in main
   WDT_Operation  & operation,         // Operation type
   WatchMode      & mode,              // Watch Mode
   DWORD          & index,             // Timer Span Index
   BOOL           & log )              // Log Event
{
   operation = WDT_HELP_ALL;

   // AdsWatchdog exit
   if ( !_stricmp( *argumentVector, "exit" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_DEINIT_WATCHDOG;
      }
      else
      {
         operation = WDT_HELP_ALL;
      }
   }

   // AdsWatchdogUtil /?
   if ( !_stricmp( *argumentVector, "/?" ) )
   {
      operation = WDT_HELP_ALL;
   }

   // AdsWatchdogUtil Enable
   if ( !_stricmp( *argumentVector, "Enable" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_ENABLE;
      }
      else
      {
         operation = WDT_HELP_ALL;
      }
   }

   // AdsWatchdogUtil Disable
   if ( !_stricmp( *argumentVector, "Disable" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_DISABLE;
      }
      else
      {
         operation = WDT_HELP_ALL;
      }
   }

   // AdsWatchdogUtil Reboot
   if ( !_stricmp( *argumentVector, "Reboot" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_REBOOT;
      }
      else
      {
         operation = WDT_HELP_ALL;
      }
   }

   // AdsWatchdogUtil Strobe
   if ( !_stricmp( *argumentVector, "Strobe" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_STROBE;
      }
      else
      {
         operation = WDT_HELP_ALL;
      }
   }

   //AdsWatchdogUtil Get
   if ( !_stricmp( *argumentVector, "Get" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_HELP_GET;
      }
      else if ( argumentCount == 2 )
      {
         operation = WDT_HELP_GET;
         argumentVector++;
         argumentCount--;
         if ( !_stricmp( *argumentVector, "Timer" ) )
         {
            operation = WDT_GET_TIMERSPAN;
         }
         else if ( !_stricmp( *argumentVector, "Mode" ) )
         {
            operation = WDT_GET_WATCHMODE;
         }
         else if ( !_tcsicmp( *argumentVector, TEXT( "Log" ) ) )
         {
            operation = WDT_GET_LOGSTATUS;
         }
      }
      else
      {
         operation = WDT_HELP_GET;
      }
   }

   // AdsWatchdogUtil Set
   if ( !_stricmp( *argumentVector, "Set" ) )
   {
      if ( argumentCount == 1 )
      {
         operation = WDT_HELP_SET;
      }
      else if ( argumentCount == 2 )
      {
         operation = WDT_HELP_SET;
         argumentVector++;
         argumentCount--;

         if ( !_stricmp( *argumentVector, "Timer" ) )
         {
            operation = WDT_HELP_SET_TIMER;
         }
         else if ( !_stricmp( *argumentVector, "Mode" ) )
         {
            operation = WDT_HELP_SET_MODE;
         }
         else if ( !_tcsicmp( *argumentVector, TEXT( "Log" ) ) )
         {
            operation = WDT_HELP_SET_LOG;
         }
      }
      else if ( argumentCount >= 3 )
      {
         operation = WDT_HELP_SET;
         argumentVector++;
         argumentCount--;
         if ( !_stricmp( *argumentVector, "Timer" ) )
         {
            operation = WDT_HELP_SET_TIMER;
            argumentVector++;
            argumentCount--;
            index = atoi( *argumentVector );
            if ( index >=1 && index <= 14 && argumentCount == 1 )
            {
               operation = WDT_SET_TIMERSPAN;
            }
         }
         else if ( !_stricmp( *argumentVector, "Mode" ) )
         {
            operation = WDT_HELP_SET_MODE;
            argumentVector++;
            argumentCount--;
            if ( ( !_stricmp( *argumentVector, "Sys" ) ) 
                   && ( argumentCount == 1 ) )
            {
               mode = WATCH_MODE_SYSTEM;
               operation = WDT_SET_WATCHMODE;
            }
            else if ( !_stricmp( *argumentVector, "App" ) 
               && ( argumentCount == 1 ) )
            {
               mode = WATCH_MODE_APPLICATION;
               operation = WDT_SET_WATCHMODE;
            }
         }
         else if ( !_tcsicmp( *argumentVector, TEXT( "Log" ) ) )
         {
            operation = WDT_HELP_SET_LOG;
            argumentVector++;
            argumentCount--;
            if ( !_tcsicmp( *argumentVector, TEXT( "On" ) ) 
               && ( argumentCount == 1 ) )
            {
               log = TRUE;
               operation = WDT_SET_LOGSTATUS;
            }
            else if ( !_tcsicmp( *argumentVector, TEXT( "Off" ) ) 
               && ( argumentCount == 1 ) )
            {
               log = FALSE;
               operation = WDT_SET_LOGSTATUS;
            }
         }
      }

   }

   return 0;
}
