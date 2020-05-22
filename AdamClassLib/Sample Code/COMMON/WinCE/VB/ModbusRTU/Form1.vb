Imports Advantech.Adam

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer
    Private m_iStart As Integer, m_iLength As Integer
    Private m_bRegister As Boolean, m_bStart As Boolean
    Private adamCom As Advantech.Adam.AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer, iPos As Integer, iStart As Integer

        m_bStart = False    ' the action stops at the beginning
        m_bRegister = False ' set to true to read the register, otherwise, read the coil
        m_iCom = 2          ' host COM port number
        m_iAddr = 3         ' modbus slave address
        m_iStart = 1        ' modbus starting address
        m_iLength = 8       ' modbus reading length
        adamCom = New AdamCom(m_iCom)

        ' fill the ListView
        If m_bRegister = True Then ' The initial register list 
            iStart = 40000 + m_iStart ' The register starting position  (4X references)
            For iIdx = 0 To m_iLength - 1
                iPos = iStart + iIdx
                listViewModbusCur.Items.Add(New ListViewItem(iPos.ToString()))
                listViewModbusCur.Items(iIdx).SubItems.Add("Word")
                listViewModbusCur.Items(iIdx).SubItems.Add("*****")
                listViewModbusCur.Items(iIdx).SubItems.Add("****")
            Next iIdx
        Else ' The initial coil list
            iStart = m_iStart  ' The coil starting position (0X references)
            For iIdx = 0 To m_iLength - 1
                iPos = iStart + iIdx
                listViewModbusCur.Items.Add(New ListViewItem(iPos.ToString("00000")))
                listViewModbusCur.Items(iIdx).SubItems.Add("Bit")
                listViewModbusCur.Items(iIdx).SubItems.Add("*****")
                listViewModbusCur.Items(iIdx).SubItems.Add("****")
            Next iIdx
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_bStart = True Then
            Timer1.Enabled = False  'disable timer
            adamCom.CloseComPort()  'close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
            m_bStart = False ' starting flag
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
            buttonStart.Text = "Start"
        Else ' was stoped
            If adamCom.OpenComPort() = True Then
                ' set COM port state
                adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_9600, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One)
                ' set COM port timeout
                adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                m_iCount = 0 ' reset the reading counter
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True 'starting flag
            Else
                MessageBox.Show("Open COM port failed", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim iIdx As Integer
        Dim iData() As Integer
        Dim bData() As Boolean


        If m_bRegister = True Then ' Read registers (4X references)
            If adamCom.Modbus(m_iAddr).ReadHoldingRegs(m_iStart, m_iLength, iData) = True Then
                m_iCount = m_iCount + 1 ' increment the reading counter
                txtStatus.Text = "Read registers " + m_iCount.ToString() + " times..."
                ' update ListView
                For iIdx = 0 To m_iLength - 1
                    listViewModbusCur.Items(iIdx).SubItems(2).Text = iData(iIdx).ToString()   ' show value in decimal
                    listViewModbusCur.Items(iIdx).SubItems(3).Text = iData(iIdx).ToString("X04") ' show value in hexdecimal
                Next iIdx

            Else
                txtStatus.Text = "Read registers failed!" ' show error message in "txtStatus"
            End If
        Else    ' read coil (0X) data from slave
            If adamCom.Modbus(m_iAddr).ReadCoilStatus(m_iStart, m_iLength, bData) = True Then
                m_iCount = m_iCount + 1 ' increment the reading counter
                txtStatus.Text = "Read coil " + m_iCount.ToString() + " times..."
                ' update ListView
                For iIdx = 0 To m_iLength - 1
                    listViewModbusCur.Items(iIdx).SubItems(2).Text = bData(iIdx).ToString() ' show value
                Next iIdx
            Else
                txtStatus.Text = "Read coil failed!" ' show error message in "txtStatus"
            End If
        End If
    End Sub
End Class
