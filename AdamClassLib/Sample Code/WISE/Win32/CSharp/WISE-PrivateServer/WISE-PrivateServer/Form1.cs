using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace WISE_PrivateServer
{
    public partial class Form1 : Form
    {
        internal const string HTTP_Prefix = "http://*:8000/"; //Waiting for HTTP request on port 8000
        internal const string HTTPS_Prefix = "https://*:8080/"; //Waiting for HTTPS request on port 8080
        internal const string Url_File_UploadLog_Token = @"upload_log";
        internal const string Url_Json_IoLog_Token = @"io_log";
        internal const string Url_Json_SysLog_Token = @"sys_log";
        internal const string DataType_Csv_File = @"CSV File";
        internal const string DataType_Json_Str = @"JSON String";
        internal const string Slash_Str_Token = @"/";
        internal const string BackSlash_Str_Token = @"\";
        internal const int Max_Rows_Val = 1000;

        private Hashtable moduleLockObject = new Hashtable();//for csv file
        private Object lockObject = new Object(); //for json

        private delegate void DataGridViewCtrlAddDataRow(DataGridViewRow i_Row);
        private DataGridViewCtrlAddDataRow m_DataGridViewCtrlAddDataRow;
        static HttpListener m_HttpListener;
        private Thread httpRequestThread;
        private long _runState = (long)State.Stopped;

        Boolean bScrollToBottom = false;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Rows.Clear();
            try
            {
                m_DataGridViewCtrlAddDataRow = new DataGridViewCtrlAddDataRow(DataGridViewCtrlAddNewRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public enum State
        {
            Stopped,
            Stopping,
            Starting,
            Started
        }

        public State RunState
        {
            get
            {
                return (State)Interlocked.Read(ref _runState);
            }
        }

        private void DataGridViewCtrlAddNewRow(DataGridViewRow i_Row)
        {
            if (this.dataGridView1.InvokeRequired)
            {
                this.dataGridView1.Invoke(new DataGridViewCtrlAddDataRow(DataGridViewCtrlAddNewRow), new object[] { i_Row });
                return;
            }

            this.dataGridView1.Rows.Add(i_Row);
            if (bScrollToBottom)
            {
                //make scroll bar move to bottom
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }
            
            if (dataGridView1.Rows.Count > Max_Rows_Val)
            {
                dataGridView1.Rows.Clear();
            }            
            this.dataGridView1.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                m_HttpListener = new HttpListener();
                
                try
                {
                    m_HttpListener.Prefixes.Add(HTTP_Prefix);
                    m_HttpListener.Prefixes.Add(HTTPS_Prefix);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err : " + ex.ToString());
                }
                try
                {
                    m_HttpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                    httpRequestThread = new Thread(new ThreadStart(StartListen));
                    httpRequestThread.IsBackground = true;
                    httpRequestThread.Start();
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Err : " + exe.ToString());
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show("Err : " + eee.ToString());
            }
        }

        private void StartListen()
        {
            Interlocked.Exchange(ref this._runState, (long)State.Starting);
            try
            {
                if (!m_HttpListener.IsListening)
                {
                    try
                    {
                        m_HttpListener.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:\n TCP port listen failed.\n Please make sure:\n(1) Port is not used.\n(2) Firewall is not blocked.\n(3) Use Administrator to run this program.\n\nDetail Information:\n" + ex.ToString());
                    }
                }
                if (m_HttpListener.IsListening)
                {
                    Interlocked.Exchange(ref this._runState, (long)State.Started);
                }
                try
                {
                    while (RunState == State.Started)
                    {
                        //HttpListenerContext context = m_HttpListener.GetContext();
                        //IncomingHttpRequest(context);
                        //Use asynchronous API to improve performance
                        IAsyncResult result = m_HttpListener.BeginGetContext(new AsyncCallback(ListenerCallback), m_HttpListener);                        
                        // Use a wait handle to prevent this thread from terminating while the asynchronous operation completes.
                        //Console.WriteLine("Waiting for request to be processed asyncronously.");
                        result.AsyncWaitHandle.WaitOne();
                    }
                }
                catch (HttpListenerException)
                {
                    Interlocked.Exchange(ref this._runState, (long)State.Stopped);
                }
            }
            finally
            {
                Interlocked.Exchange(ref this._runState, (long)State.Stopped);
            }
        }

        private void StopListen()
        {
            if (m_HttpListener.IsListening)
            {
                m_HttpListener.Stop();
                Interlocked.Exchange(ref this._runState, (long)State.Stopping);
            }

            if (httpRequestThread != null && httpRequestThread.IsAlive)
            {
                httpRequestThread.Join(1000);//block main thread and wait max 1 seconds for http thread terminate
                httpRequestThread.Abort();
            }
        }

        //lock object bases on module id
        private Object getLockObject(string moduleId)
        {
            if(!moduleLockObject.ContainsKey(moduleId))
            {
                moduleLockObject.Add(moduleId, new Object());
            }

            return moduleLockObject[moduleId];
        }

        private string getUniqueFileName(string logFilePath)
        {
            while (true)
            {
                if (File.Exists(logFilePath))
                {
                    //file already exists, create new file name
                    string extensionName = Path.GetExtension(logFilePath);
                    var fileName = Path.GetFileNameWithoutExtension(logFilePath);
                    var dirName = Path.GetDirectoryName(logFilePath);
                    if (fileName.IndexOf(' ') == -1)
                    {
                        //ex: 20151125111821
                        fileName = fileName + " (1)" + extensionName;
                    }
                    else
                    {
                        //ex: 20151125111821 (1)
                        string pattern = @"(\S+)\ \((\d+)\)";
                        // Instantiate the regular expression object.
                        Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                        // Match the regular expression pattern against a text string.
                        Match m = r.Match(fileName);
                        if (m.Success)
                        {
                            string match1 = m.Groups[1].ToString();
                            string match2 = m.Groups[2].ToString();
                            int tmp = Int32.Parse(match2) + 1;
                            fileName = match1 + " (" + tmp + ")" + extensionName;
                        }
                        else
                        {
                            //match failed, append a random number to file name
                            Random rnd = new Random();
                            int tmp = rnd.Next(1, 1000);
                            fileName = fileName + "_" + tmp + extensionName;
                        }
                    }
                    logFilePath = Path.Combine(dirName, fileName);
                }
                else
                {
                    //file not exists
                    return logFilePath;
                }
            }//while
        }

        //private void IncomingHttpRequest(HttpListenerContext context)
        private void ListenerCallback(IAsyncResult result)
        {
            try
            {
                //HttpListenerResponse response = context.Response;
                HttpListener listener = (HttpListener)result.AsyncState;
                if (!m_HttpListener.IsListening)
                {
                    Console.WriteLine("HttpListener is closed. Stop process request.");
                    return;
                }

                // Call EndGetContext to complete the asynchronous operation.
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                var receive_data = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();

                //Upload log(csv file)
                if (context.Request.Url.AbsolutePath.Contains(Url_File_UploadLog_Token))
                {
                    string szFileName = string.Empty;
                    List<string> szList = new List<string>(context.Request.Url.AbsolutePath.Split('/'));
                    //foreach (string subValue in szList)
                    //{
                        //if (subValue.Contains(".csv"))
                        if (szList.Count >= 6 &&  szList[5].Contains(".csv"))
                        {
                            string szModuleId = szList[2];
                            szFileName = context.Request.Url.AbsolutePath.Replace(Slash_Str_Token, BackSlash_Str_Token);
                            szFileName = szFileName.Substring(BackSlash_Str_Token.Length, (szFileName.Length - BackSlash_Str_Token.Length));
                            Object lockObj = getLockObject(szModuleId);
                            //lock is based on module id
                            lock (lockObj)
                            {
                                szFileName = getUniqueFileName(szFileName);
                                FileInfo file = new FileInfo(szFileName);
                                file.Directory.Create();
                                System.IO.File.WriteAllText(file.FullName, receive_data);
                            }
                            //break;
                        }
                    //}
                }
                /*
                //Un-comment this block to write Push log(json file)
                var dateString = DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2");
                var dateTimeString = dateString + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
                if (context.Request.Url.AbsolutePath.Contains(Url_Json_IoLog_Token))
                {
                    string szFileName = string.Empty;
                    szFileName = Url_Json_IoLog_Token + "\\" + dateString + "\\" + dateTimeString + ".log";
                    lock (lockObject)
                    {
                        FileInfo file = new FileInfo(szFileName);
                        file.Directory.Create();
                        System.IO.File.WriteAllText(file.FullName, receive_data);
                    }
                }
                else if (context.Request.Url.AbsolutePath.Contains(Url_Json_SysLog_Token))
                {
                    string szFileName = string.Empty;
                    szFileName = Url_Json_SysLog_Token + "\\" + dateString + "\\" + dateTimeString + ".log";
                    lock (lockObject)
                    {
                        FileInfo file = new FileInfo(szFileName);
                        file.Directory.Create();
                        System.IO.File.WriteAllText(file.FullName, receive_data);
                    }
                }
                */
                DataGridViewRow dgvRow;
                DataGridViewCell dgvCell;
                dgvRow = new DataGridViewRow();

                dgvCell = new DataGridViewTextBoxCell(); //Column Time
                var dataTimeInfo = DateTime.Now.Year.ToString("D4") + "/" +
                                             DateTime.Now.Month.ToString("D2") + "/" +
                                             DateTime.Now.Day.ToString("D2") + " " +
                                             DateTime.Now.Hour.ToString("D2") + ":" +
                                             DateTime.Now.Minute.ToString("D2") + ":" +
                                             DateTime.Now.Second.ToString("D2");
                dgvCell.Value = dataTimeInfo;
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell(); //RemoteEndPoint
                dgvCell.Value = context.Request.RemoteEndPoint.ToString();
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell(); //Url Scheme
                dgvCell.Value = context.Request.Url.Scheme.ToString();
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell(); //HTTP Method
                dgvCell.Value = context.Request.HttpMethod;
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell(); //Data Format
                if (context.Request.Url.AbsolutePath.Contains(Url_File_UploadLog_Token))
                {
                    dgvCell.Value = DataType_Csv_File;
                }
                else
                {
                    dgvCell.Value = DataType_Json_Str;
                }
                dgvRow.Cells.Add(dgvCell);

                dgvCell = new DataGridViewTextBoxCell(); //Request URL
                dgvCell.Value = context.Request.Url.ToString();
                dgvRow.Cells.Add(dgvCell);

                dgvRow.Tag = receive_data;

                m_DataGridViewCtrlAddDataRow(dgvRow);

                response.StatusCode = 200;
                response.StatusDescription = "OK";
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListen();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iSelectedIdx = -1;
            if ((e.RowIndex < dataGridView1.Rows.Count) && (e.RowIndex >= 0))
            {
                iSelectedIdx = e.RowIndex;
                reviewDataRichTbx.Clear();
                reviewDataRichTbx.AppendText(dataGridView1.Rows[iSelectedIdx].Tag.ToString());

                //check if user click last row
                if (dataGridView1.SelectedCells.Count != 0 && dataGridView1.SelectedCells[0].RowIndex == (dataGridView1.RowCount - 1))
                {
                    bScrollToBottom = true;
                }
                else
                {
                    bScrollToBottom = false;
                }
            }
        }
    }
}
