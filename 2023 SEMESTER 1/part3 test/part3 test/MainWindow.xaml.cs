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

namespace part3_test
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

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            //Add Recipe 
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            //Display Recipe 
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            //Choose recipe 

        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            //Reset Quantities 
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            //Clear Recipe 
        }

        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {
            //Add Ingredients 
        }

        private void ListViewItem_Selected_7(object sender, RoutedEventArgs e)
        {
            //exit button 
            this.Close();
        }
    }
}
