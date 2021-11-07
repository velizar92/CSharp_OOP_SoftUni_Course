using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {


            string pizzaName = Console.ReadLine().Split()[1];
            string[] doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int weight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);


                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    string[] cmdArgs = command.Split().ToArray();

                    string toppingType = cmdArgs[1];
                    int toppingWeight = int.Parse(cmdArgs[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalToppingCalories():f2} Calories.");
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
