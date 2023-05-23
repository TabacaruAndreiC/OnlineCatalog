using Platforma_Educationala.Models.EntityLayer;
using Platforma_Educationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Platforma_Educationala.Views
{
    public partial class ModificaUtilizator : UserControl
    {
        private UserVM userVM = new UserVM();
        private ClassVM classVM = new ClassVM();
        private int id;
        private ObservableCollection<Users> users = new ObservableCollection<Users>();
        public ModificaUtilizator()
        {
            InitializeComponent();
            users = userVM.usersBLL.GetAllUsers();
            foreach ( var item in users)
            {
                user.Items.Add(item.Username);
            }
            ObservableCollection<string> aux = classVM.GetAllClassNames();
            foreach (var item in aux)
            {
                classes.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (user.Text.Contains("@profesor"))
                userVM.usersBLL.ModifyUser(username.Text, password.Text, id, secondName.Text + " " + firstName.Text, classes.Text, "Profesor");
            if (user.Text.Contains("@elev"))
                userVM.usersBLL.ModifyUser(username.Text, password.Text, id, secondName.Text + " " + firstName.Text, classes.Text, "Elev");
            if (user.Text.Contains("@diriginte"))
                userVM.usersBLL.ModifyUser(username.Text, password.Text, id, secondName.Text + " " + firstName.Text, classes.Text, "Diriginte");
            MessageBox.Show("Utilizator modificat cu succes");
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (user.Text.Contains("@profesor"))
                username.Text = secondName.Text + firstName.Text + "@profesor";
            if (user.Text.Contains("@elev"))
                username.Text = secondName.Text + firstName.Text + "@elev";
            if (user.Text.Contains("@diriginte"))
                username.Text = secondName.Text + firstName.Text + "@diriginte";
        }

        private void user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id = userVM.usersBLL.GetUserIDByUsername(user.SelectedItem.ToString());
            Users U = userVM.usersBLL.GetUserById(id);
            username.Text = U.Username;
            password.Text = U.Password;

            string[] nume = U.Username.Split('@');
            if (nume.Length >= 2)
            {
                string[] nume2 = Regex.Split(nume[0], @"(?<!^)(?=[A-Z])");
                if (nume2.Length >= 2)
                {
                    firstName.Text = nume2[1];
                    secondName.Text = nume2[0];
                }
            }
        }

    }
}
