// Description:  Define the class WatchdogSet
// -----------------------------------------------------------------------------
#include <AdsWatchdog.h>  

extern LONG g_lDeviceHandle;


// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_SetTimerSpan ( DWORD index )
{
   LONG status = WDT_SetTimerSpan( g_lDeviceHandle, index );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Set the watchdog timer span success\n" );
   }
   else
   {
      printf( "Set the watchdog timer span failed\n" );
   }
      
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
DWORD WINAPI ThreadProc( LPVOID lpParameter )
{
  return ADS_WATCHDOG_ERROR_SUCCESS; 
}


// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_SetMode ( WatchMode mode )
{
   if ( mode == WATCH_MODE_APPLICATION )
   {
   }

   LONG status = WDT_SetMode( g_lDeviceHandle, mode );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Set the watchdog mode success\n" );
   }
   else
   {
      printf( "Set the watchdog mode failed\n" );
   }
}


// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_SetLogStatus( BOOL i_bLogStatus )
{
   LONG status = WDT_LogEvent( g_lDeviceHandle, i_bLogStatus );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Set the watchdog log status success\n" );
   }
   else
   {
      printf( "Set the watchdog log status failed\n" );
   }
}
