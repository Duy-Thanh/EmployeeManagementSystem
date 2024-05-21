using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagers
{
    public class ImageHandler
    {
        private MySQLConnection mySqlConnection;

        private string serverName;
        private string databaseName;
        private string username;
        private string password;

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public ImageHandler(string serverName, string databaseName, string username, string password)
        {
            this.mySqlConnection = MySQLConnection.Instance();
            this.ServerName = serverName;
            this.DatabaseName = databaseName;
            this.UserName = username;
            this.Password = password;
        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                {
                    format = System.Drawing.Imaging.ImageFormat.Bmp;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                {
                    format = System.Drawing.Imaging.ImageFormat.Gif;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                {
                    format = System.Drawing.Imaging.ImageFormat.Tiff;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                {
                    format = System.Drawing.Imaging.ImageFormat.Emf;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
                {
                    format = System.Drawing.Imaging.ImageFormat.Wmf;
                }
                else if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                {
                    format = System.Drawing.Imaging.ImageFormat.Exif;
                }

                image.Save(ms, format);

                return ms.ToArray();
            }
        }

        public void SaveImageToDatabase(string userLogin, System.Drawing.Image image)
        {
            // Convert image to byte array
            byte[] imageBytes = ImageToByteArray(image);

            string sqlQuery = 
                "UPDATE Account_System SET avatar = @Avatar WHERE user_login = '" + 
                userLogin + "'";

            var dbCon = MySQLConnection.Instance();
            dbCon.Server = Crypto.Base64Decode(SQLConfigurations.ServerName);
            dbCon.DatabaseName = Crypto.Base64Decode(SQLConfigurations.DatabaseName);
            dbCon.Username = Crypto.Base64Decode(SQLConfigurations.UserName);
            dbCon.Password = Crypto.Base64Decode(SQLConfigurations.Password);

            if (dbCon.IsConnect())
            {
                using (MySqlCommand cmd_update_avatar = new MySqlCommand(sqlQuery, dbCon.Connection))
                {
                    // Add parameter
                    cmd_update_avatar.Parameters.AddWithValue("@Avatar", imageBytes);
                    cmd_update_avatar.ExecuteNonQuery();
                }
            }

            dbCon.Close();
            dbCon = null;
        }
    }
}
