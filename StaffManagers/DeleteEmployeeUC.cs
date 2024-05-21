using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class DeleteEmployeeUC : UserControl
    {
        string[] data_to_add;
        
        private bool isSafeToExit;

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

        public DeleteEmployeeUC()
        {
            InitializeComponent();

            this.Load += DeleteEmployeeUC_Load;
            dgvEmployeeViewer.CellClick += DgvEmployeeViewer_CellClick;
        }

        private void DgvEmployeeViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /**
             * if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
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
            **/

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvEmployeeViewer.Rows[e.RowIndex];

                Id = selectedRow.Cells[0].Value.ToString();
            }
        }

        private void DeleteEmployeeUC_Load(object sender, EventArgs e)
        {
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Delete Employee
            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                string update_employees =
                    "UPDATE Account_System SET employee_status = @Status WHERE ID = @UserId";

                var query_update_employees =
                    new MySqlCommand(update_employees, dbCon.Connection);

                query_update_employees.Parameters.AddWithValue("@Status", 2);
                query_update_employees.Parameters.AddWithValue("@UserId", Id);

                query_update_employees.ExecuteNonQuery();

                
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            IsSafeToExit = true;
        }
    }
}
