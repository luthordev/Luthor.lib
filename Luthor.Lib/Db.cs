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

        public static bool ExecuteQuery(string query)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand(query, Connection.DBConnection);
                command.ExecuteNonQuery();
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

        public static bool Insert(string table, string values)
        {
            try
            {
                Connection.Open();
                command = new MySqlCommand($"INSERT INTO {table} VALUES({values})", Connection.DBConnection);
                command.ExecuteNonQuery();
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
                command.ExecuteNonQuery();
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
                command = new MySqlCommand($"DELETE FROM {table} WHERE {condition}", Connection.DBConnection);
                command.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return false;
            }

            Db.Read("tabel", "*");
        }

        public static DataTable Read(string table, string column)
        {
            try
            {
                command = new MySqlCommand($"SELECT {column} FROM {table}", Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return new DataTable();
            }

        }

        public static DataTable Read(string table, string column, string condition)
        {
            try
            {
                command = new MySqlCommand($"SELECT {column} FROM {table} WHERE {condition}", Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return new DataTable();
            }
        }

        public static DataTable Read(string query)
        {
            try
            {
                command = new MySqlCommand(query, Connection.DBConnection);
                adapter = new MySqlDataAdapter(command);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                Error.error_msg = err.Message;
                Error.error_code = err.Number;
                return new DataTable();
            }
        }
    }
}
