using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
        public static List<Priem> pacientsTalon {  get; set; }
        public static List<Vrach> employees {  get; set; }

        public static Vrach vrach;

        public ReadersPage()
        {
            InitializeComponent();
            // Проверяем, есть ли текущий врач
            if (AuthorizationPage.vrach != null)
            {
                // Загружаем только приёмы текущего врача
                pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem.Where(p => p.idVrach == AuthorizationPage.vrach.idVrach).ToList());
            }
            else
            {
                MessageBox.Show("Требуется вход в систему");
                return;
            }

            this.DataContext = this;
        }



        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim(); // Получаем текст из TextBox

            if (string.IsNullOrEmpty(search)) // Проверяем, пуст ли ввод
                ReadersLv.ItemsSource = pacientsTalon.ToList(); // Если пусто, показываем все записи
            else
                // Фильтруем по кличке питомца
                ReadersLv.ItemsSource = pacientsTalon
                    .Where(i => i.Pet != null && i.Pet.namePet != null && i.Pet.namePet.ToLower().Contains(search.ToLower()))
                    .ToList(); // Ищем по кличке, игнорируя регистр
        }

        private void FiltrDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpFilterDate.SelectedDate.HasValue)
            {
                // Преобразуем выбранную дату в чистый формат (без учета времени)
                DateTime selectedDate = dpFilterDate.SelectedDate.Value.Date;

                // Фильтруем приёмы только по указанной дате
                var filteredAppointments = pacientsTalon
                                            .Where(a => a.DataPriem.HasValue &&
                                                       a.DataPriem.Value.Date == selectedDate)
                                            .ToList();

                // Обновляем источник данных для ListView
                ReadersLv.ItemsSource = filteredAppointments;

                // Если не найдено никаких приёмов на указанную дату
                if (!filteredAppointments.Any())
                {
                    MessageBox.Show("На выбранную дату приёмов не найдено.",
                                    "Информация",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            else
            {
                // Если дата не указана, показываем все приёмы
                ReadersLv.ItemsSource = pacientsTalon;
            }
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

        private void DeleteReadreBtn_Click(object sender, RoutedEventArgs e)
        {
            var pacient = ReadersLv.SelectedItem as Priem;
            if (pacient != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить приём №{pacient.idPriem}?", "Удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    // Удаляем приём из контекста данных
                    DBConnection.Connection.vet.Priem.Remove(pacient);
                    DBConnection.Connection.vet.SaveChanges();

                    // Обновляем список приёмов, оставив только текущие
                    pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem.Where(p => p.idVrach == AuthorizationPage.vrach.idVrach).ToList());
                    ReadersLv.ItemsSource = pacientsTalon;

                    MessageBox.Show("Приём успешно удалён.", "Удаление выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите приём для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            dpFilterDate.SelectedDate = null; // Очищаем выбранную дату
            ReadersLv.ItemsSource = pacientsTalon; // Возвращаемся ко всему списку
        }
    }
}
