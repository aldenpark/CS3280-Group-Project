using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class clsSearchLogic
{
    /// <summary>
    /// global static number of items returned
    /// </summary>
    public static int numberReturned = 0;
    /// <summary>
    /// private static db for db access
    /// </summary>
    private static clsDataAccess db = new clsDataAccess();
    /// <summary>
    /// private dataset to be passed up
    /// </summary>
    private static DataSet ds = new DataSet();
    /// <summary>
    /// method to return all invoices in a dataset
    /// </summary>
    /// <returns></returns>
    public static DataSet dbAllInvoice()
    {

        ds = db.ExecuteSQLStatement(clsSearchSQL.allRecords(), ref numberReturned);

        return ds;
    }
    /// <summary>
    /// return dataset for sorted charges
    /// </summary>
    /// <returns></returns>
    public static DataSet dbAllInvoiceSort()
    {
        return db.ExecuteSQLStatement(clsSearchSQL.allRecordsSortCost(), ref numberReturned);
    }

    /// <summary>
    /// return dataset for selected invoice
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DataSet dbSelectedInvoice(int item)
    {
        return db.ExecuteSQLStatement(clsSearchSQL.invoiceNum(item), ref numberReturned);
    }

    /// <summary>
    /// return dataset for selected date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DataSet dbSelectedDate(string date)
    {
        return db.ExecuteSQLStatement(clsSearchSQL.selectedDate(date), ref numberReturned);
    }
    /// <summary>
    /// return dataset for selected cost query
    /// </summary>
    /// <param name="charge"></param>
    /// <returns></returns>
    public static DataSet dbSelectedCharge(string charge)
    {
        return db.ExecuteSQLStatement(clsSearchSQL.selectedCharge(charge), ref numberReturned);
    }

    internal IEnumerable LoadSearchWindow()
    {
        ds = clsSearchLogic.dbAllInvoice();
        return ds.Tables[0].DefaultView;
    }
}

