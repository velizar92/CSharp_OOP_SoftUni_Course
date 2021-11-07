using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            int lineNumber = 0;
            Queue<Animal> animals = new Queue<Animal>();
            Animal animal = null;

            while (command != "End")
            {
                string[] cmdArgs = command.Split().ToArray();
               
                Food food = null; 

                //-------------------Animal part:------------------

                if(lineNumber == 0)
                {
                   
                    string animlaType = cmdArgs[0];
                    string name = cmdArgs[1];
                    double weight = double.Parse(cmdArgs[2]);

                    if (animlaType == nameof(Cat)) 
                    {               
                        string livingRegion = cmdArgs[3];
                        string breed = cmdArgs[4];
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    if(animlaType == nameof(Tiger))
                    {
                        string livingRegion = cmdArgs[3];
                        string breed = cmdArgs[4];
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }


                    if(animlaType == nameof(Owl))
                    {
                        double wingSize = double.Parse(cmdArgs[3]);
                        animal = new Owl(name, weight, wingSize);
                    }
                    if (animlaType == nameof(Hen))
                    {
                        double wingSize = double.Parse(cmdArgs[3]);
                        animal = new Hen(name, weight, wingSize);
                    }


                    if (animlaType == nameof(Mouse)) 
                    {
                        string livingRegion = cmdArgs[3];
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    if(animlaType == nameof(Dog))
                    {
                        string livingRegion = cmdArgs[3];
                        animal = new Dog(name, weight, livingRegion);
                    }

                    animals.Enqueue(animal);
                    lineNumber++;
                }

                //-------------------Food part:------------------
                else
                {
                    string foodType = cmdArgs[0];
                    int foodQuantity = int.Parse(cmdArgs[1]);

                    if (foodType == nameof(Vegetable))
                    {
                        food = new Vegetable(foodQuantity);
                    }
                    if (foodType == nameof(Meat))
                    {
                        food = new Meat(foodQuantity);
                    }
                    if (foodType == nameof(Fruit))
                    {
                        food = new Fruit(foodQuantity);
                    }
                    if (foodType == nameof(Seeds))
                    {
                        food = new Seeds(foodQuantity);
                    }

                    try
                    {
                        //Actions:
                        animal.MakeSound();
                        animal.Eat(food, foodQuantity);
                    }
                    catch (ArgumentException aex)
                    {
                        Console.WriteLine(aex.Message.ToString());
                    }
                    
                   
                                 
                    lineNumber = 0;
                }
                             
                command = Console.ReadLine();
                
            }

            //Printing:
            foreach(var animalType in animals)
            {
                Console.WriteLine(animalType);
            }





        }
    }
}
