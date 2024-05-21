using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagers
{
    public class Config
    {
        private Config() { }

        private static Config _instance = null;

        public static Config Instance()
        {
            if (_instance == null)
            {
                _instance = new Config();
            }

            return _instance;
        }
        
        private static bool save_credentials;

        public static bool Save_credentials
        {
            get { return save_credentials; }
            set { save_credentials = value; }
        }

        private static string username_shared;

        public static string Username_shared
        {
            get { return username_shared; }
            set { username_shared = value; }
        }

        private static string password_shared;

        public static string Password_shared
        {
            get { return password_shared; }
            set { password_shared = value; }
        }

        private static string role_account;

        public static string Role_account
        {
            get { return role_account; }
            set { role_account = value; }
        }

        private static byte[] guid;

        public static byte[] Guid
        {
            get { return guid; }
            set { guid = value; }
        }
    }
}
