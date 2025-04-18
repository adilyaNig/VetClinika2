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
    /// Логика взаимодействия для PetsListWindow.xaml
    /// </summary>
    public partial class PetsListWindow : Window
    {
        public static List<Pet> pets { get; set; }
        public PetsListWindow()
        {
            InitializeComponent();
            pets = new List<Pet>(Connection.vet.Pet.ToList());
            this.DataContext = this;
        }
        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim(); 

            if (string.IsNullOrEmpty(search)) 
                ReadersLv.ItemsSource = pets.ToList(); 
            else
                
                ReadersLv.ItemsSource = pets
                    .Where(i => i.idPet != -1 && i.namePet != null && i.namePet.ToLower().Contains(search.ToLower()))
                    .ToList(); 
        }
        
        

        private void ReadersLv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReadersLv.ItemsSource = new List<Pet>(DBConnection.Connection.vet.Pet.ToList());
        }

    }
}
