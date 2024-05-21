namespace StaffManagers
{
    partial class AddEmployeeUserControl
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
            this.panelAddEmployee = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelAddEmployee
            // 
            this.panelAddEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddEmployee.Location = new System.Drawing.Point(0, 0);
            this.panelAddEmployee.Name = "panelAddEmployee";
            this.panelAddEmployee.Size = new System.Drawing.Size(785, 461);
            this.panelAddEmployee.TabIndex = 0;
            // 
            // AddEmployeeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelAddEmployee);
            this.Name = "AddEmployeeUserControl";
            this.Size = new System.Drawing.Size(785, 461);
            this.Load += new System.EventHandler(this.AddEmployeeUserControl_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAddEmployee;
    }
}
