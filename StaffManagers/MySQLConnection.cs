using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace StaffManagers
{
    public class MySQLConnection
    {
        private MySQLConnection()
        {
            // Constructor
            // DO NOTHING
        }

        private string server;
        private string databaseName;
        private string username;
        private string password;

        private MySqlConnection connection;

        public string Server 
        { 
            get { return server; } 
            set { server = value; } 
        }
        public string DatabaseName 
        { 
            get { return databaseName; }
            set { databaseName = value; }
        }
        public string Username 
        { 
            get { return username; }
            set { username = value; }
        }
        public string Password 
        { 
            get { return password; } 
            set { password = value; }
        }

        public MySqlConnection Connection 
        { 
            get { return connection; }
            set { connection = value; }
        }

        private static MySQLConnection _instance = null;

        public static MySQLConnection Instance()
        {
            if (_instance == null)
            {
                _instance = new MySQLConnection();
            }
            return _instance;
        }

        public bool IsConnect()
        {
            try
            {
                if (Connection == null || Connection.State != ConnectionState.Open)
                {
                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, Username, Password);
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                // Handle connection error, log or display error message
                Console.WriteLine("Error connecting to database: " + ex.Message);
                return false;
            }
        }

        public void Close()
        {
            Connection.Close();
            Connection = null;
        }
    }
}
