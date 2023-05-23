using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.Models.EntityLayer
{
    public class Class: BasePropertyChanged
    {
        private int id;
        private string denumire;
        private string diriginte;

        public int ID { get { return id; } set { id = value; NotifyPropertyChanged("ID"); } }
        public string Denumire { get { return denumire; } set { denumire = value; NotifyPropertyChanged("Denumire"); } }
        public string Diriginte { get { return diriginte; } set { diriginte = value; NotifyPropertyChanged("Diriginte"); } }
    }
}
