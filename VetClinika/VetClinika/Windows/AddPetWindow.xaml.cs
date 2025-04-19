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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VetClinika.DBConnection;

namespace VetClinika.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPetWindow.xaml
    /// </summary>
    public partial class AddPetWindow : Window
    {
        public AddPetWindow()
        {
            InitializeComponent();
            // Загрузка данных о полах
            PolTb.ItemsSource = Connection.vet.Gender.ToList();

            // Загрузка данных о типах животных
            TypeTb.ItemsSource = Connection.vet.Type_Pet.ToList();
        }

        
        private void SavePetBtn_Click(object sender, RoutedEventArgs e)
        {
            Pet pet = new Pet();
            pet.namePet = NameTb.Text.Trim();
            // Получаем id выбранного пола
            if (PolTb.SelectedItem is Gender selectedGender)
            {
                pet.idGender = selectedGender.id;
            }

            // Получаем id выбранного типа животного
            if (TypeTb.SelectedItem is Type_Pet selectedType)
            {
                pet.idType = selectedType.id;
            }

            // Преобразуем вес и рост
            pet.Weight = Convert.ToInt32(WeightTb.Text.Trim());
            pet.Height = Convert.ToInt32(HeightTb.Text.Trim());

            // Сохраняем питомца в базе данных
            Connection.vet.Pet.Add(pet);
            Connection.vet.SaveChanges();

            MessageBox.Show("Пациент успешно добавлен.");
            Close();
        }
    }
}
