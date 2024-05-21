using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class SelectableItems : UserControl
    {
        private string title;

        private string _value;

        private Image icon;

        public string Title
        {
            get { return title; }
            set { title = value; lblTitle.Text = Title; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; lblValue.Text = Value; }
        }

        public Image Icon
        {
            get { return icon; }
            set { icon = value; picIcon.Image = Icon; }
        }

        private Color title_BackColor;

        public Color Title_BackColor
        {
            get { return title_BackColor; }
            set { title_BackColor = value; lblTitle.BackColor = Title_BackColor; }
        }

        private Color value_BackColor;

        public Color Value_BackColor
        {
            get { return value_BackColor; }
            set { value_BackColor = value; lblValue.BackColor = Value_BackColor; }
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

        public event EventHandler MouseEnterValue;
        public event EventHandler MouseLeaveValue;

        public event EventHandler ClickIcon;
        public event EventHandler ClickTitle;
        public event EventHandler ClickValue;

        public SelectableItems()
        {
            InitializeComponent();

            picIcon.MouseEnter += PicIcon_MouseEnter;
            picIcon.MouseLeave += PicIcon_MouseLeave;

            lblTitle.MouseEnter += LblTitle_MouseEnter;
            lblTitle.MouseLeave += LblTitle_MouseLeave;

            lblValue.MouseEnter += LblValue_MouseEnter;
            lblValue.MouseLeave += LblValue_MouseLeave;

            picIcon.Click += PicIcon_Click;
            lblTitle.Click += LblTitle_Click;
            lblValue.Click += LblValue_Click;
        }

        protected virtual void OnClickValue()
        {
            ClickValue?.Invoke(this, EventArgs.Empty);
        }

        private void LblValue_Click(object sender, EventArgs e)
        {
            OnClickValue();
        }

        protected virtual void OnClickTitle()
        {
            ClickTitle?.Invoke(this, EventArgs.Empty);
        }

        private void LblTitle_Click(object sender, EventArgs e)
        {
            OnClickTitle();
        }

        protected virtual void OnClickIcon()
        {
            ClickIcon?.Invoke(this, EventArgs.Empty);
        }

        private void PicIcon_Click(object sender, EventArgs e)
        {
            OnClickIcon();
        }

        protected virtual void OnMouseLeaveValue()
        {
            MouseLeaveValue?.Invoke(this, EventArgs.Empty);
        }

        private void LblValue_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeaveValue();
        }

        protected virtual void OnMouseEnterValue()
        {
            MouseEnterValue?.Invoke(this, EventArgs.Empty);
        }

        private void LblValue_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnterValue();
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

        //private void SelectableItems_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = ColorTranslator.FromHtml("#210B61");
        //}

        //private void SelectableItems_MouseEnter(object sender, EventArgs e)
        //{
        //    this.BackColor = ColorTranslator.FromHtml("#48088A");
        //}
    }
}