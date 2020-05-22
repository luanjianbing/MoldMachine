// BackupSystem.cs : Defines the entry point for the console application.

// 1. Use an Ethernet switch and Ethernet cables to connect two APAX-controllers and APAX-5000 I/O modules.
//    (Refer to SetUpPicFolder\setup.jpg)
//
//    NOTE: The switch for backup system should be a local network, NOT to connect with other external network(such as enterprise network, Internet)       
// 
// 2. Use Advantech APAX.NET Utility to configured controller ID
//    Execute Utility and click the Enable check box to enable backup function in the "Backup System Setting" area.
//    Define the controller ID for the APAX-controllers by the controller ID selector. (The ID can only be "0" or "1")
//    Please set different ID for two APAX-controllers. After completing the configuration, click the "Apply" button to save the configuration.
//    (Refer to SetUpPicFolder\config.jpg) 
//
//	  NOTE: The system will automatically decide which one is the master controller.
//
// 3. Power cycle the whole system to run the backup functionality.
//
// 4. Complier this sample code and run the execution file ( BackupSystem.exe ) in two APAX-controllers.
//    The program will print the current status on console. For the master controller, it shows "This controller is running as Master" and executes the control function(AccessIOModule)
//    For the slave controller, it shows "This controller is running as Slave" and be put on standby. 
//    Once the master controller crash or disconnect with Ethernet switch, the slave controller will replace master immediately and continue to execute the control function.   


using System;
using Advantech.Adam;


namespace APAX_PAC_BackupSys
{
    class BackupSys
    {
        //Controller object
        private static Advantech.Adam.AdamControl apaxCtlHandler;

        static void Main(string[] args)
        {
            //Get controller handler
            apaxCtlHandler = new AdamControl(AdamType.Apax5000);

            //Open device
            if (apaxCtlHandler.OpenDevice())
            {
                //Test routine process
                TestBackupSys();
                apaxCtlHandler.CloseDevice();

            }
            else
            {
                Console.WriteLine("OpenDevice() failed!\n");
            }

            Console.WriteLine("Test End.\n");
            return;
        }

        private static void TestBackupSys()
        {
            ushort identity = 0, //0:Controller is Slave
                                 //1:Controller is Master
                   preIdentity = 2;//record controller status 
            int delayCnt = 100,  //interval delay counter
                accessIOCounter = 0;

            Console.WriteLine("BackupSys sample run....\n");

            // Enable the system to run heartbeat 
            if (!EnableRunHeartbeat())
                return;

            // Polling the system status (master or slave)
            while (true)
            {
           
                if (!GetIdentifyStatus(ref identity))
                    return;

                if (identity == 1)
                {
                    //the controller is running as master 
                    if (preIdentity != identity)
                    { 
                        preIdentity = identity;
                        Console.WriteLine("This controller is running as Master...          ");
                        accessIOCounter = 0;//clear access IO counter;
                    }

                    // refresh Global heartbeat
                    // NOTE: You have to refresh global heartbeat in less than 500 milliseconds. 
                    //       Otherwise, the master will be replace by backup system.
                    if (!SentLiveMsgToSlave())
                        return;


                    if (delayCnt >= 30)//Access IO per 30 loops.
                    {
                        accessIOCounter++;
                        //================ Please replace AccessIOModule with your control function ================
                        AccessIOModule(accessIOCounter);
                        delayCnt = 0;
                    }
                }
                else
                {
                    //the controller is running as slave
                    if (preIdentity != identity)
                    {
                        preIdentity = identity;
                        Console.WriteLine("This controller is running as Slave...          ");  
                    } 
                }

                delayCnt++;
                System.Threading.Thread.Sleep(1);
            }
        }

        private static bool EnableRunHeartbeat()
        {
            if (!apaxCtlHandler.Configuration().SYS_SetHeartbeatRun(true))
            {
                Console.WriteLine("SYS_SetHeartbeatRun() failed!\n");
                return false;
            }
            return true;
        }

        private static bool GetIdentifyStatus(ref ushort identity)
        {
            // Get status of identity 	
            if (!apaxCtlHandler.Configuration().SYS_GetGlobalActive(out identity))
            {
                Console.WriteLine("SYS_GetGlobalActive() failed!\n");
                return false;
            }
            return true;
        }

        private static bool SentLiveMsgToSlave()
        {
            //Notify the slave the master is live.
            if (!apaxCtlHandler.Configuration().SYS_SetGlobalHeartbeat())
            {
                Console.WriteLine("SYS_SetGlobalHeartbeat() failed!\n");
                return false;
            }
            return true;
        }

        private static void AccessIOModule(int accessIOCounter)
        {
            int CursorTopPosition = Console.CursorTop;
            Console.WriteLine("Number of times to access Module:{0}", accessIOCounter);
            //If you own the device of apax-5060, set up it "SlotID" to 0 and uncomment below code section.
            //demoAccessApax5060(accessIOCounter);
            Console.CursorTop = CursorTopPosition;
        }

        private static void demoAccessApax5060(int accessIOCounter)
        {
           ushort slotID = 0;
           const int iTotal = 12;
           bool[] bSetDoVal = new bool[iTotal];
           bSetDoVal[accessIOCounter % iTotal] = true;
           if (!apaxCtlHandler.DigitalOutput().SetValues(slotID, bSetDoVal))
                return;
        }
    }
}
