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
    /// Interaction logic for StergeUtilizator.xaml
    /// </summary>
    public partial class StergeUtilizator : UserControl
    {
        private UserVM userVM = new UserVM();

        public StergeUtilizator()
        {
            InitializeComponent();
            ObservableCollection<Users> users = userVM.usersBLL.GetAllUsers();
            foreach (var item in users)
            {
                if(!item.Username.Contains("@diriginte") && item.ID > 1)
                    user.Items.Add(item.Username);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esti sigur ca vrei sa stergi acest utilizator ?");
            int id = userVM.usersBLL.GetUserIDByUsername(user.SelectedItem.ToString());
            userVM.usersBLL.DeleteUser(id);
            MessageBox.Show("Utilizator sters cu succes");
        }
    }
}
