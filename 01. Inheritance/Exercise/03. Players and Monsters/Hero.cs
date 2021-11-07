using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {

        public Hero(string _userName, int _level)
        {
            this.Username = _userName;
            this.Level = _level;
        }

        public string Username { get; set; }
        public int Level { get; set; }


        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
