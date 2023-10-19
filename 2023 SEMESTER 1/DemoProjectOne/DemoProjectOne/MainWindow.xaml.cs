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
using System.Windows.Threading;

namespace DemoProjectOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //create an object of Dispatcher Timer
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            //when the form loads
            //set the timer interval
            //start and stop the timer 
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0,0,8);
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            //what happens after the second screen
            Second sec = new Second(); /*class object*/
            sec.Show(); /*sets visability*/
            dt.Stop(); /*stops the timer*/
            this.Close(); /*closes the splash*/
        }
    }
}
