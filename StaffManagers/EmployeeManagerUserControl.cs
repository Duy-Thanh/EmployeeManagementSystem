using StaffManagers.Properties;
using System;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class EmployeeManagerUserControl : UserControl
    {
        public EmployeeManagerUserControl()
        {
            InitializeComponent();

            this.Load += EmployeeManagerUserControl_Load;
        }

        private void EmployeeManagerUserControl_Load(object sender, EventArgs e)
        {
            label1.Font = FontLoader.LoadFontToMemory(20.0F);

            EmployeeManagerDashboard dashboard = new EmployeeManagerDashboard();

            dashboard.Dock = DockStyle.Fill;

            dashboard.Visible = true;
            dashboard.Enabled = true;

            panelEmployeeManagement.Controls.Add(dashboard);
        }
    }
}
