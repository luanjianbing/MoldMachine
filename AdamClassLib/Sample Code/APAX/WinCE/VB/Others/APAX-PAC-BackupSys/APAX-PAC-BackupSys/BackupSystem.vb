' BackupSystem.vb : Defines the entry point for the console application.

' 1. Use an Ethernet switch and Ethernet cables to connect two APAX-controllers and APAX-5000 I/O modules.
'    (Refer to SetUpPicFolder\setup.jpg)
'
'    NOTE: The switch for backup system should be a local network, NOT to connect with other external network(such as enterprise network, Internet)       
' 
' 2. Use Advantech APAX.NET Utility to configured controller ID
'    Execute Utility and click the Enable check box to enable backup function in the "Backup System Setting" area.
'    Define the controller ID for the APAX-controllers by the controller ID selector. (The ID can only be "0" or "1")
'    Please set different ID for two APAX-controllers. After completing the configuration, click the "Apply" button to save the configuration.
'    (Refer to SetUpPicFolder\config.jpg) 
'
'	  NOTE: The system will automatically decide which one is the master controller.
'
' 3. Power cycle the whole system to run the backup functionality.
'
' 4. Complier this sample code and run the execution file ( BackupSystem.exe ) in two APAX-controllers.
'    The program will print the current status on console. For the master controller, it shows "This controller is running as Master" and executes the control function(AccessIOModule)
'    For the slave controller, it shows "This controller is running as Slave" and be put on standby. 
'    Once the master controller crash or disconnect with Ethernet switch, the slave controller will replace master immediately and continue to execute the control function.   

Imports System
Imports Advantech.Adam

Namespace APAX_PAC_BackupSys

    Class BackupSys

        'Controller object
        Private Shared apaxCtlHandler As Advantech.Adam.AdamControl

        Shared Sub Main(ByVal args() As String)
            'Get controller handler
            apaxCtlHandler = New AdamControl(AdamType.Apax5000)
            'Open device
            If apaxCtlHandler.OpenDevice Then
                'Test routine process
                TestBackupSys()
                apaxCtlHandler.CloseDevice()
            Else
                Console.WriteLine("OpenDevice() failed!" & vbLf)
            End If
            Console.WriteLine("Test End." & vbLf)
            Return
        End Sub

        Private Shared Sub TestBackupSys()
            Dim preIdentity As System.UInt16 = 2 'record system status 
            Dim identity As System.UInt16 = 0 '0:Controller is Slave; 1:Controller is Master
            Dim accessIOCounter As Integer = 0
            Dim delayCnt As Integer = 100
            Console.WriteLine("BackupSys sample run...." & vbLf)

            ' Enable the system to run heartbeat 
            If Not EnableRunHeartbeat() Then
                Return
            End If

            ' Polling the system status (master or slave)
            While True
                If Not GetIdentifyStatus(identity) Then
                    Return
                End If
                If (identity = 1) Then
                    'the controller is running as master 
                    If (preIdentity <> identity) Then
                        preIdentity = identity
                        Console.WriteLine("This controller is running as Master...          ")
                        accessIOCounter = 0 'clear access IO counter;
                    End If
                    ' refresh Global heartbeat
                    ' NOTE: You have to refresh global heartbeat in less than 500 milliseconds. 
                    '       Otherwise, the master will be replace by backup system.
                    If Not SentLiveMsgToSlave Then
                        Return
                    End If
                    If (delayCnt >= 30) Then
                        accessIOCounter = (accessIOCounter + 1)
                        '================ Please replace AccessIOModule with your control function ================
                        AccessIOModule(accessIOCounter)
                        delayCnt = 0
                    End If
                Else
                    'the controller is running as slave
                    If (preIdentity <> identity) Then
                        preIdentity = identity
                        Console.WriteLine("This controller is running as Slave...          ")
                    End If
                End If
                delayCnt = (delayCnt + 1)
                System.Threading.Thread.Sleep(1)

            End While
        End Sub

        Private Shared Function EnableRunHeartbeat() As Boolean

            If Not apaxCtlHandler.Configuration.SYS_SetHeartbeatRun(True) Then

                Console.WriteLine("SYS_SetHeartbeatRun() failed!" & vbLf)
                Return False

            End If

            Return True

        End Function

        Private Shared Function GetIdentifyStatus(ByRef identity As System.UInt16) As Boolean
            ' Get status of identity     
            If Not apaxCtlHandler.Configuration.SYS_GetGlobalActive(identity) Then

                Console.WriteLine("SYS_GetGlobalActive() failed!" & vbLf)
                Return False

            End If

            Return True

        End Function

        Private Shared Function SentLiveMsgToSlave() As Boolean
            'Notify the slave the master is live.
            If Not apaxCtlHandler.Configuration.SYS_SetGlobalHeartbeat Then

                Console.WriteLine("SYS_SetGlobalHeartbeat() failed!" & vbLf)
                Return False

            End If

            Return True

        End Function

        Private Shared Sub AccessIOModule(ByVal accessIOCounter As System.UInt64)
            If accessIOCounter = 0 Then
                Console.WriteLine("Start accessing Module...")
            End If

            'If you own the device of apax-5060, set up it "SlotID" to 0 and uncomment below code section.
            'demoAccessApax5060(accessIOCounter);
        End Sub

        Private Shared Sub demoAccessApax5060(ByVal accessIOCounter As Integer)

            Dim slotID As System.UInt16 = 0
            Const iTotal As Integer = 12
            Dim bSetDoVal() As Boolean = New Boolean((iTotal) - 1) {}
            bSetDoVal((accessIOCounter Mod iTotal)) = True

            If Not apaxCtlHandler.DigitalOutput.SetValues(slotID, bSetDoVal) Then
                Return
            End If

        End Sub

    End Class

End Namespace