using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class SelectionUserControl : UserControl
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; lblTitle.Text = Title; }
        }

        private Image icon;
        
        public Image Icon
        {
            get { return icon; }
            set { icon = value; picIcon.Image = Icon; }
        }

        private bool isClicked;

        public bool IsClicked
        {
            get { return isClicked; }
            set { isClicked = value; }
        }

        private Color title_BackColor;

        public Color Title_BackColor
        {
            get { return title_BackColor; }
            set { title_BackColor = value; lblTitle.BackColor = Title_BackColor; }
        }

        private Color icon_BackColor;

        public Color Icon_BackColor
        {
            get { return icon_BackColor; }
            set { icon_BackColor = value; picIcon.BackColor = Icon_BackColor; }
        }

        public event EventHandler MouseEnterIcon;
        public event EventHandler MouseLeaveIcon;

        public event EventHandler MouseEnterTitle;
        public event EventHandler MouseLeaveTitle;

        public event EventHandler ClickIcon;
        public event EventHandler ClickTitle;

        public SelectionUserControl()
        {
            InitializeComponent();

            lblTitle.Text = "";

            picIcon.MouseEnter += PicIcon_MouseEnter;
            picIcon.MouseLeave += PicIcon_MouseLeave;

            lblTitle.MouseEnter += LblTitle_MouseEnter;
            lblTitle.MouseLeave += LblTitle_MouseLeave;

            picIcon.Click += PicIcon_Click;
            lblTitle.Click += LblTitle_Click;
        }

        protected virtual void OnTitleClicked()
        {
            ClickTitle?.Invoke(this, EventArgs.Empty);
        }

        private void LblTitle_Click(object sender, EventArgs e)
        {
            OnTitleClicked();
        }

        protected virtual void OnIconClicked()
        {
            ClickIcon?.Invoke(this, EventArgs.Empty);
        }

        private void PicIcon_Click(object sender, EventArgs e)
        {
            OnIconClicked();
        }

        protected virtual void OnMouseLeaveTitle()
        {
            MouseLeaveTitle?.Invoke(this, EventArgs.Empty);
        }

        private void LblTitle_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeaveTitle();
        }

        protected virtual void OnMouseEnterTitle()
        {
            MouseEnterTitle?.Invoke(this, EventArgs.Empty);
        }

        private void LblTitle_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnterTitle();
        }

        protected virtual void OnMouseLeaveIcon()
        {
            MouseLeaveIcon?.Invoke(this, EventArgs.Empty);
        }

        private void PicIcon_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeaveIcon();
        }

        protected virtual void OnMouseEnterIcon()
        {
            MouseEnterIcon?.Invoke(this, EventArgs.Empty);
        }

        private void PicIcon_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnterIcon();
        }
    }
}