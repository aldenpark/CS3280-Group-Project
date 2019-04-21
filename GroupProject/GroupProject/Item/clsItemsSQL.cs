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
                return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            }

            /// <summary>
            /// SQL to Add Item to items list
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static string AddItem(string code, string description, int cost)
            {
                return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES ( '" + code + "', '" + description + "', " + cost + ")";
            }
            /// <summary>
            /// SQL to update ItemDesc Table with relevant data
            /// </summary>
            /// <param name="code"></param>
            /// <param name="description"></param>
            /// <param name="cost"></param>
            /// <returns></returns>
            public static string UpdateItem(string code, string description, int cost)
            {
                return "UPDATE ItemDesc SET ItemDesc = '" + description + "', Cost = " + cost + " WHERE ItemCode = '" + code + "'";
            }
            /// <summary>
            /// Method that returns SQL to delete item from ItemDesc table
            /// </summary>
            /// <param name="code"></param>
            /// <returns></returns>
            public static string DeleteItem(string code)
            {
                return "DELETE FROM ItemDesc WHERE ItemCode = '" + code + "'";
            }
            /// <summary>
            /// SQL statement to retrieve all lineItems containing items of the specified code
            /// </summary>
            /// <param name="code"></param>
            /// <returns></returns>
            public static string GetLineItems(string code)
            {
                return "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '" + code + "'";
            }
        }
    }

    /*
    class clsItemsSQL
    {
        /// <summary>
        /// SQL to get Item Names
        /// </summary>
        /// <returns></returns>
        public static string ItemsList()
        {
            return  "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
        }

        /// <summary>
        /// SQL to Add Item to items list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string AddItem(string code, string description, int cost)
        {
            return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES ( " + code + ", " + description + ", " + cost + ")";
        }
        /// <summary>
        /// SQL to update ItemDesc Table with relevant data
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static string UpdateItem(string code, string description, int cost)
        {
            return "UPDATE ItemDesc SET ItemDesc = " + description + ", Cost = " + cost.ToString() + " WHERE ItemCode = " + code;
        }
        /// <summary>
        /// Method that returns SQL to delete item from ItemDesc table
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string DeleteItem(string code)
        {
            return "DELETE FROM ItemDesc WHERE ItemCode = " + code;
        }
        /// <summary>
        /// SQL statement to retrieve all lineItems containing items of the specified code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetLineItems(string code)
        {
            return "SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = " + code;
        }
    }
}
*/