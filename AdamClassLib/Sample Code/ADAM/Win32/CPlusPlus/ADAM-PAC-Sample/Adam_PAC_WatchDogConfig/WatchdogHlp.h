// Description:  Define the class WatchdogHelp
// -----------------------------------------------------------------------------

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
extern RUN_Mode g_RunMode;

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_Set ()
{
   printf( "Advantech Watchdog Command Line Usage->Set:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Set Mode  i_WatchMode\n" );
      printf( "   [2] Watchdog Set Timer i_TimerSpan\n" );
      printf( "   [3] Watchdog Set Log   i_LogEvent\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Set Mode  i_WatchMode\n" );
      printf( "   [2] Set Timer i_TimerSpan\n" );
      printf( "   [3] Set Log   i_LogEvent\n" );
   }

   printf( "Notes:\n" );
   printf( "   i_WatchMode:\n" );
   printf( "         Sys->Watch System\n" ); 
   printf( "         App->Watch Application.\n" );
   printf( "   i_TimerSpan:\n" );
   printf( "         1->15 Seconds\n" );
   printf( "         2->45 Seconds\n" );
   printf( "         3->1 Minute 15 Seconds\n" );
   printf( "         4->2 Minute 15 Seconds\n" );
   printf( "         5->3 Minute 15 Seconds\n" );
   printf( "         6->4 Minute 15 Seconds\n" );
   printf( "         7->5 Minute 15 Seconds\n" );
   printf( "         8->10 Minute 15 Seconds\n" );
   printf( "         9->20 Minute 15 Seconds\n" );
   printf( "         10->30 Minute 15 Seconds\n" );
   printf( "         11->40 Minute 15 Seconds\n" );
   printf( "         12->50 Minute 15 Seconds\n" );
   printf( "         13->1 Hour 15 Seconds\n" );
   printf( "         14->2 Hour 15 Seconds\n" );
   printf( "   i_LogEvent:\n" );
   printf( "         On->Log operation into system event base\n" ); 
   printf( "         Off->Do not log operation into system event base\n" ); 
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_Get ()
{
   printf( "Advantech Watchdog Command Line Usage->Get:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Get Mode\n" );
      printf( "   [2] Watchdog Get Timer\n" );
      printf( "   [3] Watchdog Get Log\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Get Mode\n" );
      printf( "   [2] Get Timer\n" );
      printf( "   [3] Get Log\n" );
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_Set_TimerSpan ()
{
   printf( "Advantech Watchdog Command Line Usage->Set Timer:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Set Timer i_TimerSpan\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Set Timer i_TimerSpan\n" );
   }
   
   printf( "Notes:\n" );
   printf( "   i_TimerSpan:\n" );
   printf( "         1->15 Seconds\n" );
   printf( "         2->45 Seconds\n" );
   printf( "         3->1 Minute 15 Seconds\n" );
   printf( "         4->2 Minute 15 Seconds\n" );
   printf( "         5->3 Minute 15 Seconds\n" );
   printf( "         6->4 Minute 15 Seconds\n" );
   printf( "         7->5 Minute 15 Seconds\n" );
   printf( "         8->10 Minute 15 Seconds\n" );
   printf( "         9->20 Minute 15 Seconds\n" );
   printf( "         10->30 Minute 15 Seconds\n" );
   printf( "         11->40 Minute 15 Seconds\n" );
   printf( "         12->50 Minute 15 Seconds\n" );
   printf( "         13->1 Hour 15 Seconds\n" );
   printf( "         14->2 Hour 15 Seconds\n" );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_Set_Mode ()
{
   printf( "Advantech Watchdog Command Line Usage->Set Mode:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Set Mode  i_WatchMode\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Set Mode  i_WatchMode\n" );
   }

   printf( "Notes:\n" );
   printf( "   i_WatchMode:\n" );
   printf( "         Sys->Watch System\n" ); 
   printf( "         App->Watch Application.\n" );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_Set_LogStatus ()
{
   printf( "Advantech Watchdog Command Line Usage->Set Log:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Set Log i_LogEvent\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Set Log i_LogEvent\n" );
   }

   printf( "Notes:\n" );
   printf( "   i_LogEvent:\n" );
   printf( "         On->Log operation into system event base\n" ); 
   printf( "         Off->Do not log operation into system event base.\n" );   
}


// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void Watchdog_Help_All ()
{
   printf( "Advantech Watchdog Command Line Usage:\n" );

   if ( g_RunMode == NON_INTERACTIVE_MODE )
   {
      printf( "   [1] Watchdog Enable\n" );
      printf( "   [2] Watchdog Disable\n" );
      printf( "   [3] Watchdog Reboot\n" );
      printf( "   [4] Watchdog Strobe\n" );
      printf( "   [5] Watchdog Set\n" );
      printf( "   [6] Watchdog Get\n" );
      printf( "   [7] Watchdog Set Timer i_TimerSpan\n" );
      printf( "   [8] Watchdog Set Mode  i_WatchMode\n" );
      printf( "   [9] Watchdog Set Log   i_LogEvent\n" );
      printf( "   [10] Watchdog Get Timer\n" );
      printf( "   [11] Watchdog Get Mode\n" );
      printf( "   [12] Watchdog Get Log\n" );
      printf( "   [13] Watchdog /?\n" );
   }
   else if ( g_RunMode == INTERACTIVE_MODE )
   {
      printf( "   [1] Enable\n" );
      printf( "   [2] Disable\n" );
      printf( "   [3] Reboot\n" );
      printf( "   [4] Strobe\n" );
      printf( "   [5] Set\n" );
      printf( "   [6] Get\n" );
      printf( "   [7] Set Timer i_TimerSpan\n" );
      printf( "   [8] Set Mode  i_WatchMode\n" );
      printf( "   [9] Set Log   i_LogEvent\n" );
      printf( "   [10] Get Timer\n" );
      printf( "   [11] Get Mode\n" );
      printf( "   [12] Watchdog Get Log\n" );
      printf( "   [13] /?\n" );
      printf( "   [14] Exit\n\n" );
   }
   printf( "For detailed help information about parameters i_TimerSpan,"
      " i_WatchMode and i_LogEvent, please type specified command\n" );
}