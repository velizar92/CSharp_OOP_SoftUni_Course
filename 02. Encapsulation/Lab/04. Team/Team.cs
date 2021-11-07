using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string _name)
        {
            this.name = _name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }


        public IReadOnlyCollection<Person> FirstTeam {

            get
            {
                return firstTeam;
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return reserveTeam;
            }
        }


        public void AddPlayer(Person _person)
        {
            if(_person.Age < 40)
            {
                this.firstTeam.Add(_person);
            }
            else
            {
                this.reserveTeam.Add(_person);
            }
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First team has {FirstTeam.Count} players.");
            stringBuilder.AppendLine($"Reserve team has {ReserveTeam.Count} players.");

            return stringBuilder.ToString();
        }




    }
}
