using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlacingOrders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //submit btn validations 
            //if the person leaves a field blank 

            if (textBox1.Text =="" || textBox2.Text == ""
                || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Fields can't be blank");
            }
            else
            {
                //fetch the values  --> Pass it onto mbox
                // variables

                int id = Int32.Parse(textBox1.Text);
                string name = textBox1.Text;
                int qnty = Int32.Parse(textBox3.Text);
                int drinks = Int32.Parse(textBox4.Text);

                //output

                MessageBox.Show("Order Summary \n___________________\n\n" + 
                   "Id:" + id 
                   + "\nName:" + name
                   + "\nBurgers:" + qnty
                   + "\nDrinks:" + drinks);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
