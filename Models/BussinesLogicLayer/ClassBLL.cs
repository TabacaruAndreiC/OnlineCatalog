using Platforma_Educationala.Models.DataAccescLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class ClassBLL
    {
        public ObservableCollection<Class> ClassesList { get; set; }
        ClassesDAL classDAL = new ClassesDAL();

        public ClassBLL()
        {
            ClassesList = new ObservableCollection<Class>();
        }

        public ObservableCollection<Class> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }
        public Class GetClass(Elev elev)
        {
            return classDAL.GetClass(elev);
        }
        public ObservableCollection<Class> GetClassForProfesor(Profesor profesor)
        {
            return classDAL.GetClassForProfesor(profesor);
        }
        public Class GetClassFromList(ObservableCollection<Class> clase, string denumire)
        {
            foreach (var item in clase)
            {
                if (item.Denumire == denumire)
                    return item;
            }
            return null;
        }

        public Class GetClassForDiriginte(Profesor profesor)
        {
            return classDAL.GetClassForDiriginte(profesor);
        }
    }
}
