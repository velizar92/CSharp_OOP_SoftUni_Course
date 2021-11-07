using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {


        public Person(string _firstName, string _lastName, int _age, decimal _salary)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Age = _age;
            this.Salary = _salary;
        }


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }



        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary = this.Salary + this.Salary * percentage / 100;
            }
            else
            {
                this.Salary = this.Salary + this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }


    }
}
