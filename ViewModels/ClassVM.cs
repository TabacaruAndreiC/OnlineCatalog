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
    class ClassVM
    {
       public ClassBLL classBLL;

        public ClassVM()
        {
            classBLL = new ClassBLL();
        }

       public ObservableCollection<string> GetAllClassNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            ObservableCollection<Class> collection = classBLL.GetAllClasses();
            foreach (var item in collection)
            {
                names.Add(item.Denumire);
            }
            return names;
        }
    }
}
