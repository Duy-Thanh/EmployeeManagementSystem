using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler ViewLogButtonPressed;

        LoginFormPanel loginPanel = new LoginFormPanel();
        LoginOptionsPanel loginOptionsPanel = new LoginOptionsPanel();

        public LoginUserControl()
        {
            InitializeComponent();

            // Display login panel
            panel2.Controls.Add(loginPanel);

            // Display login options panel
            panelLoginOptions.Controls.Add(loginOptionsPanel);

            // Handle event
            loginPanel.LoginButtonPressed += LoginPanel_LoginButtonPressed;
            loginOptionsPanel.OnForgotPasswordPressed += LoginOptionsPanel_OnForgotPasswordPressed;
        }

        private void LoginOptionsPanel_OnForgotPasswordPressed(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact to the administrator to reset your password!",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoginPanel_LoginButtonPressed(object sender, EventArgs e)
        {
            if (loginPanel.IsSuccess)
            {
                var login_success = false;

                var dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    string query_username = 
                        "SELECT user_login FROM Account_System WHERE user_login = '" + 
                        Config.Username_shared + "'";

                    var cmd_username = new MySqlCommand(query_username, dbCon.Connection);
                    var reader_username = cmd_username.ExecuteReader();

                    // Username incorrect
                    if (!reader_username.Read())
                    {
                        MessageBox.Show("Username is incorrect, please try again!",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Username corrected
                    else
                    {
                        while (reader_username.Read())
                        {
                            string read_data_username = reader_username.GetString(0);

                            if (Config.Username_shared != read_data_username)
                            {
                                MessageBox.Show("Username is incorrect, please try again!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        dbCon.Close();
                        dbCon = null;

                        dbCon = MySQLConnection.Instance();
                        dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                        dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                        dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                        dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                        if (dbCon.IsConnect())
                        {
                            string query_password = 
                                "SELECT user_password FROM Account_System WHERE user_login = '" +
                                Config.Username_shared + "'";

                            var cmd_password = new MySqlCommand(query_password, dbCon.Connection);
                            var reader_password = cmd_password.ExecuteReader();

                            while (reader_password.Read())
                            {
                                string password_retrieved = reader_password.GetString(0);

                                if (password_retrieved != Config.Password_shared)
                                {
                                    MessageBox.Show("Password is incorrect, please try again!",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    login_success = false;

                                    break;
                                }
                                else
                                {
                                    login_success = true;

                                    break;
                                }
                            }

                            if (login_success)
                            {
                                // Username and password is corrected
                                // Now let's check role account then select GUI

                                dbCon.Close();
                                dbCon = null;

                                dbCon = MySQLConnection.Instance();
                                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                                if (dbCon.IsConnect())
                                {
                                    string query_role_account =
                                        "SELECT role_account FROM Account_System WHERE user_login = '" +
                                        Config.Username_shared + "'" +
                                        "AND user_password = '" + Config.Password_shared + "'";

                                    var cmd_role_account =
                                        new MySqlCommand(query_role_account, dbCon.Connection);
                                    var reader_role_account =
                                        cmd_role_account.ExecuteReader();

                                    while (reader_role_account.Read())
                                    {
                                        int role_account_retrieved =
                                            reader_role_account.GetInt32(0);

                                        if (role_account_retrieved == 0)
                                        {
                                            // Staff
                                            Config.Role_account = "EMPLOYEE";
                                            Console.WriteLine($"Role account: {Config.Role_account}");
                                        }
                                        else if (role_account_retrieved == 1)
                                        {
                                            // Administrator
                                            Config.Role_account = "ADMIN";
                                            Console.WriteLine($"Role account: {Config.Role_account}");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cannot fetch role account. Please contact to the administrator!" +
                                                $"\n\nRole Account: {role_account_retrieved}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dbCon.Close();
                                dbCon = null;
                            }
                        }
                    }
                }

                if (dbCon != null)
                {
                    dbCon.Close();
                    dbCon = null;
                }

                dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    DateTime currentDateTime = DateTime.Now;

                    string add_log =
                        "INSERT INTO User_Log " +
                        " (username_logged_in, date_user_logged_in, time_user_logged_in, date_user_logged_out, time_user_logged_out) VALUES (" +
                        "\"" + Config.Username_shared + 
                        "\", \"" + 
                        currentDateTime.ToLongDateString() + 
                        "\", \"" + 
                        currentDateTime.ToLongTimeString()
                        + "\", \"\", \"\")";

                    var cmd_add_log = new MySqlCommand(add_log, dbCon.Connection);
                    var exec_query_add_log = cmd_add_log.ExecuteNonQuery();

                    if (exec_query_add_log > 0)
                    {
                        Console.Write("Done\n");
                    }
                    else
                    {
                        Console.Write("Failed\n");
                    }

                    dbCon.Close();
                    dbCon = null;

                    // We are done, now let's switch to the GUI!
                }
            }
            else
            {
                MessageBox.Show("Username and login must not be null!", "Login error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        protected virtual void OnViewLogButtonPressed()
        {
            ViewLogButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            OnViewLogButtonPressed();
        }
    }
}
