namespace StaffManagers
{
    partial class LoginUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLoginOptions = new System.Windows.Forms.Panel();
            this.btnViewLog = new StaffManagers.CustomizedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 627);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 144);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome back to Employee Management \r\nSystem!\r\n\r\nTo continue, please enter your c" +
    "redentials \r\nhere\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(40, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(537, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 295);
            this.panel2.TabIndex = 1;
            // 
            // panelLoginOptions
            // 
            this.panelLoginOptions.Location = new System.Drawing.Point(537, 491);
            this.panelLoginOptions.Name = "panelLoginOptions";
            this.panelLoginOptions.Size = new System.Drawing.Size(482, 51);
            this.panelLoginOptions.TabIndex = 3;
            // 
            // btnViewLog
            // 
            this.btnViewLog.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnViewLog.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnViewLog.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnViewLog.BorderRadius = 20;
            this.btnViewLog.BorderSize = 0;
            this.btnViewLog.FlatAppearance.BorderSize = 0;
            this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLog.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLog.ForeColor = System.Drawing.Color.White;
            this.btnViewLog.Location = new System.Drawing.Point(977, 567);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(124, 40);
            this.btnViewLog.TabIndex = 4;
            this.btnViewLog.Text = "View Log";
            this.btnViewLog.TextColor = System.Drawing.Color.White;
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // LoginUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::StaffManagers.Properties.Resources.ur0EyqQN_2x;
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.panelLoginOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LoginUserControl";
            this.Size = new System.Drawing.Size(1119, 624);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelLoginOptions;
        private CustomizedButton btnViewLog;
    }
}
