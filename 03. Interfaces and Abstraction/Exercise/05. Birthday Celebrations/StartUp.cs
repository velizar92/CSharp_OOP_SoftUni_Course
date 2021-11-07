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
            IInformable inform;
            List<IInformable> informables = new List<IInformable>();
            Queue<Creature> creatures = new Queue<Creature>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputArgs[0] == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthDate = inputArgs[4];
                    DateTime dtBirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    inform = new Citizen(name, age, id, dtBirthDate);
                    informables.Add(inform);
                }
                else if (inputArgs[0] == "Robot")
                {
                    string model = inputArgs[1];
                    string id = inputArgs[2];
                    creature = new Robot(model, id);
                }
                else if (inputArgs[0] == "Pet")
                {
                    string name = inputArgs[1];
                    string birthDate = inputArgs[2];
                    DateTime dtBirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    inform = new Pet(name, dtBirthDate);
                    informables.Add(inform);
                }


                input = Console.ReadLine();
            }

            int receivedYear = int.Parse(Console.ReadLine());

            //Printing: 


            foreach (var infor in informables.Where(i => i.BirthDate.Year == receivedYear))
            {
                Console.WriteLine(infor.BirthDate.Day.ToString("00") + "/" + infor.BirthDate.Month.ToString("00") + "/" + infor.BirthDate.Year);
            }



        }
    }
}
