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
    public partial class AddPriemWindow : Window
    {
        public static List<Pet> pets { get; set; }
        public static List<Vrach> vraches { get; set; }

        public AddPriemWindow()
        {
            InitializeComponent();



            vraches = new List<Vrach>(Connection.vet.Vrach.ToList());
            pets = new List<Pet>(Connection.vet.Pet.ToList());
            this.DataContext = this;


        }

        private void SaveTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый приём
            Priem priem = new Priem();
            priem.isDelete = false;

            // Забираем выбранную дату из DatePicker
            priem.DataPriem = DateOfVisitDtp.SelectedDate ?? DateTime.Now; // Используем текущую дату, если дата не выбрана

            priem.Comment=ComTb.Text;

            // Забираем выбранный питомец
            var pet = PetCm.SelectedItem as Pet;
            if (pet != null)
            {
                priem.idPet = pet.idPet;
            }

            // Устанавливаем id врача
            priem.idVrach = CurrentUser.IdVrach ?? 0; // Используйте 0 или другое значение по умолчанию, если idVrach не установлен

            // Сохраняем приём в базу данных
            Connection.vet.Priem.Add(priem);
            Connection.vet.SaveChanges();

            MessageBox.Show("Новый прием добавлен.");
            Close();
        }

        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPetWindow addReaderWindow = new AddPetWindow();
            addReaderWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            PetCm.ItemsSource = new List<Pet>(Connection.vet.Pet.ToList());
        }
    }
}
