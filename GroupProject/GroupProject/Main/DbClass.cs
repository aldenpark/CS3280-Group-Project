using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;


namespace GroupProject.Main
{
    abstract class DbClass
    {
        /// <summary>
        /// DB Connection Variable
        /// </summary>
        protected OleDbConnection Conn;

        /// <summary>
        /// Get the db connection 
        /// </summary>
        /// <returns></returns>
        protected static OleDbConnection GetConnection()
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BillingConnectionString"].ConnectionString;
            return Conn;
        }
    }
}
