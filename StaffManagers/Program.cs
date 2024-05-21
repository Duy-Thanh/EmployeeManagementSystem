using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;
using OSVersionExtension;
using System.Runtime.InteropServices;
using System.Text;
using MySql.Data.MySqlClient;

namespace StaffManagers
{
    internal static class Program
    {
        private static bool isMySQLInstalled;

        public static bool IsMySQLInstalled
        {
            get { return isMySQLInstalled; }
            set { isMySQLInstalled = value; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                RegistryKey appKey = Registry.CurrentUser.OpenSubKey("CyberDay Studios");
                if (appKey != null)
                {
                    if (!appKey.GetValueNames().Contains("guid"))
                    {
                        throw new Exception("Key not found");
                    }
                    else
                    {
                        Config.Guid = (byte[])appKey.GetValue("guid");
                        appKey.Close();
                    }
                }
                else
                {
                    throw new Exception("An error occurred when trying to fetch key data");
                }

                appKey.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Key not found")
                {
                    RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("CyberDay Studios");
                    registryKey.SetValue("guid", Encoding.ASCII.GetBytes(Crypto.GenerateUUID()));

                    registryKey.Close();
                }
                else if (ex.Message == "An error occurred when trying to fetch key data")
                {
                    MessageBox.Show("An serious error occurred. Error:\n\n" + ex.Message,
                        "Fatal error cannot be recovered",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("CyberDay Studios");
                    registryKey.SetValue("guid", Encoding.ASCII.GetBytes(Crypto.GenerateUUID()));

                    registryKey.Close();
                }
                else
                {
                    MessageBox.Show("An serious error occurred. Error:\n\n" + ex.Message,
                        "Fatal error cannot be recovered",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Environment.Exit(0xFFFF);
                }
            }

            // Check Operating System section
            // 
            // We only have rounded corners (actually is uDWM hack) on Windows 11
            // On earlier OS version, we need to apply our custom rounded corner
            // that defined in EllipseControl.cs
            //
            // To check Windows version, we use OSCheckExt from NuGet package
            // manager
            // 
            // So, we have these cases:
            //
            // Case 1: If users have Windows 11: Let's use native uDWM hack (inside
            //         dwmapi.dll) and opt in system rounded corners
            // 
            // Case 2: If users doesn't have Windows 11: We need to create 
            //         custom interface to enable rounded corners that defined
            //         in EllipseControl.cs then enable them in Form1.cs
            // 
            // Note that on Windows Server 2022, we still doesn't have uDWM hack,
            // actually uDWM hack exists only on Windows 11. So if we detected
            // Windows Server Edition, we have to use our custom rounded corners
            // defined in EllipseControl.cs to enable rounded corners effect
            //
            // 9/3/2024

            OSVersionExtension.OperatingSystem osFetchData = OSVersion.GetOperatingSystem();

            // Windows 11 detected
            if (osFetchData == OSVersionExtension.OperatingSystem.Windows11)
            {
                // Check if MySQL is installed
                //string exec_check = "cmd.exe";
                //string exec_args =
                //    " /c \"C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\mysql\" --version";

                //proc_helper.ExecuteCommand(exec_check, exec_args);

                //MessageBox.Show(proc_helper.Output);

                //if (proc_helper.Output != "") IsMySQLInstalled = true;
                //else IsMySQLInstalled = false;

                //if (IsMySQLInstalled)
                //{

                //}

                //else
                //{

                //}
                var dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    string cmd_disable_safe_sql_update = "SET SQL_SAFE_UPDATES = 0";
                    var query_disable_safe_sql_update = new MySqlCommand(cmd_disable_safe_sql_update, dbCon.Connection);

                    query_disable_safe_sql_update.ExecuteNonQuery();
                }

                string plainText = "Hello, world!";
                byte[] key = new byte[32]; // 256-bit key (32 bytes)
                byte[] iv = new byte[16]; // 128-bit IV (16 bytes)

                NativeHandler.generate_random_key(key, 32);
                NativeHandler.generate_random_iv(iv, 16);

                // Encrypt the string
                byte[] encryptedBytes = Crypto.EncryptStringToBytes_Aes(Encoding.ASCII.GetBytes(plainText),
                    plainText.Length, key, iv);

                // Decrypt the bytes to string
                string decryptedString = Crypto.DecryptStringFromBytes_Aes(encryptedBytes, encryptedBytes.Length, key, iv);

                Console.WriteLine("Decrypted string: " + decryptedString);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new Form1(true)); // Yes, we're running on Windows 11
            }
            else
            {
                // Older Windows (even Windows Server Editions detected)
                // 
                // (NOTE: Currently I don't know if this worked on ReactOS or Wine,
                //        maybe I will test when I have free time :D)
                //
                // Check if MySQL is installed
                //string exec_check = "cmd.exe";
                //string exec_args =
                //    " /c \"C:\\Program Files\\MySQL\\MySQL Server 8.3\\bin\\mysql\" --version";

                //proc_helper.ExecuteCommand(exec_check, exec_args);

                ////MessageBox.Show(proc_helper.Output);

                //if (proc_helper.Output != "") IsMySQLInstalled = true;
                //else IsMySQLInstalled = false;

                //if (IsMySQLInstalled)
                //{

                //}
                //else
                //{

                //}
                var dbCon = MySQLConnection.Instance();
                dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
                dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
                dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
                dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

                if (dbCon.IsConnect())
                {
                    string cmd_disable_safe_sql_update = "SET SQL_SAFE_UPDATES = 0";
                    var query_disable_safe_sql_update = new MySqlCommand(cmd_disable_safe_sql_update, dbCon.Connection);

                    query_disable_safe_sql_update.ExecuteNonQuery();
                }

                string plainText = "Hello, world!";
                byte[] key = new byte[16]; // 256-bit key (32 bytes)
                byte[] iv = new byte[16]; // 128-bit IV (16 bytes)

                // Encrypt the string
                byte[] encryptedBytes = Crypto.EncryptStringToBytes_Aes(Encoding.ASCII.GetBytes(plainText), Encoding.ASCII.GetBytes(plainText).Length, key, iv);

                // Decrypt the bytes to string

                string decryptedString = Crypto.DecryptStringFromBytes_Aes(encryptedBytes, encryptedBytes.Length, key, iv);

                Console.WriteLine("Decrypted string: " + decryptedString);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new Form1(false)); // Non Windows 11
            }
        }
    }
}
