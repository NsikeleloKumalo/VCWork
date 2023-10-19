using System;
using System.Collections.Generic;
using System.IO;
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

namespace FileMainTwo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save btn
            //take data from a new txt file -- memory
            //write the data into the txt file 
            //varibles per text box to hold user input 

            string name = txtName.Text;
            string surname = txtSurname.Text;

            using(System.IO.StreamWriter writer = new StreamWriter("data.txt",true))
            {
                writer.WriteLine(name);
                writer.WriteLine(surname);
                writer.WriteLine("----------------------------------");
            }
            //pop up 
            MessageBox.Show("Data saved to text file ");
            //clear the textbox 
            txtName.Text="";
            txtSurname.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //load/read btn --> populate the txt boxes
            using(StreamReader sr = new StreamReader("data.txt"))
            {
                string name = sr.ReadLine();
                string surname = sr.ReadLine();
                //place them into the textboxes
                txtName.Text = name;
                txtSurname.Text = surname;
                //optional --> mbox --> label
                MessageBox.Show("Data read complete");


            }
        }
    }
}
