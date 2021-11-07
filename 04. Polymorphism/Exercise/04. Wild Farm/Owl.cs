using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double FOOD_INCREASER = 0.25;
        public Owl(string name, double weight, double wingSize)
           : base(name, weight, wingSize)
        {

        }

        public override void Eat(Food food, int foodQuantity)
        {
            if (food is Meat)
            {
                Weight += FOOD_INCREASER * foodQuantity;
                FoodEaten += foodQuantity;
            }
            else
            {
                throw new ArgumentException($"{nameof(Owl)} does not eat {food.GetType().Name}!");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
