using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace ADAM_6200_REST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text;
        }

        private void url_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPostData.Text.Length > 0) // POST
                    SendPOSTRequest();
                else
                    SendGETRequest();
            }
            catch (Exception err)
            {
                txtXML.Text = err.ToString();
            }
        }

        private void SendPOSTRequest()
        {
            byte[] byData;
            string szResponse;
            System.IO.Stream outputStream, responseStream;
            System.IO.StreamReader reader;
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;

            myRequest = (HttpWebRequest)WebRequest.Create(txtURL.Text); // create request
            byData = Encoding.ASCII.GetBytes(txtPostData.Text); // convert POST data to bytes
            myRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(txtAcount.Text + ":" + txtPassword.Text)));
            myRequest.Method = "POST";
            myRequest.KeepAlive = false;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = byData.Length;
            // send data
            outputStream = myRequest.GetRequestStream();
            outputStream.Write(byData, 0, byData.Length);
            outputStream.Close();
            // try to receive
            myResponse = (HttpWebResponse)myRequest.GetResponse();
            responseStream = myResponse.GetResponseStream();
            reader = new System.IO.StreamReader(responseStream, Encoding.ASCII);
            szResponse = reader.ReadToEnd();
            txtXML.Text = szResponse;
        }

        private void SendGETRequest()
        {
            string szResponse;
            System.IO.Stream responseStream;
            System.IO.StreamReader reader;
            HttpWebRequest myRequest;
            HttpWebResponse myResponse;

            myRequest = (HttpWebRequest)WebRequest.Create(txtURL.Text);
            myRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(txtAcount.Text + ":" + txtPassword.Text)));
            myRequest.Method = "GET";
            myRequest.KeepAlive = false;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            // try to receive
            myResponse = (HttpWebResponse)myRequest.GetResponse();
            responseStream = myResponse.GetResponseStream();
            reader = new System.IO.StreamReader(responseStream, Encoding.ASCII);
            szResponse = reader.ReadToEnd();
            txtXML.Text = szResponse;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtXML.Text.Length > 0)
            {
                try
                {
                    DataSet dataSet1 = new DataSet();
                    StringReader theReader = new StringReader(txtXML.Text);
                    dataSet1.ReadXml(theReader);
                    //
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dataSet1; // dataset
                    dataGridView1.DataMember = dataSet1.Tables[1].TableName;
                }
                catch
                {
                }
            }
        }
    }
}
