using Platforma_Educationala.Models.EntityLayer;
using Platforma_Educationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Platforma_Educationala.Views
{
    /// <summary>
    /// Interaction logic for AdaugaUtilizator.xaml
    /// </summary>
    public partial class AdaugaUtilizator : UserControl
    {
        private ClassVM classVM = new ClassVM();
        private UserVM userVM = new UserVM();
        public AdaugaUtilizator()
        {
            InitializeComponent();
            ObservableCollection<string> aux = classVM.GetAllClassNames();
            foreach (var item in aux)
            {
                classes.Items.Add(item);
            }
            string[] types = { "Elev", "Profesor", "Diriginte" };
            foreach (var item in types)
            {
                userType.Items.Add(item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userVM.usersBLL.AddUser(username.Text, password.Text);
            switch (userType.SelectedItem.ToString())
            {
                case "Elev":
                    userVM.usersBLL.AddElev(secondName.Text +" "+ firstName.Text, classes.Text);
                    break;
                case "Profesor":
                    userVM.usersBLL.AddProfesor(secondName.Text + " " + firstName.Text, classes.Text);
                    break;
                case "Diriginte":
                    userVM.usersBLL.AddDiriginte(secondName.Text + " " + firstName.Text, classes.Text);
                    break;
            }
            MessageBox.Show("Utilizator adaugat cu succes");
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ComboBoxItem typeItem = (ComboBoxItem)userType.SelectedItem;
            string typeItem = userType.SelectedItem.ToString();
            username.Text = secondName.Text + firstName.Text + "@" + typeItem.ToLower();
        }

    }
}
