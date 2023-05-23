using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platforma_Educationala.Models.EntityLayer
{
    class Materie:BasePropertyChanged
    {
        private int? materieId;
        public int? MaterieId
        {
            get
            {
                return materieId;
            }
            set
            {
                materieId = value;
                NotifyPropertyChanged("MaterieId");
            }
        }

        private string denumire;

        public string Denumire
        {
            get
            {
                return denumire;
            }
            set
            {
                denumire = value;
                NotifyPropertyChanged("Denumire");
            }
        }

    }
}
