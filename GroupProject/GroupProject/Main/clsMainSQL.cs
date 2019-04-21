using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class clsMainSQL
    {
        /// <summary>
        /// Get invoice
        /// </summary>
        internal static string GetInvoice
        {
            get
            {
                return "SELECT Invoices.InvoiceNum, Invoices.InvoiceDate, ItemDesc.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                            "FROM((Invoices INNER JOIN " +
                            "LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) INNER JOIN " +
                            "ItemDesc ON LineItems.ItemCode = ItemDesc.ItemCode) " +
                            "WHERE Invoices.InvoiceNum = {0}";
            }
        }

        /// <summary>
        /// Get invoice
        /// </summary>
        internal static string GetLineItems
        {
            get
            {
                return "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            }
        }

        internal static string SaveNewInvoice
        {
            get
            {
                return "INSERT INTO Invoices (InvoiceDate, TotalCost) VALUES ('{0}', {1})";
            }
        }

        internal static string SaveInvoice
        {
            get
            {
                return "UPDATE Invoices SET InvoiceDate = '{0}', TotalCost = {1} WHERE InvoiceNum = {2}";
            }
        }
        internal static string SaveLineItems
        {
            get
            {
                return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) VALUES ({0}, {1}, '{2}')";
            }
        }

        internal static string DeleteInvoice
        {
            get
            {
                return "DELETE FROM Invoices  WHERE InvoiceNum = {0}";
            }
        }
        internal static string DeleteLineItems
        {
            get
            {
                return "DELETE FROM LineItems WHERE InvoiceNum = {0}";
            }
        }
    }

}
