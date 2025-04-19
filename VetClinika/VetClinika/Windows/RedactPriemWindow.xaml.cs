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
using VetClinika.DBConnection;
using VetClinika.Pages;

namespace VetClinika.Windows
{
    /// <summary>
    /// Логика взаимодействия для RedactPriemWindow.xaml
    /// </summary>
    public partial class RedactPriemWindow : Window
    {
        public static List<Pet> pets { get; set; }
        public static Priem priem1 = new Priem();
        public RedactPriemWindow(Priem priem)
        {

            InitializeComponent();
            pets = new List<Pet>(Connection.vet.Pet.ToList());

            priem1 = priem; // Присвоим принятому приёму нашу статическую переменную

            // Зададим начальные значения полей
            if (priem != null)
            {
                PetCm.SelectedItem = priem.Pet; // Установим выбранного питомца
                DateOfVisitDtp.SelectedDate = priem.DataPriem; // Установим дату приёма
                ComTb.Text = priem.Comment; // Установим комментарий
            }

            this.DataContext = this;
        }

        private void SavePriemBtn_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текущие данные из элементов управления
            var pet = PetCm.SelectedItem as Pet;
            if (pet != null)
            {
                priem1.idPet = pet.idPet;
            }
            priem1.DataPriem = DateOfVisitDtp.SelectedDate ?? DateTime.Now;
            priem1.Comment = ComTb.Text;

            // Сохраняем изменения в базе данных
            Connection.vet.SaveChanges();

            MessageBox.Show("Приём успешно изменён.");
            Close();
        }

        private void AddPetBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPetWindow addPetWindow = new AddPetWindow();
            addPetWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            PetCm.ItemsSource = new List<Pet>(Connection.vet.Pet.ToList());

        }
    }
}
