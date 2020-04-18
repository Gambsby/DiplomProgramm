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
            String connString = GetDBConnectionString();

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static string GetDBConnectionString()
        {
            try
            {
                Props props = new Props();
                props.ReadXml();

                string host = props.Fields.Host;
                int port = props.Fields.Port;
                string database = props.Fields.Database;
                string username = props.Fields.Username;
                string password = props.Fields.Password;

                String connString = "Server=" + host + ";Database=" + database
                    + ";port=" + port + ";User Id=" + username + ";password=" + password;

                return connString;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при загрузке конфигурации подключения к бд");
            }
        }
    }
}
