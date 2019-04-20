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
    }

}
