using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Interfaces
{
    interface ITypeAnimal
    {
        
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Speak { get; set; }
        public int Age { get; set; }

    }
}
