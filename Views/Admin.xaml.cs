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

namespace Platforma_Educationala.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void AdaugaUtilizator_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AdaugaUtilizator();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ModificaUtilizator();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new StergeUtilizator();
        }
    }
}
