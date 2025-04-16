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
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public AddReaderWindow()
        {
            InitializeComponent();
        }
        private void SaveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Pet pet = new Pet();
            pet.namePet = NameTb.Text.Trim();
            pet.idGender= (PolTb.SelectedItem as Gender).id;
            pet.idType = (TypeTb.SelectedItem as Type_Pet).id;

            Connection.vet.Pet.Add(pet);
            Connection.vet.SaveChanges();
            MessageBox.Show("Пациент успешно добавлен.");
            Close();
        }
    }
}
