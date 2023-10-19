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

namespace DesignWitrhClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //object variables 
        private Values values;
        public MainWindow()
        {
            InitializeComponent();

            values = new Values();//new 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save btn
            int qnty;
            if (!int.TryParse(ingredientQntyTextBox.Text,out qnty))
            {
                MessageBox.Show("Invalid quantity --> must be int");
                return;
            }

            string name = ingredNameTextBox.Text;
            string desc = ingredDescTextBox.Text;

            double scale;
            if (!double.TryParse(scaleTextBox.Text, out scale))
            {
                MessageBox.Show("Enter Scale value as 0,5");
                return;
            }
            //output
            resultTextBlock.Text = $"Quantity: {qnty} \n" +
                $"Name: {name} \n" +
                 $"Desc: {desc} \n" +
                  $"Name: {name} ";

        }
    }
}
