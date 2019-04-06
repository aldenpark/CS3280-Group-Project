﻿using System;
using System.Collections.Generic;
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
        clsMainLogic mn;
        clsSearchLogic sl;
        //wndItemsLogic il;
        public MainWindow()
        {
            InitializeComponent();

            mn = new clsMainLogic(); // Load Main Class
            sl = new clsSearchLogic(); // Load Search Class
            //il = new wndItemsLogic(); // Load Item Class

            Main.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;

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
        /// Load New Invoice User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void MI_NewInvoice_Click(object sender, RoutedEventArgs e)
        //{
            //MI_Search.IsEnabled = true;
            //MI_Close.IsEnabled = false;
            //Btn_Create.IsEnabled = true;
            //Btn_Edit.IsEnabled = false;
            //Btn_Delete.IsEnabled = false;
            //Btn_Save.IsEnabled = false;

        //    //WP_Invoice.Children.Add(new Main.UC_Definition());
        //}

        /// <summary>
        /// Close Loaded User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Close_Click(object sender, RoutedEventArgs e)
        {
            MI_Search.IsEnabled = true;
            MI_Close.IsEnabled = false;
            Btn_Create.IsEnabled = true;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = false;
            //Btn_Save.IsEnabled = false;

            Main.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
            Item.Visibility = Visibility.Hidden;

        }

        /// <summary>
        ///  Call User Control Save method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Call Delete Method in User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            MI_Search.IsEnabled = false;
            MI_Close.IsEnabled = true;
            Btn_Create.IsEnabled = false;
            Btn_Edit.IsEnabled = false;
            Btn_Delete.IsEnabled = true;
            //Btn_Save.IsEnabled = true;
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

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

            //ds = clsSearchLogic.dbAllInvoice();
            //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
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
                //ds = clsSearchLogic.dbSelectedDate(cmbInvoiceDate.SelectedValue.ToString());
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();
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
                //ds = clsSearchLogic.dbSelectedCharge(cmbInvoiceCharges.SelectedValue.ToString());
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();
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
            //IList rows = grdInvoiceList.SelectedItems;
            //DataRowView row = (DataRowView)grdInvoiceList.SelectedItems[0];
            //MessageBox.Show("Pass back invoice num: " + row["InvoiceNum"].ToString());
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
            //grdInvoiceList.ItemsSource = null;
            //grdInvoiceList.Items.Refresh();
            //cmbInvoiceCharges.SelectedIndex = -1;
            //cmbInvoiceDate.SelectedIndex = -1;
            //cmbInvoiceNumber.SelectedIndex = -1;
            //ds = clsSearchLogic.dbAllInvoice();
            //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
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
                //ds = clsSearchLogic.dbSelectedInvoice(Int32.Parse(cmbInvoiceNumber.SelectedValue.ToString()));
                //grdInvoiceList.ItemsSource = null;
                //grdInvoiceList.ItemsSource = ds.Tables[0].DefaultView;
                //grdInvoiceList.Items.Refresh();
            }

        }
    }
}
