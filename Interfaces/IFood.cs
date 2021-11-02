using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Interfaces
{
    interface IFood
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int NumberofCans { get; set; }
        public int AnimalId { get; set; }

        
    }
}
