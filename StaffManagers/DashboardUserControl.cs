using MySql.Data.MySqlClient;
using StaffManagers.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class DashboardUserControl : UserControl
    {
        public DashboardUserControl()
        {
            InitializeComponent();

            this.Load += DashboardUserControl_Load;
        }

        private void DashboardUserControl_Load(object sender, EventArgs e)
        {
            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string count_active =
                    "SELECT COUNT(*) FROM Account_System WHERE employee_status = @Status";

                var query_count_active =
                    new MySqlCommand(count_active, dbCon.Connection);
                query_count_active.Parameters.AddWithValue("@Status", 1);

                var reader_active = query_count_active.ExecuteReader();

                while (reader_active.Read())
                {
                    string active_employees = reader_active.GetValue(0).ToString();

                    employeeAttendanced.Value = active_employees;
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
                    string count_inactive =
                        "SELECT COUNT(*) FROM Account_System WHERE employee_status = @Status";

                    var query_count_inactive =
                        new MySqlCommand(count_inactive, dbCon.Connection);
                    query_count_inactive.Parameters.AddWithValue("@Status", 0);

                    var reader_inactive = query_count_inactive.ExecuteReader();

                    while (reader_inactive.Read())
                    {
                        string inactive_employees = reader_inactive.GetValue(0).ToString();

                        unattendancedEmployee.Value = inactive_employees;
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
                    string count_retired =
                        "SELECT COUNT(*) FROM Account_System WHERE employee_status = @Status";

                    var query_count_retired =
                        new MySqlCommand(count_retired, dbCon.Connection);
                    query_count_retired.Parameters.AddWithValue("@Status", 3);

                    var reader_retired = query_count_retired.ExecuteReader();

                    while (reader_retired.Read())
                    {
                        string retired_employees = reader_retired.GetValue(0).ToString();

                        retiredEmployee.Value = retired_employees;
                    }

                    dbCon.Close();
                    dbCon = null;
                }
            }

            employeeAttendanced.Title = "Attendance";

            Bitmap bmpEmployeeAttendance = new Bitmap(Resources.list_long);
            employeeAttendanced.Icon = bmpEmployeeAttendance;

            unattendancedEmployee.Title = "Unattendance";

            Bitmap bmpEmployeeUnattendance = new Bitmap(Resources.person_aspron);
            unattendancedEmployee.Icon = bmpEmployeeUnattendance;

            retiredEmployee.Title = "Retired Employees";

            Bitmap bmpRetired = new Bitmap(Resources.retired);
            retiredEmployee.Icon = bmpRetired;

            label1.Font = FontLoader.LoadFontToMemory(20.0F);

            employeeAttendanced.MouseEnter += EmployeeAttendanced_MouseEnter;
            employeeAttendanced.MouseLeave += EmployeeAttendanced_MouseLeave;

            employeeAttendanced.MouseEnterTitle += EmployeeAttendanced_MouseEnterTitle;
            employeeAttendanced.MouseLeaveTitle += EmployeeAttendanced_MouseLeaveTitle;

            employeeAttendanced.MouseEnterValue += EmployeeAttendanced_MouseEnterValue;
            employeeAttendanced.MouseLeaveValue += EmployeeAttendanced_MouseLeaveValue;

            employeeAttendanced.MouseEnterIcon += EmployeeAttendanced_MouseEnterIcon;
            employeeAttendanced.MouseLeaveIcon += EmployeeAttendanced_MouseLeaveIcon;

            unattendancedEmployee.MouseEnter += UnattendancedEmployee_MouseEnter;
            unattendancedEmployee.MouseLeave += UnattendancedEmployee_MouseLeave;

            unattendancedEmployee.MouseEnterIcon += UnattendancedEmployee_MouseEnterIcon;
            unattendancedEmployee.MouseLeaveIcon += UnattendancedEmployee_MouseLeaveIcon;

            unattendancedEmployee.MouseEnterTitle += UnattendancedEmployee_MouseEnterTitle;
            unattendancedEmployee.MouseLeaveTitle += UnattendancedEmployee_MouseLeaveTitle;

            unattendancedEmployee.MouseEnterValue += UnattendancedEmployee_MouseEnterValue;
            unattendancedEmployee.MouseLeaveValue += UnattendancedEmployee_MouseLeaveValue;

            retiredEmployee.MouseEnter += RetiredEmployee_MouseEnter;
            retiredEmployee.MouseLeave += RetiredEmployee_MouseLeave;

            retiredEmployee.MouseEnterIcon += RetiredEmployee_MouseEnterIcon;
            retiredEmployee.MouseLeaveIcon += RetiredEmployee_MouseLeaveIcon;

            retiredEmployee.MouseEnterTitle += RetiredEmployee_MouseEnterTitle;
            retiredEmployee.MouseLeaveTitle += RetiredEmployee_MouseLeaveTitle;

            retiredEmployee.MouseEnterValue += RetiredEmployee_MouseEnterValue;
            retiredEmployee.MouseLeaveValue += RetiredEmployee_MouseLeaveValue;
        }

        private void RetiredEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void RetiredEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void RetiredEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void RetiredEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void RetiredEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void RetiredEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UnattendancedEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UnattendancedEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UnattendancedEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UnattendancedEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UnattendancedEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UnattendancedEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void EmployeeAttendanced_MouseLeaveIcon(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void EmployeeAttendanced_MouseEnterIcon(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void EmployeeAttendanced_MouseLeaveValue(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void EmployeeAttendanced_MouseEnterValue(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void EmployeeAttendanced_MouseLeaveTitle(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void EmployeeAttendanced_MouseEnterTitle(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void RetiredEmployee_MouseLeave(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void RetiredEmployee_MouseEnter(object sender, EventArgs e)
        {
            retiredEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UnattendancedEmployee_MouseLeave(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UnattendancedEmployee_MouseEnter(object sender, EventArgs e)
        {
            unattendancedEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void EmployeeAttendanced_MouseLeave(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void EmployeeAttendanced_MouseEnter(object sender, EventArgs e)
        {
            employeeAttendanced.BackColor = ColorTranslator.FromHtml("#48088A");
        }
    }
}
