using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> reserveTeam;
        private List<Person> firstTeam;

        public Team(string name)
        {
           this.Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get => firstTeam; 
            private set
            {
                    firstTeam = (List<Person>)value;
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => reserveTeam; 
            private set
            {
                reserveTeam = (List<Person>)value;
            }
        }

        public string Name { get => name; set => name = value; }


        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
