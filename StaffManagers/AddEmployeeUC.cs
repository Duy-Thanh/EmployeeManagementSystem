using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class AddEmployeeUC : UserControl
    {
        private Panel panelBrowser;

        private Timer timerBrowser;

        private HelpBrowser helpBrowser;

        public event EventHandler OnBackButtonPressed;

        private event EventHandler CloseBrowserEventHandle;

        private bool isSafeToExit;

        public bool IsSafeToExit
        {
            get { return isSafeToExit; }
            set { isSafeToExit = value; }
        }

        public AddEmployeeUC()
        {
            InitializeComponent();

            this.Load += AddEmployeeUC_Load;
        }

        private void AddEmployeeUC_Load(object sender, EventArgs e)
        {
            cbbRoleAccount.SelectedIndex = 0;
            cbbGender.SelectedIndex = 0;
        }

        protected virtual void OnBackButtonPress()
        {
            if (txtUsername.Text != ""          ||
                txtPassword.Text != ""          ||
                cbbRoleAccount.Text != "Staff"  ||
                txtFullName.Text != ""          ||
                txtPhoneNumber.Text != ""       ||
                txtDateOfBirth.Text != ""       ||
                cbbGender.Text != "Male"        ||
                txtAddress.Text != ""           ||
                txtPosition.Text != ""          ||
                txtEmail.Text != "")
            {
                if (MessageBox.Show(
                    "You have made changes recently. If you exit, you will lose any changes. " +
                    "Do you want to continue?", "Discard changes", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    IsSafeToExit = false;
                }
                else
                {
                    IsSafeToExit = true;
                }
            }
            else
            {
                IsSafeToExit = true;
            }

            OnBackButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != ""          ||
                txtPassword.Text != ""          ||
                txtFullName.Text != ""          ||
                txtPhoneNumber.Text != ""       ||
                txtDateOfBirth.Text != ""       ||
                txtAddress.Text != ""           ||
                txtPosition.Text != ""          ||
                txtEmail.Text != "")
            {
                var dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    bool role_account = false;

                    if (cbbRoleAccount.Text == "Admin")
                    {
                        role_account = true;
                    }
                    else role_account = false;

                    string add_query =
                        "INSERT INTO Account_System " +
                        "(user_login, user_password, role_account, " +
                        "full_name, date_of_birth, gender, " +
                        "address, employee_status, phone_number, " +
                        "employee_position, email) VALUES " +
                        "(" +
                        "\"" + txtUsername.Text + "\", " +
                        "\"" + txtPassword.Text + "\", " +
                        (role_account ? "1" : "0") + ", " + // Assuming role_account is a boolean value
                        "\"" + txtFullName.Text + "\", " +
                        "\"" + txtDateOfBirth.Text + "\", " +
                        "\"" + cbbGender.Text + "\", " +
                        "\"" + txtAddress.Text + "\", " +
                        "1, " + // Assuming employee_status is always 1
                        "\"" + txtPhoneNumber.Text + "\", " +
                        "\"" + txtPosition.Text + "\", " +
                        "\"" + txtEmail.Text + "\"" + // Assuming txtEmail is the email input field
                        ")";

                    var cmd_add_query = new MySqlCommand(add_query, dbCon.Connection);
                    cmd_add_query.ExecuteNonQuery();

                    MessageBox.Show("Add employee completed successfully",
                        "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbCon.Close();
                    dbCon = null;

                    IsSafeToExit = true;
                }
            }
            else
            {
                MessageBox.Show("Cannot add new employee\n\nReason: Required fields must not be null!", 
                    "Add Employee Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void customizedButton1_Click(object sender, EventArgs e)
        {
            // Help button
            panelBrowser = new Panel();
            panelBrowser.Dock = DockStyle.Fill;

            helpBrowser = new HelpBrowser();
            helpBrowser.Dock = DockStyle.Fill;

            helpBrowser.Visible = true;
            helpBrowser.Enabled = true;

            timerBrowser = new Timer();
            timerBrowser.Interval = 1;

            timerBrowser.Tick += TimerBrowser_Tick;

            timerBrowser.Start();

            helpBrowser.CloseBrowserClick += HelpBrowser_CloseBrowserClick;
            helpBrowser.Html_file = "add_employee.html";

            panelBrowser.Controls.Add(helpBrowser);

            panelBrowser.Visible = true;
            panelBrowser.Enabled = true;

            this.Controls.Add(panelBrowser);
            panelBrowser.BringToFront();
        }

        private bool isBrowserClose;

        public bool IsBrowserClose
        {
            get { return isBrowserClose; }
            set { isBrowserClose = value; }
        }

        protected virtual void OnCloseBrowserEventHandle()
        {
            if (!IsBrowserClose)
            {
                IsBrowserClose = true;
            }
            else return;

            CloseBrowserEventHandle?.Invoke(this, EventArgs.Empty);
        }

        private void HelpBrowser_CloseBrowserClick(object sender, EventArgs e)
        {
            OnCloseBrowserEventHandle();
        }

        private void TimerBrowser_Tick(object sender, EventArgs e)
        {
            if (IsBrowserClose)
            {
                panelBrowser.Controls.Remove(helpBrowser);
                this.Controls.Remove(panelBrowser);

                timerBrowser.Stop();

                Process parentProcess = Process.GetCurrentProcess();

                // Get the child processes
                IList<Process> childProcesses = parentProcess.GetChildProcesses();

                // Display information about child processes
                //Console.WriteLine("Child processes:");
                foreach (Process childProcess in childProcesses)
                {
                    //Console.WriteLine($"Name: {childProcess.ProcessName}, ID: {childProcess.Id}");

                    string cmd_kill_pid = $"C:\\WINDOWS\\System32\\taskkill.exe /PID {childProcess.Id} /F /T";

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "C:\\WINDOWS\\System32\\cmd.exe";
                    startInfo.Arguments = $"/c {cmd_kill_pid}";
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;

                    Process cmdProcess = new Process();
                    cmdProcess.StartInfo = startInfo;
                    cmdProcess.Start();
                    cmdProcess.WaitForExit();
                }

                IsBrowserClose = false;
            }
            else return;
        }

        #region Unused code
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Unused code
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackButtonPress();
        }
    }
}
