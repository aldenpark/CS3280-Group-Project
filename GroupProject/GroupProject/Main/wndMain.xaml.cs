using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main Logic Class
        /// </summary>
        clsMainLogic mn;
        
        /// <summary>
        /// Search Logic Class
        /// </summary>
        clsSearchLogic sl;

        /// <summary>
        /// Item Logic Class
        /// </summary>
        ///wndItemsLogic il;

        public MainWindow()
        {
            InitializeComponent();

            // load each of the 3 logic classes, all data will pass through here
            mn = new clsMainLogic(); // Load Main Class
            sl = new clsSearchLogic(); // Load Search Class
            //il = new wndItemsLogic(); // Load Item Class
        }

        /// <summary>
        /// Handle errors
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\InvoiceError.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Exit Program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Close_Click(object sender, RoutedEventArgs e)
        {
            MI_Close_Click();
        }

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Close_Click()
        {
            MI_Search.IsEnabled = true;
            MI_Close.IsEnabled = false;
            Btn_Create.IsEnabled = true;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = false;
            Btn_Edit.Visibility = Visibility.Visible;
            Btn_Save.Visibility = Visibility.Hidden;
            Btn_Delete.Visibility = Visibility.Visible;
            Btn_Cancel.Visibility = Visibility.Hidden;


            Main.Visibility = Visibility.Visible;
            Invoice.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Create Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            MI_Search.IsEnabled = false;
            MI_Close.IsEnabled = true;
            Btn_Create.IsEnabled = false;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = true;
            Btn_Delete.Content = "Cancel";
            Btn_Edit.Visibility = Visibility.Hidden;
            Btn_Save.Visibility = Visibility.Visible;
            Btn_Delete.Visibility = Visibility.Hidden;
            Btn_Cancel.Visibility = Visibility.Visible;

            // Invoice data will be updated through clsItemLogic class


            Main.Visibility = Visibility.Hidden;
            Invoice.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Edit Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            // Invoice data will be updated through clsItemLogic class
        }

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            // Invoice data will be updated through clsItemLogic class

            MI_Close_Click();
        }

        private void CmbInvoiceCharges_SelectionChanged(object sender, DataTransferEventArgs e)
        {

        }

        private void Btn_UpdateInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openInvoice(int id)
        {
            MI_Search.IsEnabled = true;
            MI_Close.IsEnabled = false;
            Btn_Create.IsEnabled = true;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = false;
            Btn_Edit.Visibility = Visibility.Visible;
            Btn_Save.Visibility = Visibility.Hidden;
            Btn_Delete.Visibility = Visibility.Visible;
            Btn_Cancel.Visibility = Visibility.Hidden;

            Main.Visibility = Visibility.Hidden;
            Invoice.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;

            //cb_InvoiceItems
            //tb_InvoiceItemsCost

            //try
            //{
                Invoice inv = mn.GetInvoice(id);

                lbl_InvoiceNumber.Content = inv.InvoiceNumber;
                lbl_InvoiceDate.Content = inv.InvoiceDate;
                lbl_InvoiceTotalCost.Content = string.Format("{0:C}", Convert.ToDecimal(inv.Cost));
                DG_Items.ItemsSource = inv.Items;
            //}
            //catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            //{
            //    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            //}

            //DG_Items.ColumnCount = 3;
            //DG_Items.Columns[0].Name = "Product ID";
            //DG_Items.Columns[1].Name = "Product Name";
            //DG_Items.Columns[2].Name = "Product Price";

            //string[] row = new string[] { "1", "Product 1", "1000" };
            //dataGridView1.Rows.Add(row);
            //row = new string[] { "2", "Product 2", "2000" };
            //dataGridView1.Rows.Add(row);
            //row = new string[] { "3", "Product 3", "3000" };
            //dataGridView1.Rows.Add(row);
            //row = new string[] { "4", "Product 4", "4000" };
            //dataGridView1.Rows.Add(row);

        }

        // -------------- Search UI functions

        /// <summary>
        /// when the form first loads, populate grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Window(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Visible;
            Item.Visibility = Visibility.Hidden;
            MI_Search.IsEnabled = false;
            MI_Close.IsEnabled = true;
            Btn_Create.IsEnabled = false;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = false;
            //Btn_Save.IsEnabled = false;

            try
            {
                grdInvoiceList.ItemsSource = sl.LoadSearchWindow();
                cmbInvoiceNumber.ItemsSource = sl.getcmbInvoiceNumberItems();
                cmbInvoiceDate.ItemsSource = sl.getcmbInvoiceDateItems();
                cmbInvoiceCharges.ItemsSource = sl.getcmbInvoiceCostItems();
            }
            catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
                try {
                    grdInvoiceList.ItemsSource = sl.SelectedDateSearchWindow(cmbInvoiceDate.SelectedValue.ToString());
                }
                catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
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
                try {
                    grdInvoiceList.ItemsSource = sl.SelectedChargeSearchWindow(cmbInvoiceCharges.SelectedValue.ToString());
                }
                catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        /// <summary>
        /// when an Item is selected and passed back to the main window, then load this in item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            IList rows = grdInvoiceList.SelectedItems;
            DataRowView row = (DataRowView)grdInvoiceList.SelectedItems[0];
            MI_Close_Click();
            openInvoice(Int32.Parse(row["InvoiceNum"].ToString()));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MI_Close_Click();
        }

        /// <summary>
        /// reset / clear selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try {
                grdInvoiceList.ItemsSource = sl.LoadSearchWindow();
                grdInvoiceList.Items.Refresh();
                cmbInvoiceCharges.SelectedIndex = -1;

                cmbInvoiceNumber.ItemsSource = sl.getcmbInvoiceNumberItems();
                cmbInvoiceNumber.SelectedIndex = -1;
                cmbInvoiceDate.ItemsSource = sl.getcmbInvoiceDateItems();
                cmbInvoiceDate.SelectedIndex = -1;
                cmbInvoiceCharges.ItemsSource = sl.getcmbInvoiceCostItems();
                cmbInvoiceCharges.SelectedIndex = -1;
            }
            catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
                try
                {
                    grdInvoiceList.ItemsSource = sl.SelectedInvoiceSearchWindow(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                }
                catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
            }

        }

        // -------------- Items UI functions

    }
}
