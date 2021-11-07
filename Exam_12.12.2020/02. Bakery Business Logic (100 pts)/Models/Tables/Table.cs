using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;          
        }


        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }      
        }


        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }



        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }    


        public decimal Price
        {
            get
            {
                return NumberOfPeople * Price;
            }
        }


        public void Clear()
        {          
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = 0.0m;
            foreach (var foodOrder in foodOrders)
            {
                bill += foodOrder.Price;
            }
            foreach (var drinkOrder in drinkOrders)
            {
                bill += drinkOrder.Price;
            }

            return bill;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {TableNumber}\r\n" + 
                    $"Type: {this.GetType().Name}\r\n" + 
                    $"Capacity: {Capacity}\r\n" + 
                    $"Price per Person: {PricePerPerson}";
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
