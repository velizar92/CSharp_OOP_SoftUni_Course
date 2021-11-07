using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Citizen : Creature, IInformable, IBuyer
    {
       
        public Citizen(string _name, int _age, string _id, DateTime _birtDate)
            :base(_id)
        {
            this.Name = _name;
            this.Age = _age;
            this.Id = _id;
            this.BirthDate = _birtDate; 
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
