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
        clsItemsLogic il;

        /// <summary>
        /// Variable for passing data around Items window
        /// </summary>
        Item ThisItem; 

        public MainWindow()
        {
            InitializeComponent();

            // load each of the 3 logic classes, all data will pass through here
            mn = new clsMainLogic(); // Load Main Class
            sl = new clsSearchLogic(); // Load Search Class
            il = new clsItemsLogic(); // Load Item Class
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
            mn.CurrentInvoice = new Invoice(); // clear current invoice
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

            dp_InvoiceDate.IsEnabled = false;
            cb_InvoiceItems.IsEnabled = false;
            btn_AddToInvoice.IsEnabled = false;
            btn_RemoveFromInvoice.IsEnabled = false;
            tb_InvoiceItemsCost.Text = "";
            DG_Items.ItemsSource = null;

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
            Btn_Edit.Visibility = Visibility.Hidden;
            Btn_Save.Visibility = Visibility.Visible;
            Btn_Delete.Visibility = Visibility.Hidden;
            Btn_Cancel.Visibility = Visibility.Visible;

            dp_InvoiceDate.IsEnabled = true;
            cb_InvoiceItems.IsEnabled = true;
            btn_AddToInvoice.IsEnabled = true;
            btn_RemoveFromInvoice.IsEnabled = true;
            tb_InvoiceItemsCost.Text = "";
            DG_Items.ItemsSource = null;

            Main.Visibility = Visibility.Hidden;
            Invoice.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;

            cb_InvoiceItems.ItemsSource = mn.GetLineItems();
            cb_InvoiceItems.SelectedIndex = -1;
            dp_InvoiceDate.IsEnabled = true;

            lbl_InvoiceNumber.Content = "Invoice #: TBD";
            dp_InvoiceDate.SelectedDate = null;
            dp_InvoiceDate.DisplayDate = DateTime.Today;
        }

        /// <summary>
        /// Edit Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Btn_Edit.Visibility = Visibility.Hidden;
            Btn_Save.Visibility = Visibility.Visible;
            Btn_Delete.Visibility = Visibility.Hidden;
            Btn_Cancel.Visibility = Visibility.Visible;

            dp_InvoiceDate.IsEnabled = true;
            cb_InvoiceItems.IsEnabled = true;
            btn_AddToInvoice.IsEnabled = true;
            btn_RemoveFromInvoice.IsEnabled = true;
        }

        /// <summary>
        ///  Save Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (mn.CurrentInvoice.Items != null && mn.CurrentInvoice.Items.Count > 0)
            {
                mn.SaveInvoice();
                lbl_InvoiceNumber.Content = mn.CurrentInvoice.InvoiceNumber;

                Btn_Edit.Visibility = Visibility.Visible;
                Btn_Save.Visibility = Visibility.Hidden;
                Btn_Delete.Visibility = Visibility.Visible;
                Btn_Cancel.Visibility = Visibility.Hidden;

                dp_InvoiceDate.IsEnabled = false;
                cb_InvoiceItems.IsEnabled = false;
                btn_AddToInvoice.IsEnabled = false;
                btn_RemoveFromInvoice.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Items box cannot be empty!");
            }
        }

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBoxResult)MessageBox.Show("Are you sure you want to delete this invoice?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                mn.DeleteInvoice();
            }
            MI_Close_Click();
        }

        /// <summary>
        /// Open invoice
        /// </summary>
        /// <param name="id"></param>
        private void openInvoice(int id)
        {
            MI_Search.IsEnabled = true;
            MI_Close.IsEnabled = true;
            Btn_Create.IsEnabled = false;
            Btn_Edit.IsEnabled = true;
            Btn_Delete.IsEnabled = false;
            Btn_Edit.Visibility = Visibility.Visible;
            Btn_Save.Visibility = Visibility.Hidden;
            Btn_Delete.Visibility = Visibility.Visible;
            Btn_Cancel.Visibility = Visibility.Hidden;

            Main.Visibility = Visibility.Hidden;
            Invoice.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;

            try
            {
                mn.GetInvoice(id);

                lbl_InvoiceNumber.Content = mn.CurrentInvoice.InvoiceNumber;
                dp_InvoiceDate.SelectedDate = mn.CurrentInvoice.InvoiceDate;

                lbl_InvoiceTotalCost.Content = string.Format("{0:C}", Convert.ToDecimal(mn.CurrentInvoice.Cost));
                DG_Items.ItemsSource = mn.CurrentInvoice.Items;

                cb_InvoiceItems.ItemsSource = mn.GetLineItems();
                cb_InvoiceItems.SelectedIndex = -1;

            }
            catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Update TotalCost field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_InvoiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_InvoiceItems.SelectedIndex > -1)
            {
                Item item = (Item)cb_InvoiceItems.SelectedValue;
                tb_InvoiceItemsCost.Text = String.Format("{0:C2}", Convert.ToDecimal(item.Cost.ToString()));
            }
        }

        /// <summary>
        /// Add items to invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddToInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (cb_InvoiceItems.SelectedIndex > -1)
            {
                if (mn.CurrentInvoice.Items == null)
                {
                    mn.CurrentInvoice.Items = new List<Item>();
                }

                Item item = (Item)cb_InvoiceItems.SelectedValue;

                mn.CurrentInvoice.Items.Add(new Item()
                {
                    Code = item.Code,
                    Description = item.Description,
                    Cost = item.Cost
                });
                DG_Items.ItemsSource = null;
                DG_Items.ItemsSource = mn.CurrentInvoice.Items;
                lbl_InvoiceTotalCost.Content = string.Format("{0:C}", Convert.ToDecimal(mn.CurrentInvoice.Cost));
            }
        }

        /// <summary>
        /// remove items from invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RemoveFromInvoice_Click(object sender, RoutedEventArgs e)
        {
            if(DG_Items.SelectedIndex > -1)
            {
                Item item = (Item)DG_Items.SelectedValue;
                mn.CurrentInvoice.Items.Remove(item);

                DG_Items.ItemsSource = null;
                DG_Items.ItemsSource = mn.CurrentInvoice.Items;
                lbl_InvoiceTotalCost.Content = string.Format("{0:C}", Convert.ToDecimal(mn.CurrentInvoice.Cost));
            }
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
            Invoice.Visibility = Visibility.Hidden;
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
                    updateList();
                    //grdInvoiceList.ItemsSource = sl.SelectedDateSearchWindow(cmbInvoiceDate.SelectedValue.ToString());
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
                    updateList();
                    //grdInvoiceList.ItemsSource = sl.SelectedChargeSearchWindow(cmbInvoiceCharges.SelectedValue.ToString());

                   

                }
                catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
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
                    updateList();
                    //grdInvoiceList.ItemsSource = sl.SelectedInvoiceSearchWindow(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                }
                catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                {
                    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
            }

        }

        /// <summary>
        /// helper method to help with updateing the grid
        /// </summary>
        private void updateList()
        {
            DataSet ds;
            string charge = "";
            string num = "";
            string date = "";
            if (cmbInvoiceCharges.SelectedIndex != -1) { charge = cmbInvoiceCharges.SelectedValue.ToString(); }
            if (cmbInvoiceDate.SelectedIndex != -1) { date = cmbInvoiceDate.SelectedValue.ToString(); }
            if (cmbInvoiceNumber.SelectedIndex != -1) { num = cmbInvoiceNumber.SelectedValue.ToString(); }

            string sSql = "SELECT* FROM Invoices WHERE ";
            int first = 0;
            if (cmbInvoiceCharges.SelectedIndex != -1)
            {

                first = 1;
                sSql += "TotalCost = " + charge;


            }
            if (cmbInvoiceDate.SelectedIndex != -1)
            {
                if (first != 1)
                {
                    first = 1;
                    sSql += "InvoiceDate = #" + date + "#";
                }
                else
                {
                    sSql += " AND InvoiceDate = #" + date + "#";
                }

            }
            if (cmbInvoiceNumber.SelectedIndex != -1)
            {
                if (first != 1)
                {
                    first = 1;
                    sSql += "InvoiceNum = " + num.ToString();
                }
                else
                {
                    sSql += " AND InvoiceNum = " + num.ToString();
                }
            }

            //MessageBox.Show("SELECT * FROM Invoices WHERE " + sSql);

            ds = clsSearchLogic.dbUpdateALL(sSql);

            grdInvoiceList.ItemsSource = null;
            grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
            grdInvoiceList.Items.Refresh();
        }

        /// <summary>
        /// when an Item is selected and passed back to the main window, then load this in item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (grdInvoiceList.SelectedItems.Count == 1)
            {
                IList rows = grdInvoiceList.SelectedItems;
                DataRowView row = (DataRowView)grdInvoiceList.SelectedItems[0];
                MI_Close_Click();
                openInvoice(Int32.Parse(row["InvoiceNum"].ToString()));
            }
            else
            {
                MessageBox.Show("Please make one selection or cancel");
            }
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



        // -------------- Items UI functions

        /// <summary>
        /// when the form first loads, populate grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Items_Window(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Invoice.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Visible;
            MI_Search.IsEnabled = false;
            MI_Close.IsEnabled = true;
            Btn_Create.IsEnabled = false;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = false;
            ItemsListGrid.ItemsSource = il.GetItemList();
            //Btn_Save.IsEnabled = false;

            try
            {
            }
            catch (Exception ex) // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the Event of changing a selection on the Datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemoveItem.IsEnabled = true;
            btnEditItem.IsEnabled = true;
            ThisItem = (Item)ItemsListGrid.SelectedItem;
        }

        /// <summary>
        /// Handles button click event on the Add New Item Button. Labels are filled and buttons are enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            lblNewEdit.Content = "New Item: ";
            btnSave.IsEnabled = true;
            lblNotification.Content = "Enter a description and cost for the Item";
            btnRemoveItem.IsEnabled = false;
            lblCode.Visibility = Visibility.Visible;
            TxtCode.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Handles the Edit Item button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditItem_Click(object sender, RoutedEventArgs e)
        {
            lblNewEdit.Content = "Edit Item: ";
            btnUpdate.IsEnabled = true;
            lblNotification.Content = "Update Item description and/or cost";
            btnRemoveItem.IsEnabled = false;
            TxtDescription.Text = ThisItem.Description;
            txtCost.Text = ThisItem.Cost.ToString();
        }
        /// <summary>
        /// Handles event of clicking the save button after entering appropriate data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxtDescription.Text == "" && txtCost.Text == "" && TxtCode.Text == "")
            {
                MessageBox.Show("Please Enter a Code, a Description, and a cost");
            }
            else
            {
                string description = TxtDescription.Text;

                int cost = Convert.ToInt32(txtCost.Text);
                string code = TxtCode.Text;
                il.AddItem(code, description, cost);
                ItemsListGrid.ItemsSource = null;
                ItemsListGrid.ItemsSource = il.GetItemList();
            }

        }
        /// <summary>
        /// Handles the click event of the Update button after relevant data is entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string description = TxtDescription.Text;
            int cost = Convert.ToInt32(txtCost.Text);
            Item code = (Item)ItemsListGrid.SelectedItem;
            il.UpdateItem(code.Code, description, cost);
            ItemsListGrid.ItemsSource = null;
            ItemsListGrid.ItemsSource = il.GetItemList();
        }
        /// <summary>
        /// Handles the click event of the remove item button. Code is tested for usage and either deleted or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)ItemsListGrid.SelectedItem;
            List<lineItem> test = il.GetLineItems(item.Code);
            if (test.Count > 0)
            {
                MessageBox.Show("Error: Cannot delete " + item.ToString() + " because it is being used by certain Invoices");
            }
            else
            {
                il.DeleteItem(item.Code);
                ItemsListGrid.ItemsSource = null;
                ItemsListGrid.ItemsSource = il.GetItemList();
            }

        }
    }
}
