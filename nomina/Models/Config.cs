using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nomina.Models
{
    public class Config
    {
        private static string connectionString = "server=saacapps.com;UserID=saacapps_ucatolica;Database=saacapps_training;Password=Ucat0lica";

        /// <summary>
        /// example quiz commit
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}