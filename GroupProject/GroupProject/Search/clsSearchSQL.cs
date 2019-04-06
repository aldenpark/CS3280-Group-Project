using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class clsSearchSQL
{
    /// <summary>
    /// static reference to SQL statement for all records
    /// </summary>
    /// <returns></returns>
    public static string allRecords()
    {
        return "SELECT * FROM Invoices";
    }
    /// <summary>
    /// static reference to SQL statement for select invoice and provided num
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string invoiceNum(int num)
    {
        return "SELECT * FROM Invoices WHERE InvoiceNum = " + num.ToString();
    }
    /// <summary>
    /// static reference to SQL statement for selected charges, sorted
    /// </summary>
    /// <returns></returns>
    public static string allRecordsSortCost()
    {
        return "SELECT * FROM Invoices ORDER BY TotalCost";
    }

    /// <summary>
    /// static reference to SQL statement for selected date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string selectedDate(string date)
    {
        return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date +"#";
    }

    /// <summary>
    /// static reference to SQL statement for selected cost
    /// </summary>
    /// <param name="charge"></param>
    /// <returns></returns>
    public static string selectedCharge(string charge)
    {
        return "SELECT * FROM Invoices WHERE TotalCost = " + charge;
    }
}

