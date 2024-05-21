using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class frmViewLog : Form
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

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        // Copied from dwmapi.h
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        // Copied from dwmapi.h
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        public frmViewLog()
        {
            InitializeComponent();

            //var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            //var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            //DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Unused event
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                dgvLogViewer.Rows.Clear();

                if (IsRefreshEnabled)
                {
                    this.Text = "Log Viewer - Last updated: " + DateTime.Now.ToString() + " (Live Update Enabled)";
                }
                else
                {
                    this.Text = "Log Viewer - Last updated: " + DateTime.Now.ToString() + " (Live Update Disabled)";
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
            catch (Exception)
            {
                this.Text += " (Live Update paused to waiting another action completed)";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartStopRefresh_Click(object sender, EventArgs e)
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

        private void btnEnableDisableAutoScroll_Click(object sender, EventArgs e)
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IsAutoScrollToBottom)
                {
                    dgvLogViewer.FirstDisplayedScrollingRowIndex = dgvLogViewer.RowCount - 1;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"NON FATAL ERROR");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (IsRefreshEnabled)
            {
                btnStartStopRefresh.Text = "Disable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.Blue;
                btnStartStopRefresh.ForeColor = Color.White;

                this.Text = this.Text.Replace(" (Live Update Disabled)", " (Live Update Enabled)");
            }
            else
            {
                btnStartStopRefresh.Text = "Enable Auto Refresh";
                btnStartStopRefresh.BackColor = Color.White;
                btnStartStopRefresh.ForeColor = Color.Black;

                this.Text = this.Text.Replace(" (Live Update Enabled)", " (Live Update Disabled)");
            }
        }
    }
}
