using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public struct Invoice
    {
        /// <summary>
        /// Invoice number
        /// </summary>
        public string InvoiceNumber;

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime InvoiceDate;

        /// <summary>
        /// Items attached to invoice
        /// </summary>
        public List<Item> Items { get; set; }
        
        /// <summary>
        /// Total cost of all items attached to invoice
        /// </summary>
        public double Cost
        {
            get
            {
                if (this.Items != null && this.Items.Count > 0)
                {
                    return this.Items.Select(i => i.Cost).Sum();
                }
                return 0;
            }
        }
    }

    public struct Item
    {
        /// <summary>
        /// db id of item
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// name of item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// cost of item
        /// </summary>
        public double Cost { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }


    class clsMainLogic
    {
        /// <summary>
        /// For determing if an invoice is new or there is one open
        /// </summary>
        public Invoice CurrentInvoice;

        /// <summary>
        /// Dataa Access object
        /// </summary>
        clsDataAccess clsData;

        // save invoice 

        // update invoice

        /// <summary>
        /// Get invoice by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal void GetInvoice(int id)
        {
            DataSet ds = new DataSet();
            clsData = new clsDataAccess();

            Invoice inv = new Invoice();
            inv.Items = new List<Item>();

            try
            {
                string sSQL = String.Format(clsMainSQL.GetInvoice, id);
                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    inv.InvoiceNumber = ds.Tables[0].Rows[i][0].ToString();
                    inv.InvoiceDate = DateTime.Parse(ds.Tables[0].Rows[i][1].ToString());
                    inv.Items.Add(new Item()
                    {
                        Code = ds.Tables[0].Rows[i][2].ToString(),
                        Description = ds.Tables[0].Rows[i][3].ToString(),
                        Cost = int.Parse(ds.Tables[0].Rows[i][4].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            CurrentInvoice = inv;
        }

        internal void SaveInvoice()
        {
            DataSet ds = new DataSet();
            clsData = new clsDataAccess();
            string sSQL;

            if (CurrentInvoice.Items != null && CurrentInvoice.Items.Count > 0)
            {
                if (CurrentInvoice.InvoiceNumber == null)
                {
                    sSQL = String.Format(clsMainSQL.SaveNewInvoice, CurrentInvoice.InvoiceDate, CurrentInvoice.Cost);
                    int incId = clsData.InsertNonQuery(sSQL);
                    CurrentInvoice.InvoiceNumber = incId.ToString();
                }
                else
                {
                    sSQL = String.Format(clsMainSQL.SaveInvoice, CurrentInvoice.InvoiceDate, CurrentInvoice.Cost, CurrentInvoice.InvoiceNumber);
                    clsData.ExecuteNonQuery(sSQL);
                }

                sSQL = String.Format(clsMainSQL.DeleteLineItems, CurrentInvoice.InvoiceNumber);
                clsData.ExecuteNonQuery(sSQL);
                int i = 1;
                foreach (Item row in CurrentInvoice.Items)
                {
                    sSQL = String.Format(clsMainSQL.SaveLineItems, CurrentInvoice.InvoiceNumber, i, row.Code);
                    clsData.ExecuteNonQuery(sSQL);
                    i++;
                }
            }

        }

        internal void DeleteInvoice()
        {
            DataSet ds = new DataSet();
            clsData = new clsDataAccess();
            string sSQL;

            sSQL = String.Format(clsMainSQL.DeleteInvoice, CurrentInvoice.InvoiceNumber);
            clsData.ExecuteNonQuery(sSQL);

            sSQL = String.Format(clsMainSQL.DeleteLineItems, CurrentInvoice.InvoiceNumber);
            clsData.ExecuteNonQuery(sSQL);
        }

        /// <summary>
        /// Get list of LineItems
        /// </summary>
        /// <returns></returns>
        internal List<Item> GetLineItems()
        {
            List<Item> items = new List<Item>();

            //try
            //{
                DataSet ds = new DataSet();
                string sSQL = String.Format(clsMainSQL.GetLineItems);
                int iRet = 0;
                clsData = new clsDataAccess();

                ds = clsData.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    items.Add(new Item()
                    {
                        Code = ds.Tables[0].Rows[i][0].ToString(),
                        Description = ds.Tables[0].Rows[i][1].ToString(),
                        Cost = int.Parse(ds.Tables[0].Rows[i][2].ToString())
                    });
                }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            //}

            return items;
        }
    }
}
