using System;
using System.Collections.Generic;
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

using VetClinika.Windows;
using VetClinika.DBConnection;

namespace VetClinika.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReaderTicketWindow.xaml
    /// </summary>
    public partial class AddReaderTicketWindow : Window
    {
        public static List<Pet> pets { get; set; }
        public static List<Vrach> vraches { get; set; }
        public AddReaderTicketWindow()
        {
            InitializeComponent();
            pets = new List<Pet>(Connection.vet.Pet.ToList());
            vraches = new List<Vrach>(Connection.vet.Vrach.ToList());
            this.DataContext = this;
        }

        private void SaveTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Priem priem = new Priem();
            priem.isDelete = false;
            priem.DataPriem = new DateTime();
            var pet = PetCm.SelectedItem as Pet;
            priem.idPet = pet.idPet;
            var vrach = VrachCm.SelectedItem as Vrach;
            priem.idVrach = vrach.idVrach;
            Connection.vet.Pet.Add(pet);
            Connection.vet.SaveChanges();
            MessageBox.Show("Новый билет добавлен.");
            Close();
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReaderWindow addReaderWindow = new AddReaderWindow();
            addReaderWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            PetCm.ItemsSource = new List<Pet>(Connection.vet.Pet.ToList());
        }
    }
}
