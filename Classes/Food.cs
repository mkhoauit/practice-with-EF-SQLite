using Animal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Classes
{
    public class Food : IFood
    {
        public int FoodId { get; set; }
        public string FoodName { get; set;}
        public int NumberofCans { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
