using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Luthor.lib
{
    class Auth
    {
        private static MySqlCommand command;
        private static MySqlDataReader reader;
        private static MySqlDataAdapter adapter;

        public static bool CheckLogin(string username, string password, string tableName)
        {
            Connection.Open();
            command = new MySqlCommand($"SELECT * FROM {tableName} WHERE username='{username}' AND password='{password}'", Connection.DBConnection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                Connection.Close();
                return true;
            }
            else return false; 
        }
        public static bool Login(string username, string password, string tableName)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand($"SELECT * FROM {tableName} WHERE username='{username}' AND password='{password}'", Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(Session.userInfo);
                Connection.Close();
                return true;
            } catch(MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return false;
            }
        }

        public static void Logout()
        {
            Session.clearSession();
        }
    }
}
