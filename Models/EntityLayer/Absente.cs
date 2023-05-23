using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platforma_Educationala.Models.EntityLayer
{
    class Absente:BasePropertyChanged
    {
        private int? abs_crt;

        public int? Abs_Crt
        {
            get
            {
                return abs_crt;
            }
            set
            {
                abs_crt = value;
                NotifyPropertyChanged("Abs_Crt");
            }
        }
        private string tip;
        public string Tip
        {
            get
            {
                return tip;
            }
            set
            {
                tip = value;
                NotifyPropertyChanged("Tip");
            }
        }
        private DateTime data;

        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                NotifyPropertyChanged("Data");
            }
        }

       
    }
}

