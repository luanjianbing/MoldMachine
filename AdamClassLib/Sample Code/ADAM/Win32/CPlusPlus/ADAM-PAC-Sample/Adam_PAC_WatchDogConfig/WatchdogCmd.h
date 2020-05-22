// Description:  Define the class WatchdogCommand
// -----------------------------------------------------------------------------

// Functions exported in the AdsWatchdog.dll
#include <iostream>
#include <AdsWatchdog.h>  

// -----------------------------------------------------------------------------
// DESCRIPTION: Event Name for Exit Signal
// -----------------------------------------------------------------------------
#define ADS_WATCHDOG_EXIT_EVENT        _T("ADS.Watchdog.Exit.Event.Req.User")

// -----------------------------------------------------------------------------
// DESCRIPTION: Acknowledgement Event Name for Exit Signal
// -----------------------------------------------------------------------------
#define ADS_WATCHDOG_EXIT_ACK_EVENT    _T("ADS.Watchdog.Exit.Event.Ack.User") 

extern LONG g_lDeviceHandle;
static HANDLE g_hExitEvent;
static HANDLE g_hAckExitEvent;
static HANDLE g_hTimer;

LONG UserCriticalAction()
{
   LONG status = ERROR_SUCCESS;
   printf( "    Connecting remote machine: www.microsoft.com...\n" );
   printf( "    +Performing I/O port 1 Operation\n" );
   printf( "        Reading ...\n" );
   printf( "        Writing ...\n" );
   printf( "    +Performing I/O port 2 Operation\n" );
   printf( "        Reading ...\n" );
   printf( "        Writing ...\n" );
   printf( "    +Performing I/O port 3 Operation\n" );
   printf( "        Reading ...\n" );
   printf( "        Writing ...\n" );
   printf( "     Close connection with www.microsoft.com...\n" );
   
   return status;
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
DWORD WINAPI UserThreadProc( LPVOID lpParameter )
{
   HANDLE hWaitObjects[2] = { g_hExitEvent, g_hTimer };
   BOOL bExitNow = FALSE;
   while ( !bExitNow )
   {
      DWORD dwWaitedObjects = WaitForMultipleObjects(
         2,
         hWaitObjects,
         FALSE,
         INFINITE );

      switch( dwWaitedObjects )
      {
      case WAIT_OBJECT_0:
         {
            printf( "\n->Received exit notification REQUEST signal! "
               "exiting program...\n" );
               
            printf( "\n  Exiting the strobe function...\n\n" ); 
            CancelWaitableTimer( g_hTimer );

            SetEvent( g_hAckExitEvent );
            bExitNow = TRUE;
         }
         break;

      case WAIT_OBJECT_0 + 1:
         {
            printf( "+Performing User Critical Action Now...\n" );
            LONG status = UserCriticalAction();
            printf( "User Critical Action end\n\n" );

            if ( ERROR_SUCCESS ==  status )
            {
               WDT_Strobe( g_lDeviceHandle );
               printf( "+Feed watchdog now...\n\n" );
            }
         }
         break;

      case WAIT_TIMEOUT:
         {
            printf( "Can not wait any objects!\n" );
         }

      default:
         {
         }
         break;
      }
   }
   return ERROR_SUCCESS;
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void SetupUserWatchApplication()
{
   DWORD errCode;

   // Open the exit notification event
   SetLastError( 0 );
   g_hExitEvent = CreateEvent( 
      NULL,
      TRUE,
      FALSE,
      ADS_WATCHDOG_EXIT_EVENT );

   if ( g_hExitEvent == NULL )
   {
      errCode = GetLastError();
      printf( "Unable to Create the Exit Notification Event!\n" );
      return;
   }

   // Create the exit acknowledgement event
   g_hAckExitEvent = CreateEvent( 
      NULL,
      TRUE,
      FALSE,
      ADS_WATCHDOG_EXIT_ACK_EVENT );

   if ( g_hAckExitEvent == NULL )
   {
      errCode = GetLastError();
      printf( "Unable to Create the Exit Notification Acknowledgement Event!\n" );
      return;
   }

   // Create the user hit key notification event
   SetLastError( 0 );
   g_hTimer = CreateWaitableTimer(
      NULL,
      FALSE,
      TEXT( "UNO.Watchdog.Timer" ) );

   if ( g_hTimer == NULL )
   {
      errCode = GetLastError();
      printf( "Unable to Create the Feed Watchdog Timer!\n" );
      return;
   }

   std::cout<<"Please enter watchdog timer span(ms):"<<std::endl;
   std::cout<<"   0->Use Default: 2000"<<std::endl;
   std::cout<<"   1->Use Watchdog HARDWARE timer span"<<std::endl;
   std::cout<<"Timer Span:";

   DWORD timerSpanValue;
   std::cin>>timerSpanValue;

   if ( timerSpanValue == 0 )
   {
      timerSpanValue = 2000;
   }
   else if ( timerSpanValue == 1 )
   {
      DWORD index;
      DWORD period;
      WDT_GetTimerSpan( g_lDeviceHandle, &index, &period );
      period -= 2000;
      timerSpanValue = period;
   }
   if ( timerSpanValue < 1000 )
   {
      timerSpanValue = 2000;
      printf( "Watchdog timer span is two small, regulated to 2000\n" );
   }
   printf( "Current watchdog timer span is %u\n", timerSpanValue );

   LARGE_INTEGER dueTime;
   dueTime.QuadPart = 0;
   errCode = SetWaitableTimer(
      g_hTimer,
      &dueTime,
      timerSpanValue,
      NULL,
      NULL,
      FALSE );

   if ( !errCode )
   {
      errCode = GetLastError();
      printf( "Unable to set the waitable timer...\n" );
      return;
   }

   // Create thread to run user specified task. the operation in watched by the 
   // watchdog is very critical.
   HANDLE hUserApplication = CreateThread(
      NULL,
      0,
      UserThreadProc,
      NULL,
      0,
      NULL );

   if ( hUserApplication == NULL )
   {
      printf( "Unable to create user application...\n" );
   }
   else
   {
      printf( "Create user application succeed!\n" );
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Enable ()
{
   printf( "Enable Watchdog...\n\n" );

   WatchMode mode;
   WDT_GetMode( g_lDeviceHandle, &mode );
   if ( mode == WATCH_MODE_APPLICATION )
   {
      // Create User Watchdog Thread
      SetupUserWatchApplication();
   }

   LONG status = WDT_Enable( g_lDeviceHandle );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Enable Advantech Watchdog Succeed\n" );
   }
   else
   {
      printf( "Enable Advantech Watchdog Failed\n" );
   }

   if ( mode == WATCH_MODE_APPLICATION )
   {
      printf( "\n=============Press any key to exit this fucntion========\n\n" );
      getch();
      SetEvent( g_hExitEvent );
      DWORD waitObject  = WaitForSingleObject( g_hAckExitEvent, INFINITE );
      
      switch( waitObject )
      {
      case WAIT_OBJECT_0:
         {
            printf( "->Received exit notification ACKNOWLEDGEMENT signal!\n" );
         }
         break;

      case WAIT_TIMEOUT:
         {
            printf( "Wait exit acknowledgement event timeout!\n" );
         }

      default:
         {
            printf( "Unknown wait results!\n" );
         }
         break;
      }

      // Close watchdog,otherwise the machine will reboot.
      printf( "\nDisable Watchdog Now..." );
      WDT_Disable( g_lDeviceHandle );
      Sleep( 1000 );
      printf( "OK\n" );
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Disable ()
{
   printf( "Disable Watchdog....\n\n" );

   LONG status = WDT_Disable( g_lDeviceHandle );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Disable Advantech Watchdog Succeed\n" );
   }
   else
   {
      printf( "Disable Advantech Watchdog Failed\n" );
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Reboot ()
{
   printf( "Reboot Machine by Watchdog...\n\n" );

   LONG status;

   status = WDT_Reboot( g_lDeviceHandle );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Reboot Advantech Watchdog Succeed\n" );
   }
   else
   {
      printf( "Reboot Advantech Watchdog Failed\n" );
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Strobe ()
{
   printf( "Strobe Watchdog Once...\n\n" );

   LONG status = WDT_Strobe( g_lDeviceHandle );
   if ( status == ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "Strobe Advantech Watchdog Succeed\n" );
   }
   else
   {
      printf( "Strobe Advantech Watchdog Failed\n" );
   }
}

void Watchdog_DeInit()
{
   // De-Initialize watchdog
   // All the setting such as enable and disable will lost. Finally use it.
   LONG status = WDT_DeInit( &g_lDeviceHandle );
   
   if ( status ==  ADS_WATCHDOG_ERROR_SUCCESS )
   {
      printf( "UnInitialize Advantech watchdog Succeed!\n" );
   }
   else
   {
      printf( "Uninitialize Advantech watchdog Failed!\n" );
   }
}
