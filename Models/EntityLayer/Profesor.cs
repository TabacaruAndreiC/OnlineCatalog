﻿using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platforma_Educationala.Models.EntityLayer
{
    class Profesor:BasePropertyChanged
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("ID_profesor");

            }
        }
        private string nume;
        public string Nume
        {
            get
            {
                return nume;

            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");


            }
        }
        



    }
}
