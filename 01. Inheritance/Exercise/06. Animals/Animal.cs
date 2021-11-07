using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {

         
        public Animal(string _name, int _age, string _gender)
        {
            this.Name = _name;
            this.Age = _age;
            this.Gender = _gender;
        }


        public string Name { get; set; }

        public int  Age { get; set; }

        public string Gender { get; set; }


        public virtual string ProduceSound()
        {
            return null;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.GetType().Name);
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.Append($"{ProduceSound()}");

            return stringBuilder.ToString();
        }


    }
}
