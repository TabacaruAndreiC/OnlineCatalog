using Platforma_Educationala.Models.DataAccesLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class AbsenteBLL
    {
        public ObservableCollection<Absente> AbsList { get; set; }

        AbsenteDAL absenteDAL = new AbsenteDAL();

        public AbsenteBLL()
        {
            AbsList = new ObservableCollection<Absente>();
        }

        public ObservableCollection<Absente> GetAbs(Elev elev, Materie materie)
        {
            return absenteDAL.GetAbs(elev, materie);
        }

        public void AddAbsente(Absente absente, Elev elev, Materie materie)
        {
            absenteDAL.AddAbsente(absente, elev, materie);
        }

        public void DeleteAbs(Absente abs)
        {
            absenteDAL.DeleteAbs(abs);
        }
        public int GetAbsNumber(Elev elev)
        {
            return absenteDAL.GetAbsNumber(elev);
        }
    }
}
