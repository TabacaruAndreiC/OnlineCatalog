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
    class UsersBLL
    {
        public ObservableCollection<Users> UsersList { get; set; }
        UserDAL usersDAL = new UserDAL();

        public UsersBLL()
        {
            UsersList = new ObservableCollection<Users>();
        }

        public ObservableCollection<Users> GetAllUsers()
        {
            return usersDAL.GetAllUsers();
        }

        public void AddUser(string username, string password)
        {
            usersDAL.AddUser(username, password);
        }

        public void AddElev(string nume, string clasa)
        {
            usersDAL.AddElev(nume, clasa);
        }

        public void AddProfesor(string nume, string clasa)
        {
            usersDAL.AddProfesor(nume, clasa);
        }

        public void AddDiriginte(string nume, string clasa)
        {
            usersDAL.AddDiriginte(nume, clasa);
        }

        public int GetUserIDByUsername(string username)
        {
            return usersDAL.GetUserIDByUsername(username);
        }

        public void ModifyUser(string username, string password, int id, string nume, string clasa, string tip)
        {
            usersDAL.ModifyUser(username, password, id, nume, clasa, tip);
        }

        public void DeleteUser(int id)
        {
            usersDAL.DeleteUser(id);
        }

        public Users GetUserById(int id)
        {
            return usersDAL.GetUserById(id);
        }
    }
}
