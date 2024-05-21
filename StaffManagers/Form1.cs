using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class Form1 : Form
    {
        private Form currentChildForm;

        LoginUserControl loginUserControl = new LoginUserControl();
        FormControlHomepage formControlHomepage = new FormControlHomepage();
        AdministrativeUserControl adminPage = new AdministrativeUserControl();
        FormControl formLoginControl = new FormControl();

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        // Copied from dwmapi.h
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        // Copied from dwmapi.h
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        public Form1(bool isWindows11Detected)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            if (isWindows11Detected)
            {
                var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                DwmSetWindowAttribute(this.Handle, 
                    attribute, ref preference, sizeof(uint));
            }
            else
            {
                ElipseControl cornerEffect = new ElipseControl();
                cornerEffect.CornerRadius = 40;
                cornerEffect.TargetControl = this;
            }

            formLoginControl.Label_title = "Employee Management System";

            formLoginControl.Btn_back_enabled = false;
            formLoginControl.Btn_close_enabled = true;
            formLoginControl.Btn_minimize_enabled = true;
            formLoginControl.MouseDown += FormControl1_MouseDown;
            this.MouseDown += Form1_MouseDown;
            formLoginControl.ButtonMinimizeHandler += FormControl1_ButtonMinimizeHandler;

            // Login form will be show!
            formControl1.Controls.Add(formLoginControl);
            panelForm.Controls.Add(loginUserControl);

            loginUserControl.ViewLogButtonPressed += LoginUserControl_ViewLogButtonPressed;

            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ShowChildForm(Form childForm)
        {
            // Close the currently displayed child form, if any
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // Set the child form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.Sizable;

            // Add the child form to the container panel
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;

            // Display the child form
            childForm.BringToFront();
            childForm.Show();

            // Update the currentChildForm reference
            currentChildForm = childForm;
        }

        private void LoginUserControl_ViewLogButtonPressed(object sender, EventArgs e)
        {
            frmViewLog viewLog = new frmViewLog();
            viewLog.MdiParent = this.FindForm();
            viewLog.FormBorderStyle = FormBorderStyle.Sizable;
            viewLog.Show();
            ShowChildForm(viewLog);
        }

        private void FormControl1_ButtonMinimizeHandler(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeHandler.ReleaseCapture();
                NativeHandler.SendMessage(Handle, NativeHandler.WM_NCLBUTTONDOWN, NativeHandler.HT_CAPTION, 0);
            }
        }

        private void FormControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeHandler.ReleaseCapture();
                NativeHandler.SendMessage(Handle, NativeHandler.WM_NCLBUTTONDOWN, NativeHandler.HT_CAPTION, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Config.Role_account == "ADMIN")
            {
                this.timer1.Stop();

                formControl1.Controls.Remove(loginUserControl);
                loginUserControl.Enabled = false;
                loginUserControl.Visible = false;
                formControl1.Controls.Clear();
                panelForm.Controls.Clear();

                formControl1.MouseDown += FormControl1_MouseDown;

                formControlHomepage.Mode_running = Config.Role_account;
                formControlHomepage.Dock = DockStyle.Fill;

                formControlHomepage.OnControlMouseDown += FormControlHomepage_OnControlMouseDown;
                formControlHomepage.OnMinimizeButtonPressed += FormControlHomepage_OnMinimizeButtonPressed;

                formControlHomepage.OnSignOutButtonPressed += FormControlHomepage_OnSignOutButtonPressed;

                formControl1.Controls.Add(formControlHomepage);

                adminPage.Dock = DockStyle.Fill;
                panelForm.Controls.Add(adminPage);

                formControl1.BringToFront();
            }
            else if (Config.Role_account == "EMPLOYEE")
            {
                this.timer1.Stop();
            }
            else return;
        }

        private void FormControlHomepage_OnSignOutButtonPressed(object sender, EventArgs e)
        {
            OverlayTransparentPanel panel = new OverlayTransparentPanel();

            panel.Dock = DockStyle.Fill;
            panel.Width = this.Width;
            panel.Height = this.Height;

            this.Controls.Add(panel);

            panel.BringToFront();

            if (MessageBox.Show("Are you sure you want to sign out?", "Account session management",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close();
            }
            else
            {
                panel.Visible = false;

                this.Controls.Remove(panel);

                formControl1.ResumeLayout();
                panelForm.ResumeLayout();

                panelForm.BringToFront();
                formControl1.BringToFront();
            }
        }

        private void FormControlHomepage_OnMinimizeButtonPressed(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormControlHomepage_OnControlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeHandler.ReleaseCapture();
                NativeHandler.SendMessage(Handle, NativeHandler.WM_NCLBUTTONDOWN, NativeHandler.HT_CAPTION, 0);
            }
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
