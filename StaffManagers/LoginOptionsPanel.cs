using Microsoft.Win32;
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
    public partial class LoginOptionsPanel : UserControl
    {
        public event EventHandler OnForgotPasswordPressed;

        public LoginOptionsPanel()
        {
            InitializeComponent();
        }

        protected virtual void ForgotPasswordButtonPressed()
        {
            OnForgotPasswordPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordButtonPressed();
        }

        private void chkRememberCredentials_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRememberCredentials.Checked)
            {
                Config.Save_credentials = true;
            }
            else if (!chkRememberCredentials.Checked)
            {
                Config.Save_credentials = false;
            }
        }

        private void LoginOptionsPanel_Load(object sender, EventArgs e)
        {
            RegistryKey app = Registry.CurrentUser.OpenSubKey("CyberDay Studios", false);

            if (app != null)
            {
                try
                {
                    if (app.GetValue("save_data").ToString() == "true")
                    {
                        Config.Save_credentials = true;
                    }
                    else if (app.GetValue("save_data").ToString() == "false")
                    {
                        Config.Save_credentials = false;
                    }
                    else
                    {
                        Config.Save_credentials = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return;
                }
                finally
                {
                    app.Close();
                }
            }

            if (Config.Save_credentials) chkRememberCredentials.Checked = true;
            else chkRememberCredentials.Checked = false;
        }
    }
}
