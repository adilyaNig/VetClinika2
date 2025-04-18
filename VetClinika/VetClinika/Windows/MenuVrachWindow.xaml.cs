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
using System.Windows.Shapes;

using VetClinika.Pages;

namespace VetClinika.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuEmployeeWindow.xaml
    /// </summary>
    public partial class MenuVrachWindow : Window
    {
        public MenuVrachWindow()
        {
            InitializeComponent();
        }
        private void readerBtn_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new PetsPage());
        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            //menuFr.NavigationService.Navigate(new BookksPage());
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void petsBtn_Click(object sender, RoutedEventArgs e)
        {
            
                PetsListWindow petsList = new PetsListWindow();
                petsList.Show();
            
        }
    }
}
