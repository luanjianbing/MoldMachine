// Description:  Define the class WatchdogGet
// -----------------------------------------------------------------------------
#include <AdsWatchdog.h>  

extern LONG g_lDeviceHandle;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_GetTimerSpan ( DWORD index )
{
   DWORD value;
   WDT_GetTimerSpan( g_lDeviceHandle, &index, &value );
   
   LPTSTR dispMsg = reinterpret_cast<LPTSTR>( malloc( MAX_PATH ) );
   WDT_GetTimerSpanDescription( g_lDeviceHandle, index, dispMsg );

   printf( "Current timer span index is: %d\n", index );
   printf( "Current Watchdog Timer Span is: %s\n", dispMsg );
   printf( "\n" );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_GetMode ( WatchMode & mode )
{
   WDT_GetMode( g_lDeviceHandle, &mode );

   printf( "Current Watchdog mode is:\n" );
   if ( mode == WATCH_MODE_SYSTEM )
   {
      printf( "Watch The Whole System\n" );
   }
   else if ( mode == WATCH_MODE_APPLICATION )
   {
      printf( "Watch The application\n" );
   }
   else
   {
      printf( "Invalid watch mode\n" );
   }
   printf( "\n" );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_GetLogStatus( BOOL & o_bLogStatus )
{
   WDT_IsLogged( g_lDeviceHandle, &o_bLogStatus );

   printf( "Current Watchdog Log Statys is: " );
   if ( o_bLogStatus )
   {
      printf( "On\n" );
   }
   else 
   {
      printf( "Off\n" );
   }

   printf( "\n" );
}
