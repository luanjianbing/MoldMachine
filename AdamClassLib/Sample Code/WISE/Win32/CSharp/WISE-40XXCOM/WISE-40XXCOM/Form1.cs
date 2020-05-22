using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WISE_4000_REST
{
    public partial class Form1 : Form
    {
        AdvantechHttpWebUtility m_httpRequest;
        int MAX_CHANNEL_NUMBER = 32;
        String expansion_type = String.Empty;
        string[] evtCodeString = { "No error", "Illegal function", "Illegal data address", "Illegal data value", "Slave device failure", "Acknowledge", "Slave device busy", "Negative acknowledge", "Memory parity error", "Reserved", "Gateway path unavailable", "Gateway target device failed to respond", "Reserved", "Reserved", "Reserved", "Reserved", "Unavailable", "Slave response timeout", "Checksum error", "Received data error", "Send request fail", "Unprocessed" };

        public Form1()
        {
            InitializeComponent();
            m_httpRequest = new AdvantechHttpWebUtility();
            comboBox1.SelectedIndex = 0;
            comboBoxUrl1.SelectedIndex = 0;
            comboBoxUrl2.SelectedIndex = 0;
            m_httpRequest.ResquestResponded += this.OnGetRequestData;
            m_httpRequest.ResquestOccurredError += this.OnGetErrorRequest;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            //Add default 32 channels in dataGridView
            for (int i = 0; i < MAX_CHANNEL_NUMBER; i++ )
            {
                dataGridView1.Rows.Add(i, "", "", "", "", "");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + comboBoxUrl1.SelectedItem + "/" + comboBoxUrl2.SelectedItem;
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
        private void SetBtnToEnabled(Button btn, bool enabled)
        {
            if (btn.InvokeRequired)//If need sync with form
            {
                btn.Invoke((MethodInvoker)delegate()
                {
                    SetBtnToEnabled(btn, enabled);
                });
            }
            else
            {
                btn.Enabled = enabled;
            }
        }

        private void OnGetRequestData(string rawData)
        {
            var dataObj = (ExpansionValueData[])null;
            if (expansion_type == "expansion_bit") 
            {
                dataObj = (AdvantechHttpWebUtility.ParserJsonToObj<ExpansionBitObject>(rawData)).ExpBit;
            }
            else 
            {
                dataObj = (AdvantechHttpWebUtility.ParserJsonToObj<ExpansionWordObject>(rawData)).ExpWord;
            }
            //update data grid values
            int length = dataObj.Length;
            String evtString = String.Empty;
            uint evtWriteOnlyBit =0;
            for (int i = 0; i < length; i++)
            {
                evtWriteOnlyBit = dataObj[i].Evt >> 7;
                dataObj[i].Evt = dataObj[i].Evt & 0x7F;//strip bit 7
                evtString = evtCodeString[dataObj[i].Evt];
                if (evtWriteOnlyBit == 1)
                    dataGridView1.Rows[i].SetValues(new object[] { dataObj[i].Ch, "(Write Only)", evtString, dataObj[i].SID, dataObj[i].Addr, dataObj[i].MAddr });
                else
                    dataGridView1.Rows[i].SetValues(new object[] { dataObj[i].Ch, dataObj[i].Val, evtString, dataObj[i].SID, dataObj[i].Addr, dataObj[i].MAddr });
            }
            SetTextToTextBox(txtJSON, "Response reveived.");
            SetBtnToEnabled(btnSend,true);
        }
        private void OnGetErrorRequest(Exception e)
        {
            SetTextToTextBox(txtJSON, e.Message);
            SetBtnToEnabled(btnSend, true);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnSend.Enabled = false;
                string account  = txtAcount.Text,
                       password = txtPassword.Text,
                       URL = txtURL.Text;
                SetTextToTextBox(txtJSON, "Requesting http...");
                m_httpRequest.SendGETRequest(account, password, URL);
            }
            catch (Exception err)
            {
                txtJSON.Text = err.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string method = (string)cmb.SelectedItem;
        }

        private void comboBoxUrl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + comboBoxUrl1.SelectedItem + "/" + comboBoxUrl2.SelectedItem;
            expansion_type = (String)comboBoxUrl1.SelectedItem;
        }

        private void comboBoxUrl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + comboBoxUrl1.SelectedItem + "/" + comboBoxUrl2.SelectedItem;
        }

        private void txtIPAddress_textChanged(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + comboBoxUrl1.SelectedItem + "/" + comboBoxUrl2.SelectedItem;
        }
    }
    /// <summary>
    /// Expansion values object
    /// </summary>
    public class ExpansionValueData
    {
        public uint Ch { get; set; }//Channel Number
        public uint Val { get; set; }//Channel Value
        public uint Evt { get; set; }//Channel Error Code
        public int SID { get; set; }//Slave ID
        public int Addr { get; set; }//Slave Modbus address
        public int MAddr { get; set; }//Modbus TCP Mapping Address
    }
    /// <summary>
    /// Expansion bit object
    /// </summary>
    public class ExpansionBitObject
    {
        public ExpansionValueData[] ExpBit { get; set; }//Array of Expansion values
    }
    /// <summary>
    /// Expansion word object
    /// </summary>
    public class ExpansionWordObject
    {
        public ExpansionValueData[] ExpWord { get; set; }//Array of Expansion values
    }
    /// <summary>
    ///emun Http request method
    /// </summary>
    public enum HttpRequestOption
    {
        GET,
        PATCH
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
                        if (response.ContentLength > 0)
                        {
                            result = httpWebStreamReader.ReadToEnd();
                        }
                        else
                        {
                            result = ((int)(HttpStatusCode.OK)).ToString() + " " + response.StatusDescription;
                        }
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
