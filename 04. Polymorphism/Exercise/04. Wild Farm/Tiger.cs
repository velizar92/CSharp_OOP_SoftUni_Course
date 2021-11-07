using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double FOOD_INCREASER = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            :base(name, weight,livingRegion, breed)
        {

        }

        public override void Eat(Food food, int foodQuantity)
        {
            if(food is Meat)
            {
                Weight += FOOD_INCREASER * foodQuantity;
                FoodEaten += foodQuantity;
            }
            else
            {
                throw new ArgumentException($"{nameof(Tiger)} does not eat {food.GetType().Name}!");
            }
        }


        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
