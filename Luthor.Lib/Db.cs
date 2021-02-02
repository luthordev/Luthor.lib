using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Luthor.lib
{
    public static class Db
    {
        private static MySqlCommand command;
        private static MySqlDataReader reader;
        private static MySqlDataAdapter adapter;
        private static DataTable result;

        private static void clearResult()
        {
            result.Rows.Clear();
            result.Columns.Clear();
        }

        public static bool Insert(string table, string values)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand($"INSERT INTO {table} VALUES({values})", Connection.DBConnection);
                Connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return false;
            }
        }

        public static bool Update(string table, string values, string condition)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand($"UPDATE {table} SET {values} WHERE {condition}", Connection.DBConnection);
                Connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return false;
            }
        }

        public static bool Delete(string table, string condition)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand($"DELETE * FROM {table} WHERE {condition}", Connection.DBConnection);
                Connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return false;
            }
        }

        public static DataTable Read(string table, string column)
        {
            clearResult();

            try
            {
                command = new MySqlCommand($"SELECT {column} FROM {table}", Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(result);
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
            }

            return result;
        }

        public static DataTable Read(string table, string column, string condition)
        {
            clearResult();

            try
            {
                command = new MySqlCommand($"SELECT {column} FROM {table} WHERE {condition}", Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(result);
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
            }

            return result;
        }
    }
}
