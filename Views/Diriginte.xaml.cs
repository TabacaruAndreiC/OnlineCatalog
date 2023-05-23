using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
using Platforma_Educationala.ViewModels;
using School_Platform.ViewModels;
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
    /// Interaction logic for Diriginte.xaml
    /// </summary>
    public partial class Diriginte : Window
    {
        private DiriginteVM diriginteVM;
        private UserVM userVM = new UserVM();
        public Diriginte()
        {
            InitializeComponent();
            diriginteVM = new DiriginteVM();
            var usernamelogIn = ((MainWindow)Application.Current.MainWindow).UsernameText.Text;
            Auxiliar.myClass = diriginteVM.clasaBLL.GetClassForDiriginte(diriginteVM.profesorBLL.GetDiriginteByUsername(usernamelogIn));

            diriginteVM.clasa = Auxiliar.myClass;
            Console.WriteLine(diriginteVM.clasa);
            foreach (var item in diriginteVM.materieBLL.GetAllSubjectsForClass(diriginteVM.clasa))
            {
                cbMaterie.Items.Add(item.Denumire);

            }

            foreach (var item in diriginteVM.elevBLL.GetStudentFromClass(diriginteVM.clasa))
            {
                cbElev.Items.Add(item.Nume);
            }
        }

        private void VizualizareAbsente_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Visible;

            diriginteVM.elev = diriginteVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString());

            diriginteVM.Materii = diriginteVM.materieBLL.GetAllSubjectsForClass(diriginteVM.clasa);

            diriginteVM.materie = diriginteVM.materieBLL.GetMaterie(diriginteVM.Materii, cbMaterie.SelectedItem.ToString());

            DataGrid.ItemsSource = diriginteVM.absBLL.GetAbs(diriginteVM.elev, diriginteVM.materie);


            Total.Content = "Total absente ";

            Valoare.Visibility = Visibility.Visible;
            Valoare.Content = diriginteVM.absBLL.GetAbsNumber(diriginteVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString())).ToString();

            Motiveaza.Visibility = Visibility.Visible;

        }

        private void VizualizareMedii_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Visible;

            Total.Content = "Madia generala";

            Valoare.Content = diriginteVM.GeneralAvrage(diriginteVM.SituatieElev(diriginteVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString())));

            DataGrid.ItemsSource = diriginteVM.SituatieElev(diriginteVM.elev);

            Motiveaza.Visibility = Visibility.Hidden;
        }

        private void Motiveaza_Click(object sender, RoutedEventArgs e)
        {

            Valoare.Content = diriginteVM.absBLL.GetAbsNumber(diriginteVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString())).ToString();
            if (DataGrid.SelectedItem != null)
            {


                diriginteVM.absBLL.DeleteAbs((Absente)DataGrid.SelectedItem);
                DataGrid.ItemsSource = diriginteVM.absBLL.GetAbs(diriginteVM.elev, diriginteVM.materie);
            }
            else
            {
                MessageBox.Show("Selecteaza absenta");
            }

        }



        private void cbElev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            diriginteVM.elev = diriginteVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString());

        }

        private void cbMaterie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            diriginteVM.materie = diriginteVM.materieBLL.GetMaterie(diriginteVM.Materii, cbMaterie.SelectedItem.ToString());


        }

        private void Ierarhie_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = diriginteVM.Statistica(diriginteVM.clasa);
        }

        private void Corigenti_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = diriginteVM.Corigenti(diriginteVM.clasa);
        }

        private void Premianti_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = diriginteVM.Premianti(diriginteVM.clasa);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = diriginteVM.Repetenti(diriginteVM.clasa);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = diriginteVM.Exmatriculare(diriginteVM.clasa);
        }
    }
}
