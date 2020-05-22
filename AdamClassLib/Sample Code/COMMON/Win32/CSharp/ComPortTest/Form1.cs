using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Common;

namespace ComPortTest
{
    public partial class Form1 : Form
    {
        private ComPort com;

        public Form1()
        {
            InitializeComponent();

            cbxCOM.SelectedIndex = 1;			// default is COM2
            cbxBaudrate.SelectedIndex = 2;		// default baudrate 9600
            cbxDatabits.SelectedIndex = 3;		// databits 8
            cbxParity.SelectedIndex = 0;		// parity is None
            cbxStopbits.SelectedIndex = 0;		// stopbits is 1
            cbxReadTimeout.SelectedIndex = 0;	// read timeout is 100 ms
            cbxWriteTimeout.SelectedIndex = 0;	// write timeout is 100 ms
        }

        private void SwitchEnable(bool i_bEnable)
        {
            btnOpen.Enabled = i_bEnable;
            cbxCOM.Enabled = i_bEnable;
            cbxBaudrate.Enabled = i_bEnable;
            cbxDatabits.Enabled = i_bEnable;
            cbxParity.Enabled = i_bEnable;
            cbxStopbits.Enabled = i_bEnable;
            cbxReadTimeout.Enabled = i_bEnable;
            cbxWriteTimeout.Enabled = i_bEnable;
        }

        private bool SetComState()
        {
            Advantech.Common.Baudrate baudrate;
            Advantech.Common.Databits databits;
            Advantech.Common.Parity parity;
            Advantech.Common.Stopbits stopbits;

            switch (cbxBaudrate.SelectedIndex)
            {
                case 0:
                    baudrate = Advantech.Common.Baudrate.Baud_2400;
                    break;
                case 1:
                    baudrate = Advantech.Common.Baudrate.Baud_4800;
                    break;
                case 2:
                    baudrate = Advantech.Common.Baudrate.Baud_9600;
                    break;
                case 3:
                    baudrate = Advantech.Common.Baudrate.Baud_19200;
                    break;
                case 4:
                    baudrate = Advantech.Common.Baudrate.Baud_38400;
                    break;
                case 5:
                    baudrate = Advantech.Common.Baudrate.Baud_57600;
                    break;
                case 6:
                    baudrate = Advantech.Common.Baudrate.Baud_115200;
                    break;
                default:
                    baudrate = Advantech.Common.Baudrate.Baud_57600;
                    break;
            }
            switch (cbxDatabits.SelectedIndex)
            {
                case 0:
                    databits = Advantech.Common.Databits.Five;
                    break;
                case 1:
                    databits = Advantech.Common.Databits.Six;
                    break;
                case 2:
                    databits = Advantech.Common.Databits.Seven;
                    break;
                default:
                    databits = Advantech.Common.Databits.Eight;
                    break;
            }
            switch (cbxParity.SelectedIndex)
            {
                case 0:
                    parity = Advantech.Common.Parity.None;
                    break;
                case 1:
                    parity = Advantech.Common.Parity.Odd;
                    break;
                case 2:
                    parity = Advantech.Common.Parity.Even;
                    break;
                case 3:
                    parity = Advantech.Common.Parity.Mark;
                    break;
                default:
                    parity = Advantech.Common.Parity.Space;
                    break;
            }
            switch (cbxStopbits.SelectedIndex)
            {
                case 0:
                    stopbits = Advantech.Common.Stopbits.One;
                    break;
                case 1:
                    stopbits = Advantech.Common.Stopbits.OneAndHalf;
                    break;
                default:
                    stopbits = Advantech.Common.Stopbits.Two;
                    break;
            }
            return com.SetComPortState(baudrate, databits, parity, stopbits);
        }

        private bool SetComTimeout()
        {
            int rdTout, wrTout;

            switch (cbxReadTimeout.SelectedIndex)
            {
                case 0:
                    rdTout = 100;
                    break;
                case 1:
                    rdTout = 500;
                    break;
                case 2:
                    rdTout = 1000;
                    break;
                default:
                    rdTout = 5000;
                    break;
            }
            switch (cbxWriteTimeout.SelectedIndex)
            {
                case 0:
                    wrTout = 100;
                    break;
                case 1:
                    wrTout = 500;
                    break;
                case 2:
                    wrTout = 1000;
                    break;
                default:
                    wrTout = 5000;
                    break;
            }
            return com.SetComPortTimeout(rdTout, rdTout, 0, wrTout, 0);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            int port;

            port = cbxCOM.SelectedIndex + 1;

            com = new Advantech.Common.ComPort(port);
            if (com.OpenComPort()) // open the COM port
            {
                // set COM port state
                if (!SetComState())
                {
                    MessageBox.Show("Set COM port state failed!", "Error");
                    return;
                }
                // set COM port timeout
                if (!SetComTimeout())
                {
                    MessageBox.Show("Set COM port timeout failed!", "Error");
                    return;
                }
                btnClose.Enabled = true;
                btnSend.Enabled = true;
                SwitchEnable(false);
            }
            else
            {
                MessageBox.Show("Open COM" + port.ToString() + ": failed!", "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int port;

            port = cbxCOM.SelectedIndex + 1;

            if (com.CloseComPort()) // close COM port
                MessageBox.Show("Close COM" + port.ToString() + ": done!", "Close");
            else
                MessageBox.Show("Close COM" + port.ToString() + ": failed!", "Error");
            btnClose.Enabled = false;
            btnSend.Enabled = false;
            SwitchEnable(true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string szSend, szRecv;

            if (txtSend.Text.Length == 0)
            {
                MessageBox.Show("Please input the command string!", "Warn");
                return;
            }

            szSend = txtSend.Text + "\r";	// append carrage return for sending ADAM-ASCII command
            if (com.IsOpen)
            {
                com.SetPurge((int)Purge.RxClear); // purge the port before sending
                com.SetPurge((int)Purge.TxClear); // purge the port before sending
                com.Send(szSend); // snding command

                if (com.Recv(out szRecv) > 0)	// receiving command
                    lsbxRecv.Items.Add(szRecv);
                else
                {
                    lsbxRecv.Items.Add("## Fail to receive! ##");
                }
            }
            lsbxRecv.SelectedIndex = lsbxRecv.Items.Count - 1;
        }
    }
}
