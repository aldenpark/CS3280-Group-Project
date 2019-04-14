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
            //Btn_Save.IsEnabled = false;
            Btn_Delete.Content = "Delete";

            Main.Visibility = Visibility.Visible;
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
            //Btn_Save.IsEnabled = true;

            Btn_Delete.Content = "Cancel";

            // Invoice data will be updated through clsItemLogic class


            Main.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Visible;
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

            // Search data will be loaded through clsSearchLogic class

            //ds = clsSearchLogic.dbAllInvoice();
            //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;

            grdInvoiceList.ItemsSource = sl.LoadSearchWindow();

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
                // Search data will be loaded through clsSearchLogic class

                //// I think parts of this needs moved to the logic class
                //ds = clsSearchLogic.dbSelectedDate(cmbInvoiceDate.SelectedValue.ToString());
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();

                grdInvoiceList.ItemsSource = sl.SelectedDateSearchWindow(cmbInvoiceDate.SelectedValue.ToString());
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
                // Search data will be loaded through clsSearchLogic class

                //ds = clsSearchLogic.dbSelectedCharge(cmbInvoiceCharges.SelectedValue.ToString());
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();

                grdInvoiceList.ItemsSource = sl.SelectedChargeSearchWindow(cmbInvoiceCharges.SelectedValue.ToString());
                grdInvoiceList.Items.Refresh();
            }
        }

        /// <summary>
        /// when an Item is selected and passed back to the main window, then load this in item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Search data will be loaded through clsSearchLogic class

            //Pass on selected invoice to main
            IList rows = grdInvoiceList.SelectedItems;
            DataRowView row = (DataRowView)grdInvoiceList.SelectedItems[0];
            MessageBox.Show("Pass back invoice num: " + row["InvoiceNum"].ToString());
            // Need furher info to update items display
            //il.GetInvoice(row["InvoiceNum"].ToString());  load into InvoiceListBox?, what elements needs loaded?, do you have a working example?
            MI_Close_Click();
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
            // Search data will be loaded through clsSearchLogic class

            //grdInvoiceList.ItemsSource = null;
            //grdInvoiceList.Items.Refresh();
            //cmbInvoiceCharges.SelectedIndex = -1;
            //cmbInvoiceDate.SelectedIndex = -1;
            //cmbInvoiceNumber.SelectedIndex = -1;
            //ds = clsSearchLogic.dbAllInvoice();
            //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;

            grdInvoiceList.ItemsSource = sl.LoadSearchWindow();
            grdInvoiceList.Items.Refresh();
            cmbInvoiceCharges.SelectedIndex = -1;
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
                // Search data will be loaded through clsSearchLogic class

                //ds = clsSearchLogic.dbSelectedInvoice(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();

                grdInvoiceList.ItemsSource = sl.SelectedInvoiceSearchWindow(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                grdInvoiceList.Items.Refresh();
            }

        }
    }
}
