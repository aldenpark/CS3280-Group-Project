using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class clsMainLogic
    {
        // No Main logic, all changes were applied to other classes

        /**
         * Additional Search Methods created
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
        */
    }
}
