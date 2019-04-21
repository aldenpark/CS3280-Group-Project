using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{

    public struct lineItem
    {
        /// <summary>
        /// db id of item
        /// </summary>
        public int InvoiceNum { get; set; }

        /// <summary>
        /// Line number from db
        /// </summary>
        public int LineitemNumber { get; set; }

        /// <summary>
        /// ItemCode
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// Override method of ToString to help display the lineItem object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemCode;
        }
    }

    class clsItemsLogic
    {
        /// <summary>
        /// List to hold list items fetched from Database
        /// </summary>
        private List<Item> items;
        /// <summary>
        /// List to hold line Items fetched from Database
        /// </summary>
        private List<lineItem> LI;

        /// <summary>
        /// number to track index for the listItems array
        /// </summary>
        public static int CurrentIndex = 0;

        /// <summary>
        /// int variable used for executing SQL Statments 
        /// </summary>
        public static int numberReturned = 0;
        /// <summary>
        /// db for Access database
        /// </summary>
        private static clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Retrevies Item information from database to use in the drop down list
        /// </summary>
        
        /// <summary>
        /// constructor for the Logic class
        /// </summary>
        public clsItemsLogic()
        {
        }

        /// <summary>
        /// Gets all the data for the Item's Drop Down List
        /// </summary>
        /// <returns></returns>
        
       internal List<Item> GetItemList()
       {
            
            items = new List<Item>();

                DataSet ds = new DataSet();
                string sSQL = String.Format(clsItemsSQL.ItemsList());
                ds = db.ExecuteSQLStatement(sSQL, ref numberReturned);

                for (int i = 0; i < numberReturned; i++)
                {
                    items.Add(new Item()
                    {
                        Code = ds.Tables[0].Rows[i][0].ToString(),
                        Description = ds.Tables[0].Rows[i][1].ToString(),
                        Cost = int.Parse(ds.Tables[0].Rows[i][2].ToString())
                    });
                }
              

            return items;
        }

        /// <summary>
        /// Gets the cost of the item
        /// </summary>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        internal void AddItem(string code, string Description, int cost)
        {
            string sSQL = String.Format(clsItemsSQL.AddItem(code, Description, cost));
            db.ExecuteNonQuery(sSQL);
        }
        
        /// <summary>
        /// Calculates the total amount for the totalCost textbox
        /// </summary>
        /// <returns></returns>
        internal void UpdateItem(string code, string description, int cost)
        {
            
             db.ExecuteNonQuery(clsItemsSQL.UpdateItem(code, description, cost));
        }
        /// <summary>
        /// Method to call the Delete Item SQL statement 
        /// </summary>
        /// <param name="code"></param>
        internal void DeleteItem(string code)
        {
           
            db.ExecuteNonQuery(clsItemsSQL.DeleteItem(code));
        }
        /// <summary>
        /// Method that calls SQL statment to retrieve Line Items and populate a List object
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal List<lineItem> GetLineItems(string code)
        {
            LI = new List<lineItem>();

            DataSet ds = new DataSet();
            string sSQL = String.Format(clsItemsSQL.GetLineItems(code));
            ds = db.ExecuteSQLStatement(sSQL, ref numberReturned);

            for (int i = 0; i < numberReturned; i++)
            {
                LI.Add(new lineItem()
                {
                    InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]),
                    LineitemNumber = Convert.ToInt32(ds.Tables[0].Rows[i][1]),
                    ItemCode = ds.Tables[0].Rows[i][2].ToString()
                });
            }
            return LI;
        }

    }
}
