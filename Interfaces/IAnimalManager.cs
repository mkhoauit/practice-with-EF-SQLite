using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Interfaces
{
    interface IAnimalManager
    {
        void Add(IAnimal animal);
        void RemoveAnimal(int id);
        void UpdateAnimal(int id, IAnimal animal, string name ,int typeid);
        IAnimal Find(int id);
        IAnimal FindName(string name);
        ITypeAnimal FindType(int id);
        
        void AddFood(IFood food);
        void RemoveFood(int id);
        void UpdateFood(int id, IFood food,string foodname ,int numberofcans);
        IFood FindFood(int id);
    }
}
