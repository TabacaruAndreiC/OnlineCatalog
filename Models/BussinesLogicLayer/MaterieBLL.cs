using Platforma_Educationala.Models.EntityLayer;
using Platforma_Educationala.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class MaterieBLL
    {
        public  ObservableCollection<Materie> MateriiList { get; set; }

        MaterieDAL materieDAL = new MaterieDAL();

        public MaterieBLL()
        {
            MateriiList = new ObservableCollection<Materie>();
            
        }

        public ObservableCollection<Materie> GetSubjectsForStudent(Elev elev)
        {
           
            return materieDAL.GetSubjectsForStudent( elev);
            
        }
        public ObservableCollection<Materie> GetSubjectsWithTeza(Elev elev)
        {
            return materieDAL.GetSubjectsWithTeza(elev);
        }
        public Materie GetMaterie(ObservableCollection<Materie> materii,string denumire)
        {
            foreach(var item in materii)
            {
                if (item.Denumire == denumire)
                    return item;
            }
            return null;
        }
        public ObservableCollection<Materie> GetSubjectsForClass(Class cls, Profesor p)
        {
            return materieDAL.GetSubjectForClass(cls,p);
        }

        public ObservableCollection<Materie> GetAllSubjectsForClass(Class cls)
        {
            return materieDAL.GetAllSubjectsForClass(cls);
        }
    }
}
