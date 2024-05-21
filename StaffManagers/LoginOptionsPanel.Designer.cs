namespace StaffManagers
{
    partial class LoginOptionsPanel
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
            this.chkRememberCredentials = new System.Windows.Forms.CheckBox();
            this.btnForgotPassword = new StaffManagers.CustomizedButton();
            this.SuspendLayout();
            // 
            // chkRememberCredentials
            // 
            this.chkRememberCredentials.AutoSize = true;
            this.chkRememberCredentials.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberCredentials.Location = new System.Drawing.Point(3, 9);
            this.chkRememberCredentials.Name = "chkRememberCredentials";
            this.chkRememberCredentials.Size = new System.Drawing.Size(212, 28);
            this.chkRememberCredentials.TabIndex = 0;
            this.chkRememberCredentials.Text = "Save login credentials";
            this.chkRememberCredentials.UseVisualStyleBackColor = true;
            this.chkRememberCredentials.CheckedChanged += new System.EventHandler(this.chkRememberCredentials_CheckedChanged);
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnForgotPassword.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnForgotPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.btnForgotPassword.BorderRadius = 20;
            this.btnForgotPassword.BorderSize = 0;
            this.btnForgotPassword.FlatAppearance.BorderSize = 0;
            this.btnForgotPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotPassword.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotPassword.ForeColor = System.Drawing.Color.White;
            this.btnForgotPassword.Location = new System.Drawing.Point(322, 3);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(150, 40);
            this.btnForgotPassword.TabIndex = 1;
            this.btnForgotPassword.Text = "Forget password";
            this.btnForgotPassword.TextColor = System.Drawing.Color.White;
            this.btnForgotPassword.UseVisualStyleBackColor = false;
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // LoginOptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.chkRememberCredentials);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LoginOptionsPanel";
            this.Size = new System.Drawing.Size(487, 51);
            this.Load += new System.EventHandler(this.LoginOptionsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRememberCredentials;
        private CustomizedButton btnForgotPassword;
    }
}
