using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Reflection;


namespace GroupProject.Main
{
    class DbClass
    {
        /// <summary>
        /// DB Connection Variable
        /// </summary>
        private OleDbConnection Conn;

        /// <summary>
        /// Get the db connection 
        /// </summary>
        /// <returns></returns>
        private static OleDbConnection GetConnection()
        {
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BillingConnectionString"].ConnectionString;
            return Conn;
        }

        //public static List<ObjectName> ExmapleConnection()
        //{
        //    OleDbConnection Conn = GetConnection();

        //    List<ObjectName> ObjectVar = new List<ObjectName>();
        //    try
        //    {
        //        OleDbCommand cmd = Conn.CreateCommand();
        //        Conn.Open();
        //        cmd.CommandText = "SELECT * FROM Flight";
        //        var data = cmd.ExecuteReader();

        //        while (data.Read())
        //        {
        //            ObjectVar.Add(new ObjectName()
        //            {
        //                id = Int32.Parse(data["id"].ToString()),
        //                field = data["anotherfield"].ToString()
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //    }

        //    return ObjectVar;
        //}

    }
}
