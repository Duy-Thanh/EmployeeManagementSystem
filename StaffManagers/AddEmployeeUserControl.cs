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
    public partial class AddEmployeeUserControl : UserControl
    {
        private bool isExit;

        public bool IsExit
        {
            get { return isExit; }
            set { isExit = value; }
        }

        public AddEmployeeUserControl()
        {
            InitializeComponent();

            this.Load += AddEmployeeUserControl_Load;
        }

        private void AddEmployeeUserControl_Load(object sender, EventArgs e)
        {
            AddEmployeeUC addEmployee = new AddEmployeeUC();
            addEmployee.Dock = DockStyle.Fill;
            addEmployee.OnBackButtonPressed += AddEmployee_OnBackButtonPressed;

            panelAddEmployee.Controls.Add(addEmployee);
        }

        private void AddEmployee_OnBackButtonPressed(object sender, EventArgs e)
        {
            panelAddEmployee.Controls.Clear();
        }

        private void AddEmployeeUserControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
