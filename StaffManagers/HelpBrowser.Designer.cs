namespace StaffManagers
{
    partial class HelpBrowser
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
            this.progressLoading = new System.Windows.Forms.ProgressBar();
            this.btnDevTool = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnReload = new System.Windows.Forms.PictureBox();
            this.btnForward = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 405);
            this.panel1.TabIndex = 0;
            // 
            // progressLoading
            // 
            this.progressLoading.BackColor = System.Drawing.Color.White;
            this.progressLoading.ForeColor = System.Drawing.Color.Transparent;
            this.progressLoading.Location = new System.Drawing.Point(0, 0);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.Size = new System.Drawing.Size(785, 55);
            this.progressLoading.TabIndex = 1;
            // 
            // btnDevTool
            // 
            this.btnDevTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDevTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevTool.Image = global::StaffManagers.Properties.Resources.devtool;
            this.btnDevTool.Location = new System.Drawing.Point(626, 3);
            this.btnDevTool.Name = "btnDevTool";
            this.btnDevTool.Size = new System.Drawing.Size(48, 48);
            this.btnDevTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnDevTool.TabIndex = 7;
            this.btnDevTool.TabStop = false;
            this.btnDevTool.Click += new System.EventHandler(this.btnDevTool_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::StaffManagers.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(734, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReload.Image = global::StaffManagers.Properties.Resources.refresh_ios;
            this.btnReload.Location = new System.Drawing.Point(680, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(48, 48);
            this.btnReload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnReload.TabIndex = 5;
            this.btnReload.TabStop = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForward.Image = global::StaffManagers.Properties.Resources.forward_ios;
            this.btnForward.Location = new System.Drawing.Point(53, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(48, 48);
            this.btnForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnForward.TabIndex = 4;
            this.btnForward.TabStop = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Image = global::StaffManagers.Properties.Resources.back_ios_new;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(48, 48);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnBack.TabIndex = 3;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // HelpBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDevTool);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.progressLoading);
            this.Controls.Add(this.panel1);
            this.Name = "HelpBrowser";
            this.Size = new System.Drawing.Size(785, 461);
            ((System.ComponentModel.ISupportInitialize)(this.btnDevTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnReload;
        private System.Windows.Forms.PictureBox btnForward;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.ProgressBar progressLoading;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnDevTool;
    }
}
