using System;
using System.Collections.Generic;
using System.Text;
using Platforma_Educationala.Models.EntityLayer;



namespace Platforma_Educationala.Models.EntityLayer
{
    class Note:BasePropertyChanged
    {
        private int? nota_crt;

        public int? Nota_Crt
        {
            get
            {
                return nota_crt;
            }
            set
            {
                nota_crt = value;
                NotifyPropertyChanged("Nota_Crt");
            }
        }
        private int? nota;
        public int? Nota
        {
            get
            {
                return nota;
            }
            set
            {
                nota = value;
                NotifyPropertyChanged("Nota");
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

        private string teza;
        public string Teza
        {
            get
            {
                return teza;
            }
            set
            {
                teza = value;
                NotifyPropertyChanged("Teza");
            }
        }
    }
    
}
