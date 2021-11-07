using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MIN_NAME_SYMBOLS = 1;
        private const int MAX_NAME_SYMBOLS = 15;


        private string name;
        private Dough dough;
        private List<Topping> toppings;


        public Pizza(string _name, Dough _dough)
        {
            this.Name = _name;
            this.dough = _dough;
            this.toppings = new List<Topping>();
        }


        public string Name
        {
            get { return name; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > MAX_NAME_SYMBOLS)
                {
                    throw new ArgumentException($"Pizza name should be between [1 and 15] symbols.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddTopping(Topping _topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(_topping);
        }


        public double GetTotalToppingCalories()
        {
            return dough.GetCalories() + toppings.Sum(t => t.GetCalories());
        }


    }
}
