using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace StaticMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbxAdamType.Items.Add(AdamType.Adam4000);
            cbxAdamType.Items.Add(AdamType.Adam5000);
            cbxAdamType.Items.Add(AdamType.Adam5000Tcp);
            cbxAdamType.Items.Add(AdamType.Adam6000);
            cbxAdamType.SelectedIndex = 0;
        }

        private void cbxAdamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdamType adamType;
            adamType = (AdamType)cbxAdamType.SelectedItem;
            if (adamType.Equals(AdamType.Adam4000))
                InitAdam4000ComboxList();
            else if (adamType.Equals(AdamType.Adam6000))
                InitAdam6000ComboxList();
            else
                InitAdam5000ComboxList();
        }

        private void cbxModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdamType adamType;
            adamType = (AdamType)cbxAdamType.SelectedItem;
            if (adamType.Equals(AdamType.Adam4000))
                RefreshAdam4000Information();
            else if (adamType.Equals(AdamType.Adam6000))
                RefreshAdam6000Information();
            else
                RefreshAdam5000Information();
        }

        private void InitAdam4000ComboxList()
        {
            cbxModuleType.Items.Clear();
            cbxModuleType.Items.Add(Adam4000Type.Adam4011);
            cbxModuleType.Items.Add(Adam4000Type.Adam4011D);
            cbxModuleType.Items.Add(Adam4000Type.Adam4012);
            cbxModuleType.Items.Add(Adam4000Type.Adam4013);
            cbxModuleType.Items.Add(Adam4000Type.Adam4015);
            cbxModuleType.Items.Add(Adam4000Type.Adam4015T);
            cbxModuleType.Items.Add(Adam4000Type.Adam4016);
            cbxModuleType.Items.Add(Adam4000Type.Adam4017);
            cbxModuleType.Items.Add(Adam4000Type.Adam4017P);
            cbxModuleType.Items.Add(Adam4000Type.Adam4018);
            cbxModuleType.Items.Add(Adam4000Type.Adam4018M);
            cbxModuleType.Items.Add(Adam4000Type.Adam4018P);
            cbxModuleType.Items.Add(Adam4000Type.Adam4019);
            cbxModuleType.Items.Add(Adam4000Type.Adam4019P);
            cbxModuleType.Items.Add(Adam4000Type.Adam4021);
            cbxModuleType.Items.Add(Adam4000Type.Adam4022T);
            cbxModuleType.Items.Add(Adam4000Type.Adam4024);
            cbxModuleType.Items.Add(Adam4000Type.Adam4050);
            cbxModuleType.Items.Add(Adam4000Type.Adam4051);
            cbxModuleType.Items.Add(Adam4000Type.Adam4052);
            cbxModuleType.Items.Add(Adam4000Type.Adam4053);
            cbxModuleType.Items.Add(Adam4000Type.Adam4055);
            cbxModuleType.Items.Add(Adam4000Type.Adam4056S);
            cbxModuleType.Items.Add(Adam4000Type.Adam4056SO);
            cbxModuleType.Items.Add(Adam4000Type.Adam4060);
            cbxModuleType.Items.Add(Adam4000Type.Adam4068);
            cbxModuleType.Items.Add(Adam4000Type.Adam4069);
            cbxModuleType.Items.Add(Adam4000Type.Adam4080);
            cbxModuleType.Items.Add(Adam4000Type.Adam4080D);
            cbxModuleType.SelectedIndex = 0;
        }

        private void RefreshAdam4000Information()
        {
            int iIdx;
            byte byCode;

            Adam4000Type adamType;
            adamType = (Adam4000Type)cbxModuleType.SelectedItem;
            // AI information
            txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString();
            listViewAI.Items.Clear();
            for (iIdx = 0; iIdx < AnalogInput.GetRangeTotal(adamType); iIdx++)
            {
                byCode = AnalogInput.GetRangeCode(adamType, iIdx);
                listViewAI.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetRangeName(adamType, byCode));	// range name
                listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetUnitName(adamType, byCode));	// range name
            }
            // AO information
            txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString();
            listViewAO.Items.Clear();
            for (iIdx = 0; iIdx < AnalogOutput.GetRangeTotal(adamType); iIdx++)
            {
                byCode = AnalogOutput.GetRangeCode(adamType, iIdx);
                listViewAO.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode));	// range name
                listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode));	// range name
            }
            // DIO
            txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString();
            txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString();
            // counter
            txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString();
            listViewCounter.Items.Clear();
            if (Counter.GetModeTotal(adamType) > 0)
            {
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam4080_CounterMode.Counter)));		// mode name
                listViewCounter.Items[0].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam4080_CounterMode.Counter));			// unit name
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam4080_CounterMode.Frequency)));	// mode name
                listViewCounter.Items[1].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam4080_CounterMode.Frequency));			// unit name
            }
            // alarm
            listViewAlarm.Items.Clear();
            for (iIdx = 0; iIdx < Alarm.GetModeTotal(adamType); iIdx++)
            {
                byCode = Alarm.GetModeCode(adamType, iIdx);
                listViewAlarm.Items.Add(new ListViewItem(Alarm.GetModeName(adamType, byCode)));	// mode name
            }
        }

        private void InitAdam5000ComboxList()
        {
            cbxModuleType.Items.Clear();
            cbxModuleType.Items.Add(Adam5000Type.Adam5013);
            cbxModuleType.Items.Add(Adam5000Type.Adam5017);
            cbxModuleType.Items.Add(Adam5000Type.Adam5017H);
            cbxModuleType.Items.Add(Adam5000Type.Adam5017UH);
            cbxModuleType.Items.Add(Adam5000Type.Adam5018);
            cbxModuleType.Items.Add(Adam5000Type.Adam5018P);
            cbxModuleType.Items.Add(Adam5000Type.Adam5024);
            cbxModuleType.Items.Add(Adam5000Type.Adam5050);
            cbxModuleType.Items.Add(Adam5000Type.Adam5051);
            cbxModuleType.Items.Add(Adam5000Type.Adam5052);
            cbxModuleType.Items.Add(Adam5000Type.Adam5055);
            cbxModuleType.Items.Add(Adam5000Type.Adam5060);
            cbxModuleType.Items.Add(Adam5000Type.Adam5068);
            cbxModuleType.Items.Add(Adam5000Type.Adam5069);
            cbxModuleType.Items.Add(Adam5000Type.Adam5080);
            cbxModuleType.SelectedIndex = 0;
        }

        private void RefreshAdam5000Information()
        {
            int iIdx;
            byte byCode;

            Adam5000Type adamType;
            adamType = (Adam5000Type)cbxModuleType.SelectedItem;
            // AI information
            txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString();
            listViewAI.Items.Clear();
            for (iIdx = 0; iIdx < AnalogInput.GetRangeTotal(adamType); iIdx++)
            {
                byCode = AnalogInput.GetRangeCode(adamType, iIdx);
                listViewAI.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetRangeName(adamType, byCode));	// range name
                listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetUnitName(adamType, byCode));	// range name
            }
            // AO information
            txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString();
            listViewAO.Items.Clear();
            for (iIdx = 0; iIdx < AnalogOutput.GetRangeTotal(adamType); iIdx++)
            {
                byCode = AnalogOutput.GetRangeCode(adamType, iIdx);
                listViewAO.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode));	// range name
                listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode));	// range name
            }
            // DIO
            txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString();
            txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString();
            // counter
            txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString();
            listViewCounter.Items.Clear();
            if (Counter.GetModeTotal(adamType) > 0)
            {
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam5080_CounterMode.Bi_Direction)));	// mode name
                listViewCounter.Items[0].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam5080_CounterMode.Bi_Direction));			// unit name
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam5080_CounterMode.Up_Down)));			// mode name
                listViewCounter.Items[1].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam5080_CounterMode.Up_Down));				// unit name
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam5080_CounterMode.Frequency)));		// mode name
                listViewCounter.Items[2].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam5080_CounterMode.Frequency));				// unit name
            }
            // alarm
            listViewAlarm.Items.Clear();
            for (iIdx = 0; iIdx < Alarm.GetModeTotal(adamType); iIdx++)
            {
                byCode = Alarm.GetModeCode(adamType, iIdx);
                listViewAlarm.Items.Add(new ListViewItem(Alarm.GetModeName(adamType, byCode)));	// mode name
            }
        }

        private void InitAdam6000ComboxList()
        {
            cbxModuleType.Items.Clear();
            cbxModuleType.Items.Add(Adam6000Type.Adam6015);
            cbxModuleType.Items.Add(Adam6000Type.Adam6017);
            cbxModuleType.Items.Add(Adam6000Type.Adam6018);
            cbxModuleType.Items.Add(Adam6000Type.Adam6022);
            cbxModuleType.Items.Add(Adam6000Type.Adam6024);
            cbxModuleType.Items.Add(Adam6000Type.Adam6050);
            cbxModuleType.Items.Add(Adam6000Type.Adam6050W);
            cbxModuleType.Items.Add(Adam6000Type.Adam6051);
            cbxModuleType.Items.Add(Adam6000Type.Adam6051W);
            cbxModuleType.Items.Add(Adam6000Type.Adam6052);
            cbxModuleType.Items.Add(Adam6000Type.Adam6055);
            cbxModuleType.Items.Add(Adam6000Type.Adam6060);
            cbxModuleType.Items.Add(Adam6000Type.Adam6060W);
            cbxModuleType.Items.Add(Adam6000Type.Adam6066);
            cbxModuleType.Items.Add(Adam6000Type.Adam6217);
            cbxModuleType.Items.Add(Adam6000Type.Adam6224);
            cbxModuleType.Items.Add(Adam6000Type.Adam6250);
            cbxModuleType.Items.Add(Adam6000Type.Adam6251);
            cbxModuleType.Items.Add(Adam6000Type.Adam6256);
            cbxModuleType.Items.Add(Adam6000Type.Adam6260);
            cbxModuleType.Items.Add(Adam6000Type.Adam6266);
            cbxModuleType.SelectedIndex = 0;
        }

        private void RefreshAdam6000Information()
        {
            //int iIdx;
            byte byCode;
            ushort usCode;
            int intAdamType;

            Adam6000Type adamType;
            adamType = (Adam6000Type)cbxModuleType.SelectedItem;
            intAdamType = (int)adamType;

            // AI information
            txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString();
            listViewAI.Items.Clear();

            if ((intAdamType == 6017) || ((intAdamType >= 6217) && (intAdamType <= 6224)))
            {
                for (int iIdx = 0; iIdx < AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Ushort); iIdx++)
                {
                    usCode = AnalogInput.GetRangeCode2Byte(adamType, iIdx);
                    listViewAI.Items.Add(new ListViewItem("0x" + usCode.ToString("X04")));				// range code
                    listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetRangeName(adamType, usCode));	// range name
                    listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetUnitName(adamType, usCode));	// unit name
                }
            }
            else
            {
                for (int iIdx = 0; iIdx < AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Byte); iIdx++)
                {
                    byCode = AnalogInput.GetRangeCode(adamType, iIdx);
                    listViewAI.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                    listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetRangeName(adamType, byCode));	// range name
                    listViewAI.Items[iIdx].SubItems.Add(AnalogInput.GetUnitName(adamType, byCode));	// unit name
                }
            }
            
            // AO information
            txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString();
            listViewAO.Items.Clear();

                if ((intAdamType >= 6217) && (intAdamType <= 6224))
                {
                    for (int iIdx = 0; iIdx < AnalogOutput.GetRangeTotal(adamType, Adam6000_RangeFormat.Ushort); iIdx++)
                    {
                        usCode = AnalogOutput.GetRangeCode2Byte(adamType, iIdx);
                        listViewAO.Items.Add(new ListViewItem("0x" + usCode.ToString("X04")));				// range code
                        listViewAO.Items[iIdx].SubItems.Add(AnalogInput.GetRangeName(adamType, usCode));	// range name
                        listViewAO.Items[iIdx].SubItems.Add(AnalogInput.GetUnitName(adamType, usCode));	// unit name
                    }
                }
                else
                {
                    for (int iIdx = 0; iIdx < AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Byte); iIdx++)
                    {
                        byCode = AnalogOutput.GetRangeCode(adamType, iIdx);
                        listViewAO.Items.Add(new ListViewItem("0x" + byCode.ToString("X02")));				// range code
                        listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode));	// range name
                        listViewAO.Items[iIdx].SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode));	// range name
                    }
                }

            // DIO
            txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString();
            txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString();
            // counter
            txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString();
            listViewCounter.Items.Clear();
            if (Counter.GetModeTotal(adamType) > 0)
            {
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam6051_CounterMode.Counter)));		// mode name
                listViewCounter.Items[0].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam6051_CounterMode.Counter));			// unit name
                listViewCounter.Items.Add(new ListViewItem(Counter.GetModeName(adamType, (byte)Adam6051_CounterMode.Frequency)));	// mode name
                listViewCounter.Items[1].SubItems.Add(Counter.GetUnitName(adamType, (byte)Adam6051_CounterMode.Frequency));			// unit name
            }
            // alarm
            listViewAlarm.Items.Clear();
            for (int iIdx = 0; iIdx < Alarm.GetModeTotal(adamType); iIdx++)
            {
                byCode = Alarm.GetModeCode(adamType, iIdx);
                listViewAlarm.Items.Add(new ListViewItem(Alarm.GetModeName(adamType, byCode)));	// mode name
            }
        }
    }
}
