using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
        
            while (true)
            {

                string input = Console.ReadLine();
                
                if (input == "Beast!")
                {
                    break;
                }

                string[] mainInfoArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string name = mainInfoArgs[0];
                int age = int.Parse(mainInfoArgs[1]);
                string gender = mainInfoArgs[2];

                //Validation:
                if(String.IsNullOrEmpty(name) || age < 0 || String.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");                  
                    continue;
                }

                if (input == "Cat")
                {                                   
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }

                else if (input == "Dog")
                {                
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }

                else if (input == "Frog")
                {                
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }

                //They ignore 'gender' because they have default such
                else if (input == "Kitten")
                {
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }

                else if (input == "Tomcat")
                {
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }

             
            }

            //Printing:

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }


        }
    }
}
