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

namespace ADAM36XXDIO
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        private const int MAX_DI_NUMBER = 16, MAX_DO_NUMBER = 8;
        private bool m_bStart;
        private ADAM3600Type m_Adam3600Type;
        private string m_szIP;
        private string m_szAccount;
        private string m_szPassword;
        private int m_iPort;
        private int m_iSlot;
        private int m_iPollingTime;
        private int m_iDoTotal, m_iDiTotal, m_iCount;
        private List<TextBox> m_textBoxList;//For initial UI
        private List<Panel> m_DIOPanelList;//For initial UI
        private List<Button> m_DIOBtnList;//For initial UI
        private AdvantechHttpWebUtility m_HttpRequestDI;
        private AdvantechHttpWebUtility m_HttpRequestDO;
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.105";	// device IP address
            m_iPort = 80;				// http port is 80
            m_szAccount = "root";  // Login account
            m_szPassword = "00000000"; // Login password
            m_iPollingTime = 1000;
            m_iSlot = 0; //Range form 0~4, Device localhost default slot is 0

            m_Adam3600Type = ADAM3600Type.ADAM3600; // the sample is for ADAM-3600
            //m_Adam3600Type = ADAM3600Type.ADAM3651; // the sample is for ADAM-3651
            //m_Adam3600Type = ADAM3600Type.ADAM3656; // the sample is for ADAM-3656
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtModule.Text = m_Adam3600Type.ToString();
            txtSlot.Text = "Slot " + m_iSlot.ToString();
            m_textBoxList = new List<TextBox>();
            m_textBoxList.Add(txtCh0); m_textBoxList.Add(txtCh1);
            m_textBoxList.Add(txtCh2); m_textBoxList.Add(txtCh3);
            m_textBoxList.Add(txtCh4); m_textBoxList.Add(txtCh5);
            m_textBoxList.Add(txtCh6); m_textBoxList.Add(txtCh7);
            m_textBoxList.Add(txtCh8); m_textBoxList.Add(txtCh9);
            m_textBoxList.Add(txtCh10); m_textBoxList.Add(txtCh11);
            m_textBoxList.Add(txtCh12); m_textBoxList.Add(txtCh13);
            m_textBoxList.Add(txtCh14); m_textBoxList.Add(txtCh15);
            m_textBoxList.Add(txtCh16); m_textBoxList.Add(txtCh17);
            m_textBoxList.Add(txtCh18); m_textBoxList.Add(txtCh19);
            m_textBoxList.Add(txtCh20); m_textBoxList.Add(txtCh21);
            m_textBoxList.Add(txtCh22); m_textBoxList.Add(txtCh23);

            m_DIOPanelList = new List<Panel>();
            m_DIOPanelList.Add(panelCh0); m_DIOPanelList.Add(panelCh1);
            m_DIOPanelList.Add(panelCh2); m_DIOPanelList.Add(panelCh3);
            m_DIOPanelList.Add(panelCh4); m_DIOPanelList.Add(panelCh5);
            m_DIOPanelList.Add(panelCh6); m_DIOPanelList.Add(panelCh7);
            m_DIOPanelList.Add(panelCh8); m_DIOPanelList.Add(panelCh9);
            m_DIOPanelList.Add(panelCh10); m_DIOPanelList.Add(panelCh11);
            m_DIOPanelList.Add(panelCh12); m_DIOPanelList.Add(panelCh13);
            m_DIOPanelList.Add(panelCh14); m_DIOPanelList.Add(panelCh15);
            m_DIOPanelList.Add(panelCh16); m_DIOPanelList.Add(panelCh17);
            m_DIOPanelList.Add(panelCh18); m_DIOPanelList.Add(panelCh19);
            m_DIOPanelList.Add(panelCh20); m_DIOPanelList.Add(panelCh21);
            m_DIOPanelList.Add(panelCh22); m_DIOPanelList.Add(panelCh23);

            m_DIOBtnList = new List<Button>();
            m_DIOBtnList.Add(btnCh0); m_DIOBtnList.Add(btnCh1);
            m_DIOBtnList.Add(btnCh2); m_DIOBtnList.Add(btnCh3);
            m_DIOBtnList.Add(btnCh4); m_DIOBtnList.Add(btnCh5);
            m_DIOBtnList.Add(btnCh6); m_DIOBtnList.Add(btnCh7);
            m_DIOBtnList.Add(btnCh8); m_DIOBtnList.Add(btnCh9);
            m_DIOBtnList.Add(btnCh10); m_DIOBtnList.Add(btnCh11);
            m_DIOBtnList.Add(btnCh12); m_DIOBtnList.Add(btnCh13);
            m_DIOBtnList.Add(btnCh14); m_DIOBtnList.Add(btnCh15);
            m_DIOBtnList.Add(btnCh16); m_DIOBtnList.Add(btnCh17);
            m_DIOBtnList.Add(btnCh18); m_DIOBtnList.Add(btnCh19);
            m_DIOBtnList.Add(btnCh20); m_DIOBtnList.Add(btnCh21);
            m_DIOBtnList.Add(btnCh22); m_DIOBtnList.Add(btnCh23);

            m_HttpRequestDI = new AdvantechHttpWebUtility();
            m_HttpRequestDI.ResquestOccurredError += this.OnGetDIHttpRequestError;
            m_HttpRequestDI.ResquestResponded += this.OnGetDIData;
            m_HttpRequestDO = new AdvantechHttpWebUtility();
            m_HttpRequestDO.ResquestOccurredError += this.OnGetDOHttpRequestError;
            m_HttpRequestDO.ResquestResponded += this.OnGetDOData;
            if (m_Adam3600Type == ADAM3600Type.ADAM3600)
            {
                Initial_ADAM_3600();
            }
            else if (m_Adam3600Type == ADAM3600Type.ADAM3651)
            {
                Initial_ADAM_3651();
            }
            else
            {
                Initial_ADAM_3656();
            }
        }

        private void Initial_ADAM_3600()
        {
            m_iDoTotal = 8;
            m_iDiTotal = 16;
            InitailForm();
        }
        private void Initial_ADAM_3651()
        {
            m_iDoTotal = 0;
            m_iDiTotal = 8;
            InitailForm();
        }
        private void Initial_ADAM_3656()
        {
            m_iDoTotal = 8;
            m_iDiTotal = 0;
            InitailForm();
        }
        private void InitailForm()
        {
            for (int diCh = 0; diCh < MAX_DI_NUMBER; ++diCh)
            {
                if (diCh < m_iDiTotal)
                {
                    m_DIOBtnList[diCh].Text = "DI";
                    m_DIOBtnList[diCh].Enabled = false;
                }
            }
            for (int doCh = m_iDiTotal; doCh < MAX_DO_NUMBER + MAX_DI_NUMBER; ++doCh)
            {
                if ((doCh - m_iDiTotal) < m_iDoTotal)
                    m_DIOBtnList[doCh].Text = "DO";
                else
                    m_DIOPanelList[doCh].Visible = false;
            }
        }
        private string GetURL(string ip, int port, string requestUri)
        {
            return "http://"+ip + ":" + port.ToString() + "/" + requestUri;
        }

        private void SetTextToTextBox( TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
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
        private void OnGetDIHttpRequestError(Exception e)
        {
            for (int i = 0; i < m_iDiTotal; ++i)
            {
                SetTextToTextBox(m_textBoxList[i], e.Message);
            }
        }
        private void OnGetDOHttpRequestError(Exception e)
        {
            for (int i = 0; i < m_iDoTotal; ++i)
            {
                SetTextToTextBox(m_textBoxList[i + m_iDiTotal], e.Message);
            }
        }
        private void UpdateDIUIStatus(DISlotValueData di_values)
        {
            try
            {
                if (di_values.DIVal != null)
                {
                    for (int i = 0; i < di_values.DIVal.Length; ++i)
                    {
                        int textboxIndex = di_values.DIVal[i].Ch;
                        SetTextToTextBox(m_textBoxList[textboxIndex], di_values.DIVal[i].Val.ToString());
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
                        SetTextToTextBox(m_textBoxList[textboxIndex], do_values.DOVal[i].Val.ToString());
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
        private void GetDIValue()
        {
            m_HttpRequestDI.SendGETRequest(this.m_szAccount, this.m_szPassword, GetURL(this.m_szIP, this.m_iPort, WISE_RESTFUL_URI.di_value.ToString() + "/slot_" + this.m_iSlot));
        }
        private void GetDOValue()
        {
            m_HttpRequestDO.SendGETRequest(this.m_szAccount, this.m_szPassword, GetURL(this.m_szIP, this.m_iPort, WISE_RESTFUL_URI.do_value.ToString() + "/slot_" + this.m_iSlot));
        }
        private void RefreshIOStatus()
        {
            SetTextToTextBox(txtReadCount, "Requesting http...");
            if (this.m_iDiTotal > 0)
                GetDIValue();
            else
                GetDOValue();
        }
        private void OnGetDIData(string rawData)
        {
            var dateObj = AdvantechHttpWebUtility.ParserJsonToObj<DISlotValueData>(rawData);
            UpdateDIUIStatus(dateObj);
            GetDOValue();
        }
        private void OnGetDOData(string rawData)
        {
            var dateObj = AdvantechHttpWebUtility.ParserJsonToObj<DOSlotValueData>(rawData);
            UpdateDOUIStatus(dateObj);
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
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                m_bStart = !m_bStart;
            }
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            DOSetValueData doData = new DOSetValueData() { Val = (txtBox.Text == "1") ? 0 : 1 }; // was ON, now set to OFF };
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
                this.InvokeReadStatus();
            }		
        }
        private void btnCh0_Click(object sender, EventArgs e)
        {
            btnCh_Click(0, txtCh0);
        }

        private void btnCh1_Click(object sender, EventArgs e)
        {
            btnCh_Click(1, txtCh1);
        }

        private void btnCh2_Click(object sender, EventArgs e)
        {
            btnCh_Click(2, txtCh2);
        }

        private void btnCh3_Click(object sender, EventArgs e)
        {
            btnCh_Click(3, txtCh3);
        }

        private void btnCh4_Click(object sender, EventArgs e)
        {
            btnCh_Click(4, txtCh4);
        }

        private void btnCh5_Click(object sender, EventArgs e)
        {
            btnCh_Click(5, txtCh5);
        }

        private void btnCh6_Click(object sender, EventArgs e)
        {
            btnCh_Click(6, txtCh6);
        }

        private void btnCh7_Click(object sender, EventArgs e)
        {
            btnCh_Click(7, txtCh7);
        }

        private void btnCh8_Click(object sender, EventArgs e)
        {
            btnCh_Click(8, txtCh8);
        }

        private void btnCh9_Click(object sender, EventArgs e)
        {
            btnCh_Click(9, txtCh9);
        }

        private void btnCh10_Click(object sender, EventArgs e)
        {
            btnCh_Click(10, txtCh10);
        }

        private void btnCh11_Click(object sender, EventArgs e)
        {
            btnCh_Click(11, txtCh11);
        }

        private void btnCh12_Click(object sender, EventArgs e)
        {
            btnCh_Click(12, txtCh12);
        }

        private void btnCh13_Click(object sender, EventArgs e)
        {
            btnCh_Click(13, txtCh13);
        }

        private void btnCh14_Click(object sender, EventArgs e)
        {
            btnCh_Click(14, txtCh14);
        }

        private void btnCh15_Click(object sender, EventArgs e)
        {
            btnCh_Click(15, txtCh15);
        }

        private void btnCh16_Click(object sender, EventArgs e)
        {
            btnCh_Click(16, txtCh16);
        }

        private void btnCh17_Click(object sender, EventArgs e)
        {
            btnCh_Click(17, txtCh17);
        }

        private void btnCh18_Click(object sender, EventArgs e)
        {
            btnCh_Click(18, txtCh18);
        }

        private void btnCh19_Click(object sender, EventArgs e)
        {
            btnCh_Click(19, txtCh19);
        }

        private void btnCh20_Click(object sender, EventArgs e)
        {
            btnCh_Click(20, txtCh20);
        }

        private void btnCh21_Click(object sender, EventArgs e)
        {
            btnCh_Click(21, txtCh21);
        }

        private void btnCh22_Click(object sender, EventArgs e)
        {
            btnCh_Click(22, txtCh22);
        }

        private void btnCh23_Click(object sender, EventArgs e)
        {
            btnCh_Click(23, txtCh23);
        }
    }
    /// <summary>
    ///emun WISE series device
    /// </summary>
    public enum ADAM3600Type
    {
        ADAM3600 = 3600,
        ADAM3651 = 3651,
        ADAM3656 = 3656,
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
        public int Val { get; set; }//Channel Value
        public int PsCtn { get; set; }//Pulse Output Continue State
        public int PsStop { get; set; }//Stop Pulse Output
        public int PsIV { get; set; }//Incremental Pulse Output Value

    }
    /// <summary>
    /// Do value object
    /// </summary>
    public class DOSetValueData
    {
        public int Val { get; set; }//Channel Value
    }
    public class DOSlotValueData
    {
        public DOValueData[] DOVal{ get; set; }//Array of Digital output values
    }
    /// <summary>
    /// DI value object
    /// </summary>
    public class DIValueData
    {
        public int Ch { get; set; }//Channel Number
        public int Md { get; set; }//Mode
        public int Val { get; set; }//Channel Value
        public int Stat { get; set; }//Signal Logic Status
        public int Cnting { get; set; }//Start Counter
        public int OvLch { get; set; }//Counter Overflow or Latch Status

    }
    public class DISlotValueData
    {
        public DIValueData[] DIVal{ get; set; }//Array of Digital output values
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
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            string result = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
                using (System.IO.StreamReader httpWebStreamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                        result = httpWebStreamReader.ReadToEnd();
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
                OnResquestResponded(result);
            }
        }
    }

}