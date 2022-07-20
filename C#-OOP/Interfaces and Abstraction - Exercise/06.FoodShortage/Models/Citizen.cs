using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : ICitizen, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private int food;
        private string birthdate;

        public Citizen(string name, int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
            this.food = 0;

        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                this.name = value;
            }

        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set { this.age = value; }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            protected set { this.id = value; }
        }

        public int Food
        {
            get
            {
                return this.food;
            }
            private set { this.food = value; }
        }

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            private set { this.birthdate = value; }
        }

        

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
