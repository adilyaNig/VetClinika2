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
            pets = new List<Pet>(Connection.vet.Pet.ToList());
            this.DataContext = this;
        }
        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim(); // Получаем текст из TextBox

            if (string.IsNullOrEmpty(search)) // Проверяем, пуст ли ввод
                ReadersLv.ItemsSource = pets.ToList(); // Если пусто, показываем все записи
            else
                // Фильтруем по кличке питомца
                ReadersLv.ItemsSource = pets
                    .Where(i => i.idPet != -1 && i.namePet != null && i.namePet.ToLower().Contains(search.ToLower()))
                    .ToList(); // Ищем по кличке, игнорируя регистр
        }
        
        

        private void ReadersLv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReadersLv.ItemsSource = new List<Pet>(DBConnection.Connection.vet.Pet.ToList());
        }

    }
}
