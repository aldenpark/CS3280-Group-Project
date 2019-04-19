using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// <summary>
    /// links to update method to execute a concatinated SQL string based on combo box selections
    /// </summary>
    /// <param name="sSQL"></param>
    /// <returns></returns>
    public static DataSet dbUpdateALL(string sSQL)
    {
        return db.ExecuteSQLStatement(sSQL, ref numberReturned);
    }

    // --------------------- Additional Methods for updating to wndMain.cs
    
    public clsSearchLogic()
    {
        try {
            ds = clsSearchLogic.dbAllInvoice();
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
    }

    /// <summary>
    /// get list of invoice numbers for drop down
    /// </summary>
    /// <returns></returns>
    internal List<string> getcmbInvoiceNumberItems()
    {
        List<string> temp = new List<string>();
        for (int i = 0; i < clsSearchLogic.numberReturned; i++)
        {
            temp.Add(ds.Tables[0].Rows[i]["InvoiceNum"].ToString());
        }
        return temp;
    }

    /// <summary>
    /// get list of invoice dates for drop down
    /// </summary>
    /// <returns></returns>
    internal List<string> getcmbInvoiceDateItems()
    {
        List<string> temp = new List<string>();
        for (int i = 0; i < clsSearchLogic.numberReturned; i++)
        {
            temp.Add(ds.Tables[0].Rows[i]["InvoiceDate"].ToString());
        }
        return temp;
    }

    /// <summary>
    /// get list of invoice costs for drop down
    /// </summary>
    /// <returns></returns>
    internal List<int> getcmbInvoiceCostItems()
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < clsSearchLogic.numberReturned; i++)
        {
            temp.Add(Int32.Parse(ds.Tables[0].Rows[i]["TotalCost"].ToString()));
        }
        temp.Sort();
        return temp;
    }

    /// <summary>
    /// return Invoice Data
    /// </summary>
    /// <returns></returns>
    internal IEnumerable LoadSearchWindow()
    {
        try {
            ds = clsSearchLogic.dbAllInvoice();
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
        return ds.Tables[0].DefaultView;
    }

    /// <summary>
    /// return search Window data by date
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    internal IEnumerable SelectedDateSearchWindow(string v)
    {
        try {
            ds = clsSearchLogic.dbSelectedDate(v);
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
        return ds.Tables[0].DefaultView;
    }

    /// <summary>
    /// return search window data by charge
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    internal IEnumerable SelectedChargeSearchWindow(string v)
    {
        try {
            ds = clsSearchLogic.dbSelectedCharge(v);
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
        return ds.Tables[0].DefaultView;
    }

    /// <summary>
    /// return search window data by selected invoice
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    internal IEnumerable SelectedInvoiceSearchWindow(int v)
    {
        try {
            ds = clsSearchLogic.dbSelectedInvoice(v);
        }
        catch (Exception ex)
        {
            throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        }
        return ds.Tables[0].DefaultView;
    }
}

