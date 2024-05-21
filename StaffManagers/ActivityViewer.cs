using MySql.Data.MySqlClient;
using StaffManagers.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class ActivityViewer : UserControl
    {
        private bool isRefreshEnabled;

        public bool IsRefreshEnabled
        {
            get { return isRefreshEnabled; }
            set { isRefreshEnabled = value; }
        }

        private bool isAutoScrollToBottom;

        public bool IsAutoScrollToBottom
        {
            get { return isAutoScrollToBottom; }
            set { isAutoScrollToBottom = value; }
        }

        public ActivityViewer()
        {
            InitializeComponent();

            this.Load += ActivityViewer_Load;
            timer1.Tick += Timer1_Tick;
            timer2.Tick += Timer2_Tick;
            timer3.Tick += Timer3_Tick;
            btnStartStopRefresh.Click += BtnStartStopRefresh_Click;
            btnEnableDisableAutoScroll.Click += BtnEnableDisableAutoScroll_Click;
            btnManualRefresh.Click += btnManualRefresh_Click;

            btnManualRefresh.MouseEnter += BtnManualRefresh_MouseEnter;
            btnManualRefresh.MouseLeave += BtnManualRefresh_MouseLeave;
        }

        private void BtnManualRefresh_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void BtnManualRefresh_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (IsRefreshEnabled)
            {
                btnStartStopRefresh.Text = "Disable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.Blue;
                btnStartStopRefresh.ForeColor = Color.White;
            }
            else
            {
                btnStartStopRefresh.Text = "Enable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.White;
                btnStartStopRefresh.ForeColor = Color.Black;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (IsAutoScrollToBottom)
            {
                dgvLogViewer.FirstDisplayedScrollingRowIndex = dgvLogViewer.RowCount - 1;
            }
        }

        private void BtnEnableDisableAutoScroll_Click(object sender, EventArgs e)
        {
            if (IsAutoScrollToBottom)
            {
                btnEnableDisableAutoScroll.BackColor = Color.White;
                btnEnableDisableAutoScroll.ForeColor = Color.Black;
                btnEnableDisableAutoScroll.Text = "Enable Auto Scroll";

                timer2.Stop();

                IsAutoScrollToBottom = false;
            }
            else
            {
                btnEnableDisableAutoScroll.Text = "Disable Auto Scroll";
                btnEnableDisableAutoScroll.BackColor = Color.Blue;
                btnEnableDisableAutoScroll.ForeColor = Color.White;

                timer2.Start();

                IsAutoScrollToBottom = true;
            }
        }

        private void BtnStartStopRefresh_Click(object sender, EventArgs e)
        {
            if (IsRefreshEnabled)
            {
                btnStartStopRefresh.Text = "Disable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.Blue;
                btnStartStopRefresh.ForeColor = Color.White;

                timer1.Stop();

                IsRefreshEnabled = false;
            }
            else
            {
                btnStartStopRefresh.Text = "Enable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.White;
                btnStartStopRefresh.ForeColor = Color.Black;

                timer1.Start();

                IsRefreshEnabled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dgvLogViewer.Rows.Clear();

                var dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    string query = "SELECT * FROM User_Log";

                    var query_cmd = new MySqlCommand(query, dbCon.Connection);
                    var query_reader = query_cmd.ExecuteReader();
                    string append_string = "";

                    while (query_reader.Read())
                    {
                        string username = query_reader.GetString(0);
                        string date_login = query_reader.GetString(1);
                        string time_login = query_reader.GetString(2);
                        string date_logout = query_reader.GetString(3);
                        string time_logout = query_reader.GetString(4);

                        append_string = "The user '" + username + "' logged in at " + date_login +
                            " in " + time_login;

                        string[] data_grid_view =
                        {
                            DateTime.Now.ToString(),
                            append_string
                        };

                        dgvLogViewer.Rows.Add(data_grid_view);

                        if (date_logout != "" || time_logout != "")
                        {
                            append_string = "The user '" + username + "' logged out at " + date_logout +
                            " in " + time_logout;

                            string[] data_grid_view_logged_out =
                            {
                                DateTime.Now.ToString(),
                                append_string
                            };

                            dgvLogViewer.Rows.Add(data_grid_view);
                        }
                    }

                    dbCon.Close();
                    dbCon = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        private void ActivityViewer_Load(object sender, EventArgs e)
        {
            label1.Font = FontLoader.LoadFontToMemory(20.0F);

            IsRefreshEnabled = true;
            IsAutoScrollToBottom = false;

            if (IsRefreshEnabled)
            {
                btnStartStopRefresh.Text = "Disable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.Blue;
                btnStartStopRefresh.ForeColor = Color.White;

                timer1.Start();
            }
            else
            {
                btnStartStopRefresh.Text = "Enable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.White;
                btnStartStopRefresh.ForeColor = Color.Black;

                timer1.Stop();
            }

            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM User_Log";

                var query_cmd = new MySqlCommand(query, dbCon.Connection);
                var query_reader = query_cmd.ExecuteReader();
                string append_string = "";

                while (query_reader.Read())
                {
                    string username = query_reader.GetString(0);
                    string date_login = query_reader.GetString(1);
                    string time_login = query_reader.GetString(2);
                    string date_logout = query_reader.GetString(3);
                    string time_logout = query_reader.GetString(4);

                    append_string = "The user '" + username + 
                        "' logged in at " + date_login +
                        " in " + time_login;

                    string[] data_grid_view =
                    {
                        DateTime.Now.ToString(),
                        append_string
                    };

                    dgvLogViewer.Rows.Add(data_grid_view);

                    if (date_logout != "" || time_logout != "")
                    {
                        append_string = "The user '" + username + 
                            "' logged out at " + date_logout +
                            " in " + time_logout;

                        string[] data_grid_view_logged_out =
                        {
                            DateTime.Now.ToString(),
                            append_string
                        };

                        dgvLogViewer.Rows.Add(data_grid_view);
                    }
                }

                dbCon.Close();
                dbCon = null;
            }
        }

        private void btnManualRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Cursor.Current = Cursors.Default;

            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM User_Log";

                var query_cmd = new MySqlCommand(query, dbCon.Connection);
                var query_reader = query_cmd.ExecuteReader();
                string append_string = "";

                while (query_reader.Read())
                {
                    string username = query_reader.GetString(0);
                    string date_login = query_reader.GetString(1);
                    string time_login = query_reader.GetString(2);
                    string date_logout = query_reader.GetString(3);
                    string time_logout = query_reader.GetString(4);

                    append_string = "The user '" + username +
                        "' logged in at " + date_login +
                        " in " + time_login;

                    string[] data_grid_view =
                    {
                        DateTime.Now.ToString(),
                        append_string
                    };

                    dgvLogViewer.Rows.Add(data_grid_view);

                    if (date_logout != "" || time_logout != "")
                    {
                        append_string = "The user '" + username +
                            "' logged out at " + date_logout +
                            " in " + time_logout;

                        string[] data_grid_view_logged_out =
                        {
                            DateTime.Now.ToString(),
                            append_string
                        };

                        dgvLogViewer.Rows.Add(data_grid_view);
                    }
                }

                dbCon.Close();
                dbCon = null;
            }
        }
    }
}