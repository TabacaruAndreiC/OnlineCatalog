using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace School_Platform.ViewModels
{
    class StudentWindowVM
    {
        public MaterieBLL materieBLL;
        public Materie materie;
        public ObservableCollection<Materie> SubjectsList = new ObservableCollection<Materie>();
        public ObservableCollection<String> MaterialList = new ObservableCollection<String>();

        public ElevBLL elevBLL;
        public Elev elev;
        public NoteBLL noteBLL;
        public AbsenteBLL absBLL;
        public ClassBLL calsaBLL;

        public StudentWindowVM()
        {
            materieBLL = new MaterieBLL();
            elevBLL = new ElevBLL();
            elev = new Elev();
            noteBLL = new NoteBLL();
            absBLL = new AbsenteBLL();
            materie = new Materie();
            calsaBLL = new ClassBLL();

        }
        public Elev GetStudent(string username)
        {
            return elevBLL.GetStudentByUsername(username);
        }
        public ObservableCollection<Materie> GetSubjectList(Elev elev)
        {
            return materieBLL.GetSubjectsForStudent(elev);
        }
        public double GetGeneralAvrage(Elev elev)
        {
            double media = 0;
            double s = 0;
            ObservableCollection<Materie> teza = new ObservableCollection<Materie>();

            teza = materieBLL.GetSubjectsWithTeza(elev);

            foreach( var item in materieBLL.GetSubjectsForStudent(elev))
            {
                if(teza.Contains(item))
                    s = s + noteBLL.GetAvgTeza(noteBLL.GetGrades(elev,item));
                else
                    s = s + noteBLL.GetAvrage(noteBLL.GetGrades(elev, item));
            }
            media = (double)s / materieBLL.GetSubjectsForStudent(elev).Count;
            return media;
        }  
    }
}

