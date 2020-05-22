using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Extensions;
using System.Web.Script.Serialization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Odbc;
using System.Data.SQLite;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Threading;

namespace WISE_ColudDataCollect
{

    public partial class Form1 : Form
    {

        LogInformation mInfo = new LogInformation();
        private string CollectionPath;
        private string StartPath; //for query the folder name of device
        private string LogType;
        private Thread myThread;
        //private long CurrentData;
        private List<Button> Button;
        private int MAX_SIZE = 256;
        private int SQL_Data = 0;
        private string Server_Name;
        private string DB_Name;
        private string ID;
        private string Password;
        private Series _series = new Series();
        //string[] DBCol;
        bool mStart, mException;
        private delegate void DelegatePrintToList(string Item, string format, string Content, int col, int type);
        private delegate void DelegateModifyTitle(int index, string Content);
        private delegate void DelegateModifyHeight(int index);
        private delegate void DelegateSQLException();
        private string DateFormat = "yyyy/MM/ddTHH:mm:ss";
        private int Mode;
        private bool bDbInitialized = false;

        //Title of log item
        string[] TitleArray = 
        {
            "Device", "Format", "PE", "TIM", 
            "DI_0", "DI_0 Frq", "DI_0 Cnt",            
            "DI_1", "DI_1 Frq", "DI_1 Cnt",
            "DI_2", "DI_2 Frq", "DI_2 Cnt",
            "DI_3", "DI_3 Frq", "DI_3 Cnt",
            "DI_4", "DI_4 Frq", "DI_4 Cnt",            
            "DI_5", "DI_5 Frq", "DI_5 Cnt",
            "DI_6", "DI_6 Frq", "DI_6 Cnt",
            "DI_7", "DI_7 Frq", "DI_7 Cnt",
            "DO_0", "DO_0 Ps", "DO_0 PsIV", 
            "DO_1", "DO_1 Ps", "DO_1 PsIV", 
            "DO_2", "DO_2 Ps", "DO_2 PsIV", 
            "DO_3", "DO_3 Ps", "DO_3 PsIV", 
            "DO_4", "DO_4 Ps", "DO_4 PsIV", 
            "DO_5", "DO_5 Ps", "DO_5 PsIV", 
            "DO_6", "DO_6 Ps", "DO_6 PsIV", 
            "DO_7", "DO_7 Ps", "DO_7 PsIV", 
            "AI_0 Val","AI_0 HVal","AI_0 LVal", "AI_0 SVal", "AI_0 Eg", "AI_0 HEg", "AI_0 LEg", "AI_0 Evt", "AI_0 PEg", "AI_0 EgF", "AI_0 HEgF", "AI_0 LEgF", "AI_0 PEgF",
            "AI_1 Val","AI_1 HVal","AI_1 LVal", "AI_1 SVal", "AI_1 Eg", "AI_1 HEg", "AI_1 LEg", "AI_1 Evt", "AI_1 PEg", "AI_1 EgF", "AI_1 HEgF", "AI_1 LEgF", "AI_1 PEgF",
            "AI_2 Val","AI_2 HVal","AI_2 LVal", "AI_2 SVal", "AI_2 Eg", "AI_2 HEg", "AI_2 LEg", "AI_2 Evt", "AI_2 PEg", "AI_2 EgF", "AI_2 HEgF", "AI_2 LEgF", "AI_2 PEgF", 
            "AI_3 Val","AI_3 HVal","AI_3 LVal", "AI_3 SVal", "AI_3 Eg", "AI_3 HEg", "AI_3 LEg", "AI_3 Evt", "AI_3 PEg", "AI_3 EgF", "AI_3 HEgF", "AI_3 LEgF", "AI_3 PEgF",
            "AI_4 Val","AI_4 HVal","AI_4 LVal", "AI_4 SVal", "AI_4 Eg", "AI_4 HEg", "AI_4 LEg", "AI_4 Evt", "AI_4 PEg", "AI_4 EgF", "AI_4 HEgF", "AI_4 LEgF", "AI_4 PEgF",
            "AI_5 Val","AI_5 HVal","AI_5 LVal", "AI_5 SVal", "AI_5 Eg", "AI_5 HEg", "AI_5 LEg", "AI_5 Evt", "AI_5 PEg", "AI_5 EgF", "AI_5 HEgF", "AI_5 LEgF", "AI_5 PEgF",
            "AI_6 Val","AI_6 HVal","AI_6 LVal", "AI_6 SVal", "AI_6 Eg", "AI_6 HEg", "AI_6 LEg", "AI_6 Evt", "AI_6 PEg", "AI_6 EgF", "AI_6 HEgF", "AI_6 LEgF", "AI_6 PEgF",
            "AI_7 Val","AI_7 HVal","AI_7 LVal", "AI_7 SVal", "AI_7 Eg", "AI_7 HEg", "AI_7 LEg", "AI_7 Evt", "AI_7 PEg", "AI_7 EgF", "AI_7 HEgF", "AI_7 LEgF", "AI_7 PEgF",
            "COM_1 Bit_0", "COM_1 Bit_0 Evt", "COM_1 Wd_0", "COM_1 Wd_0 Evt",
            "COM_1 Bit_1", "COM_1 Bit_1 Evt", "COM_1 Wd_1", "COM_1 Wd_1 Evt",
            "COM_1 Bit_2", "COM_1 Bit_2 Evt", "COM_1 Wd_2", "COM_1 Wd_2 Evt",
            "COM_1 Bit_3", "COM_1 Bit_3 Evt", "COM_1 Wd_3", "COM_1 Wd_3 Evt",
            "COM_1 Bit_4", "COM_1 Bit_4 Evt", "COM_1 Wd_4", "COM_1 Wd_4 Evt",
            "COM_1 Bit_5", "COM_1 Bit_5 Evt", "COM_1 Wd_5", "COM_1 Wd_5 Evt",
            "COM_1 Bit_6", "COM_1 Bit_6 Evt", "COM_1 Wd_6", "COM_1 Wd_6 Evt",
            "COM_1 Bit_7", "COM_1 Bit_7 Evt", "COM_1 Wd_7", "COM_1 Wd_7 Evt",
            "COM_1 Bit_8", "COM_1 Bit_8 Evt", "COM_1 Wd_8", "COM_1 Wd_8 Evt",
            "COM_1 Bit_9", "COM_1 Bit_9 Evt", "COM_1 Wd_9", "COM_1 Wd_9 Evt",
            "COM_1 Bit_10", "COM_1 Bit_10 Evt", "COM_1 Wd_10", "COM_1 Wd_10 Evt",
            "COM_1 Bit_11", "COM_1 Bit_11 Evt", "COM_1 Wd_11", "COM_1 Wd_11 Evt",
            "COM_1 Bit_12", "COM_1 Bit_12 Evt", "COM_1 Wd_12", "COM_1 Wd_12 Evt",
            "COM_1 Bit_13", "COM_1 Bit_13 Evt", "COM_1 Wd_13", "COM_1 Wd_13 Evt",
            "COM_1 Bit_14", "COM_1 Bit_14 Evt", "COM_1 Wd_14", "COM_1 Wd_14 Evt",
            "COM_1 Bit_15", "COM_1 Bit_15 Evt", "COM_1 Wd_15", "COM_1 Wd_15 Evt",
            "Record",
        };

        //Type of log item
        string[] Dataformat = 
        {
            "char","char","char","char",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int","int","int","int","int","int","int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",
            "int","int","int","int",   
            "char",
        };

        enum Col
        {
            DeviceName,
            DataFormat,
            TotalData,
            LastTime,
        }

        enum DB
        {
            SQLServer,
            SQLite,
        }

        enum ButtonIndex
        {
            Start,
        }

        enum DataType
        {
            system_log,
            signal_log,
        }

        enum PrintType
        {
            first_print,
            re_write,
        }

        public Form1()
        {
            InitializeComponent();
            this.DirPath.Enabled = true;    
            //CurrentData = 0; //Initial the total data
            mInfo.Period = int.Parse(this.Period.Text);
            mInfo.T_Range = int.Parse(this.TimeRange.Text);
            mStart = false;
            mException = false;
            Button = new List<Button>();
            Button.Add(this.Start);
            //ODBCCheck.Checked = true;
            //SQLServerCheck.Checked = true;
            DBMode.SelectedIndex = (int)DB.SQLServer;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            mException = false;
            Mode = DBMode.SelectedIndex;
            //Start the csv data query                      
            if (mStart == false)
            {
                if (this.DirPath.Text == "")
                {
                    FolderBrowserDialog mPath = new FolderBrowserDialog();
                    if (mPath.ShowDialog() == DialogResult.OK)
                    {
                        this.DirPath.Text = mPath.SelectedPath;
                        StartPath = this.DirPath.Text;
                    }
                    else
                        return;
                }
                else
                    StartPath = this.DirPath.Text;

                if (StartPath == "")
                {
                    MessageBox.Show("Please select log location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!Directory.Exists(StartPath))
                    {
                        MessageBox.Show("Directory does not exist, please check it", "Directory not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (this.Period.Text != "" && this.TimeRange.Text != "")
                {
                    if (DBMode.SelectedIndex == (int)DB.SQLServer && (this.ServerName.Text == "" || this.DBName.Text == "" || this.UID.Text == "" || this.PWD.Text == ""))
                    {
                        MessageBox.Show("Please fill all the parameters", "SQL Server Setting error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (DBMode.SelectedIndex == (int)DB.SQLite && this.SQLiteDB.Text == "")
                        SQLiteDB.Text = Application.StartupPath.ToString();

                    DBMode.Enabled = false;
                    DBName.Enabled = false;
                    ServerName.Enabled = false;
                    UID.Enabled = false;
                    PWD.Enabled = false;
                    Period.Enabled = false;
                    TimeRange.Enabled = false;
                    SQLiteDB.Enabled = false;
                    listData.Items.Clear();
                    mStart = true;
                    mInfo.Period = int.Parse(this.Period.Text);
                    mInfo.T_Range = int.Parse(this.TimeRange.Text);
                    Server_Name = ServerName.Text;
                    DB_Name = DBName.Text;
                    ID = UID.Text;
                    Password = PWD.Text;
                    //Get device name, data type
                    StartQuery();
                    this.Start.Text = "Stop Parse";
                }
                else
                {
                    MessageBox.Show("Period and interval can not be empty", "Setting error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DBMode.Enabled = true;
                DBName.Enabled = true;
                ServerName.Enabled = true;
                UID.Enabled = true;
                PWD.Enabled = true;
                Period.Enabled = true;
                TimeRange.Enabled = true;
                SQLiteDB.Enabled = true;
                mStart = false;
                this.Start.Text = "Select Log Directory and Start Parse";
            }
        }

        private void StartQuery()
        {
            myThread = new Thread(GetCSVDir);
            myThread.Start();
        }

        /*Csv file will locate at upload_log/'device name'/xxxx_log/'date'/xxxx.csv
          StartPath is log location that user sets*/
        private void GetCSVDir()
        {
            bool UploadLog = false;
            string DeviceName;
            while (mStart && !mException)
            {
                foreach (string DevicePath in Directory.GetDirectories(StartPath)) //upload_log, sys_log, io_log
                {
                    DeviceName = Path.GetFileNameWithoutExtension(DevicePath);
                    foreach (string deviceDir in Directory.GetDirectories(DevicePath)) //Get device name in deviceDir
                    {
                        if (Path.GetFileNameWithoutExtension(deviceDir).IndexOf("system_log") >= 0 || Path.GetFileNameWithoutExtension(deviceDir).IndexOf("signal_log") >= 0)
                        {
                            UploadLog = true;
                            //Get log type(system_log or sigmal_log or both) in CSVDir
                            LogType = Path.GetFileNameWithoutExtension(deviceDir).ToString();
                            if (this.InvokeRequired)
                            { //Show information on device information
                                this.BeginInvoke(new DelegatePrintToList(this.PrintToList), DeviceName, null, Path.GetFileNameWithoutExtension(deviceDir), null, (int)PrintType.first_print);
                            }
                            CollectionPath = deviceDir;
                            if (Mode == (int)DB.SQLServer)
                            {
                                //string connectionstring = "";
                                //if (UseODBC)
                                mInfo.connectionstring = String.Format(@"DRIVER={{SQL Server}};SERVER={0};database={1};UID={2};PWD={3}", Server_Name, DB_Name, ID, Password);
                                if (!CreateODBC(deviceDir, DeviceName, mInfo.connectionstring)) //Connect to SQL server
                                {
                                    mException = true;
                                    this.BeginInvoke(new DelegateSQLException(this.SQLException));
                                    break;
                                }
                            }
                            else
                            {
                                //string DBLocation = SQLiteDB.Text.Replace(@"\\", @"\\\");
                                mInfo.connectionstring = @"DRIVER={SQLite3 ODBC Driver};Database=" + SQLiteDB.Text + @"\" + mInfo.DBName + @";LongNames=0;Timeout=1000;NoTXN=0;SyncPragma=NORMAL;StepAPI=0";
                                if (!CreateODBC(deviceDir, DeviceName, mInfo.connectionstring)) //Connect to SQLite
                                {
                                    mException = true;
                                    this.BeginInvoke(new DelegateSQLException(this.SQLException));
                                    break;
                                }
                            }
                        }
                    }
                }
                if (!UploadLog)
                {
                    mStart = false;
                    MessageBox.Show("Directory 'system_log' or 'signal_log' not found", "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (this.InvokeRequired)
                    { //Modify title of Start button
                        this.BeginInvoke(new DelegateModifyTitle(this.ModifyTitle), (int)ButtonIndex.Start, "Select Log Directory and Start Parse");
                    }
                    else
                        Button[(int)ButtonIndex.Start].Text = "Select Log Directory and Start Parse";
                }
                Thread.Sleep(mInfo.Period);
            }
        }
        private void ModifyTitle(int index, string Content)
        {
            Button[index].Text = Content;
            DBMode.Enabled = true;
            DBName.Enabled = true;
            ServerName.Enabled = true;
            UID.Enabled = true;
            PWD.Enabled = true;
        }
        private void SQLException() //SQL exception, kill collect data thread then stop parse
        {
            if (myThread.IsAlive)
                myThread.Abort();
            Start.PerformClick();   //Click "Stop Parse"
        }
        private void PrintToList(string Item, string format, string Content, int col, int type)
        {
            if (type == (int)PrintType.first_print)
            {
                try
                {
                    bool RepeatTitle = false;
                    foreach (ListViewItem subitem in listData.Items)
                    {
                        if (subitem.SubItems[(int)Col.DeviceName].Text.IndexOf(Item) >= 0 && subitem.SubItems[(int)Col.DataFormat].Text.ToLower().IndexOf(Content.Replace("_log", "").ToString()) >= 0)
                        {
                            RepeatTitle = true;
                        }
                    }
                    if (!RepeatTitle) //data title and format caught first time
                    {
                        ListViewItem listitem = new ListViewItem(Item);
                        //listitem.SubItems.Add(Path.GetFileNameWithoutExtension(CSVDir));
                        if (Content.IndexOf("system_log") >= 0)
                            listitem.SubItems.Add("System");
                        else if (Content.IndexOf("signal_log") >= 0)
                            listitem.SubItems.Add("Signal");
                        //listitem.SubItems.Add(Content);
                        listitem.SubItems.Add("");
                        listitem.SubItems.Add("");
                        listData.Items.Add(listitem);
                    }
                }
                catch(Exception e)
                {
                    Console.Write(e.Message);
                    //throw;
                }
            }
            else
            {
                try
                {
                    foreach (ListViewItem subitem in listData.Items)
                    {
                        if (subitem.SubItems[(int)Col.DeviceName].Text.IndexOf(Item) >= 0 && subitem.SubItems[(int)Col.DataFormat].Text.ToLower().IndexOf(format.Replace("_log","").ToString()) >= 0)
                        {
                            if (col == (int)Col.DataFormat)
                            {
                                if(Content.IndexOf("system_log") >= 0)
                                    subitem.SubItems[col].Text = "System";
                                else if(Content.IndexOf("signal_log") >= 0)
                                    subitem.SubItems[col].Text = "Signal";
                            }
                            else
                                subitem.SubItems[col].Text = Content;
                        }
                    }
                }
                catch(Exception e2)
                {
                    Console.Write(e2.Message);
                    //throw;
                }
            }
            listData.Update();
        }
        private bool CreateODBC(string DataDir, string DeviceName, string ConnectString)
        {
            OdbcCommand sql_cmd = new OdbcCommand();
            OdbcTransaction trans;
            OdbcConnection con = new OdbcConnection(ConnectString);          
            DataSet dds = new DataSet();
            List<string> UploadList = new List<string>();
            List<string> SendCmd = new List<string>();
            int count = 0;
            string table = "";
            string LastDate = "";
            string DBLocation = SQLiteDB.Text.Replace(@"\\", @"\\\");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (bDbInitialized == false)
            {
                //Create db file when SQLite enable
                if (Mode == (int)DB.SQLite)    //SQLite DB not define
                {
                    if (!File.Exists(DBLocation + @"\" + mInfo.DBName))
                    {
                        SQLiteConnection.CreateFile(DBLocation + @"\" + mInfo.DBName);
                    }
                }

                //Create db table
                for (int i = 0; i < TitleArray.Length; i++)
                {
                    string tmptable = "";
                    if (i == 0)
                        tmptable = string.Format("CREATE TABLE {0}([{1}][{2}]({3}) NULL,", mInfo.TableName, TitleArray[i], Dataformat[i], MAX_SIZE);
                    else if (i == TitleArray.Length - 1)
                    {
                        if (Dataformat[i].IndexOf("char") >= 0) //Format is char
                            tmptable = string.Format("[{0}][{1}]({2}) NULL);", TitleArray[i], Dataformat[i], MAX_SIZE, mInfo.TableName);
                        else
                            tmptable = string.Format("[{0}][{1}] NULL);", TitleArray[i], Dataformat[i]);
                    }
                    else
                    {
                        if (Dataformat[i].IndexOf("char") >= 0) //Format is char
                            tmptable = string.Format("[{0}][{1}]({2}) NULL,", TitleArray[i], Dataformat[i], MAX_SIZE);
                        else
                            tmptable = string.Format("[{0}][{1}] NULL,", TitleArray[i], Dataformat[i]);
                    }
                    table += tmptable;
                }
          	}

            try
            {                   
                con.Open();
				if (bDbInitialized == false){
					sql_cmd.CommandText = table;
                    sql_cmd.Connection = con;
	                sql_cmd.ExecuteNonQuery();
    	            sql_cmd.Parameters.Add(sql_cmd.CreateParameter());
				}
            }
            catch (Exception eee)
            {
                Console.Write(eee.Message);
                if (eee.Message.ToString().IndexOf("already") < 0)    //table or object already exists, ignore
                {
                    MessageBox.Show(eee.Message, "SQL Server Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            sw.Stop();
            sw.Reset();
            if (bDbInitialized == false)
            {
                Console.Write("Done, Create data table, spend: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms\n\r");
            }          

            //DB table is created
            bDbInitialized = true;

            sw.Start();

            //Read ini file to get the last upload time
            string IniName = DataDir + @"\" + DeviceName + @".ini";
            try
            {
                if (!File.Exists(IniName))
                {   //Create ini file and set the last upload time
                    var mfile = File.Create(IniName);
                    LastDate = default(DateTime).ToString();
                    SQL_Data = 0;
                    mfile.Close();
                }
                else
                {   //Read the record from the previous log collection
                    string[] Content = File.ReadAllLines(IniName);
                    if (Content.Count() == 0) //No data
                    {
                        LastDate = default(DateTime).ToString();
                    }
                    else
                    {
                        LastDate = Content[0];
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new DelegatePrintToList(this.PrintToList), DeviceName, LogType, Content[0], Col.LastTime, (int)PrintType.re_write);
                            this.BeginInvoke(new DelegatePrintToList(this.PrintToList), DeviceName, LogType, Content[1], Col.TotalData, (int)PrintType.re_write);
                        }
                        else
                        {
                            PrintToList(DeviceName, LogType, Content[0], (int)Col.LastTime, (int)PrintType.re_write);
                            PrintToList(DeviceName, LogType, Content[1], (int)Col.TotalData, (int)PrintType.re_write);
                        }
                        if (int.Parse(Content[1]) >= 0)
                            SQL_Data = int.Parse(Content[1]);
                    }
                }
            }
            catch (OdbcException e)
            {
                Console.Write(e.Message);
                MessageBox.Show(e.Message, "ODBC Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Collect all the data rows of csv file in the same path
            var di = new DirectoryInfo(DataDir);
            var directories = di.GetDirectories().OrderBy(d => d.CreationTime).Select(d => d.FullName).ToList(); //Sorting dir according to dir create time
            foreach (string FileDir in directories)
            {
                di = new DirectoryInfo(FileDir);
                var files = di.GetFiles().OrderBy(f => f.LastWriteTime).Select(f => f.FullName).ToList(); //Sorting file according to the last write time
                foreach (string Csvfile in files)
                {   //Check file format, if format is .csv, parsing the content of csv file
                    if (Csvfile.ToLower().IndexOf(".csv") > 0 && (DateTime.Compare(DateTime.Parse(LastDate), File.GetLastWriteTime(Csvfile)) < 0)
                        && LastDate.IndexOf(File.GetLastWriteTime(Csvfile).ToString("yyyy/MM/dd HH:mm:ss")) < 0)
                    {
                        DateTime test1 = File.GetLastWriteTime(Csvfile);
                        bool test = DateTime.Equals(DateTime.Parse(LastDate), File.GetLastWriteTime(Csvfile));
                        //Process csv file then generate SQL command
                        SendCmd = TxtConvertToSQLite(Csvfile, mInfo.TableName, Path.GetFileNameWithoutExtension(DataDir).ToString(), ",", count, DeviceName);
                        UploadList.AddRange(SendCmd);
                        count++;
                        LastDate = File.GetLastWriteTime(Csvfile).ToString("yyyy/MM/dd HH:mm:ss");

                    }
                }
            }
            sw.Stop();
            Console.Write("Done, Marge data, spend: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms\n\r");

            sw.Reset();
            sw.Start();

            //Upload data to db
            if (SQL_Data > 0)
            {
                try
                {
                    count = 0;
                    trans = con.BeginTransaction();
                    foreach (string Upload in UploadList)
                    {
                        sql_cmd.CommandType = CommandType.Text;
                        sql_cmd.CommandText = Upload;
                        sql_cmd.Connection = con;
                        sql_cmd.Transaction = trans;
                        sql_cmd.ExecuteNonQuery();
                        count++;
                    }
                    trans.Commit();
                    //Update the last upload time
                    if (this.InvokeRequired)
                    {
                        //Console.Write(Path.GetFileNameWithoutExtension(DataDir).ToString());
                        this.BeginInvoke(new DelegatePrintToList(this.PrintToList), DeviceName, Path.GetFileNameWithoutExtension(DataDir).ToString(), SQL_Data.ToString(), Col.TotalData, (int)PrintType.re_write);
                        this.BeginInvoke(new DelegatePrintToList(this.PrintToList), DeviceName, Path.GetFileNameWithoutExtension(DataDir).ToString(), LastDate, Col.LastTime, (int)PrintType.re_write);
                    }
                }
                catch (Exception SQLEX)
                {
                    //trans.Rollback(); // <-------------------
                    //throw; // <-------------------
                    Console.Write(SQLEX.Message);
                    MessageBox.Show(SQLEX.Message, "SQL Server Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                UploadList.Clear();
            }
            sw.Stop();
            Console.Write("Done, Upload " + SQL_Data + " data, spend: " + sw.Elapsed.TotalMilliseconds.ToString() + "ms\r\n");
            Console.Write("Done\r\n");

            //Write the last upload time and data count into ini file
            try
            {
                if (!File.Exists(IniName))
                    File.Create(IniName);
                string[] Result = { LastDate, SQL_Data.ToString() };
                File.WriteAllLines(IniName, Result);

                //close connection
                con.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                MessageBox.Show(e.Message, "ODBC Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Parsing csv file and generate db command
        public List<string> TxtConvertToSQLite(string File, string TableName, string Format, string delimiter, int count, string DeviceName)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new DataSet();
            StreamReader s = new StreamReader(File, System.Text.Encoding.Default);
            string resultcol, value;
            string[] columns = s.ReadLine().Split(delimiter.ToCharArray()); //first line in csv file, generate sql table
			//string[] columns;
            List<string> cmdlist = new List<string>();
/*             if (count == 0)
                DBCol = columns; */
            string line;

            if (columns.Length == 1)//there is file tag in first line of log file, ignore it
            {
                columns = s.ReadLine().Split(delimiter.ToCharArray());
            }
            while ((line = s.ReadLine()) != null) // Read context
            {
				string[] items = line.Split(delimiter.ToCharArray());
				
                resultcol = string.Format("INSERT INTO {0} (Device,Format,", mInfo.TableName);
                value = string.Format(" VALUES ('{0}','{1}',", DeviceName, Format);
                
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == columns.Length - 1)
                        resultcol += "[" + columns[i].Replace("\"", "") + @"])";
                    else
                        resultcol += "[" + columns[i].Replace("\"", "") + @"],";

                    if (i == columns.Length - 1)
                        value += @"'" + items[i].Replace(" ", "") + @"');";
                    else if (i == 1) //TIM in signal log, PE in system log, using datetime parsing
                    {
                        //Time format check, UTC or GTM
                        DateTime nt, utcTime;
                        string DT;
                        if (DateTime.TryParseExact(items[i], "yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out nt))
                        {  
                            utcTime = nt;
                        }
                        else
                        {
                            //DateTime gtm = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(items[i].Replace(" ", ""))); //get UTC time
                            DateTime gtm = new DateTime(1970, 1, 1).AddSeconds(Convert.ToDouble(items[i].Replace(" ", ""))); //get UTC time
                            utcTime = TimeZoneInfo.ConvertTimeFromUtc(gtm, TimeZoneInfo.Local); //get local time   
                        }
                            DT = utcTime.ToString(DateFormat);
                            value += @"'" + DT + @"',";
                    }
                    else
                        value += @"'" + items[i].Replace(" ", "") + @"',";

                }
                cmdlist.Add(resultcol + value);
                SQL_Data++;
            }
            return cmdlist;
        }
        
        private void Show_Click(object sender, EventArgs e)
        {
            if (StartPath == null)
            {
                MessageBox.Show("Please select log location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Period.Text != "" && this.TimeRange.Text != "")
            {
                mInfo.Period = int.Parse(this.Period.Text);
                mInfo.T_Range = int.Parse(this.TimeRange.Text);
            }
            else
            {
                MessageBox.Show("Period or interval can not be null value", "Setting error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool selected = false; ;
                foreach (ListViewItem tmpLstView in listData.Items)
                {
                    if (tmpLstView.Selected == true)
                        selected = true;
                }
                if (selected)
                {
                    if (!CheckData(listData.FocusedItem.SubItems[(int)Col.DeviceName].Text, listData.FocusedItem.SubItems[(int)Col.DataFormat].Text.ToLower() + "_log", mInfo.T_Range))
                    {
                        MessageBox.Show("No data in this time interval", "Data is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Form2 m = new Form2();
                        m.Period = mInfo.Period;
                        m.T_Range = mInfo.T_Range;
                        m.DeviceName = listData.FocusedItem.SubItems[(int)Col.DeviceName].Text;
                        m.Format = listData.FocusedItem.SubItems[(int)Col.DataFormat].Text.ToLower() + "_log";
                        m.Text = listData.FocusedItem.SubItems[(int)Col.DataFormat].Text + " log of " + listData.FocusedItem.SubItems[(int)Col.DeviceName].Text;
                        m.connectionstring = mInfo.connectionstring;
                        m.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please select one device", "No device selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ee)
            {
                Console.Write(ee.Message);

            }
        }
        public void TxtConvertToDataTable(string File, string TableName, string delimiter)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            StreamReader s = new StreamReader(File, System.Text.Encoding.Default);
            //string ss = s.ReadLine();//skip the first line
            string[] columns = s.ReadLine().Split(delimiter.ToCharArray());

            foreach (string col in columns)
            {
                //bool added = false;
                string next = "";
                //int i = 0;

                string columnname = col + next;
                columnname = columnname.Replace("#", "");
                columnname = columnname.Replace("'", "");
                columnname = columnname.Replace("&", "");
                columnname = columnname.Replace(@"""", "");
                if (!ds.Tables[TableName].Columns.Contains(columnname))
                {
                    ds.Tables[TableName].Columns.Add(columnname.ToUpper());
                    //added = true;
                }
            }
            string line;
            while ((line = s.ReadLine()) != null)
            {
                string[] items = line.Split(delimiter.ToCharArray());
                ds.Tables[TableName].Rows.Add(items);
            }

            dt = ds.Tables[0];
            s.Close();
        }

        //Only number key will be detact
        private void Period_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //Only number key will be detact
        private void TimeRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        //Check data count, return false if no data in time interval, return true if any data is exist
        private bool CheckData(string device, string format, int timerange)
        {
            DateTime NowTime = System.DateTime.Now;
            TimeSpan span = new TimeSpan(0, timerange, 0);
            string E_Time = NowTime.ToString("yyyy/MM/ddTHH:mm:ss");
            string S_Time = (NowTime - span).ToString("yyyy/MM/ddTHH:mm:ss");
            var conn = new OdbcConnection(mInfo.connectionstring);
            string[] label = { "DI_1", "DO_0", "AI_0 SVal" };
            conn.Open();

            //RowCount recieve total count of database's return
            OdbcCommand cmd = new OdbcCommand();

            if (format.IndexOf("signal_log") >= 0)
            {
                foreach (string checkcmd in label)
                {   //Check data count
                    string sqlcmd_pe = string.Format("SELECT COUNT('{0}') FROM {1} WHERE \"{0}\" is not null AND Device LIKE '{2}' AND Format LIKE '{3}' AND TIM BETWEEN '{4}' AND '{5}';"
                        , checkcmd, mInfo.TableName, device, format, S_Time, E_Time);
                    cmd.CommandText = sqlcmd_pe;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    int RowCount = 0;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount > 0)   //Create a new line if there is any value
                    {
                        return true;
                    }
                }
            }
            else if (format.IndexOf("system_log") >= 0)
            {
                string sqlcmd_pe = string.Format("SELECT COUNT('{0}') FROM {1} WHERE \"{2}\" is not null AND Device LIKE '{3}' AND Format LIKE '{0}' AND TIM BETWEEN '{4}' AND '{5}';"
                    , format, mInfo.TableName, "Format", device, S_Time, E_Time);
                cmd.CommandText = sqlcmd_pe;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                int RowCount = 0;
                RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                if (RowCount > 0)   //Create a new line if there is any value
                {
                    return true;
                }
            }
            return false;
        }
        private void ChangeUserSetting()
        {
            if (DBMode.SelectedIndex == (int)DB.SQLite)
            {
                SQLiteDB.Visible = true;
                SQLiteTitle.Visible = true;

                ServerName.Visible = false;
                UID.Visible = false;
                PWD.Visible = false;
                DBName.Visible = false;

                DBTitle.Visible = false;
                UIDTitle.Visible = false;
                PWDTitle.Visible = false;
                ServerTitle.Visible = false;
                SQLiteTitle.Location = new Point(label4.Location.X, label4.Location.Y + 29);
                SQLiteDB.Location = new Point(label4.Location.X, label4.Location.Y + 49);
                SQLiteDB.Size = new Size(DirPath.Size.Width, DirPath.Size.Height);
                
            }
            else
            {
                SQLiteDB.Visible = false;
                SQLiteTitle.Visible = false;

                ServerName.Visible = true;
                UID.Visible = true;
                PWD.Visible = true;
                DBName.Visible = true;

                DBTitle.Visible = true;
                UIDTitle.Visible = true;
                PWDTitle.Visible = true;
                ServerTitle.Visible = true;
            }
        }
        private void DBMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeUserSetting();
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            mStart = false;
            if (myThread != null && myThread.IsAlive)
            {
                myThread.Join(1000);//block main thread and wait max 1 seconds for http thread terminate
                myThread.Abort();
            }
        }
    }
    //Store user setting for Form1 and Form2
    public class LogInformation
    {
        public string DBName = "LogChartDemo.db3";
        public string TableName = "LogChart";
        public int Period;
        public int T_Range;
        public string connectionstring;
    }
}
