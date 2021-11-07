using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {

        public Citizen(string _name, int _age, string _id, string _birthDate)
        {
            this.Name = _name;
            this.Age = _age;
            this.Id = _id;
            this.Birthdate = _birthDate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
