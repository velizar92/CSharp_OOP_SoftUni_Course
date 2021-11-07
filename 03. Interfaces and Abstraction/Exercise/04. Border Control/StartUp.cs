using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Creature creature;
            Queue<Creature> creatures = new Queue<Creature>();

            string input = Console.ReadLine();

            while(input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    creature = new Citizen(name, age, id);
                    creatures.Enqueue(creature);
                }
                else if(inputArgs.Length == 2)
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];
                    creature = new Robot(model, id);
                    creatures.Enqueue(creature);
                }


                input = Console.ReadLine();
            }

            string lastFakeIdNumbers = Console.ReadLine();
            //Printing:

            foreach(var creatureObj in creatures.Where(cr => cr.Id.EndsWith(lastFakeIdNumbers)))
            {
                Console.WriteLine(creatureObj.Id);
            }

        }
    }
}
