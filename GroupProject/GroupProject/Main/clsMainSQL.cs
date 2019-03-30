using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainSQL : DbClass
    {
        public static List<Definitions> GetDefinitions()
        {
            OleDbConnection Conn = DbClass.GetConnection();

            List<Definitions> ObjectVar = new List<Definitions>();
            try
            {
                OleDbCommand cmd = Conn.CreateCommand();
                Conn.Open();
                cmd.CommandText = "SELECT * FROM Definitions";
                var data = cmd.ExecuteReader();

                while (data.Read())
                {
                    ObjectVar.Add(new Definitions()
                    {
                        Id = Int32.Parse(data["id"].ToString()),
                        Name = data["defname"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            finally
            {
                Conn.Close();
            }

            return ObjectVar;
        }
    }
}
