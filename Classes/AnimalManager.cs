using Animal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Classes
{
  
    class AnimalManager : IAnimalManager
    {
        private AnimalContext _dbContext;
        public AnimalManager(AnimalContext dbContext) 
        {
            _dbContext = dbContext ;
        }
        public void Add(IAnimal animal)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try {
                var existingAnimal = _dbContext.Animals.SingleOrDefault(a => a.AnimalId == animal.AnimalId);
                if (existingAnimal !=null) 
                {
                    throw new Exception("Existing Animal");

                }

                _dbContext.Animals.Add(animal as Animal);
                _dbContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

            }

        }

        public void AddFood(IFood food)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var existingFood = _dbContext.Foods.SingleOrDefault(f => f.FoodId == food.FoodId);
                if (existingFood != null)
                {
                    throw new Exception("Existing Food");

                }

                _dbContext.Foods.Add(food as Food);
                _dbContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

            }

        }

        public IAnimal Find(int id)
        {
            var existingAnimal = _dbContext.Animals.SingleOrDefault(a => a.AnimalId == id);
            if (existingAnimal == null)
            {
                throw new Exception("NotExisting Animal");

            }
            return existingAnimal; 
        }

        public IFood FindFood(int id)
        {
            var existingFood = _dbContext.Foods.SingleOrDefault(f => f.FoodId == id);
            if (existingFood == null)
            {
                throw new Exception("NotExisting Food");

            }
            return existingFood;
           
        }

        public IAnimal FindName(string name)
        {
            var existingName = _dbContext.Animals.SingleOrDefault(b => b.Name == name);
            if (existingName == null)
            {
                Console.WriteLine($"NotExisting Name: {name}!!");
            }

            return existingName;

        }

        public ITypeAnimal FindType(int id)
        {
            var existingType = _dbContext.Types.SingleOrDefault(t => t.TypeId == id);
            if (existingType == null)
            {
                throw new Exception("NotExisting Type");

            }
            return existingType;
           
        }

        public void RemoveAnimal(int id)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingAnimal = _dbContext.Animals.SingleOrDefault(b => b.AnimalId == id);
                if (existingAnimal == null)
                {
                    throw new Exception("NotExisting Animal !!");

                }

                _dbContext.Animals.Remove(existingAnimal);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            
        }

        public void RemoveFood(int id)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingFood = _dbContext.Foods.SingleOrDefault(p => p.FoodId == id);
                if (existingFood == null)
                {
                    throw new Exception("NotExisting Food !!");

                }

                _dbContext.Foods.Remove(existingFood);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void UpdateAnimal(int id, IAnimal animal, string name,int typeid)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var existingAnimal = _dbContext.Animals.SingleOrDefault(a => a.AnimalId == animal.AnimalId);
                if (existingAnimal == null)
                {
                    throw new Exception("NotExisting Animal");

                }

                _dbContext.Animals.Update(animal as Animal);
                _dbContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

            }
        }

        public void UpdateFood(int id, IFood food, string foodname, int numberofcans)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var existingFood = _dbContext.Foods.SingleOrDefault(f => f.FoodId == food.FoodId);
                if (existingFood == null)
                {
                    throw new Exception("NotExisting Food");

                }

                _dbContext.Foods.Update(food as Food);
                _dbContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

            }

            
        }
    }
}
