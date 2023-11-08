using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr6
{
    public class FullName
    {
        public string Surname;
        public string Name;
        public string MiddleName;
        public FullName(string _Surname, string _Name, string _MiddleName)
        {
            Surname = _Surname;
            Name = _Name;
            MiddleName = _MiddleName;
        }
        public FullName()
        { }
    }
}
