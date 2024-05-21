using StaffManagers.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class FormControlHomepage : UserControl
    {
        public event EventHandler OnCloseButtonPressed;
        public event EventHandler OnMinimizeButtonPressed;
        public event EventHandler OnSignOutButtonPressed;
        public event MouseEventHandler OnControlMouseDown;

        private string mode_running;

        public string Mode_running
        {
            get { return mode_running; }
            set 
            { 
                mode_running = value;

                if (Mode_running == "ADMIN")
                {
                    label1.Text = "ADMINISTRATIVE MODE";
                }
                else
                {
                    label1.Text = "STAFF MODE";
                }
            }
        }

        public FormControlHomepage()
        {
            InitializeComponent();

            // btnMinimize
            btnMinimize.MouseEnter += BtnMinimize_MouseEnter;
            btnMinimize.MouseLeave += BtnMinimize_MouseLeave;

            // btnClose
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;

            // btnSignOut
            btnSignOut.MouseEnter += BtnSignOut_MouseEnter;
            btnSignOut.MouseLeave += BtnSignOut_MouseLeave;
        }

        private void BtnSignOut_MouseLeave(object sender, EventArgs e)
        {
            btnSignOut.Image = Resources.signout_normal;
        }

        private void BtnSignOut_MouseEnter(object sender, EventArgs e)
        {
            btnSignOut.Image = Resources.signout_hover;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Resources.close_normal;
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Resources.close_hover;
        }

        private void BtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.Image = Resources.minimize_normal;
        }

        private void BtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.Image = Resources.minimize_hover;
        }

        protected virtual void SignOutButtonPressed()
        {
            OnSignOutButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SignOutButtonPressed();
        }

        protected virtual void MinimizeButtonPressed()
        {
            OnMinimizeButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            MinimizeButtonPressed();
        }

        private bool isSafeToExit;

        public bool IsSafeToExit
        {
            get { return isSafeToExit; }
            set { isSafeToExit = value; }
        }

        protected virtual void CloseButtonPressed()
        {
            if (MessageBox.Show("Close application will end your session. " +
                "You will need to login in the next time you launch the application. " +
                "Do you want to continue?", "Session Management", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsSafeToExit = true;
            }
            else
            {
                IsSafeToExit = false;
            }

            OnCloseButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseButtonPressed();

            if (IsSafeToExit) Application.Exit();
            else return;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "ADMINISTRATIVE MODE")
            {
                MessageBox.Show("You're in Administrative Mode, that's mean your account have administrator role.\n\n" +
                    "With administrator role, you having superuser permissions, and you can do anything you want.",
                    "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (label1.Text == "STAFF MODE")
            {
                MessageBox.Show("You're in Staff Mode, that's mean your account have staff or normal role.\n\n" +
                    "With staff or normal role only, you can do limited things on the software.",
                    "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }

        protected virtual void FormControlMouseDown(MouseEventArgs e)
        {
            OnControlMouseDown?.Invoke(this, e);
        }

        private void FormControlHomepage_MouseDown(object sender, MouseEventArgs e)
        {
            FormControlMouseDown(e);
        }
    }
}