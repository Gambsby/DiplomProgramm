using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "remotemysql.com";
            int port = 3306;
            string database = "xVpoPVpBoJ";
            string username = "xVpoPVpBoJ";
            string password = "e9ji45qzRZ";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
