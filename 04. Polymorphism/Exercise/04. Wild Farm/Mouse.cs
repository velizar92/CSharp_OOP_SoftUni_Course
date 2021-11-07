using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {

        private const double FOOD_INCREASER = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
        {

        }

        public override void Eat(Food food, int foodQuantity)
        {
            if(food is Vegetable || food is Fruit)
            {
                Weight += FOOD_INCREASER * foodQuantity;
                FoodEaten += foodQuantity;
            }
            else
            {
                throw new ArgumentException($"{nameof(Mouse)} does not eat {food.GetType().Name}!");
            }
            
        }


        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
