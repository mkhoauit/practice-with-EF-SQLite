using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Interfaces
{
    /// <summary>
    /// IAnimal has 3 method and 4 properties 
    /// </summary>
    interface IAnimal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        
       
        
    }
}
