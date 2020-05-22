// Functions exported in the AdsWatchdog.dll
#include <AdsWatchdog.h>  

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
enum WDT_Operation 
{
   WDT_SET_TIMERSPAN = 0,
   WDT_SET_WATCHMODE = 1,
   WDT_SET_LOGSTATUS = 3,

   WDT_GET_TIMERSPAN = 4,
   WDT_GET_WATCHMODE = 5,
   WDT_GET_LOGSTATUS = 6,

   WDT_ENABLE = 100,
   WDT_DISABLE = 101,

   WDT_STROBE = 200,
   WDT_REBOOT = 201,

   WDT_HELP_SET = 300,
   WDT_HELP_GET = 301,

   WDT_HELP_SET_MODE = 400,
   WDT_HELP_SET_TIMER = 401,
   WDT_HELP_SET_LOG = 402,

   WDT_HELP_ALL = 500,

   WDT_DEINIT_WATCHDOG = 600
};

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
enum RUN_Mode
{
   INTERACTIVE_MODE = 0,
   NON_INTERACTIVE_MODE = 1
};

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
void ProcessCommandLine(
   WDT_Operation  operation,
   WatchMode      mode,
   DWORD          index,
   BOOL           log );