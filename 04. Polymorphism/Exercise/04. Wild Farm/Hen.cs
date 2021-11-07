using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double FOOD_INCREASER = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override void Eat(Food food, int foodQuantity)
        {
            Weight += FOOD_INCREASER * foodQuantity;
            FoodEaten += foodQuantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
