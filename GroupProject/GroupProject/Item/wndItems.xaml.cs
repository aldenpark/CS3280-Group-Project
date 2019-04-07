using System;
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

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// DataSet varaible used for populating datagrid and populating comboboxes
        /// </summary>
        public DataSet ds;

        public wndItems()
        {
            //InitializeComponent();

            //fetches items data
            ds = clsItemsLogic.GetItemsList();
      
            //populates item list 
            for (int i = 0; i < clsItemsLogic.numberReturned; i++)
            {
                ItemListDropDown.Items.Add(ds.Tables[0].Rows[i]["Item"].ToString());
            }


        }

        /// <summary>
        /// Adds item to invoice and updates total cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemToInvoice_Click(object sender, RoutedEventArgs e)
        {
            clsItemsLogic.listItems[clsItemsLogic.CurrentIndex] = ItemListDropDown.SelectedItem.ToString();
            clsItemsLogic.CurrentIndex++;
        }

        /// <summary>
        /// Removes selected item from invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItemFromInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Saves final invoice selection and adds it to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Selects Item in list and displays cost to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ds = clsItemsLogic.GetItemCost(ItemListDropDown.SelectedItem.ToString());
            CostTextBox.Text = ds.ToString();
        }
    }
}
