using Animal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;




namespace Animal.Classes
{
    class Program
    {
        public static void Main()
        {
            using (var context = new AnimalContext())
            {
                //Data Seeding
                context.Database.EnsureCreated();

                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {context.DbPath}.");

                // table type
                //type Dog
                var typeAnimal1 = context.Types.FirstOrDefault(t => t.Type == "Dog");
                if (typeAnimal1 != null)
                {
                    Console.WriteLine("Exsiting type of animal : Dog !");
                }
                else
                {
                    typeAnimal1 = new TypeAnimal
                    {
                        TypeId = 1,
                        Type = "Dog",
                        Speak = "Woof Woof",
                        Age = 3
                    };
                    context.Types.Add(typeAnimal1);
                }
                //type cat
                var typeAnimal2 = context.Types.FirstOrDefault(t => t.Type == "Cat");
                if (typeAnimal2 != null)
                {
                    Console.WriteLine("Exsiting type of animal : Cat !");
                }
                else
                {
                    typeAnimal2 = new TypeAnimal
                    {
                        TypeId = 2,
                        Type = "Cat",
                        Speak = "Meow meow",
                        Age = 2
                    };
                    context.Types.Add(typeAnimal2);
                }
                //type bird
                var typeAnimal3 = context.Types.FirstOrDefault(t => t.Type == "Bird");
                if (typeAnimal3 != null)
                {
                    Console.WriteLine("Exsiting type of animal : Bird !");
                }
                else
                {
                    typeAnimal3 = new TypeAnimal
                    {
                        TypeId = 3,
                        Type = "Bird",
                        Speak = "Cheap Cheap",
                        Age = 1
                    };
                    context.Types.Add(typeAnimal3);
                }
                //type snake
                var typeAnimal4 = context.Types.FirstOrDefault(t => t.Type == "Snake");
                if (typeAnimal4 != null)
                {
                    Console.WriteLine("Exsiting type of animal : Snake !");
                }
                else
                {
                    typeAnimal4 = new TypeAnimal
                    {
                        TypeId = 4,
                        Type = "Snake",
                        Speak = "SSSSSSSS",
                        Age = 5
                    };
                    context.Types.Add(typeAnimal4);
                }
                //table animal & food
                //animal Popy (Dog)
                var testAnimal1 = context.Animals.FirstOrDefault(b => b.Name == "Popy");
                if (testAnimal1 != null)
                {
                    Console.WriteLine($"Existing Animal Popy !!");
                }
                else
                {
                    testAnimal1 = new Animal
                    {
                        AnimalId = 1,
                        Name = "Popy",
                        TypeId = 1,
                        Foods = new List<Food>
                    {
                      new Food { FoodId = 1 , FoodName="Meat",NumberofCans=3,AnimalId=1},
                      new Food { FoodId = 2 , FoodName="DogFood",NumberofCans=10,AnimalId=1}

                    }
                    };

                    context.Animals.Add(testAnimal1);
                }
                //animal meo (Cat)
                var testAnimal2 = context.Animals.FirstOrDefault(b => b.Name == "Meo");
                if (testAnimal2 != null)
                {
                    Console.WriteLine($"Existing Animal Meo !!");
                }
                else
                {
                    testAnimal2 = new Animal
                    {
                        AnimalId = 2,
                        Name = "Meo",
                        TypeId = 2,
                        Foods = new List<Food>
                    {
                      new Food { FoodId = 3 , FoodName="Fish",NumberofCans=4,AnimalId=2},
                      new Food { FoodId = 4 , FoodName="CatFood",NumberofCans=9,AnimalId=2}

                    }
                    };

                    context.Animals.Add(testAnimal2);
                }
                //animal Snow (Bird)
                var testAnimal3 = context.Animals.FirstOrDefault(b => b.Name == "Snow");
                if (testAnimal3 != null)
                {
                    Console.WriteLine($"Existing Animal Snow !!");
                }
                else
                {
                    testAnimal3 = new Animal
                    {
                        AnimalId = 3,
                        Name = "Snow",
                        TypeId = 3,
                        Foods = new List<Food>
                    {
                      new Food { FoodId = 5 , FoodName="Vegetable",NumberofCans=1,AnimalId=3},
                      new Food { FoodId = 6 , FoodName="BirdFood",NumberofCans=20,AnimalId=3}

                    }
                    };

                    context.Animals.Add(testAnimal3);
                }
                //animal Strike (Snake)
                var testAnimal4 = context.Animals.FirstOrDefault(b => b.Name == "Strike");
                if (testAnimal4 != null)
                {
                    Console.WriteLine($"Existing Animal Strike !!");
                }
                else
                {
                    testAnimal4 = new Animal
                    {
                        AnimalId = 4,
                        Name = "Strike",
                        TypeId = 4,
                        Foods = new List<Food>
                    {
                      new Food { FoodId = 7 , FoodName="Mouse",NumberofCans=5,AnimalId=4},
                      new Food { FoodId = 8 , FoodName="SnakeFood",NumberofCans=20,AnimalId=4}

                    }
                    };

                    context.Animals.Add(testAnimal4);
                }
                context.SaveChanges();
            }
            //main
            using (var db = new AnimalContext())
            {
                Console.WriteLine();
                //main

                var AnimalManager = new AnimalManager(db);
                uint n;
                Console.WriteLine("Select a number:");
                Console.WriteLine("1:Add an Animal");
                Console.WriteLine("2:Remove an Animal");
                Console.WriteLine("3:Find an Animal");
                Console.WriteLine("4:Update an Animal");
                Console.WriteLine("5:Add a Food");//2 choice
                Console.WriteLine("6:Remove a Food");
                Console.WriteLine("7:Find a Food");
                Console.WriteLine("8:Update a Food");
                
                n = Convert.ToUInt32(Console.ReadLine());

                switch(n)
                {
                    case 1://add an animal
                        Console.WriteLine("Input your animal's name");
                        string name = Convert.ToString(Console.ReadLine());
                        AnimalManager.Add(new Animal() { Name=name});
                        break;

                    case 2://remove an animal
                        Console.WriteLine("Input id of your animal to remove:");
                        int remove = Convert.ToInt32(Console.ReadLine());
                        AnimalManager.RemoveAnimal(id:remove);
                        break;

                    case 3://find an animal
                        Console.WriteLine("Input id of your animal to find:");
                        int find = Convert.ToInt32(Console.ReadLine());
                        var findA =AnimalManager.Find(id: find);
                        var findT = AnimalManager.FindType(id: findA.TypeId);
                        Console.WriteLine($"Your animal id:{findA.AnimalId}, name:{findA.Name}, type:{findT.Type}");
                        break;

                    case 4://update an animal
                        Console.WriteLine("Input id of your animal:");
                        int update = Convert.ToInt32(Console.ReadLine());
                        var update1 = AnimalManager.Find(id: update);
                        Console.WriteLine("Input new or old name of your animal:");
                        string update2 = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Input new id of type :");
                        int update3 = Convert.ToInt32(Console.ReadLine());
                        //update for object
                        update1.Name = update2;
                        update1.TypeId = update3;
                        //update database
                        AnimalManager.UpdateAnimal(id: update , animal: update1, name: update2,typeid: update3);
                        var findType =AnimalManager.FindType(id:update3);
                        Console.WriteLine($"Update your id {update} animal: new name {update2}, new type:{findType.Type} with id type {update3} ");
                        break;

                    case 5://add a food
                        //check for an animal, or add an animal
                        Console.WriteLine("Do you have an animal? [y/n]");
                        string animal = Convert.ToString(Console.ReadLine());
                        if (animal.StartsWith("n"))
                        {
                            //add new blog
                            Console.WriteLine("Input name of your animal to add:");
                            string animal1 = Convert.ToString(Console.ReadLine());
                            AnimalManager.Add(new Animal() { Name = animal1 });
                            //find id  new animal 
                            var f1 = AnimalManager.FindName(name: animal1);

                            //add food name and number of cans
                            Console.WriteLine("Input food name:");
                            String foodname2 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Input number of cans:");
                            int foodcans = Convert.ToInt32(Console.ReadLine());
                            int f3 = f1.AnimalId;
                            var f2 = AnimalManager.Find(id: f3);
                            //add food
                            AnimalManager.AddFood(new Food() { FoodName=foodname2,NumberofCans=foodcans,AnimalId = f2.AnimalId});

                        }
                        else
                        {
                            Console.WriteLine("Input id of your animal:");
                            int idA = Convert.ToInt32(Console.ReadLine());

                            var idA1 = AnimalManager.Find(id: idA);
                            //udate vao post neu da co blog:
                            idA1.AnimalId = idA;

                            //add food name and number of cans
                            Console.WriteLine("Input food name:");
                            String foodname1 = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Input number of cans:");
                            int foodcans = Convert.ToInt32(Console.ReadLine());
                            //add food
                            AnimalManager.AddFood(new Food() { FoodName = foodname1, NumberofCans = foodcans, AnimalId = idA1.AnimalId });

                        }
                        break;

                    case 6://remove a food
                        Console.WriteLine("Input id food to remove:");
                        int foodId = Convert.ToInt32(Console.ReadLine());
                        AnimalManager.RemoveFood(id: foodId);
                        break;
                    case 7://find food
                        Console.WriteLine("Input id food to find:");
                        int findFood = Convert.ToInt32(Console.ReadLine());
                        var findF = AnimalManager.FindFood(id: findFood);
                        var findA1 =AnimalManager.Find(id:findF.AnimalId);
                        var findT1 =AnimalManager.FindType(id:findA1.TypeId);
                        Console.WriteLine($"Your food id:{findF.FoodId}, food name:{findF.FoodName}, number of cans:{findF.NumberofCans}");
                        Console.WriteLine($"With your animal id:{findA1.AnimalId}, name:{findA1.Name}, type:{findT1.Type}");
                        break;
                    case 8://update a food
                        Console.WriteLine("Input id food to update:");
                        int foodID = Convert.ToInt32(Console.ReadLine());

                        var updateF = AnimalManager.FindFood(id: foodID);

                        Console.WriteLine("Input food name:");
                        string foodname = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Input number of cans:");
                        int foodCans = Convert.ToInt32(Console.ReadLine());

                        //update vao object
                        updateF.FoodName = foodname;
                        updateF.NumberofCans = foodCans;
                        //update database
                        AnimalManager.UpdateFood(id: updateF.FoodId, food:updateF,foodname:updateF.FoodName,numberofcans:updateF.NumberofCans);
                        break;
                }
                Console.WriteLine("Done");
                Console.WriteLine("Thank you ^^");


            }
        }
    }
}
