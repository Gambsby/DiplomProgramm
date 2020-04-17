using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData.Models
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            Props props = new Props();
            props.ReadXml();

            string host = props.Fields.Host;
            int port = props.Fields.Port;
            string database = props.Fields.Database;
            string username = props.Fields.Username;
            string password = props.Fields.Password;

            String connString = GetDBConnectionString(host, port, database, username, password);

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static string GetDBConnectionString(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            return connString;
        }
    }
}
