using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {

        private string name;
        private decimal money;
        private List<Product> bagOfProducts;


        public Person(string _name, decimal _money)
        {
            this.Name = _name;
            this.Money = _money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public decimal Money
        {
            get { return this.money; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }
            }
        }

        
        public void AddProduct(Product product)
        {
            if(product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Cost;
            }
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - " + string.Join(", ", this.bagOfProducts);   
            }          
        }

    }
}
