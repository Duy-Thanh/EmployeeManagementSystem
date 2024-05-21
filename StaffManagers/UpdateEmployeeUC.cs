using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class UpdateEmployeeUC : UserControl
    {
        public event EventHandler OnBackButtonPress;

        private bool isSafeToExit;

        public string[] data_to_add;

        public bool IsSafeToExit
        {
            get { return isSafeToExit; }
            set { isSafeToExit = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public UpdateEmployeeUC()
        {
            InitializeComponent();

            this.Load += UpdateEmployeeUC_Load1;
        }

        private void UpdateEmployeeUC_Load1(object sender, EventArgs e)
        {
            dgvEmployeeViewer.CellClick += DgvEmployeeViewer_CellClick;
        }

        private void DgvEmployeeViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvEmployeeViewer.Rows[e.RowIndex];

                Id = selectedRow.Cells[0].Value.ToString();
                txtUsername.Text = selectedRow.Cells[1].Value.ToString();
                txtPassword.Text = selectedRow.Cells[2].Value.ToString();
                cbbRoleAccount.Text = selectedRow.Cells[3].Value.ToString();
                txtFullName.Text = selectedRow.Cells[4].Value.ToString();
                txtDateOfBirth.Text = selectedRow.Cells[5].Value.ToString();
                cbbGender.Text = selectedRow.Cells[6].Value.ToString();
                txtAddress.Text = selectedRow.Cells[7].Value.ToString();
                cbbStatus.Text = 
                    (selectedRow.Cells[8].Value.ToString() == "0" ? "Inactive" : 
                    (selectedRow.Cells[8].Value.ToString() == "1" ? "Active" : "Retired"));
                txtPhoneNumber.Text = selectedRow.Cells[9].Value.ToString();
                txtPosition.Text = selectedRow.Cells[10].Value.ToString();
                txtEmail.Text = selectedRow.Cells[11].Value.ToString();
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateEmployeeUC_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;

            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string cmd_read_all_employees = "SELECT * FROM Account_System WHERE employee_status = 0 OR employee_status = 1";
                var query_read_all_employees = 
                    new MySqlCommand(cmd_read_all_employees, dbCon.Connection);

                var reader_read_all_employees = query_read_all_employees.ExecuteReader();

                while (reader_read_all_employees.Read())
                {
                    data_to_add = new string[12]
                    {
                        reader_read_all_employees.GetValue(0).ToString(),
                        reader_read_all_employees.GetValue(1).ToString(),
                        reader_read_all_employees.GetValue(2).ToString(),
                        reader_read_all_employees.GetValue(3).ToString(),
                        reader_read_all_employees.GetValue(4).ToString(),
                        reader_read_all_employees.GetValue(5).ToString(),
                        reader_read_all_employees.GetValue(6).ToString(),
                        reader_read_all_employees.GetValue(7).ToString(),
                        reader_read_all_employees.GetValue(8).ToString(),
                        reader_read_all_employees.GetValue(9).ToString(),
                        reader_read_all_employees.GetValue(10).ToString(),
                        reader_read_all_employees.GetValue(11).ToString()
                    };

                    dgvEmployeeViewer.Rows.Add(data_to_add);
                }

                dbCon.Close();
                dbCon = null;
            }
        }

        protected virtual void OnBackButtonPressed()
        {
            IsSafeToExit = true;
            OnBackButtonPress?.Invoke(this, EventArgs.Empty);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string update_username =
                    "UPDATE Account_System SET user_login = @Username WHERE ID = @UserID";

                var query_update_username = new MySqlCommand(update_username, dbCon.Connection);
                query_update_username.Parameters.AddWithValue("@Username", txtUsername.Text);
                query_update_username.Parameters.AddWithValue("@UserID", Id);

                query_update_username.ExecuteNonQuery();

                string update_password =
                    "UPDATE Account_System SET user_password = @Password WHERE ID = @UserID";

                var query_update_password = new MySqlCommand(update_password, dbCon.Connection);
                query_update_password.Parameters.AddWithValue("@Password", txtPassword.Text);
                query_update_password.Parameters.AddWithValue("@UserID", Id);

                query_update_password.ExecuteNonQuery();

                string update_role =
                    "UPDATE Account_System SET role_account = @Role WHERE ID = @UserID";

                var query_update_role = new MySqlCommand(update_role, dbCon.Connection);

                bool role = (cbbRoleAccount.Text == "Admin");

                query_update_role.Parameters.AddWithValue("@Role", role);
                query_update_role.Parameters.AddWithValue("@UserID", Id);

                query_update_password.ExecuteNonQuery();

                string update_full_name =
                    "UPDATE Account_System SET full_name = @FullName WHERE ID = @UserID";

                var query_update_full_name = new MySqlCommand(update_full_name, dbCon.Connection);
                query_update_full_name.Parameters.AddWithValue("@FullName", txtFullName.Text);
                query_update_full_name.Parameters.AddWithValue("@UserID", Id);

                query_update_full_name.ExecuteNonQuery();

                string update_dob =
                    "UPDATE Account_System SET date_of_birth = @DOB WHERE ID = @UserID";

                var query_update_dob = new MySqlCommand(update_dob, dbCon.Connection);
                query_update_dob.Parameters.AddWithValue("@DOB", txtDateOfBirth.Text);
                query_update_dob.Parameters.AddWithValue("@UserID", Id);

                query_update_dob.ExecuteNonQuery();

                string update_gender =
                    "UPDATE Account_System SET gender = @Gender WHERE ID = @UserID";

                var query_update_gender = new MySqlCommand(update_gender, dbCon.Connection);
                query_update_gender.Parameters.AddWithValue("@Gender", cbbGender.Text);
                query_update_gender.Parameters.AddWithValue("@UserID", Id);

                query_update_gender.ExecuteNonQuery();

                string update_address =
                    "UPDATE Account_System SET address = @Address WHERE ID = @UserID";

                var query_update_address = new MySqlCommand(update_address, dbCon.Connection);
                query_update_address.Parameters.AddWithValue("@Address", txtAddress.Text);
                query_update_address.Parameters.AddWithValue("@UserID", Id);

                query_update_address.ExecuteNonQuery();

                int status = cbbStatus.Text == "Active" ? 1 :
                    cbbStatus.Text == "Inactive" ? 0 :
                    cbbStatus.Text == "Retired" ? 2 : -1;

                string update_status =
                    "UPDATE Account_System SET employee_status = @Status WHERE ID = @UserID";

                var query_update_status = new MySqlCommand(update_status, dbCon.Connection);
                query_update_status.Parameters.AddWithValue("@Status", status);
                query_update_status.Parameters.AddWithValue("@UserID", Id);

                query_update_status.ExecuteNonQuery();

                string update_phone_number =
                    "UPDATE Account_System SET phone_number = @PhoneNumber WHERE ID = @UserID";

                var query_update_phone_number = new MySqlCommand(update_phone_number, dbCon.Connection);
                query_update_phone_number.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                query_update_phone_number.Parameters.AddWithValue("@UserID", Id);

                query_update_phone_number.ExecuteNonQuery();

                string update_position =
                    "UPDATE Account_System SET employee_position = @Position WHERE ID = @UserID";

                var query_update_position = new MySqlCommand(update_position, dbCon.Connection);
                query_update_position.Parameters.AddWithValue("@Position", txtPosition.Text);
                query_update_position.Parameters.AddWithValue("@UserID", Id);

                query_update_position.ExecuteNonQuery();

                string update_email =
                    "UPDATE Account_System SET email = @Email WHERE ID = @UserID";

                var query_update_email = new MySqlCommand(update_email, dbCon.Connection);
                query_update_email.Parameters.AddWithValue("@Email", txtEmail.Text);
                query_update_email.Parameters.AddWithValue("@UserID", Id);

                query_update_email.ExecuteNonQuery();

                dbCon.Close();
                dbCon = null;
            }

            MessageBox.Show("Update employee information completed successfully",
                "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string cmd_read_all_employees = "SELECT * FROM Account_System";
                var query_read_all_employees =
                    new MySqlCommand(cmd_read_all_employees, dbCon.Connection);

                var reader_read_all_employees = query_read_all_employees.ExecuteReader();

                dgvEmployeeViewer.Rows.Clear();

                while (reader_read_all_employees.Read())
                {
                    data_to_add = new string[12]
                    {
                        reader_read_all_employees.GetValue(0).ToString(),
                        reader_read_all_employees.GetValue(1).ToString(),
                        reader_read_all_employees.GetValue(2).ToString(),
                        reader_read_all_employees.GetValue(3).ToString(),
                        reader_read_all_employees.GetValue(4).ToString(),
                        reader_read_all_employees.GetValue(5).ToString(),
                        reader_read_all_employees.GetValue(6).ToString(),
                        reader_read_all_employees.GetValue(7).ToString(),
                        reader_read_all_employees.GetValue(8).ToString(),
                        reader_read_all_employees.GetValue(9).ToString(),
                        reader_read_all_employees.GetValue(10).ToString(),
                        reader_read_all_employees.GetValue(11).ToString()
                    };

                    dgvEmployeeViewer.Rows.Add(data_to_add);
                }

                dbCon.Close();
                dbCon = null;
            }

            IsSafeToExit = true;
        }

        private void btnManualRefresh_Click(object sender, EventArgs e)
        {
            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string cmd_read_all_employees = "SELECT * FROM Account_System";
                var query_read_all_employees =
                    new MySqlCommand(cmd_read_all_employees, dbCon.Connection);

                var reader_read_all_employees = query_read_all_employees.ExecuteReader();

                dgvEmployeeViewer.Rows.Clear();

                while (reader_read_all_employees.Read())
                {
                    data_to_add = new string[12]
                    {
                        reader_read_all_employees.GetValue(0).ToString(),
                        reader_read_all_employees.GetValue(1).ToString(),
                        reader_read_all_employees.GetValue(2).ToString(),
                        reader_read_all_employees.GetValue(3).ToString(),
                        reader_read_all_employees.GetValue(4).ToString(),
                        reader_read_all_employees.GetValue(5).ToString(),
                        reader_read_all_employees.GetValue(6).ToString(),
                        reader_read_all_employees.GetValue(7).ToString(),
                        reader_read_all_employees.GetValue(8).ToString(),
                        reader_read_all_employees.GetValue(9).ToString(),
                        reader_read_all_employees.GetValue(10).ToString(),
                        reader_read_all_employees.GetValue(11).ToString()
                    };

                    dgvEmployeeViewer.Rows.Add(data_to_add);
                }

                dbCon.Close();
                dbCon = null;
            }
        }
    }
}