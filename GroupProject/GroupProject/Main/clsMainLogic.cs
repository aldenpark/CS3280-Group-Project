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
                return this.Items.Select(i => i.Cost).Sum();
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
        internal Invoice GetInvoice(int id)
        {
            Invoice inv = new Invoice();
            inv.Items = new List<Item>();

            try
            {
                DataSet ds = new DataSet();
                string sSQL = String.Format(clsMainSQL.GetInvoice, id);
                int iRet = 0;
                clsData = new clsDataAccess();

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
            return inv;
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
