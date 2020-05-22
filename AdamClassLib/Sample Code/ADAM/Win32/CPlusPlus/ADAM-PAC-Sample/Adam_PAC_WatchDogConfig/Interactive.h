// Description:  Define the class main
// -----------------------------------------------------------------------------

#include <stdio.h>
#include <Windows.h>

#include "ParseCMDLine.h"

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
BOOL WINAPI CtrlHandlerRoutine( DWORD i_dwCtrlType );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
void InitializeWatchdog( HANDLE i_hConsole );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
void BuildCMDArguments( LPSTR i_pCMDString, int *  o_pArgc, char * o_pArgv[] );

// -----------------------------------------------------------------------------
// DESCRIPTION: 
// -----------------------------------------------------------------------------
void ReleaseCMDArguments( int *  io_pArgc, char * o_pArgv[] );


// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void InterActive_Main()
{
   HANDLE hInConsole = GetStdHandle( STD_INPUT_HANDLE );
   HANDLE hOutConsole  = GetStdHandle( STD_OUTPUT_HANDLE );
   SetConsoleCtrlHandler( CtrlHandlerRoutine, TRUE );

   DWORD  dwReadNum;
   TCHAR  cmdBuffer[MAX_PATH];
   BOOL   bExitInterpreter = FALSE;

   InitializeWatchdog( hOutConsole );
   printf( "Watchdog>" );

   int argc = MAX_PATH;
   TCHAR * argv[MAX_PATH];
   do
   {
      ReadConsole(
         hInConsole,
         cmdBuffer,
         sizeof(cmdBuffer),
         &dwReadNum,
         NULL );

      cmdBuffer[dwReadNum-2] = NULL;

      if ( !_tcsicmp( cmdBuffer, TEXT( "exit" ) ) )
      {
         bExitInterpreter = TRUE;
      }
      else
      {
         //printf( cmdBuffer );  // Just echo user input for debugging
         BuildCMDArguments( cmdBuffer, &argc, argv );

         // Parse user command line 
         ParseCommandLine( 
            argc, 
            argv, 
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

         ReleaseCMDArguments( &argc, argv );

         printf( "\nWatchdog>" );
      }

   } while( !bExitInterpreter );

   SetConsoleCtrlHandler( CtrlHandlerRoutine, FALSE );
   CloseHandle( hInConsole );
   CloseHandle( hOutConsole );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
BOOL WINAPI CtrlHandlerRoutine( DWORD i_dwCtrlType )
{
   switch( i_dwCtrlType )
   {
   case CTRL_C_EVENT:
      {
         printf( "\nGood bye!\n" );
         exit(0);
      }
      break;

   case CTRL_BREAK_EVENT:
      {
         printf( "\nGood bye!\n" );
         exit(0);
      }
      break;

   case CTRL_CLOSE_EVENT:
      {
         printf( "\nGood bye!\n" );
         exit(0);
      }
      break;

   case CTRL_LOGOFF_EVENT:
      {
         printf( "\nGood bye!\n" );
         exit(0);
      }
      break;

   case CTRL_SHUTDOWN_EVENT:
      {
         printf( "\nGood bye!\n" );
         exit(0);
      }
      break;

   default:
      {
      }
      break;
   }
   
   return TRUE;
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void InitializeWatchdog( HANDLE i_hConsole )
{
   printf( "Advantech(R) Watchdog(R) Debugging Tool Verion 1.0\n" );
   printf( "Copyright(C) Advantech Automation Corp., 2014-2015.\n" );
   printf( "\nInitializing Advantech Watchdog " );

   CONSOLE_CURSOR_INFO cursorInfo;
   GetConsoleCursorInfo( i_hConsole, &cursorInfo );
   cursorInfo.bVisible = FALSE;
   SetConsoleCursorInfo( i_hConsole, &cursorInfo );

   Sleep( 1000 );
   WriteConsole( i_hConsole, ".", sizeof(TCHAR), NULL, NULL );
   Sleep( 1000 );
   WriteConsole( i_hConsole, ".", sizeof(TCHAR), NULL, NULL );
   Sleep( 1000 );
   WriteConsole( i_hConsole, ".", sizeof(TCHAR), NULL, NULL );
   printf( " OK!\n\n" );
   
   cursorInfo.bVisible = TRUE;
   SetConsoleCursorInfo( i_hConsole, &cursorInfo );
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void BuildCMDArguments( LPSTR i_pCMDString, int * o_pArgc, TCHAR * o_pArgv[] )
{
   size_t lineSize = _tcslen( i_pCMDString );
   TCHAR  buffer[MAX_PATH];
   size_t i;
   size_t j;
   BOOL bCounting;
   *o_pArgc = 0;
 
   bCounting = ( i_pCMDString[0] != 0x020 ) ? TRUE : FALSE;
      
   for ( i = 0, j=0; i<= lineSize; ++i )
   {
      if ( i_pCMDString[i] != 0x20 && i_pCMDString[i] != NULL )
      {
         buffer[j] = i_pCMDString[i];
         j++;
         bCounting = TRUE;
      }
      else
      {
         buffer[j] = NULL;
         if ( bCounting == TRUE )
         {
            o_pArgv[*o_pArgc] = reinterpret_cast<TCHAR *>( 
               malloc( _tcslen( buffer ) + 1 ) );

            _tcscpy( o_pArgv[*o_pArgc], buffer );
            ZeroMemory( buffer, sizeof( buffer ) );
            ++(*o_pArgc);
         }
         j = 0;
         bCounting = FALSE;
      }
      
   }
}

// *****************************************************************************
// Design Notes:  
// -----------------------------------------------------------------------------
void ReleaseCMDArguments( int *  io_pArgc, char * o_pArgv[] )
{
   for ( int i = 0; i < *io_pArgc; ++i )
   {
      free( o_pArgv[i] );
      o_pArgv[i] = NULL;
   }

   *io_pArgc = 0;
}


