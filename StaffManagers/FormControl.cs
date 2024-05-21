using StaffManagers.Properties;
using System;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class FormControl : UserControl
    {
        // Can be delete?

        private string label_title;

        public string Label_title
        {
            get { return label_title; }
            set { label_title = value; lblTitle.Text = label_title; }
        }

        private bool btn_close_enabled;

        public bool Btn_close_enabled
        {
            get { return btn_close_enabled; }
            set { btn_close_enabled = value; btnClose.Visible = Btn_close_enabled; }
        }

        private bool btn_minimize_enabled;

        public bool Btn_minimize_enabled
        {
            get { return btn_minimize_enabled; }
            set { btn_minimize_enabled = value; btnMinimize.Visible = Btn_minimize_enabled; }
        }

        private bool btn_back_enabled;

        public bool Btn_back_enabled
        {
            get { return btn_back_enabled; }
            set { btn_back_enabled = value; btnBack.Visible = Btn_back_enabled; }
        }

        #region Custom Handler
        public event EventHandler ButtonMinimizeHandler;
        public event EventHandler ButtonBackHandler;
        #endregion

        public FormControl()
        {
            InitializeComponent();
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            btnMinimize.MouseEnter += BtnMinimize_MouseEnter;
            btnMinimize.MouseLeave += BtnMinimize_MouseLeave;
        }

        private void BtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.Image = Resources.minimize_normal;
        }

        private void BtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.Image = Resources.minimize_hover;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Resources.close_normal;
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Resources.close_hover;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose.Image = Resources.close_click;
            if (MessageBox.Show("Do you want to exit the app?",
                "Session Management", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else return;
        }

        #region Unused code
        private void FormControl_MouseDown(object sender, MouseEventArgs e)
        {

        }
        #endregion

        protected virtual void OnBtnMinimizeClick()
        {
            ButtonMinimizeHandler?.Invoke(this, EventArgs.Empty);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            OnBtnMinimizeClick();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
