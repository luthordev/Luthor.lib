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

        public static bool Insert(string tableName, string values)
        {
            return true;
        }
    }
}
