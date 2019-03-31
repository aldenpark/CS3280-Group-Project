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

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for DefinitionUI.xaml
    /// </summary>
    public partial class UC_Definition : UserControl
    {
        public UC_Definition()
        {
            InitializeComponent();

            // Load UserControl Definition
            clsMainLogic.LoadDefinitions();
        }

        /// <summary>
        /// Load UserControl Edit Name Definition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LB_DefinitionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Save Data in User Control
        /// </summary>
        public void Save()
        {
            clsMainLogic.SaveDefinitions();
        }

        /// <summary>
        /// Save Data in User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Save(object sender, RoutedEventArgs e)
        {
            clsMainLogic.SaveDefinitions();
        }

        /// <summary>
        /// Cancel Changes made in User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
