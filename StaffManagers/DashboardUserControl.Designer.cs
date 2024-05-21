namespace StaffManagers
{
    partial class DashboardUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.retiredEmployee = new StaffManagers.SelectableItems();
            this.unattendancedEmployee = new StaffManagers.SelectableItems();
            this.employeeAttendanced = new StaffManagers.SelectableItems();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dashboard";
            // 
            // retiredEmployee
            // 
            this.retiredEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.retiredEmployee.Icon = null;
            this.retiredEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.retiredEmployee.Location = new System.Drawing.Point(524, 101);
            this.retiredEmployee.Name = "retiredEmployee";
            this.retiredEmployee.Size = new System.Drawing.Size(250, 200);
            this.retiredEmployee.TabIndex = 5;
            this.retiredEmployee.Title = null;
            this.retiredEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.retiredEmployee.Value = null;
            this.retiredEmployee.Value_BackColor = System.Drawing.Color.Empty;
            // 
            // unattendancedEmployee
            // 
            this.unattendancedEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.unattendancedEmployee.Icon = null;
            this.unattendancedEmployee.Icon_BackColor = System.Drawing.Color.Empty;
            this.unattendancedEmployee.Location = new System.Drawing.Point(267, 101);
            this.unattendancedEmployee.Name = "unattendancedEmployee";
            this.unattendancedEmployee.Size = new System.Drawing.Size(250, 200);
            this.unattendancedEmployee.TabIndex = 4;
            this.unattendancedEmployee.Title = null;
            this.unattendancedEmployee.Title_BackColor = System.Drawing.Color.Empty;
            this.unattendancedEmployee.Value = null;
            this.unattendancedEmployee.Value_BackColor = System.Drawing.Color.Empty;
            // 
            // employeeAttendanced
            // 
            this.employeeAttendanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.employeeAttendanced.Icon = null;
            this.employeeAttendanced.Icon_BackColor = System.Drawing.Color.Empty;
            this.employeeAttendanced.Location = new System.Drawing.Point(10, 101);
            this.employeeAttendanced.Name = "employeeAttendanced";
            this.employeeAttendanced.Size = new System.Drawing.Size(250, 200);
            this.employeeAttendanced.TabIndex = 3;
            this.employeeAttendanced.Title = null;
            this.employeeAttendanced.Title_BackColor = System.Drawing.Color.Empty;
            this.employeeAttendanced.Value = null;
            this.employeeAttendanced.Value_BackColor = System.Drawing.Color.Empty;
            // 
            // DashboardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retiredEmployee);
            this.Controls.Add(this.unattendancedEmployee);
            this.Controls.Add(this.employeeAttendanced);
            this.Name = "DashboardUserControl";
            this.Size = new System.Drawing.Size(785, 547);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectableItems retiredEmployee;
        private SelectableItems unattendancedEmployee;
        private SelectableItems employeeAttendanced;
        private System.Windows.Forms.Label label1;
    }
}
