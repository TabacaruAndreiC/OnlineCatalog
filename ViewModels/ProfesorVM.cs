using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace School_Platform.ViewModels
{
    class ProfesorVM
    {
        public ProfesorBLL profesorBLL;
        public ClassBLL clasaBLL;
        public Profesor profesor;
        public Class cls;
        public MaterieBLL matBLL;
        public ElevBLL elevBLL;
        public NoteBLL noteBLL;
        public AbsenteBLL absBLL;

        public Materie materie;
        public Elev elev;

        public ObservableCollection<Class> ClassList;
        public ObservableCollection<Materie> MateriiList;
        public ObservableCollection<Note> GradesList;
        public ProfesorVM()
        {

            profesorBLL = new ProfesorBLL();
            clasaBLL = new ClassBLL();
            matBLL = new MaterieBLL();


            ClassList = new ObservableCollection<Class>();
            MateriiList = new ObservableCollection<Materie>();
            GradesList = new ObservableCollection<Note>();

            cls = new Class();
            profesor = new Profesor();
            elevBLL = new ElevBLL();
            materie = new Materie();
            elev = new Elev();
            noteBLL = new NoteBLL();
            absBLL = new AbsenteBLL();
        }

        public ObservableCollection<Class> GetClasa(Profesor profesor)
        {
            return clasaBLL.GetClassForProfesor(profesor);
        }
        public ObservableCollection<Materie> GetSubjects(Class cls, Profesor p)
        {
            return matBLL.GetSubjectsForClass(cls,p);
        }

    }
}
