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

namespace MoreXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            label1.Visibility = Visibility.Collapsed;
            cb1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            rb1.Visibility = Visibility.Collapsed;
            rb2.Visibility = Visibility.Collapsed;
            rb3.Visibility = Visibility.Collapsed;
            rtb1.Visibility = Visibility.Collapsed;
        }

        private void cb1_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Visible;
            rb1.Visibility = Visibility.Visible;
            rb2.Visibility = Visibility.Visible;
            rb3.Visibility = Visibility.Visible;
            rtb1.Visibility= Visibility.Visible;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1.Visibility = Visibility.Visible;
            cb1.Visibility = Visibility.Visible;
        }

        private void cb1_Checked(object sender, RoutedEventArgs e)
        {
            if (cb1.IsChecked == true)
            {
                label2.Visibility = Visibility.Visible;
                rb1.Visibility = Visibility.Visible;
                rb2.Visibility = Visibility.Visible;
                rb3.Visibility = Visibility.Visible;
                rtb1.Visibility = Visibility.Visible;
            }
            else
            {
                label2.Visibility = Visibility.Collapsed;
                rb1.Visibility = Visibility.Collapsed;
                rb2.Visibility = Visibility.Collapsed;
                rb3.Visibility = Visibility.Collapsed;
                rtb1.Visibility = Visibility.Collapsed;
            }
        }
    }
}
