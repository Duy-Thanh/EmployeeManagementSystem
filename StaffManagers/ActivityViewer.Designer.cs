namespace StaffManagers
{
    partial class ActivityViewer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnableDisableAutoScroll = new System.Windows.Forms.Button();
            this.btnStartStopRefresh = new System.Windows.Forms.Button();
            this.dgvLogViewer = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnManualRefresh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManualRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Activity Viewer";
            // 
            // btnEnableDisableAutoScroll
            // 
            this.btnEnableDisableAutoScroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableDisableAutoScroll.Location = new System.Drawing.Point(188, 104);
            this.btnEnableDisableAutoScroll.Name = "btnEnableDisableAutoScroll";
            this.btnEnableDisableAutoScroll.Size = new System.Drawing.Size(169, 32);
            this.btnEnableDisableAutoScroll.TabIndex = 11;
            this.btnEnableDisableAutoScroll.Text = "Enable Auto Scroll";
            this.btnEnableDisableAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnStartStopRefresh
            // 
            this.btnStartStopRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStopRefresh.Location = new System.Drawing.Point(13, 104);
            this.btnStartStopRefresh.Name = "btnStartStopRefresh";
            this.btnStartStopRefresh.Size = new System.Drawing.Size(169, 32);
            this.btnStartStopRefresh.TabIndex = 9;
            this.btnStartStopRefresh.Text = "Enable Auto Refresh";
            this.btnStartStopRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvLogViewer
            // 
            this.dgvLogViewer.AllowUserToAddRows = false;
            this.dgvLogViewer.AllowUserToDeleteRows = false;
            this.dgvLogViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogViewer.Location = new System.Drawing.Point(0, 154);
            this.dgvLogViewer.Name = "dgvLogViewer";
            this.dgvLogViewer.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogViewer.RowHeadersWidth = 51;
            this.dgvLogViewer.RowTemplate.Height = 24;
            this.dgvLogViewer.Size = new System.Drawing.Size(785, 393);
            this.dgvLogViewer.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date/Time";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Log Message";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1;
            // 
            // btnManualRefresh
            // 
            this.btnManualRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManualRefresh.Image = global::StaffManagers.Properties.Resources.refresh;
            this.btnManualRefresh.Location = new System.Drawing.Point(728, 30);
            this.btnManualRefresh.Name = "btnManualRefresh";
            this.btnManualRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnManualRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnManualRefresh.TabIndex = 13;
            this.btnManualRefresh.TabStop = false;
            // 
            // ActivityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnManualRefresh);
            this.Controls.Add(this.btnEnableDisableAutoScroll);
            this.Controls.Add(this.btnStartStopRefresh);
            this.Controls.Add(this.dgvLogViewer);
            this.Controls.Add(this.label1);
            this.Name = "ActivityViewer";
            this.Size = new System.Drawing.Size(785, 547);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnManualRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnableDisableAutoScroll;
        private System.Windows.Forms.Button btnStartStopRefresh;
        private System.Windows.Forms.DataGridView dgvLogViewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox btnManualRefresh;
    }
}
