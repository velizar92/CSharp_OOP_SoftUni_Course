using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {


        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string _firstName, string _lastName, int _age, decimal _salary)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Age = _age;
            this.Salary = _salary;
        }


        public string FirstName
        {
            get { return firstName; }

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }

            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value;
            }
        }


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
