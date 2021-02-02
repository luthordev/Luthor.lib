using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Luthor.lib
{
    class Connection
    {
        internal static MySqlConnection DBConnection;
        internal static string error_msg;

        public static void setConnection(string server, string dbname, string user, string password)
        {
            DBConnection = new MySqlConnection(
            $"server={server};database={dbname};user={user};password={password}");
        }

        public static bool Ping()
        {
            if (Open()) return true;
            else return false;
        }

        internal static bool Open()
        {
            try
            {
                DBConnection.Open();
                return true;
            }
            catch (Exception err)
            {
                error_msg = err.Message;
                return false;
            }
        }

        internal static bool Close()
        {
            try
            {
                DBConnection.Close();
                return true;
            }
            catch (Exception err)
            {
                error_msg = err.Message;
                return false;
            }
        }
    }
}
