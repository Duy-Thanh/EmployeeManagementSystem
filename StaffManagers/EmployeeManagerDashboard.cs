using StaffManagers.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class EmployeeManagerDashboard : UserControl
    {
        private AddEmployeeUC addEmployeeUC;

        private UpdateEmployeeUC updateEmployeeUC;

        private DeleteEmployeeUC deleteEmployeeUC;

        private Panel panel;

        private Timer checkAddEmployeeExit;

        private Timer checkUpdateEmployeeExit;

        private Timer checkDeleteEmployeeExit;

        public EmployeeManagerDashboard()
        {
            InitializeComponent();

            this.Load += EmployeeManagerDashboard_Load;
        }

        public event EventHandler AddEmployeeClick;
        public event EventHandler UpdateEmployeeClick;
        public event EventHandler DeleteEmployeeClick;
        public event EventHandler ManageEmployeeClick;

        private void EmployeeManagerDashboard_Load(object sender, EventArgs e)
        {
            addEmployee.Title = "Add Employee";
            updateEmployee.Title = "Update Employee";
            deleteEmployee.Title = "Delete Employee";
            manageAllEmployee.Title = "Management Employee";

            Bitmap bmpAddPerson = new Bitmap(Resources.add_person);
            addEmployee.Icon = bmpAddPerson;

            Bitmap bmpUpdatePerson = new Bitmap(Resources.edit_person);
            updateEmployee.Icon = bmpUpdatePerson;

            Bitmap bmpDeletePerson = new Bitmap(Resources.delete_person);
            deleteEmployee.Icon = bmpDeletePerson;

            Bitmap bmpManagePerson = new Bitmap(Resources.manage_person);
            manageAllEmployee.Icon = bmpManagePerson;

            #region Add Employee Event Handler Declaration
            addEmployee.MouseEnter += AddEmployee_MouseEnter;
            addEmployee.MouseLeave += AddEmployee_MouseLeave;

            addEmployee.MouseEnterIcon += AddEmployee_MouseEnterIcon;
            addEmployee.MouseLeaveIcon += AddEmployee_MouseLeaveIcon;

            addEmployee.MouseEnterTitle += AddEmployee_MouseEnterTitle;
            addEmployee.MouseLeaveTitle += AddEmployee_MouseLeaveTitle;

            addEmployee.MouseEnterValue += AddEmployee_MouseEnterValue;
            addEmployee.MouseLeaveValue += AddEmployee_MouseLeaveValue;
            #endregion

            #region Update Employee Event Handler Declaration
            updateEmployee.MouseEnter += UpdateEmployee_MouseEnter;
            updateEmployee.MouseLeave += UpdateEmployee_MouseLeave;

            updateEmployee.MouseEnterIcon += UpdateEmployee_MouseEnterIcon;
            updateEmployee.MouseLeaveIcon += UpdateEmployee_MouseLeaveIcon;

            updateEmployee.MouseEnterTitle += UpdateEmployee_MouseEnterTitle;
            updateEmployee.MouseLeaveTitle += UpdateEmployee_MouseLeaveTitle;

            updateEmployee.MouseEnterValue += UpdateEmployee_MouseEnterValue;
            updateEmployee.MouseLeaveValue += UpdateEmployee_MouseLeaveValue;
            #endregion

            #region Delete Employee Event Handler Declaration
            deleteEmployee.MouseEnter += DeleteEmployee_MouseEnter;
            deleteEmployee.MouseLeave += DeleteEmployee_MouseLeave;

            deleteEmployee.MouseEnterIcon += DeleteEmployee_MouseEnterIcon;
            deleteEmployee.MouseLeaveIcon += DeleteEmployee_MouseLeaveIcon;

            deleteEmployee.MouseEnterTitle += DeleteEmployee_MouseEnterTitle;
            deleteEmployee.MouseLeaveTitle += DeleteEmployee_MouseLeaveTitle;

            deleteEmployee.MouseEnterValue += DeleteEmployee_MouseEnterValue;
            deleteEmployee.MouseLeaveValue += DeleteEmployee_MouseLeaveValue;
            #endregion

            #region Manage Employee Event Handler Declaration
            manageAllEmployee.MouseEnter += ManageAllEmployee_MouseEnter;
            manageAllEmployee.MouseLeave += ManageAllEmployee_MouseLeave;

            manageAllEmployee.MouseEnterIcon += ManageAllEmployee_MouseEnterIcon;
            manageAllEmployee.MouseLeaveIcon += ManageAllEmployee_MouseLeaveIcon;

            manageAllEmployee.MouseEnterTitle += ManageAllEmployee_MouseEnterTitle;
            manageAllEmployee.MouseLeaveTitle += ManageAllEmployee_MouseLeaveTitle;

            manageAllEmployee.MouseEnterValue += ManageAllEmployee_MouseEnterValue;
            manageAllEmployee.MouseLeaveValue += ManageAllEmployee_MouseLeaveValue;
            #endregion

            // Click
            addEmployee.Click += AddEmployee_Click;
            addEmployee.ClickIcon += AddEmployee_ClickIcon;
            addEmployee.ClickTitle += AddEmployee_ClickTitle;
            addEmployee.ClickValue += AddEmployee_ClickValue;

            updateEmployee.Click += UpdateEmployee_Click;
            updateEmployee.ClickIcon += UpdateEmployee_ClickIcon;
            updateEmployee.ClickTitle += UpdateEmployee_ClickTitle;
            updateEmployee.ClickValue += UpdateEmployee_ClickValue;

            deleteEmployee.Click += DeleteEmployee_Click;
            deleteEmployee.ClickIcon += DeleteEmployee_ClickIcon;
            deleteEmployee.ClickTitle += DeleteEmployee_ClickTitle;
            deleteEmployee.ClickValue += DeleteEmployee_ClickValue;

            manageAllEmployee.Click += ManageAllEmployee_Click;
            manageAllEmployee.ClickIcon += ManageAllEmployee_ClickIcon;
            manageAllEmployee.ClickTitle += ManageAllEmployee_ClickTitle;
            manageAllEmployee.ClickValue += ManageAllEmployee_ClickValue;
        }

        protected virtual void OnManageAllEmployeeClick()
        {
            ManageEmployeeClick?.Invoke(this, EventArgs.Empty);
        }

        private void ManageAllEmployee_ClickValue(object sender, EventArgs e)
        {
            OnManageAllEmployeeClick();
        }

        private void ManageAllEmployee_ClickTitle(object sender, EventArgs e)
        {
            OnManageAllEmployeeClick();
        }

        private void ManageAllEmployee_ClickIcon(object sender, EventArgs e)
        {
            OnManageAllEmployeeClick();
        }

        private void ManageAllEmployee_Click(object sender, EventArgs e)
        {
            OnManageAllEmployeeClick();
        }

        protected virtual void OnDeleteEmployeeClick()
        {
            panel = new Panel();
            panel.Size = new Size(785, 461);
            panel.Dock = DockStyle.Fill;

            panel.Visible = true;
            panel.Enabled = true;

            deleteEmployeeUC = new DeleteEmployeeUC();
            deleteEmployeeUC.Dock = DockStyle.Fill;

            deleteEmployeeUC.Visible = true;
            deleteEmployeeUC.Enabled = true;

            panel.Controls.Add(deleteEmployeeUC);

            this.Controls.Add(panel);
            panel.BringToFront();

            checkDeleteEmployeeExit = new Timer();
            checkDeleteEmployeeExit.Interval = 1;

            checkDeleteEmployeeExit.Tick += CheckDeleteEmployeeExit_Tick;

            checkDeleteEmployeeExit.Start();

            DeleteEmployeeClick?.Invoke(this, EventArgs.Empty);
        }

        private void CheckDeleteEmployeeExit_Tick(object sender, EventArgs e)
        {
            if (deleteEmployeeUC.IsSafeToExit)
            {
                this.Controls.Remove(panel);

                checkDeleteEmployeeExit.Stop();
            }
        }

        private void DeleteEmployee_ClickValue(object sender, EventArgs e)
        {
            OnDeleteEmployeeClick();
        }

        private void DeleteEmployee_ClickIcon(object sender, EventArgs e)
        {
            OnDeleteEmployeeClick();
        }

        private void DeleteEmployee_ClickTitle(object sender, EventArgs e)
        {
            OnDeleteEmployeeClick();
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            OnDeleteEmployeeClick();
        }

        protected virtual void OnUpdateEmployeeClick()
        {
            panel = new Panel();
            panel.Size = new Size(785, 461);
            panel.Dock = DockStyle.Fill;

            panel.Visible = true;
            panel.Enabled = true;

            updateEmployeeUC = new UpdateEmployeeUC();
            updateEmployeeUC.Dock = DockStyle.Fill;

            updateEmployeeUC.Visible = true;
            updateEmployeeUC.Enabled = true;

            panel.Controls.Add(updateEmployeeUC);

            this.Controls.Add(panel);
            panel.BringToFront();

            checkUpdateEmployeeExit = new Timer();
            checkUpdateEmployeeExit.Interval = 1;

            checkUpdateEmployeeExit.Tick += CheckUpdateEmployeeExit_Tick;

            checkUpdateEmployeeExit.Start();

            UpdateEmployeeClick?.Invoke(this, EventArgs.Empty);
        }

        private void CheckUpdateEmployeeExit_Tick(object sender, EventArgs e)
        {
            if (updateEmployeeUC.IsSafeToExit)
            {
                this.Controls.Remove(panel);

                checkUpdateEmployeeExit.Stop();
            }
        }

        private void UpdateEmployee_ClickValue(object sender, EventArgs e)
        {
            OnUpdateEmployeeClick();
        }

        private void UpdateEmployee_ClickTitle(object sender, EventArgs e)
        {
            OnUpdateEmployeeClick();
        }

        private void UpdateEmployee_ClickIcon(object sender, EventArgs e)
        {
            OnUpdateEmployeeClick();
        }

        private void UpdateEmployee_Click(object sender, EventArgs e)
        {
            OnUpdateEmployeeClick();
        }

        protected virtual void OnAddEmployeeClick()
        {
            panel = new Panel();
            panel.Size = new Size(785, 461);
            panel.Dock = DockStyle.Fill;

            panel.Visible = true;
            panel.Enabled = true;

            addEmployeeUC = new AddEmployeeUC();
            addEmployeeUC.Dock = DockStyle.Fill;

            addEmployeeUC.Visible = true;
            addEmployeeUC.Enabled = true;

            panel.Controls.Add(addEmployeeUC);

            this.Controls.Add(panel);
            panel.BringToFront();

            checkAddEmployeeExit = new Timer();
            checkAddEmployeeExit.Interval = 1;

            checkAddEmployeeExit.Tick += CheckAddEmployeeExit_Tick;

            checkAddEmployeeExit.Start();

            AddEmployeeClick?.Invoke(this, EventArgs.Empty);
        }

        private void CheckAddEmployeeExit_Tick(object sender, EventArgs e)
        {
            if (addEmployeeUC.IsSafeToExit)
            {
                this.Controls.Remove(panel);

                checkAddEmployeeExit.Stop();
            }
        }

        private void AddEmployee_ClickValue(object sender, EventArgs e)
        {
            OnAddEmployeeClick();
        }

        private void AddEmployee_ClickTitle(object sender, EventArgs e)
        {
            OnAddEmployeeClick();
        }

        private void AddEmployee_ClickIcon(object sender, EventArgs e)
        {
            OnAddEmployeeClick();   
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            OnAddEmployeeClick();
        }

        #region Manage Employee MouseEnter/MouseLeave Event Handler Definitions
        private void ManageAllEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void ManageAllEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void ManageAllEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void ManageAllEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void ManageAllEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void ManageAllEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void ManageAllEmployee_MouseLeave(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void ManageAllEmployee_MouseEnter(object sender, EventArgs e)
        {
            manageAllEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }
        #endregion

        #region Delete Employee MouseEnter/MouseLeave Event Handler Definitions
        private void DeleteEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void DeleteEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void DeleteEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void DeleteEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void DeleteEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void DeleteEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void DeleteEmployee_MouseLeave(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void DeleteEmployee_MouseEnter(object sender, EventArgs e)
        {
            deleteEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }
        #endregion

        #region Update Employee MouseEnter/MouseLeave Event Handler Definitions
        private void UpdateEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UpdateEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UpdateEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UpdateEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UpdateEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UpdateEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void UpdateEmployee_MouseLeave(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void UpdateEmployee_MouseEnter(object sender, EventArgs e)
        {
            updateEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }
        #endregion

        #region Add Employee MouseEnter/MouseLeave Event Handler Defintions
        private void AddEmployee_MouseLeaveValue(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void AddEmployee_MouseEnterValue(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void AddEmployee_MouseLeaveTitle(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void AddEmployee_MouseEnterTitle(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void AddEmployee_MouseLeaveIcon(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void AddEmployee_MouseEnterIcon(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }

        private void AddEmployee_MouseLeave(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#210B61");
        }

        private void AddEmployee_MouseEnter(object sender, EventArgs e)
        {
            addEmployee.BackColor = ColorTranslator.FromHtml("#48088A");
        }
        #endregion

        private void updateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void deleteEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}