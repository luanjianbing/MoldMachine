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

namespace WISE40XXDIO
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private WISEType m_WISE4000Type;
        private string m_szIP;
        private string m_szAccount;
        private string m_szPassword;
        private int m_iPort;
        private int m_iSlot;
        private int m_iPollingTime;
        private int m_iDoTotal, m_iDiTotal, m_iCount;
        private List<TextBox> m_textBoxList;
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
            m_szIP = "10.0.0.1";	// device IP address
            m_iPort = 80;				// http port is 80
            m_szAccount = "root";  // Login account
            m_szPassword = "00000000"; // Login password
            m_iPollingTime = 1000;
            m_iSlot = 0; //Device localhost default slot is 0

            //m_WISE4000Type = WISEType.WISE4050LAN; // the sample is for WISE-4050/LAN
            //m_WISE4000Type = WISEType.WISE4050; // the sample is for Wise-4050
            m_WISE4000Type = WISEType.WISE4051; // the sample is for Wise-4051
            //m_WISE4000Type = WISEType.WISE4060LAN; // the sample is for Wise-4060/LAN
           // m_WISE4000Type = WISEType.WISE4060; // the sample is for Wise-4060

            txtModule.Text = m_WISE4000Type.ToString();
            m_textBoxList = new List<TextBox>();
            m_textBoxList.Add(txtCh0);  m_textBoxList.Add(txtCh1);
            m_textBoxList.Add(txtCh2);  m_textBoxList.Add(txtCh3);
            m_textBoxList.Add(txtCh4);  m_textBoxList.Add(txtCh5);
            m_textBoxList.Add(txtCh6);  m_textBoxList.Add(txtCh7);
            m_textBoxList.Add(txtCh8);  m_textBoxList.Add(txtCh9);
            m_textBoxList.Add(txtCh10); m_textBoxList.Add(txtCh11);
            m_HttpRequestDI = new AdvantechHttpWebUtility();
            m_HttpRequestDI.ResquestOccurredError += this.OnGetDIHttpRequestError;
            m_HttpRequestDI.ResquestResponded += this.OnGetDIData;
            m_HttpRequestDO = new AdvantechHttpWebUtility();
            m_HttpRequestDO.ResquestOccurredError += this.OnGetDOHttpRequestError;
            m_HttpRequestDO.ResquestResponded += this.OnGetDOData;
            IniWISE_DIO();
        }

        protected void InitChannelItems(bool i_bVisable, bool i_bIsDI, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh)
        {
            int iCh;
            if (i_bVisable)
            {
                panelCh.Visible = true;
                iCh = i_iDI + i_iDO;
                if (i_bIsDI) // DI
                {
                    btnCh.Text = "DI " + i_iDI.ToString();
                    btnCh.Enabled = false;
                    i_iDI++;
                }
                else // DO
                {
                    btnCh.Text = "DO " + i_iDO.ToString();
                    i_iDO++;
                }
            }
            else
                panelCh.Visible = false;
        }

        protected void IniWISE_DIO()
        {
            int iDI = 0, iDO = 0;
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            InitChannelItems(false, false, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, false, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, false, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, false, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
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
                SetTextToTextBox(m_textBoxList[i + +m_iDiTotal], e.Message);
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
            if(this.m_iDoTotal > 0)
                GetDOValue();
            else
                InvokeReadStatus();
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
        WISE4051 = 24051,
        WISE4060 = 24060,
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
    /// Do value object
    /// </summary>
    public class DOSetValueData
    {
        public uint Val { get; set; }//Channel Value
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
        public uint Val { get; set; }//Channel Value
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