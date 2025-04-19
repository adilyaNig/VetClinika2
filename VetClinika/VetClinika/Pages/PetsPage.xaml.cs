using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class PetsPage : Page
    {
        public static List<Priem> pacientsTalon {  get; set; }
        public static List<Vrach> vraches {  get; set; }

        public static Vrach vrach;

        public PetsPage()
        {
            InitializeComponent();
            // Проверяем, есть ли текущий врач
            if (AuthorizationPage.vrach != null)
            {
                // Загружаем только приёмы текущего врача
                pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem.Where(p => p.idVrach == AuthorizationPage.vrach.idVrach && p.isDelete == false).ToList());
            }
            else
            {
                MessageBox.Show("Требуется вход в систему");
                return;
            }

            this.DataContext = this;
        }



        private void PriemSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = PriemSearchTb.Text.Trim(); // Получаем текст из TextBox

            if (string.IsNullOrEmpty(search)) // Проверяем, пуст ли ввод
                PacientsLv.ItemsSource = pacientsTalon.ToList(); // Если пусто, показываем все записи
            else
                // Фильтруем по кличке питомца
                PacientsLv.ItemsSource = pacientsTalon
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
                PacientsLv.ItemsSource = filteredAppointments;

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
                PacientsLv.ItemsSource = pacientsTalon;
            }
        }



        private void AddPriemBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddPriemWindow addPriem = new Windows.AddPriemWindow();
            addPriem.Show();
        }



        private void DeletePriemBtn_Click(object sender, RoutedEventArgs e)
        {
            var pacient = PacientsLv.SelectedItem as Priem;
            if (pacient != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить приём №{pacient.idPriem}?", "Удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    // Помечаем приём как удалённый
                    pacient.isDelete = true;

                    // Обновляем контекст данных
                    DBConnection.Connection.vet.Entry(pacient).State = EntityState.Modified;
                    DBConnection.Connection.vet.SaveChanges();

                    // Обновляем список приёмов, исключая помеченные как удалённые
                    pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem
                        .Where(p => p.idVrach == AuthorizationPage.vrach.idVrach && (p.isDelete == null || p.isDelete == false))
                        .ToList());
                    PacientsLv.ItemsSource = pacientsTalon;

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
            PacientsLv.ItemsSource = pacientsTalon; // Возвращаемся ко всему списку
        }

        private void RedactPriemBtn_Click(object sender, RoutedEventArgs e)
        {
            var priem = PacientsLv.SelectedItem as Priem;
            if (priem != null)
            {
                RedactPriemWindow redactPriemWindow = new RedactPriemWindow(priem); // Передаёшь объект priem
                redactPriemWindow.Show();

            }
            else
            {
                MessageBox.Show("Для редактирования выберите прием");
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            pacientsTalon = new List<Priem>(DBConnection.Connection.vet.Priem
                         .Where(p => p.idVrach == AuthorizationPage.vrach.idVrach && (p.isDelete == false))
                         .ToList());
            PacientsLv.ItemsSource = pacientsTalon;
        }
    }
}
