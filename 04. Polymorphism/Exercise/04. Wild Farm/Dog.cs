using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double FOOD_INCREASER = 0.40;
        public Dog(string name, double weight, string livingRegion)
           :base(name, weight, livingRegion)
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
                throw new ArgumentException($"{nameof(Dog)} does not eat {food.GetType().Name}!");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
