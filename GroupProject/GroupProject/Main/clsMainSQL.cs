using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainSQL
    {

        // Update to only have SQL code in it

        /// <summary>
        /// Load List of Definitions for Invoices
        /// </summary>
        /// <returns></returns>
        //public static List<Definitions> GetDefinitions()
        //{

        //    DataSet ds = new DataSet();
        //    int iRet = 0;
        //    List<Definitions> ObjectVar = new List<Definitions>();
        //    clsDataAccess clsData = new clsDataAccess();
        //    try
        //    {
        //        ds = clsData.ExecuteSQLStatement("SELECT id, defname FROM Definitions", ref iRet);

        //        for (int i = 0; i < iRet; i++)
        //        {
        //            ObjectVar.Add(new Definitions()
        //            {
        //                Id = Int32.Parse(ds.Tables[0].Rows[i][0].ToString()),
        //                Name = ds.Tables[0].Rows[i][i].ToString().ToString()
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        //    }

        //    return ObjectVar;
        //}

        ///// <summary>
        ///// Save New Definition
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public static List<Definitions> SaveDefinitions(String name)
        //{
        //    return clsMainSQL.GetDefinitions();
        //}

        ///// <summary>
        ///// Delete Definition if it is not longer used
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static bool DeleteDefinition(int id)
        //{
        //    return false;
        //}

    }

}
