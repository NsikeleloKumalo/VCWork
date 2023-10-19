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

namespace POE_Part_Three_Test
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

        private void Home_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseaRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ScaleRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ResetQuantities_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void AddIngredients_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void FilterRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void PieChart_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ClearRecipe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void LV_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_addrecipe.Visibility = Visibility.Collapsed;
                tt_displayReccipe.Visibility = Visibility.Collapsed;
                tt_chooseaReccipe.Visibility = Visibility.Collapsed;
                tt_ScaleReccipe.Visibility = Visibility.Collapsed;
                tt_ResetQuantities.Visibility = Visibility.Collapsed;
                tt_ClearRecipe.Visibility = Visibility.Collapsed;
                tt_AddIngredients.Visibility = Visibility.Collapsed;
                tt_FilterRecipe.Visibility = Visibility.Collapsed;
                tt_RecipePieChart.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_addrecipe.Visibility = Visibility.Visible;
                tt_displayReccipe.Visibility = Visibility.Visible;
                tt_chooseaReccipe.Visibility = Visibility.Visible;
                tt_ScaleReccipe.Visibility = Visibility.Visible;
                tt_ResetQuantities.Visibility = Visibility.Visible;
                tt_ClearRecipe.Visibility = Visibility.Visible;
                tt_AddIngredients.Visibility = Visibility.Visible;
                tt_FilterRecipe.Visibility = Visibility.Visible;
                tt_RecipePieChart.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void BG_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

 
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }

