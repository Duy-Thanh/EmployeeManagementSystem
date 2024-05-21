namespace StaffManagers
{
    partial class EmployeeManagerDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.manageAllEmployee = new StaffManagers.SelectableItems();
            this.deleteEmployee = new StaffManagers.SelectableItems();
            this.updateEmployee = new StaffManagers.SelectableItems();
            this.addEmployee = new StaffManagers.SelectableItems();
            this.SuspendLayout();
            // 
            // manageAllEmployee
            // 
            this.manageAllEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.manageAllEmployee.Icon = null;
            this.manageAllEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.manageAllEmployee.Location = new System.Drawing.Point(13, 230);
            this.manageAllEmployee.Name = "manageAllEmployee";
            this.manageAllEmployee.Size = new System.Drawing.Size(250, 200);
            this.manageAllEmployee.TabIndex = 3;
            this.manageAllEmployee.Title = null;
            this.manageAllEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.manageAllEmployee.Value = null;
            this.manageAllEmployee.Value_BackColor = System.Drawing.Color.Empty;
            // 
            // deleteEmployee
            // 
            this.deleteEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.deleteEmployee.Icon = null;
            this.deleteEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.deleteEmployee.Location = new System.Drawing.Point(525, 24);
            this.deleteEmployee.Name = "deleteEmployee";
            this.deleteEmployee.Size = new System.Drawing.Size(250, 200);
            this.deleteEmployee.TabIndex = 2;
            this.deleteEmployee.Title = null;
            this.deleteEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.deleteEmployee.Value = null;
            this.deleteEmployee.Value_BackColor = System.Drawing.Color.Empty;
            this.deleteEmployee.Load += new System.EventHandler(this.deleteEmployee_Load);
            // 
            // updateEmployee
            // 
            this.updateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.updateEmployee.Icon = null;
            this.updateEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.updateEmployee.Location = new System.Drawing.Point(269, 24);
            this.updateEmployee.Name = "updateEmployee";
            this.updateEmployee.Size = new System.Drawing.Size(250, 200);
            this.updateEmployee.TabIndex = 1;
            this.updateEmployee.Title = null;
            this.updateEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.updateEmployee.Value = null;
            this.updateEmployee.Value_BackColor = System.Drawing.Color.Empty;
            this.updateEmployee.Load += new System.EventHandler(this.updateEmployee_Load);
            // 
            // addEmployee
            // 
            this.addEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addEmployee.Icon = null;
            this.addEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.addEmployee.Location = new System.Drawing.Point(13, 24);
            this.addEmployee.Name = "addEmployee";
            this.addEmployee.Size = new System.Drawing.Size(250, 200);
            this.addEmployee.TabIndex = 0;
            this.addEmployee.Title = null;
            this.addEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.addEmployee.Value = null;
            this.addEmployee.Value_BackColor = System.Drawing.Color.Empty;
            // 
            // EmployeeManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.manageAllEmployee);
            this.Controls.Add(this.deleteEmployee);
            this.Controls.Add(this.updateEmployee);
            this.Controls.Add(this.addEmployee);
            this.Name = "EmployeeManagerDashboard";
            this.Size = new System.Drawing.Size(785, 461);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectableItems addEmployee;
        private SelectableItems updateEmployee;
        private SelectableItems deleteEmployee;
        private SelectableItems manageAllEmployee;
    }
}
