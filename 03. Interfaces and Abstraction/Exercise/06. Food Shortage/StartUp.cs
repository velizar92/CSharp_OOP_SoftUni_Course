using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<IBuyer> buyers = new Queue<IBuyer>();
            IBuyer buyer = null;
            int totalFood = 0;
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray(); ;

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                if (inputArgs.Length == 3)
                {
                    string group = inputArgs[2];
                    buyer = new Rebel(name, age, group);                   
                }

                else if (inputArgs.Length == 4)
                {
                    string id = inputArgs[2];
                    string birthDate = inputArgs[3];
                    DateTime dtBirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                    buyer = new Citizen(name, age, id, dtBirthDate);                   
                }

                if (buyers.FirstOrDefault(b => b.Name == name) == null)
                {
                    buyers.Enqueue(buyer);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var bayerObj = buyers.FirstOrDefault(b => b.Name == command);
                if (bayerObj != null)
                {
                    bayerObj.BuyFood();

                    if (bayerObj is Citizen)
                    {
                        totalFood += 10;
                    }
                    else
                    {
                        totalFood += 5;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(totalFood);

        }
    }
}
