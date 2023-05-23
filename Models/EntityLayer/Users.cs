using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.Models.EntityLayer
{
    class Users : BasePropertyChanged
    {
        private int id;
        private string username;
        private string password;
        public int ID { get { return id; } set { id = value; NotifyPropertyChanged("ID"); } }
        public string Username { get { return username; } set { username = value; NotifyPropertyChanged("Username"); } }
        public string Password { get { return password; } set { password = value; NotifyPropertyChanged("Password"); } }
    }
}
