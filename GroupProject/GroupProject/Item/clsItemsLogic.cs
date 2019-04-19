using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class clsItemsLogic
    {
        /// <summary>
        /// array to hold list items
        /// </summary>
        public static string[] listItems;

        /// <summary>
        /// number to track index for the listItems array
        /// </summary>
        public static int CurrentIndex = 0;


        public static int numberReturned = 0;
        /// <summary>
        /// db for Access database
        /// </summary>
        private static clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// dataset for passing data to Access
        /// </summary>
        private static DataSet ds = new DataSet();

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
        public static DataSet GetItemsList()
        {
            ds = db.ExecuteSQLStatement(clsItemsSQL.ItemsList(), ref numberReturned);

            return ds;
        }

        /// <summary>
        /// Gets the cost of the item
        /// </summary>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        public static DataSet GetItemCost(string ItemName)
        {
            ds = db.ExecuteSQLStatement(clsItemsSQL.ItemCost(ItemName), ref numberReturned);
            return ds;
        }
        
        /// <summary>
        /// Calculates the total amount for the totalCost textbox
        /// </summary>
        /// <returns></returns>
        public double CalcualteTotalCost()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// fetches item cost from database so it can be displayed in the item cost textbox
        /// </summary>
        public void GetItemCost()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// method to update invoice
        /// </summary>
        public static void SaveInvoice()
        {
            for(int i = 0; i < listItems.Length; i++)
            {
                ds = db.ExecuteSQLStatement(clsItemsSQL.UpdateInvoice(listItems[i]), ref numberReturned);
            }
        }

    }
}
