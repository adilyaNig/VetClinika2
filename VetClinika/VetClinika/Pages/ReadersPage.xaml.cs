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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VetClinika.DBConnection;
using VetClinika.Windows;

namespace VetClinika.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        public static List<Priem> pacientsTalon { get; set; }
        public static List<Vrach> employees { get; set; }
        
        public ReadersPage()
        {
            InitializeComponent();
            pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem.ToList());
            this.DataContext = this;
        }

        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim();
            if (search == "")
                ReadersLv.ItemsSource = pacientsTalon.ToList();
            else
                ReadersLv.ItemsSource = pacientsTalon.Where(i => i.idPriem.ToString() == search).ToList();
        }

        private void FiltrEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var t = FiltrEmployee.SelectedItem as Vrach;

            if (t.idVrach != -1)
                ReadersLv.ItemsSource = pacientsTalon.Where(i => i.idVrach == t.idVrach).ToList();
            else
                ReadersLv.ItemsSource = pacientsTalon.ToList();

        }

        private void AddReaderTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddReaderTicketWindow addReaderTicket = new Windows.AddReaderTicketWindow();
            addReaderTicket.Show();
        }

        private void ReadersListBtn_Click(object sender, RoutedEventArgs e)
        {
            ReadersListWindow readersList = new ReadersListWindow();
            readersList.Show();
        }
    }
}
