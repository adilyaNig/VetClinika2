using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

using VetClinika.DBConnection;

namespace VetClinika.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReadersListWindow.xaml
    /// </summary>
    public partial class ReadersListWindow : Window
    {
        public static List<Pet> pets { get; set; }
        public ReadersListWindow()
        {
            InitializeComponent();
            
        }

        private void EditReaderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteReadreBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SearchReadersTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ReadersLv_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
