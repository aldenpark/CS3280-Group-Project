using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        UserControl control;

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
        /// Load Definition User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Definition_Click(object sender, RoutedEventArgs e)
        {
            MI_NewInvoice.IsEnabled = false;
            MI_Search.IsEnabled = false;
            MI_Save.IsEnabled = true;
            MI_Close.IsEnabled = true;
            MI_Delete.IsEnabled = true;

            if (control == null || control.Name != "UC_Definition")
            {
                control = new Main.UC_Definition();
                control.Name = "UC_Definition";
                WP_Invoice.Children.Add(control);
            }
        }

        /// <summary>
        /// Load New Invoice User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_NewInvoice_Click(object sender, RoutedEventArgs e)
        {
            MI_Definitions.IsEnabled = false;
            MI_Search.IsEnabled = false;
            MI_Save.IsEnabled = true;
            MI_Close.IsEnabled = true;
            MI_Delete.IsEnabled = true;

            //WP_Invoice.Children.Add(new Main.UC_Definition());
        }

        /// <summary>
        /// Close Loaded User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MI_Close_Click(object sender, RoutedEventArgs e)
        {
            MI_NewInvoice.IsEnabled = true;
            MI_Search.IsEnabled = true;
            MI_Definitions.IsEnabled = true;
            MI_Save.IsEnabled = false;
            MI_Close.IsEnabled = false;
            MI_Delete.IsEnabled = false;

            if (control != null)
            {
                control = null;
                WP_Invoice.Children.Clear();
            }
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
    }
}
