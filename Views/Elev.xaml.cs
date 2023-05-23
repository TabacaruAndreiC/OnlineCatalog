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
    /// Interaction logic for Elev.xaml
    /// </summary>
    public partial class Elev : Window
    {
        StudentWindowVM stW;

        public Elev()
        { 
            InitializeComponent();
            stW = new StudentWindowVM();
            var usernamelogIn = ((MainWindow)Application.Current.MainWindow).UsernameText.Text;
            stW.elev = stW.GetStudent(usernamelogIn);
            stW.materieBLL.MateriiList = stW.materieBLL.GetSubjectsForStudent(stW.elev);
            stW.SubjectsList = stW.GetSubjectList(stW.elev);

            foreach (var item in stW.SubjectsList)
            {
                cbMaterie.Items.Add(item.Denumire);
            }

        }

        private void afiseaza_Click(object sender, RoutedEventArgs e)
        {

            if (cbMaterie.SelectedItem != null)
            {
                stW.materie = stW.materieBLL.GetMaterie(stW.materieBLL.MateriiList, cbMaterie.SelectedItem.ToString());
                dtaGrid.ItemsSource = stW.noteBLL.GetGrades(stW.elev, stW.materie);
                dtsABSGrid.ItemsSource = stW.absBLL.GetAbs(stW.elev, stW.materie);


                if (stW.materieBLL.GetSubjectsWithTeza(stW.elev).Contains(stW.materie))
                {
                    txtMedie.Text = stW.noteBLL.GetAvgTeza((System.Collections.ObjectModel.ObservableCollection<Models.EntityLayer.Note>)dtaGrid.ItemsSource).ToString();
                    if (txtMedie.Text == "0")
                    {
                        MessageBox.Show("Note insuficiente");
                    }
                }
                else
                {
                    txtMedie.Text = stW.noteBLL.GetAvrage((System.Collections.ObjectModel.ObservableCollection<Models.EntityLayer.Note>)dtaGrid.ItemsSource).ToString();
                    if (txtMedie.Text == "0")
                    {
                        MessageBox.Show("Note insuficiente");
                    }
                }
                txtAVG.Text = stW.GetGeneralAvrage(stW.elev).ToString();

            }
            else
            {
                MessageBox.Show("Selecteaza Materia");
            }

        }

    }
}
