using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Web.Script.Serialization;

namespace WISE_40XXAI
{
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private WISEType m_WISEType;
        private string m_szIP;
        private string m_szAccount;
        private string m_szPassword;
        private int m_iPort;
        private int m_iSlot;
        private int m_iCount;
        private int m_iPollingTime;
        private int m_iAiTotal, m_iDoTotal, m_iDiTotal;
        private bool m_bUDiChannelOccurs = false; //for Universal Input channel
        private List<UiChannelInfo> m_UDiChannelList; //for Universal Input channel
        private int m_iUDiRangeCode; //for Universal Input channel
        private List<Panel> m_AIPanelList;//For initial UI
        private List<Panel> m_DIOPanelList;//For initial UI
        private List<Button> m_DIOBtnList;//For initial UI
        private List<TextBox> m_AITextBoxList;
        private List<CheckBox> m_AICheckboxList;
        private List<TextBox> m_DIOTextBoxList;
        private AdvantechHttpWebUtility m_HttpRequestDI;
        private AdvantechHttpWebUtility m_HttpRequestDO;
        private AdvantechHttpWebUtility m_HttpRequestAI;

        public Form1()
        {
            InitializeComponent();
            m_iUDiRangeCode = 480;
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "192.168.1.1";	// device IP address
            m_iPort = 80;				// Http port is 80
            m_szAccount = "root";  // Login account
            m_szPassword = "00000000"; // Login password
            m_iSlot = 0; //Device localhost default slot is 0
            m_iPollingTime = 1000;

            m_HttpRequestAI = new AdvantechHttpWebUtility();
            m_HttpRequestAI.ResquestOccurredError += this.OnGetAIHttpRequestError;//Delegate callback for resquest value occurred error
            m_HttpRequestAI.ResquestResponded += this.OnGetAIData;

            m_HttpRequestDI = new AdvantechHttpWebUtility();
            m_HttpRequestDI.ResquestOccurredError += this.OnGetDIHttpRequestError;//Delegate callback for resquest value occurred error
            m_HttpRequestDI.ResquestResponded += this.OnGetDIData;


            m_HttpRequestDO = new AdvantechHttpWebUtility();
            m_HttpRequestDO.ResquestOccurredError += this.OnGetDOHttpRequestError;//Delegate callback for resquest value occurred error
            m_HttpRequestDO.ResquestResponded += this.OnGetDOData;

            //m_WISEType = WISEType.WISE4012E; // the sample is for WISE-4012E
            m_WISEType = WISEType.WISE4012; // the sample is for WISE-4012
            //m_WISEType = WISEType.WISE4010LAN; // the sample is for WISE-4010LAN

            m_UDiChannelList = new List<UiChannelInfo>();
            m_AITextBoxList = new List<TextBox>();
            m_AICheckboxList = new List<CheckBox>();
            m_DIOTextBoxList = new List<TextBox>();
            m_AIPanelList = new List<Panel>();
            m_DIOPanelList = new List<Panel>();
            m_DIOBtnList = new List<Button>();

            m_DIOBtnList.Add(this.btnCh0); m_DIOBtnList.Add(this.btnCh1);
            m_DIOBtnList.Add(this.btnCh2); m_DIOBtnList.Add(this.btnCh3);

            m_AIPanelList.Add(this.panelAI0); m_AIPanelList.Add(this.panelAI1);
            m_AIPanelList.Add(this.panelAI2); m_AIPanelList.Add(this.panelAI3);

            m_DIOPanelList.Add(this.panelDIO0); m_DIOPanelList.Add(this.panelDIO1);
            m_DIOPanelList.Add(this.panelDIO2); m_DIOPanelList.Add(this.panelDIO3);

            m_AITextBoxList.Add(this.txtAIValue0); m_AITextBoxList.Add(this.txtAIValue1);
            m_AITextBoxList.Add(this.txtAIValue2); m_AITextBoxList.Add(this.txtAIValue3);

            m_AICheckboxList.Add(this.chkboxCh0); m_AICheckboxList.Add(this.chkboxCh1);
            m_AICheckboxList.Add(this.chkboxCh2); m_AICheckboxList.Add(this.chkboxCh3);

            m_DIOTextBoxList.Add(this.txtDIOValue0); m_DIOTextBoxList.Add(this.txtDIOValue1);
            m_DIOTextBoxList.Add(this.txtDIOValue2); m_DIOTextBoxList.Add(this.txtDIOValue3);

            txtModule.Text = m_WISEType.ToString();
            
            // arrange channel text box

            if (m_WISEType == WISEType.WISE4012)
            {
                Initial_WISE_4012();
            }
            else if (m_WISEType == WISEType.WISE4012E)
            {
                Initial_WISE_4012E();
            }
            else
            {
                Initial_WISE_4010LAN();
            }
        }

        private void Initial_WISE_4010LAN()
        {
            m_iAiTotal = 4;
            m_iDoTotal = 4;
            InitailForm();
        }
        private void Initial_WISE_4012()
        {
            m_iAiTotal = 4;
            m_iDoTotal = 2;
            for (int i = 0; i < m_iAiTotal; i++)
            {
                UiChannelInfo ui = new UiChannelInfo();
                ui.bIsUiChannel = false;
                ui.unit = "";
                m_UDiChannelList.Add(ui);
            }
            InitailForm();
        }
        private void Initial_WISE_4012E()
        {
            m_iAiTotal = 2;
            m_iDoTotal = 2;
            m_iDiTotal = 2;
            InitailForm();
        }
        private void InitailForm()
        {
            for (int aiCh = 0; aiCh < 4; ++aiCh)
                m_AIPanelList[aiCh].Visible = (aiCh < m_iAiTotal)?true:false;
            for (int diCh = 0; diCh < 4; ++diCh)
            {
                if (diCh < m_iDiTotal)
                {
                    m_DIOBtnList[diCh].Text = "DI";
                    m_DIOBtnList[diCh].Enabled = false;
                }
            }
            for (int doCh = m_iDiTotal; doCh < 4; ++doCh)
            {
                if ((doCh - m_iDiTotal )< m_iDoTotal)
                    m_DIOBtnList[doCh].Text = "DO";
                else
                    m_DIOPanelList[doCh].Visible = false;
            }
        }

        private string GetURL(string ip, int port, string requestUri)
        {
            return "http://" + ip + ":" + port.ToString() + "/" + requestUri;
        }

        private void SetTextToTextBox(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)//If need sync with form
            {
                textBox.Invoke((MethodInvoker)delegate()
                {
                    SetTextToTextBox(textBox, text);
                });
            }
            else
            {
                textBox.Text = text;
            }
        }

        private void SetCheckedToCheckBox(CheckBox checkBox, bool status)
        {
            if (checkBox.InvokeRequired)//If need sync with form
            {
                checkBox.Invoke((MethodInvoker)delegate()
                {
                    SetCheckedToCheckBox(checkBox, status);
                });
            }
            else
            {
                checkBox.Checked = status;
            }
        }
        private void OnGetAIHttpRequestError(Exception e)
        {
            string errorMsg = e.Message;
            for (int i = 0; i < m_iAiTotal; ++i)
            {
                SetTextToTextBox(m_AITextBoxList[i], errorMsg);
            }
            InvokeReadStatus();
        }
        private void OnGetDIHttpRequestError(Exception e)
        {
            string errorMsg = e.Message;
            for (int i = 0; i < m_iDiTotal; ++i)
            {
                SetTextToTextBox(m_DIOTextBoxList[i], errorMsg);
            }
            InvokeReadStatus();
        }
        private void OnGetDOHttpRequestError(Exception e)
        {
            string errorMsg = e.Message;
            for (int i = 0; i < m_iDoTotal; ++i)
            {
                SetTextToTextBox(m_DIOTextBoxList[i + +m_iDiTotal], errorMsg);
            }
            InvokeReadStatus();
        }
        private void UpdateAIUIStatus(AISlotValueData ai_values)
        {
            try
            {
                if (ai_values.AIVal != null)
                {
                    for (int i = 0; i < ai_values.AIVal.Length - 1; ++i)
                    {
                        int textboxIndex = ai_values.AIVal[i].Ch;
                        if (ai_values.AIVal[i].En > 0)
                        {
                            int rangeCode = ai_values.AIVal[i].Rng;
                            int aiEvent = ai_values.AIVal[i].Evt;
                            string value = string.Empty;
                            if (m_WISEType == WISEType.WISE4012 && rangeCode == m_iUDiRangeCode) //UI mode
                            {
                                //value = (ai_values.AIVal[i].Val <= 0) ? "Low" : "High";
                                //value = value + " " + WISE_AI_RangeInformation.GetUnit(rangeCode);
                                m_UDiChannelList[ai_values.AIVal[i].Ch].bIsUiChannel = true; //mark channel as UI channel
                                m_UDiChannelList[ai_values.AIVal[i].Ch].unit = WISE_AI_RangeInformation.GetUnit(rangeCode);
                                m_bUDiChannelOccurs = true;
                                continue;
                            }
                            else
                            {
                                if (m_WISEType == WISEType.WISE4012)//WISE-4012 has UI channel
                                {
                                    m_UDiChannelList[ai_values.AIVal[i].Ch].bIsUiChannel = false;  //mark channel as AI channel
                                }
                                if (m_WISEType == WISEType.WISE4012E && ai_values.AIVal[i].Eg != 0) //Eg only exists in WISE-4012E old version
                                {
                                    value = (ai_values.AIVal[i].Evt > 0) ? WISE_AI_RangeInformation.GetEvent(aiEvent) : ((ai_values.AIVal[i].Eg / 1000.0).ToString("0.000") + " " + WISE_AI_RangeInformation.GetUnit(rangeCode));
                                }
                                else
                                {
                                    string unit = WISE_AI_RangeInformation.GetUnit(rangeCode);
                                    float engineerFloatValue = ai_values.AIVal[i].EgF;
                                    if (unit == "V" || unit == "A")
                                    {
                                        engineerFloatValue = engineerFloatValue / 1000;
                                        value = (ai_values.AIVal[i].Evt > 0) ? WISE_AI_RangeInformation.GetEvent(aiEvent) : ((Math.Truncate(engineerFloatValue * 10000) / 10000).ToString("0.0000") + " " + unit);
                                    }
                                    else//mV or mA
                                        value = (ai_values.AIVal[i].Evt > 0) ? WISE_AI_RangeInformation.GetEvent(aiEvent) : (engineerFloatValue + " " + unit);
                                }
                            }
                            SetTextToTextBox(m_AITextBoxList[textboxIndex], value);
                        }
                        else { SetTextToTextBox(m_AITextBoxList[textboxIndex], ""); }

                        SetCheckedToCheckBox(m_AICheckboxList[textboxIndex], Convert.ToBoolean(ai_values.AIVal[i].En));
                    }
                }
                else
                    throw new Exception("Parser AI Data Fail");
            }
            catch (Exception e)
            {
                OnGetAIHttpRequestError(e);
            }
            finally
            {
                System.GC.Collect();
            }
        }
        private void UpdateDIUIStatus(DISlotValueData di_values)
        {
            try
            {
                if (di_values.DIVal != null)
                {
                    if (m_bUDiChannelOccurs)//check Universal Input channel
                    {
                        for (int i = 0; i < di_values.DIVal.Length; ++i)
                        {
                            int textboxIndex = di_values.DIVal[i].Ch;
                            if (m_UDiChannelList[textboxIndex].bIsUiChannel)
                            {
                                string value = m_UDiChannelList[textboxIndex].unit + " ";
                                value += di_values.DIVal[i].Val.ToString();
                                SetTextToTextBox(m_AITextBoxList[textboxIndex], value);
                            }
                        }
                    }

                    for (int i = 0; i < di_values.DIVal.Length; ++i)
                    {
                        int textboxIndex = di_values.DIVal[i].Ch;
                        SetTextToTextBox(m_DIOTextBoxList[textboxIndex], di_values.DIVal[i].Val.ToString());
                    }
                }
                else
                {
                    throw new Exception("Parser DI Data Fail");
                }
            }
            catch (Exception e)
            {
                OnGetDIHttpRequestError(e);
            }
            finally
            {
                System.GC.Collect();
            }
        }

        private void UpdateDOUIStatus(DOSlotValueData do_values)
        {
            try
            {
                if (do_values.DOVal != null)
                {
                    for (int i = 0; i < do_values.DOVal.Length; ++i)
                    {
                        int textboxIndex = do_values.DOVal[i].Ch + m_iDiTotal;
                        SetTextToTextBox(m_DIOTextBoxList[textboxIndex], do_values.DOVal[i].Val.ToString());
                    }
                }
                else
                {
                    throw new Exception("Parser DO Data Fail");
                }
            }
            catch (Exception e)
            {
                OnGetDOHttpRequestError(e);
            }
            finally
            {
                System.GC.Collect();
            }
        }
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelDIO.Enabled = false;
                m_bStart = false;		// starting flag
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                panelDIO.Enabled = true;
                m_iCount = 0; // reset the reading counter
                buttonStart.Text = "Stop";
                m_bStart = true; // starting flag
                InvokeReadStatus();

            }
        }
        private void GetDIValue()
        {
            m_HttpRequestDI.SendGETRequest(this.m_szAccount, this.m_szPassword, GetURL(this.m_szIP, this.m_iPort, WISE_RESTFUL_URI.di_value.ToString() + "/slot_" + this.m_iSlot));
        }
        private void GetDOValue()
        {
            m_HttpRequestDO.SendGETRequest(this.m_szAccount, this.m_szPassword, GetURL(this.m_szIP, this.m_iPort, WISE_RESTFUL_URI.do_value.ToString() + "/slot_" + this.m_iSlot));
        }
        private void GetAIValue()
        {
            m_HttpRequestAI.SendGETRequest(this.m_szAccount, this.m_szPassword, GetURL(this.m_szIP, this.m_iPort, WISE_RESTFUL_URI.ai_value.ToString() + "/slot_" + this.m_iSlot));
        }
        private void RefreshIOStatus()
        {
            SetTextToTextBox(txtReadCount, "Requesting http...");
            if(this.m_iAiTotal > 0)
                GetAIValue();
            else if(this.m_iDiTotal > 0)
                GetDIValue();
            else if(this.m_iDoTotal > 0)
                GetDOValue();
        }
        private void OnGetDIData(string rawData)
        {
            var dateObj = AdvantechHttpWebUtility.ParserJsonToObj<DISlotValueData>(rawData);
            UpdateDIUIStatus(dateObj);
            if (this.m_iDoTotal > 0)//has DO
            {
                GetDOValue();
            }
            else
            {
                InvokeReadStatus(); 
            }
        }
        private void OnGetDOData(string rawData)
        {
            var dateObj = AdvantechHttpWebUtility.ParserJsonToObj<DOSlotValueData>(rawData);
            UpdateDOUIStatus(dateObj);
            InvokeReadStatus(); 
        }
        private void OnGetAIData(string rawData)
        {
            var dateObj = AdvantechHttpWebUtility.ParserJsonToObj<AISlotValueData>(rawData);
            UpdateAIUIStatus(dateObj);
            if (this.m_iDiTotal > 0 || m_bUDiChannelOccurs)
                GetDIValue();
            else if (this.m_iDoTotal > 0)
                GetDOValue();
            else
                InvokeReadStatus();
        }
        private void InvokeReadStatus()
        {
            m_iCount++; // increment the reading counter
            SetTextToTextBox(txtReadCount, "Request http " + m_iCount.ToString() + " times...");
            Thread.Sleep(m_iPollingTime);
            if (this.m_bStart)
            {
                RefreshIOStatus();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            DOSetValueData doData = new DOSetValueData() { Val = (uint)((txtBox.Text == "1") ? 0 : 1) }; // was ON, now set to OFF };
            int iChannel = i_iCh - m_iDiTotal;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sz_Jsonify = serializer.Serialize(doData);
            try
            {
                AdvantechHttpWebUtility httpRequest = new AdvantechHttpWebUtility();
                httpRequest.SendPATCHRequest(m_szAccount, m_szPassword, GetURL(m_szIP, m_iPort, WISE_RESTFUL_URI.do_value + "/slot_" + m_iSlot + "/ch_" + iChannel), sz_Jsonify);
            }
            catch
            {
                MessageBox.Show("Set digital output failed!", "Error");
            }
            finally
            {
                System.GC.Collect();
            }
        }
        
        private void btnCh0_Click(object sender, EventArgs e)
        {
            btnCh_Click(0, txtDIOValue0);
        }

        private void btnCh1_Click(object sender, EventArgs e)
        {
            btnCh_Click(1, txtDIOValue1);
        }

        private void btnCh2_Click(object sender, EventArgs e)
        {
            btnCh_Click(2, txtDIOValue2);
        }

        private void btnCh3_Click(object sender, EventArgs e)
        {
            btnCh_Click(3, txtDIOValue3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                m_bStart = !m_bStart;
            }
        }
    }

    /// <summary>
    ///emun WISE series device
    /// </summary>
    public enum WISEType
    {
        WISE4010LAN = 4010,
        WISE4050LAN = 4050,
        WISE4060LAN = 4060,
        WISE4012 = 24012,
        WISE4012E = 34012,
        WISE4050 = 24050,
        WISE4060 = 24060,
    }
    public class WISE_AI_RangeInformation
    {
        public static string[] EventStatusEmun = { 
                                                "Fail to provide AI value (UART timeout/ADC error)", //0
                                               "Over Range",
                                               "Under Range",
                                               "Open Circuit (Burnout)", //3
                                               "Reserved",
                                               "Unavailable Channel Configuration", //5
                                               "Reserved",
                                               "ADC initializing/Error", //7
                                               "Reserved",
                                               "Zero/Span Calibration Error"};
        public static string GetUnit(int code){
            switch(code){
                case 259: 
                case 260: 
                case 261: 
                case 262: 
                    return "mV";
                case 328: 
                case 320: 
                case 321: 
                case 322: 
                case 323: 
                case 325: 
                case 327: 
                    return "V";
                case 384: 
                case 385: 
                case 386: 
                    return "mA";
                case 480: //UI Mode
                    return "(UI Mode)";
            }
            return "Invalid Code";
        }
        public static string GetEvent(int evtMask)
        {
            var eventStatus = "";
            var evtEmunLength = EventStatusEmun.Length;
            uint mask = (uint)evtMask; 
            for(int i = 0; i <= evtEmunLength; ++i){
                if ((mask & 0x01) == 1)
                {
                    eventStatus += (EventStatusEmun[i]+" ");    
                }
                mask >>= 1;
            }
            return eventStatus;
        }
    }
    /// <summary>
    ///Universal Input channel information Object
    /// </summary>
    public class UiChannelInfo
    {
        public bool bIsUiChannel;
        public string unit;
    }
    /// <summary>
    ///emun Http request method
    /// </summary>
    public enum HttpRequestOption
    {
        GET,
        PATCH
    }
    /// <summary>
    ///emun WISE series Restful URI 
    /// </summary>
    public enum WISE_RESTFUL_URI
    {
        config,
        file_xfer,
        profile,
        sys_info,
        gen_config,
        control,
        net_basic,
        net_config,
        di_config,
        di_value,
        do_config,
        do_value,
        ai_genconfig,
        ai_config,
        ai_value,
        modbus_coilconfig,
        modbus_regconfig,
        modbus_coilbas,
        modbus_coillen,
        modbus_regbas,
        modbus_reglen,
        accessctrl,
        log_dataoption,
        log_control,
        log_output,
        log_message,
        log_event,
        logex_output,
        logex_file,
        logex_list,
        datastream,
        p2p_mode,
        p2p_basic,
        p2p_advanced,
        wlan_config

    }
    /// <summary>
    /// Do value object
    /// </summary>
    public class DOValueData
    {
        public int Ch { get; set; }//Channel Number
        public int Md { get; set; }//Mode
        public int Stat { get; set; }//Signal Logic Status
        public uint Val { get; set; }//Channel Value
        public int PsCtn { get; set; }//Pulse Output Continue State
        public int PsStop { get; set; }//Stop Pulse Output
        public uint PsIV { get; set; }//Incremental Pulse Output Value

    }
    /// <summary>
    /// Do slot value object
    /// </summary>
    public class DOSetValueData
    {
        public uint Val { get; set; }//Channel Value
    }
    /// <summary>
    /// DO channel value object
    /// </summary>
    public class DOSlotValueData
    {
        public DOValueData[] DOVal { get; set; }//Array of Digital output values
    }
    /// <summary>
    /// DI channel value object
    /// </summary>
    public class DIValueData
    {
        public int Ch { get; set; }//Channel Number
        public int Md { get; set; }//Mode
        public uint Val { get; set; }//Channel Value
        public int Stat { get; set; }//Signal Logic Status
        public int Cnting { get; set; }//Start Counter
        public int OvLch { get; set; }//Counter Overflow or Latch Status

    }
    /// <summary>
    /// AI slot value object
    /// </summary>
    public class AISlotValueData
    {
        public AIValueData[] AIVal { get; set; }//Array of Digital input values
    }
    /// <summary>
    /// AI channel value object
    /// </summary>
    public class AIValueData
    {
        public int Ch { get; set; }//Channel Number
        public int En { get; set; }//Is Enable
        public int Rng { get; set; }//Range
        public int Val { get; set; }//Channel Raw Value
        public int Eg { get; set; }//Engineering Value
        public int Evt { get; set; }//Event Status
        public int LoA { get; set; }//Low Alarm Status
        public int HiA { get; set; }//High Alarm Status
        public int HVal { get; set; }//Maximum AI Raw Value
        public int HEg { get; set; }//Maximum AI Engineering data
        public int LVal { get; set; }//Minimum AI Raw Value
        public int LEg { get; set; }//Minimum AI Engineering data
        public int SVal { get; set; }//Channel Raw Value After Scaling
        public int ClrH { get; set; }//Clear Maximum AI Value
        public int ClrL { get; set; }//Clear Minimum AI Value

        public float EgF { get; set; }//Channel Engineering data(floating type)
        public float HEgF { get; set; }//Maximum AI Engineering data(floating type)
        public float LEgF { get; set; }//Minimum AI Engineering data(floating type)

    }
    /// <summary>
    /// DI value object under slot
    /// </summary>
    public class DISlotValueData
    {
        public DIValueData[] DIVal { get; set; }//Array of Digital input values
    }
    public delegate void ResquestRespondedCallback(string raw_data);//Define callback function for request has been responded.
    public delegate void ResquestOccurredErrorCallback(Exception e);//Define callback function for request has occurred error.

    public class AdvantechHttpWebUtility
    {
        public event ResquestRespondedCallback ResquestResponded;
        public event ResquestOccurredErrorCallback ResquestOccurredError;

        protected string BasicAuthAccount { get; set; }
        protected string BasicAuthPassword { get; set; }
        protected string URL { get; set; }
        protected string JsonifyString { get; set; }
        protected bool HasData { get; set; }
        protected HttpRequestOption Method { get; set; }

        public AdvantechHttpWebUtility()
        {
        }
        /// <summary>
        /// Invoke ResquestResponded Callback function
        /// </summary>
        /// <param name="raw_data"></param>
        protected virtual void OnResquestResponded(string raw_data)
        {
            if (ResquestResponded != null)
            {
                ResquestResponded.Invoke(raw_data);
            }
        }
        public static T ParserJsonToObj<T>(string jsonifyString)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var values = serializer.Deserialize<T>(jsonifyString);
            return values;
        }
        /// <summary>
        /// Invoke ResquestOccurredError Callback function
        /// </summary>
        /// <param name="raw_data"></param>
        protected virtual void OnResquestOccurredError(Exception e)
        {
            if (ResquestOccurredError != null)
            {
                ResquestOccurredError.Invoke(e);
            }
        }

        public void SendGETRequest(string account, string password, string URL)
        {
            this.BasicAuthAccount = account;
            this.BasicAuthPassword = password;
            this.URL = URL;
            this.HasData = false;
            this.Method = HttpRequestOption.GET;
            SendRequest();
        }

        public void SendPATCHRequest(string account, string password, string URL, string JSONString)
        {
            this.BasicAuthAccount = account;
            this.BasicAuthPassword = password;
            this.URL = URL;
            this.JsonifyString = JSONString;
            this.HasData = true;
            this.Method = HttpRequestOption.PATCH;
            SendRequest();
        }
        protected void SendRequest()
        {

            HttpWebRequest myRequest;
            System.IO.Stream outputStream;// End the stream request operation

            myRequest = (HttpWebRequest)WebRequest.Create(this.URL); // create request
            myRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(this.BasicAuthAccount + ":" + this.BasicAuthPassword)));
            myRequest.Method = Method.ToString();
            myRequest.KeepAlive = false;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ReadWriteTimeout = 1000;
            // Create the patch data
            if (this.HasData)//Append data for send
            {
                byte[] byData = Encoding.ASCII.GetBytes(this.JsonifyString); // convert POST data to bytes
                myRequest.ContentLength = byData.Length;
                // Add the post data to the web request
                outputStream = myRequest.GetRequestStream();
                outputStream.Write(byData, 0, byData.Length);
                outputStream.Close();
            }
            try
            {
                myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallback), myRequest);
            }
            catch (Exception e)
            {
                OnResquestOccurredError(e);
            }
        }
        void GetResponsetStreamCallback(IAsyncResult callbackResult)
        {
            bool bRet = false;
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            string result = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
                using (System.IO.StreamReader httpWebStreamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = httpWebStreamReader.ReadToEnd();
                        bRet = true;
                    }
                    else
                        OnResquestOccurredError(new Exception(response.StatusCode.ToString()));
                }
                response.Close();
            }
            catch (Exception e)
            {
                OnResquestOccurredError(e);
            }
            finally
            {
                request.Abort();
                if (bRet)
                    OnResquestResponded(result);
            }
        }
    }
}
