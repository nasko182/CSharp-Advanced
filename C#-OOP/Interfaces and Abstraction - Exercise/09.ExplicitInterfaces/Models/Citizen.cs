using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson,IResident
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, string country,int age)
        {
            this.Name=name;
            this.Country = country;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set { this.name = value; }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            private set
            {
                this.country = value;
            }
        }


        string IPerson.GetName()
        {
            return this.Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
