using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ProjectSearch2.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// DataSet varaible used for populating datagrid and populating comboboxes
        /// </summary>
        DataSet ds;
        /// <summary>
        /// constructor
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();

            //populate invoice numbers:
            ds = clsSearchLogic.dbAllInvoice();

            for(int i = 0;i < clsSearchLogic.numberReturned; i++)
            {
                cmbInvoiceNumber.Items.Add(ds.Tables[0].Rows[i]["InvoiceNum"].ToString());
                cmbInvoiceDate.Items.Add(ds.Tables[0].Rows[i]["InvoiceDate"].ToString());
            }

            ds = clsSearchLogic.dbAllInvoiceSort();

            
            for (int i = 0; i < clsSearchLogic.numberReturned; i++)
            {
               cmbInvoiceCharges.Items.Add(ds.Tables[0].Rows[i]["TotalCost"].ToString());
            }
        }
        /// <summary>
        /// when the form first loads, populate grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ds = clsSearchLogic.dbAllInvoice();
            grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
        }


        /// <summary>
        /// When closing the window, just hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WndSearch1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// when the combobox for date changes, update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbInvoiceDate.SelectedIndex != -1)
            {
                ds = clsSearchLogic.dbSelectedDate(cmbInvoiceDate.SelectedValue.ToString());
                grdInvoiceList.ItemsSource = null;
                grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                grdInvoiceList.Items.Refresh();

            }
        }
        /// <summary>
        /// when the combobox for charges changes, update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbInvoiceCharges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbInvoiceCharges.SelectedIndex != -1)
            {
                ds = clsSearchLogic.dbSelectedCharge(cmbInvoiceCharges.SelectedValue.ToString());
                grdInvoiceList.ItemsSource = null;
                grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                grdInvoiceList.Items.Refresh();

            }
        }
        /// <summary>
        /// when an Item is selected and passed back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //Pass on selected invoice to main
            IList rows = grdInvoiceList.SelectedItems;
            DataRowView row = (DataRowView)grdInvoiceList.SelectedItems[0];
            MessageBox.Show("Pass back invoice num: "+row["InvoiceNum"].ToString()); 

        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// reset / clear selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

            grdInvoiceList.ItemsSource = null;
            grdInvoiceList.Items.Refresh();
            cmbInvoiceCharges.SelectedIndex = -1;
            cmbInvoiceDate.SelectedIndex = -1;
            cmbInvoiceNumber.SelectedIndex = -1;
            ds = clsSearchLogic.dbAllInvoice();
            grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// combobox for when the invoice number changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbInvoiceNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //populate with selected value
            if (cmbInvoiceNumber.SelectedIndex != -1)
            {
                ds = clsSearchLogic.dbSelectedInvoice(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                grdInvoiceList.ItemsSource = null;
                grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                grdInvoiceList.Items.Refresh();
            }

        }
    }
}
