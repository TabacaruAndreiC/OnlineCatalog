using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.ViewModels
{
    class UserVM
    {
        public enum Users_Type
        {
            Administrator,
            Diriginte,
            Profesor,
            Elev,
            Inexistent
        }

        public UsersBLL usersBLL;

        public UserVM()
        {
            usersBLL = new UsersBLL();

        }

        public Users_Type GetUserType(string username, string password)
        {
            ObservableCollection<Users> collection = usersBLL.GetAllUsers();
            foreach (var item in collection)
            {
                if (item.Username == username && item.Password == password)
                {
                    if (item.Username.Contains("@admin"))
                        return Users_Type.Administrator;
                    if (item.Username.Contains("@elev"))
                        return Users_Type.Elev;
                    if (item.Username.Contains("@profesor"))
                        return Users_Type.Profesor;
                    if(item.Username.Contains("@diriginte"))
                        return Users_Type.Diriginte;
                }
            }
            return Users_Type.Inexistent;
        }

    }
}
