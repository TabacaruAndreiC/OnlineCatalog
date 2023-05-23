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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Platforma_Educationala.ViewModels;
using Platforma_Educationala.Views;

namespace Platforma_Educationala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserVM userVM = new UserVM();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_C(object sender, RoutedEventArgs e)
        {
            UserVM.Users_Type aux = userVM.GetUserType(UsernameText.Text, PasswordText.Password);
              switch (aux)
            {
                case UserVM.Users_Type.Administrator:
                    Admin admin = new Admin();
                    Close();
                    admin.Show();
                    break;
                case UserVM.Users_Type.Profesor:
                    Profesor profesor = new Profesor();
                    Close();
                    profesor.Show();
                    break;
                case UserVM.Users_Type.Diriginte:
                    Diriginte diriginte = new Diriginte();
                    Close();
                    diriginte.Show();
                    break;
                case UserVM.Users_Type.Elev:
                    Elev elev = new Elev();
                    Close();
                    elev.Show();
                    break;
                default:
                    MessageBox.Show("Logare Gresita");
                    break;
            }
            
        }
    }
}
