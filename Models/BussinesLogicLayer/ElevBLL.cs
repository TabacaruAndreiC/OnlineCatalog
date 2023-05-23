using Platforma_Educationala.Models.DataAccescLayer;
using Platforma_Educationala.Models.DataAccesLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class ElevBLL
    {

       public  Elev elev;
       private ElevDAL elevDAL;
       private UserDAL userDAL;
        public ElevBLL ()
        {
            elev= new Elev();
            elevDAL = new ElevDAL();
        }

        public Elev GetStudentByUsername(string username)
        {
            return elevDAL.GetStudentByUsername(username);
        }
        public Elev GetStudentByName(string name)
        {
            return elevDAL.GetStudentByName(name);
        }
        public ObservableCollection<Elev> GetStudentFromClass(Class cls)
        {
            return elevDAL.GetStudentFromClass(cls);
        }
        public void AddElev(string nume,string clasa)
        {
            userDAL.AddElev(nume, clasa);
        }
    }
}
