using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VetClinika.Windows;

using VetClinika.Pages;
using VetClinika.DBConnection;
namespace VetClinika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Vrach vrach;
        public static Type_Vrach type_Vrach;
        public AuthorizationPage()
        {

            InitializeComponent();
        }



        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            var result = CheckCredentials(login, password);

            if (result != null)
            {
                AuthorizationPage.vrach = result.Item1;
                CurrentUser.IdVrach = result.Item1.idVrach;

                MenuVrachWindow menuVrachWindow = new MenuVrachWindow();
                menuVrachWindow.Show();

                menuVrachWindow.fioTb.Text = $"{result.Item1.famVrach} {result.Item1.nameVrach} {result.Item1.patronymicVrach}";
                menuVrachWindow.typeTb.Text = result.Item2.name; // Здесь выводится профессия
                menuVrachWindow.idTb.Text = $"Id: {result.Item1.idVrach}";
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private Tuple<Vrach, Type_Vrach> CheckCredentials(string login, string password)
        {
            using (var context = new ClinikaEntities())
            {
                var vrachQuery = from v in context.Vrach
                                 where v.login == login && v.password == password
                                 select v;

                var vrach = vrachQuery.FirstOrDefault();

                if (vrach != null)
                {
                    return new Tuple<Vrach, Type_Vrach>(vrach, vrach.Type_Vrach);
                }
            }
            return null;
        }





    }
}
