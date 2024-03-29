﻿using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {

        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;


        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            //"Added {drink name} ({drink brand}) to the drink menu"
            if (type == nameof(Tea))
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            else if (type == nameof(Water))
            {
                drinks.Add(new Water(name, portion, brand));
            }

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            //"Added {baked food name} ({baked food type}) to the menu" 
            if (type == nameof(Bread))
            {
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type == nameof(Cake))
            {
                bakedFoods.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            //"Added table number {table number} in the bakery"
            if (type == nameof(InsideTable))
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == nameof(OutsideTable))
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            //Finds all not reserved tables and for each table returns the table info.
            StringBuilder stringBuilder = new StringBuilder();
            var notReservedTables = tables.Where(t => t.IsReserved == false);

            foreach (var table in notReservedTables)
            {
                stringBuilder.AppendLine(table.GetFreeTableInfo());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var currentBill = table.GetBill() + (table.PricePerPerson * table.NumberOfPeople);
            totalIncome += currentBill;
            table.Clear();

            return $"Table: {tableNumber}\r\n" +
                    $"Bill: {currentBill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(f => f.Name == drinkName && f.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";

        }

        public string ReserveTable(int numberOfPeople)
        {

            var freeTable = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            freeTable.Reserve(numberOfPeople);

            return $"Table {freeTable.TableNumber} has been reserved for {numberOfPeople} people";


        }
    }
}
