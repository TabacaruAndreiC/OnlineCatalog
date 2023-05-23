using Platforma_Educationala.Models.BussinesLogicLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace School_Platform.ViewModels
{
    class DiriginteVM
    {
       
        public ProfesorBLL profesorBLL;
        public Profesor profesor;
        public ClassBLL clasaBLL;

        public Class clasa;
        public MaterieBLL materieBLL;
        public ElevBLL elevBLL;

        public Elev elev;
        public Materie materie;
        public AbsenteBLL absBLL;

        public NoteBLL noteBLL;

        public ObservableCollection<Materie> Materii;

        public DiriginteVM()
        {
           
            profesorBLL = new ProfesorBLL();
            clasaBLL = new ClassBLL();

            materieBLL = new MaterieBLL();
            elevBLL = new ElevBLL();

            clasa = new Class();
            profesor = new Profesor();
            elev = new Elev();
            materie = new Materie();
            Materii = new ObservableCollection<Materie>();
            absBLL = new AbsenteBLL();
            noteBLL = new NoteBLL();
        }

        public Dictionary<string,double> SituatieElev(Elev elev)
        {
            Dictionary<string, double> rez = new Dictionary<string, double>();
            ObservableCollection<Materie> teza = materieBLL.GetSubjectsWithTeza(elev);
            foreach( var item in materieBLL.GetAllSubjectsForClass(Auxiliar.myClass))
            {
                if (teza.Contains(item))
                    rez[item.Denumire] = noteBLL.GetAvgTeza(noteBLL.GetGrades(elev, item));
                else
                    rez[item.Denumire] = noteBLL.GetAvrage(noteBLL.GetGrades(elev, item));
            }
            return rez;
        }

        public double GeneralAvrage(Dictionary<string,double> situatie)
        {
            double s = 0;
            double media=0;
            foreach(var item in situatie.Values)
            {
                s = s + item;
            }
            media = s / situatie.Count;
            return media;

        }

        public IOrderedEnumerable<KeyValuePair<string, double>> Statistica(Class cls)
        {
            Dictionary<string, double> rez = new Dictionary<string, double>();

            foreach(var item in elevBLL.GetStudentFromClass(cls))
            {
                rez[item.Nume] = GeneralAvrage(SituatieElev(item));
            }
            var sorted = rez.OrderByDescending(x => x.Value);
            return sorted;

        }

        public ObservableCollection<Corigenti> Corigenti(Class cls)
        {
            ObservableCollection<Corigenti> rez = new ObservableCollection<Corigenti>();
         
         

            foreach(var item in elevBLL.GetStudentFromClass(cls))
            {
                Dictionary<string, double> situatie = SituatieElev(item); 
                foreach (var nota in situatie)
                {
                    if (nota.Value < 5)
                    {
                        Corigenti c = new Corigenti();
                        c.nume = item.Nume;
                        c.materie = nota.Key;
                        c.medie = nota.Value;
                        rez.Add(c);
                    }
                }
                

            }
            return rez;
        }
        public Dictionary<string,double> Premianti(Class cls)
        {
            
            Dictionary<string, double> rez = new Dictionary<string, double>();
            var statistica = Statistica(cls);

            int n = 0;
            foreach(var item in statistica)
            {
                if(n<3)
                {
                    rez[item.Key] = item.Value;
                    n++;
                }
                else
                {
                    break;
                }
                
            }
            return rez;
        }

        public IEnumerable<IGrouping<string,Corigenti>> Repetenti(Class cls)
        {
            var statistica = Corigenti(cls);
            ObservableCollection<Corigenti>repetenti  = new ObservableCollection<Corigenti>();
            
            
            var total = statistica.GroupBy(x => x.nume).Where(x => x.Count() >= 3);
            return total;
            
        }
        public Dictionary<string,int> Exmatriculare(Class cls)
        {
            Dictionary<string, int> rez = new Dictionary<string, int>();
            foreach(var item in elevBLL.GetStudentFromClass(cls))
            {
                int count = absBLL.GetAbsNumber(item);
                if (count > 2)
                    rez[item.Nume] = count;
            }
            return rez;
        }


    }
    
}
