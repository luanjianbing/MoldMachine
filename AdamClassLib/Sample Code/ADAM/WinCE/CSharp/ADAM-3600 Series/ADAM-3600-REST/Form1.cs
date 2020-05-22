using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WISE_4000_REST
{
    public delegate void MethodDelegate();
    public partial class Form1 : Form
    {
        AdvantechHttpWebUtility m_httpRequest;
        public Form1()
        {
            InitializeComponent();
            m_httpRequest = new AdvantechHttpWebUtility();
            comboBox1.SelectedIndex = 0;
            m_httpRequest.ResquestResponded += this.OnGetRequestData;
            m_httpRequest.ResquestOccurredError += this.OnGetErrorRequest;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text;
        }

        private void url_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text;
        }

        private void SetTextToTextBox(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)//If need sync with form
            {
                textBox.Invoke((MethodDelegate)delegate()
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
                btn.Invoke((MethodDelegate)delegate()
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
            SetTextToTextBox(txtJSON, rawData);
            SetBtnToEnabled(btnSend, true);
        }
        private void OnGetErrorRequest(Exception e)
        {
            SetTextToTextBox(txtJSON, e.Message);
            btnSend.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnSend.Enabled = false;
                string account = txtAcount.Text,
                       password = txtPassword.Text,
                       URL = txtURL.Text;
                SetTextToTextBox(txtJSON, "Requesting http...");
                if (txtPatchData.Text.Length > 0) // Patch
                {
                    string data = txtPatchData.Text;
                    m_httpRequest.SendPATCHRequest(account, password, URL, data);
                }
                else
                {
                    m_httpRequest.SendGETRequest(account, password, URL);
                }
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
            label4.Visible = (method == "PATCH") ? true : false;
            txtPatchData.Visible = (method == "PATCH") ? true : false;
        }
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
