using Animal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Classes
{
    public class Animal : IAnimal

    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
       
        public List<Food> Foods { get; set; } = new List<Food>();
    }
}
