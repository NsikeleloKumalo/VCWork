using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TextFilesOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //... open file dialog btn
            //browse for the files

            //create an object of openFile dialog
            OpenFileDialog fd = new OpenFileDialog();
            //set the show method so the screen pops up
            fd.ShowDialog();

            //temp memory has the location
            textBox1.Text = fd.FileName;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //read from filr
            //stream reader --> create an object
            //tell it where the file is
            try
            {
                StreamReader sr = new StreamReader(textBox1.Text);
                //where it should be dispayed 
                richTextBox1.Text = sr.ReadToEnd();
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to read from file");
            }
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
