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
    /// Логика взаимодействия для EditReaderBtn.xaml
    /// </summary>
    public partial class EditReaderBtn : Window
    {
        public static Pet pet1 = new Pet();

        public EditReaderBtn(Pet pet)
        {
            InitializeComponent();
            pet1 = pet;
            NameTb.Text = pet1.namePet;
            PolCm.SelectedValue = pet1.idGender;
            TypeCB.SelectedValue = pet1.idType;
            WeightTb.Text = pet1.Weight.ToString();
            Height.Text = pet1.Height.ToString();
            this.DataContext = this;
        }

        private void SaveEditBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите изменить пациента {pet1.namePet}?", "Удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                pet1.namePet = NameTb.Text;
                pet1.idGender = (PolCm.SelectedItem as Gender).id;
                pet1.idType = (TypeCB.SelectedItem as Type_Pet).id;

                if (int.TryParse(WeightTb.Text, out int weight))
                {
                    pet1.Weight = weight;
                }
                if (int.TryParse(Height.Text, out int height))
                {
                    pet1.Height = height;
                }



                Connection.vet.SaveChanges();
                ReadersListWindow readersListWindow = new ReadersListWindow();
                //readersListWindow.ReadersLv.ItemsSource = new List<Pet>(DBConnection.Connection.vet.Pet.Where(i => i.IsDelete == false).ToList());
            }
            MessageBox.Show("Читатель успешно изменен");
            Close();

        }
    }
}
