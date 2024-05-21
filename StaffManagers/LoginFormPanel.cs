using CefSharp;
using Google.Protobuf.WellKnownTypes;
using HDF5CSharp;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class LoginFormPanel : UserControl
    {
        public event EventHandler LoginButtonPressed;

        private bool isSuccess, isPass;

        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }

        public bool IsPass
        {
            get { return isPass; }
            set { isPass = value; }
        }

        public LoginFormPanel()
        {
            InitializeComponent();
        }

        protected virtual void OnLoginButtonPressed()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                IsPass = false;
                IsSuccess = false;
            }
            else
            {
                IsPass = true;
                IsSuccess = true;

                Config.Username_shared = txtUsername.Text;
                Config.Password_shared = txtPassword.Text;

                RegistryKey app1 = Registry.CurrentUser.OpenSubKey("CyberDay Studios", true);

                if (Config.Save_credentials)
                {
                    app1.SetValue("save_data", "true");
                }
                else if (!Config.Save_credentials)
                {
                    app1.SetValue("save_data", "false");
                }

                app1.Close();

                if (Config.Save_credentials)
                {
                    string user = txtUsername.Text;
                    string pass = txtPassword.Text;

                    byte[] guidBytes = Config.Guid;
                    byte[] keyBytes = new byte[16];
                    Array.Copy(guidBytes, 0, keyBytes, 0, 16);
                    byte[] ivBytes = new byte[16];

                    using (var rng = new RNGCryptoServiceProvider())
                    {
                        rng.GetBytes(ivBytes);
                    }

                    RegistryKey app = Registry.CurrentUser.OpenSubKey("CyberDay Studios", true);

                    app.SetValue("app_data_3", ivBytes);

                    app.Close();

                    try
                    {
                        // Encrypt the data
                        byte[] encryptedData_username = Crypto.EncryptStringToBytes_Aes(Encoding.ASCII.GetBytes(user), Encoding.ASCII.GetBytes(user).Length, keyBytes, ivBytes);
                        byte[] encryptedData_password = Crypto.EncryptStringToBytes_Aes(Encoding.ASCII.GetBytes(pass), Encoding.ASCII.GetBytes(pass).Length, keyBytes, ivBytes);
                        
                        RegistryKey app2 = Registry.CurrentUser.OpenSubKey("CyberDay Studios", true);

                        app2.SetValue("app_data_1", encryptedData_username);
                        app2.SetValue("app_data_2", encryptedData_password);

                        app2.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }
                else
                {
                    Console.Write("save_credentials=false\n");
                }
            }

            LoginButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OnLoginButtonPressed();
        }

        private void LoginFormPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnLoginButtonPressed();
            }
        }

        private void LoginFormPanel_Load(object sender, EventArgs e)
        {
            RegistryKey app = Registry.CurrentUser.OpenSubKey("CyberDay Studios", false);
            if (app != null)
            {
                try
                {
                    if (app.GetValue("save_data")?.ToString() == "true")
                    {
                        Config.Save_credentials = true;
                    }
                    else if (app.GetValue("save_data")?.ToString() == "false")
                    {
                        Config.Save_credentials = false;
                    }

                    if (!string.IsNullOrEmpty(app.GetValue("app_data_1")?.ToString()) && 
                        !string.IsNullOrEmpty(app.GetValue("app_data_2")?.ToString()) && 
                        !string.IsNullOrEmpty(app.GetValue("app_data_3")?.ToString()))
                    {
                        byte[] encryptedData_username = (byte[])app.GetValue("app_data_1");
                        byte[] encryptedData_password = (byte[])app.GetValue("app_data_2");
                        byte[] ivBytes = (byte[])app.GetValue("app_data_3");
                        byte[] guidBytes = Config.Guid;
                        byte[] keyBytes = new byte[16];
                        Array.Copy(guidBytes, 0, keyBytes, 0, 16);

                        // Decrypt the data
                        string output_username_byte = Crypto.DecryptStringFromBytes_Aes(encryptedData_username, encryptedData_username.Length, keyBytes, ivBytes);
                        string output_password_byte = Crypto.DecryptStringFromBytes_Aes(encryptedData_password, encryptedData_password.Length, keyBytes, ivBytes);

                        txtUsername.Text = output_username_byte;
                        txtPassword.Text = output_password_byte;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    txtUsername.Text = "";
                    txtPassword.Text = "";

                    return;
                }
                finally
                {
                    app.Close();
                }
            }
        }
    }
}
