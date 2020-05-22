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
using System.Data.SQLite;
using System.Data.Odbc;
using System.Data.Common;
using Microsoft.VisualBasic.FileIO;
using System.Data.OleDb;
using System.Threading;

namespace WISE_ColudDataCollect
{
    public partial class Form2 : Form
    {
        private string ChartPE = "PE";
        private string LegendPE = "LegendPE";   //PE: Pie Error Chart
        private string LegendRT = "LegendRT";   //RT: Real Time Chart
        private string signal_log = "signal_log";
        LogInformation PInfo = new LogInformation();
        private delegate void DelegateDrawLine(string ModelName);
        private delegate void DelegateDrawPE(string ModelName);
        public string DeviceName = "";
        public string Format = "";
        private string EndTime = "";
        private string StartTime = "";
        public int T_Range;
        public int Period;
        public string connectionstring = "";
        ToolTip tooltip = new ToolTip();

        //System_log error list
        string[] SystemError = 
        {
            "Period",
            "Wireless connection",
            "Wireless disconnection",
            "Communication WDT",
            "Cloud file upload fail",
            "Colud data push fail",
            "SNTP fail",
            "Power on/off",
            "Memory full/overwrite in log function",
            "Remote access fail(Access control)",
            "Login error",
            "FW upgrade",
            "RTC battery low",
            "Internal configuration table error",
            "Internal flash access error",
        };

        //Signal event list
        string[] SignalEvent = 
        {
            "DI",
            "DO",
            "AI",
            "AO",
            "WDT",
        };

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Init style of chart wondows
            RTChart.ChartAreas["ChartArea1"].BackColor = Color.White;
            PEChart.ChartAreas["ChartArea1"].BackColor = Color.White;
            PEChart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            PEChart.ChartAreas["ChartArea1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            RTChart.ChartAreas["ChartArea1"].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            RTChart.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid;
            ChartTab.TabPages[0].BackColor = Color.FromArgb(235, 235, 235);
            ChartTab.TabPages[1].BackColor = Color.FromArgb(235, 235, 235);
           
            if (Format.IndexOf(signal_log) >= 0)
            {         
                RTChart.Legends.Add(LegendRT);
                RTChart.Titles.Add("Loading...." + Format);
                ChartTab.TabPages[0].Text = DeviceName + " Signal Data";
                ChartTab.TabPages[1].Text = DeviceName + " Signal Event Type Analysis";
            }
            else
            {
                PEChart.Location = new System.Drawing.Point(0, 26);
                ChartTab.TabPages.Remove(tabPage1);
                RTChart.Visible = false;
                ChartTab.TabPages[0].Text = DeviceName + " System Error Type Analysis";
            }
            PEChart.Series.Add(ChartPE);
            PEChart.Legends.Add(LegendPE);
            if (Format.IndexOf(signal_log) >= 0)
                PEChart.Titles.Add("Loading....Event Analysis");
            else
                PEChart.Titles.Add("Loading....Error Analysis");
            

            SetTimer(); //Start draw chart windows with timer
        }
        private void StartDrawData()
        {
            StartDrawPE();
        }
        private void StartDrawPE()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DelegateDrawLine(this.DrawPE), DeviceName);
            }
            else
                DrawPE(DeviceName);

        }
        private void DrawPE(string Device)
        {
            List<string> xValues = new List<string>();
            List<string> yValues = new List<string>();
            DateTime NowTime = System.DateTime.Now;
            PEChart.Series[ChartPE].ChartType = SeriesChartType.Pie;
            PEChart.Series[ChartPE].Color = Color.OrangeRed;
            PEChart.Series[ChartPE]["PieLabelStyle"] = "Outside";
            PEChart.Series[ChartPE]["PieDrawingStyle"] = "Default";
            PEChart.Series[ChartPE].Font = new System.Drawing.Font("Trebuchet MS", 10, System.Drawing.FontStyle.Bold);
            PEChart.Series[ChartPE].BorderColor = Color.FromArgb(255, 101, 101, 101);

            //Legends setting
            PEChart.Legends[LegendPE].BackColor = Color.FromArgb(235, 235, 235);
            PEChart.Legends[LegendPE].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            PEChart.Legends[LegendPE].BorderWidth = 1;
            PEChart.Legends[LegendPE].BorderColor = Color.FromArgb(200, 200, 200);

            var conn = new OdbcConnection(connectionstring); 
            conn.Open();
            for (int ErrorCode = 0; ErrorCode <= 16; ErrorCode ++)
            {        
                try
                {   //Get error data in time interval
                    string sqlcmd_pe = string.Format("SELECT COUNT(PE) FROM {0} WHERE PE = '{1}' AND Device = '{2}' AND Format = '{3}' AND TIM BETWEEN '{4}' AND '{5}';"
                        , PInfo.TableName, "E" + ErrorCode.ToString(), Device, Format, StartTime, EndTime);                         

                    //RowCount recieve total count of database's return
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = sqlcmd_pe;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    int RowCount = 0;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount > 0)
                    {
                        string tmptitle;
                        if (Format.IndexOf("system_log") >= 0)
                            tmptitle = string.Format(SystemError[ErrorCode]);//"E" + ErrorCode.ToString());
                        else
                            tmptitle = string.Format(SignalEvent[ErrorCode]);
                        xValues.Add(tmptitle);
                        yValues.Add(RowCount.ToString());
                    }
                }
                catch (Exception eee)
                {
                    Console.Write(eee.Message);
                    throw;
                }
            }
            try
            {
                PEChart.Series[ChartPE].LegendText = "#AXISLABEL: #VALY";
                PEChart.Series[ChartPE].Label = "#VALY";
                PEChart.Series[ChartPE].Points.DataBindXY(xValues, yValues);
                PEChart.Titles[0].Text = PEChart.Titles[0].Text.Replace("Loading....", "");
                if (PEChart.Series.Count != 0 && PEChart.Series[ChartPE].Points.Count ==0)
                {
                    if(PEChart.Titles[0].Text.IndexOf("no data") ==-1)
                        PEChart.Titles[0].Text = PEChart.Titles[0].Text + "...no data";
                }
                else 
                {
                    PEChart.Titles[0].Text = PEChart.Titles[0].Text.Replace("...no data", "");
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //throw; //ignore exception when draw chart
            }           
        }
        private void StartDrawRT()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DelegateDrawLine(this.DrawLine), DeviceName);
            }
            else
                DrawLine(DeviceName);
                   
        }
        private void DrawLine(string Device)
        {
            DateTime NowTime = System.DateTime.Now;
            //Legend setting
            RTChart.Legends[LegendRT].BackColor = Color.FromArgb(235, 235, 235);
            RTChart.Legends[LegendRT].BackHatchStyle = ChartHatchStyle.DarkDownwardDiagonal;
            RTChart.Legends[LegendRT].BorderWidth = 1;
            RTChart.Legends[LegendRT].BorderColor = Color.FromArgb(200, 200, 200);
            //XY aris setting
            ChartArea area = this.RTChart.ChartAreas[0];

            //Get DI,DO,AI value in time interval
            string sqlcmd = string.Format("SELECT \"Device\",\"TIM\",\"PE\",\"DI_0\",\"DO_0\",\"AI_0 SVal\" FROM {0} WHERE Device = '{1}' AND Format = '{2}' AND TIM BETWEEN '{3}' AND '{4}';"
                , PInfo.TableName, Device, Format, StartTime, EndTime);
            var conn = new OdbcConnection(connectionstring);
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                var da = new OdbcDataAdapter(sqlcmd, conn);
                da.Fill(ds);
                int nullcount = 0;
                for (int colIndex = 3; colIndex < ds.Tables["Table"].Columns.Count; colIndex++)
                {
                    string columnName = ds.Tables["Table"].Columns[colIndex].ColumnName;
                    
                    //if columnName not exist, add it
                    if (RTChart.Series.Count == 0 || RTChart.Series.IndexOf(columnName) == -1)
                    {
                        //if line does not exist, create a new line
                        string sqlcmd_pe = string.Format("SELECT COUNT('{0}') FROM {1} WHERE \"{0}\" is not null AND Device = '{2}' AND Format = '{3}' AND TIM BETWEEN '{4}' AND '{5}';"
                            , columnName, PInfo.TableName, Device, Format, StartTime, EndTime);

                        //RowCount recieve total count of database's return
                        OdbcCommand cmd = new OdbcCommand();
                        cmd.CommandText = sqlcmd_pe;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        int RowCount = 0;
                        RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (RowCount > 0)   //Create a new line if there is any value
                        {
                            RTChart.Series.Add(columnName);
                            RTChart.Series[columnName].ChartType = SeriesChartType.Line;
                            RTChart.Series[columnName].BorderWidth = 4;
                            RTChart.Series[columnName].XValueMember = "TIM";
                            RTChart.Series[columnName].YValueMembers = columnName;
                            if (columnName.IndexOf("DI") >= 0 || columnName.IndexOf("DO") >= 0)
                            {
                                RTChart.Series[columnName].YAxisType = AxisType.Primary;
                                RTChart.ChartAreas["ChartArea1"].AxisY.Title = "DI/DO value";
                                RTChart.ChartAreas["ChartArea1"].AxisY.Maximum = 1;
                            }
                            else
                            {
                                RTChart.Series[columnName].YAxisType = AxisType.Secondary;
                                RTChart.ChartAreas["ChartArea1"].AxisY2.Title = columnName + " value";
                            }
                        }
                        else
                            nullcount++;
                    }
                }
                RTChart.DataSource = ds;
                RTChart.DataBind();

                RTChart.Titles[0].Text = RTChart.Titles[0].Text.Replace("Loading....", "");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                //throw; //ignore exception when draw chart
            }
        }
        private void SetTimer()
        {
            timer1.Interval = 300;
            timer1.Enabled = true;
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime NowTime = System.DateTime.Now;
            TimeSpan span = new TimeSpan(0, T_Range, 0);
            EndTime = NowTime.ToString("yyyy/MM/ddTHH:mm:ss");
            StartTime = (NowTime - span).ToString("yyyy/MM/ddTHH:mm:ss");
            timer1.Interval = Period;   //The wait time of timer
            if (Format.IndexOf(signal_log) >= 0)
                StartDrawRT();
            StartDrawPE();         
        }
    }
}
