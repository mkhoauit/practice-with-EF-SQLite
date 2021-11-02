using Animal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Classes
{
    public class TypeAnimal : ITypeAnimal
    {
        [Key]
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Speak { get; set; }
        public int Age { get; set; }
    }
}
