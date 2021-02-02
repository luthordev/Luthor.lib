using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Luthor.lib
{
    class Session
    {
        internal static DataTable userInfo;

        internal static void clearSession()
        {
            userInfo.Rows.Clear();
            userInfo.Columns.Clear();
        }

        public static DataTable getUserLogged()
        {
            return userInfo;
        }
    }
}
