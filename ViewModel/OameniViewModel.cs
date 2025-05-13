using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern.ViewModel
{
    public class OameniViewModel:ViewModelBase
    {
        public string nume { get; }

        public DateOnly data { get; }

       public OameniViewModel(string nume, DateOnly data)
        {
            this.nume = nume;
            this.data = data;
        } 
    }
}
