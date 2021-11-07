using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                return;
            }
          

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(pr => pr.Name == productName);

                try
                {
                    if (person != null && product != null)
                    {
                        person.AddProduct(product);

                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }
                catch (InvalidOperationException iex)
                {
                    Console.WriteLine(iex.Message);
                }      
            }


            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }


        static List<Person> ReadPeople()
        {
            List<string> parts = new List<string>();
            string line = Console.ReadLine();
            List<Person> people = new List<Person>();
            if (line.Contains(';'))
            {
                parts = line
               .Split(';', StringSplitOptions.RemoveEmptyEntries)
               .ToList();
            }
            else
            {
                parts.Add(line);
            }

            foreach (string part in parts)
            {
                string[] partArgs = part
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = partArgs[0];
                decimal money = decimal.Parse(partArgs[1]);
                Person person = new Person(personName, money);
                people.Add(person);
            }
        

            return people;
        }


    static List<Product> ReadProducts()
    {
        List<string> parts = new List<string>();
        string line = Console.ReadLine();
            List<Product> products = new List<Product>();

        if (line.Contains(';'))
        {
            parts = line
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
        }
        else
        {
            parts.Add(line);
        }


        foreach (string part in parts)
        {
            string[] partArgs = part
                .Split('=', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string productName = partArgs[0];
            decimal cost = decimal.Parse(partArgs[1]);
            Product product = new Product(productName, cost);
            products.Add(product);
        }

        return products;

    }

}
}
