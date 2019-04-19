using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GroupProject
{
    class clsItemsSQL
    {
        /// <summary>
        /// SQL to get Item Names
        /// </summary>
        /// <returns></returns>
        public static string ItemsList()
        {
            return "SELECT Name FROM Items";
        }

        /// <summary>
        /// SQL to get ItemCost
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ItemCost(string name)
        {
            return "SELECT Cost FROM Items WHERE Name = " + name;
        }

        /// <summary>
        /// SQL to update the edited invoice
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
       
        public static string UpdateInvoice(string name)
        {
            return "UPDATE Invoices SET InvoiceID = " + name;
        }
        


        ///<summary>
        ///SQL to remove an item from the invoice
        ///</summary>
        ///<param name="name"></param>
        ///<returns></returns>
        ///
        /*
        POSSIBLY DON'T NEED THESE
        public static string RemoveItemFromInvoice(string name)
        {
            return "DELETE FROM Invoices WHERE ItemName = " + name;
        }

        public static string AddItemToInvoice(string name)
        {
            return "UPDATE Invoices"
        }
        */
    }
}
