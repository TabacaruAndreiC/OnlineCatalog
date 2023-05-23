using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
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
    /// Interaction logic for Profesor.xaml
    /// </summary>
    public partial class Profesor : Window
    {
        private ProfesorVM profesorVM;
        public Profesor()
        {
            InitializeComponent();
            profesorVM = new ProfesorVM();
            var usernamelogIn = ((MainWindow)Application.Current.MainWindow).UsernameText.Text;
            profesorVM.profesor = profesorVM.profesorBLL.GetProfesorByUsername(usernamelogIn);

            profesorVM.ClassList = profesorVM.GetClasa(profesorVM.profesor);

            foreach (var item in profesorVM.ClassList)
            {
                cbClasa.Items.Add(item.Denumire);

            }
        }
        private void cbClasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbMaterie.Items.Clear();
            cbElev.Items.Clear();

            profesorVM.cls = profesorVM.clasaBLL.GetClassFromList(profesorVM.ClassList, cbClasa.SelectedItem.ToString());
            profesorVM.MateriiList = profesorVM.GetSubjects(profesorVM.cls, profesorVM.profesor);
            Auxiliar.myClass = profesorVM.cls;

            foreach (var item in profesorVM.MateriiList)
            {
                cbMaterie.Items.Add(item.Denumire);
            }

            foreach (var item in profesorVM.elevBLL.GetStudentFromClass(profesorVM.cls))
            {
                cbElev.Items.Add(item.Nume);
            }
            if (profesorVM.cls.Denumire == profesorVM.clasaBLL.GetClassForDiriginte(profesorVM.profesor).Denumire)
            {
                Diriginte.Visibility = Visibility.Visible;
            }
        }

        private void cbElev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Afiseaza1.Visibility = Visibility.Visible;
            profesorVM.materie = profesorVM.matBLL.GetMaterie(profesorVM.MateriiList, cbMaterie.SelectedItem.ToString());
            profesorVM.elev = profesorVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString());
            profesorVM.GradesList = profesorVM.noteBLL.GetGrades(profesorVM.elev, profesorVM.materie);
            dtaGrid.ItemsSource = profesorVM.noteBLL.GetGrades(profesorVM.elev, profesorVM.materie);
            txtMedie.Text = "";
            dtsABSGrid.ItemsSource = profesorVM.absBLL.GetAbs(profesorVM.elev, profesorVM.materie);

        }

        private void Afiseaza_Click_1(object sender, RoutedEventArgs e)
        {
            txtNote.Visibility = Visibility.Visible;
            dtaGrid.Visibility = Visibility.Visible;
            txtAbs.Visibility = Visibility.Visible;
            dtsABSGrid.Visibility = Visibility.Visible;
            MedieLbl.Visibility = Visibility.Visible;
            Modifica.Visibility = Visibility.Visible;
            Adauga.Visibility = Visibility.Visible;
            calculeaza.Visibility = Visibility.Visible;
            AdaugaABS.Visibility = Visibility.Visible;
            sterge.Visibility = Visibility.Visible;
            stergeAbs.Visibility = Visibility.Visible;


            profesorVM.elev = profesorVM.elevBLL.GetStudentByName(cbElev.SelectedItem.ToString());
            profesorVM.materie = profesorVM.matBLL.GetMaterie(profesorVM.MateriiList, cbMaterie.SelectedItem.ToString());
            profesorVM.GradesList = profesorVM.noteBLL.GetGrades(profesorVM.elev, profesorVM.materie);
            dtaGrid.ItemsSource = profesorVM.GradesList;

            dtsABSGrid.ItemsSource = profesorVM.absBLL.GetAbs(profesorVM.elev, profesorVM.materie);


        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            if (dtaGrid.SelectedItem != null)
            {
                profesorVM.noteBLL.ModifyGrade((Note)dtaGrid.SelectedItem);

            }
            else
            {
                MessageBox.Show("Selecteaza o nota");
            }
        }

        private void Adauga_Click(object sender, RoutedEventArgs e)
        {
            if (dtaGrid.SelectedItem != null)
            {
                profesorVM.noteBLL.AddGrade((Note)dtaGrid.SelectedItem, profesorVM.elev, profesorVM.materie);
            }
            else
            {
                MessageBox.Show("Adauga valorile");
            }
        }

        private void calculeaza_Click(object sender, RoutedEventArgs e)
        {
            txtMedie.Visibility = Visibility.Visible;

            if (profesorVM.matBLL.GetSubjectsWithTeza(profesorVM.elev).Contains(profesorVM.materie))
            {
                txtMedie.Text = profesorVM.noteBLL.GetAvgTeza((System.Collections.ObjectModel.ObservableCollection<Models.EntityLayer.Note>)dtaGrid.ItemsSource).ToString();
                if (txtMedie.Text == "0" || txtMedie.Text == null)
                {
                    MessageBox.Show("Note insuficiente");
                }
            }
            else
            {
                txtMedie.Text = profesorVM.noteBLL.GetAvrage((System.Collections.ObjectModel.ObservableCollection<Models.EntityLayer.Note>)dtaGrid.ItemsSource).ToString();
                if (txtMedie.Text == "0" || txtMedie.Text == null)
                {
                    MessageBox.Show("Note insuficiente");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dtsABSGrid.SelectedItem != null)
            {
                profesorVM.absBLL.AddAbsente((Absente)dtsABSGrid.SelectedItem, profesorVM.elev, profesorVM.materie);
            }
            else
            {
                MessageBox.Show("Adauga valorile");
            }
        }

        private void sterge_Click(object sender, RoutedEventArgs e)
        {
            if (dtaGrid.SelectedItem != null)
            {
                profesorVM.noteBLL.DeleteGrade((Note)dtaGrid.SelectedItem);
                dtaGrid.ItemsSource = profesorVM.noteBLL.GetGrades(profesorVM.elev, profesorVM.materie);
            }
            else
            {
                MessageBox.Show("Selecteaza nota");
            }


        }

        private void sterge_Click_1(object sender, RoutedEventArgs e)
        {
            if (dtsABSGrid.SelectedItem != null)
            {
                profesorVM.absBLL.DeleteAbs((Absente)dtsABSGrid.SelectedItem);
                dtsABSGrid.ItemsSource = profesorVM.absBLL.GetAbs(profesorVM.elev, profesorVM.materie);
            }
            else
            {
                MessageBox.Show("Selecteaza absenta");
            }
        }

        private void Diriginte_Click(object sender, RoutedEventArgs e)
        {
            Diriginte WDiriginte = new Diriginte();
            WDiriginte.Show();
            Close();
        }
    }
}
