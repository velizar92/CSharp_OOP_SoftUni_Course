using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {

        private const double DEFAULT_CALORIES = 2;
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 50;


        private int weight;
        private string toppingType;


        public Topping(string _toppingType, int _weight)
        {
            this.ToppingType = _toppingType;
            this.Weight = _weight;
        }


        public string ToppingType
        {
            get { return toppingType; }

            private set
            {
                var toopingTypeLower = value.ToLower();
                if (toopingTypeLower != "meat" &&
                    toopingTypeLower != "veggies" &&
                    toopingTypeLower != "cheese" &&
                    toopingTypeLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }


        public int Weight
        {
            get
            {
                return weight;
            }

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
                }

                this.weight = value;
            }
        }


        public double GetCalories()
        {
            return DEFAULT_CALORIES * this.Weight * GetToppingModifier(ToppingType);
        }


        private double GetToppingModifier(string _modifierName)
        {
            string lowerModifierName = _modifierName.ToLower();
            if (lowerModifierName == "meat")
            {
                return 1.2;
            }

            if (lowerModifierName == "veggies")
            {
                return 0.8;
            }

            if (lowerModifierName == "cheese")
            {
                return 1.1;
            }

            return 0.9; //sauce
        }



    }
}
