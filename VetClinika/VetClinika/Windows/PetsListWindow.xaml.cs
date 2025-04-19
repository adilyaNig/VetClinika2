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
        private void PriemSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = PriemSearchTb.Text.Trim(); 

            if (string.IsNullOrEmpty(search)) 
                PacientsLv.ItemsSource = pets.ToList(); 
            else
                
                PacientsLv.ItemsSource = pets
                    .Where(i => i.idPet != -1 && i.namePet != null && i.namePet.ToLower().Contains(search.ToLower()))
                    .ToList(); 
        }
        
        

        private void PacientsLv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PacientsLv.ItemsSource = new List<Pet>(DBConnection.Connection.vet.Pet.ToList());
        }

    }
}
