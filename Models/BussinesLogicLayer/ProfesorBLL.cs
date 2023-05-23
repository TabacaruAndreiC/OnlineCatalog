using Platforma_Educationala.Models.DataAccescLayer;
using Platforma_Educationala.Models.DataAccesLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Platforma_Educationala.Models.BussinesLogicLayer
{
    class ProfesorBLL
    {
        ProfesorDAL profesorDAL;
        UserDAL userDAL;
        public ProfesorBLL()
        {
            profesorDAL = new ProfesorDAL();

        }

        public EntityLayer.Profesor GetProfesorByUsername(string username)
        {
            return profesorDAL.GetProfesorByUsername(username);
        }
        public void AddProfesor(string cnp,string nume)
        {
            userDAL.AddProfesor(cnp, nume);
        }

        public Profesor GetDiriginteByUsername(string username)
        {
            return profesorDAL.GetDiriginteByUsername(username);
        }

    }
}
