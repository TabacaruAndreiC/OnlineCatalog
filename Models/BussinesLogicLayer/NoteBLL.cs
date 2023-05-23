
using Platforma_Educationala.Models.DataAccesLayer;
using Platforma_Educationala.Models.EntityLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class NoteBLL
    {

        public ObservableCollection<Note> GradesList { get; set; }

        NotaDAL noteDAL = new NotaDAL();

        public NoteBLL ()
        {
            GradesList = new ObservableCollection<Note>();
        }

        public ObservableCollection<Note> GetGrades(Elev elev,Materie materie)
        {
            return noteDAL.GetGrades(elev, materie.Denumire);
        }
        public double GetAvrage(ObservableCollection<Note> Grades)
        {
            
            int s = 0;
            if (Grades.Count >= 3)
            {
                foreach (var item in Grades)
                {
                    s += (int)item.Nota;
                }
            }
            return s / (double)Grades.Count;

        }
        public double GetAvgTeza(ObservableCollection<Note> Grades)
        {
            int s = 0, nota_teza=0;
            double medie_fara_teza = 0;
            bool ok = false;
            
            if (Grades.Count >= 3)
            {
                foreach (var item in Grades)
                {
                    if (item.Teza == "da")
                    {
                        nota_teza = (int)item.Nota;
                        ok = true;
                    }
                    else
                    {
                        s = s + (int)item.Nota;
                    }

                }
            }
            if (ok)
            {
                medie_fara_teza = (double) s / (Grades.Count - 1);
               
            }
            return (medie_fara_teza*3+nota_teza)/ 4;


        }
        public void ModifyGrade(Note nota)
        {

            noteDAL.ModifyGrade(nota);
        }

        public void AddGrade(Note nota,Elev elev,Materie materie)
        {
            noteDAL.AddNota(nota, elev,materie);
        }

        public void DeleteGrade(Note nota)
        {
            noteDAL.DeleteNota(nota);
        }
    }
}
