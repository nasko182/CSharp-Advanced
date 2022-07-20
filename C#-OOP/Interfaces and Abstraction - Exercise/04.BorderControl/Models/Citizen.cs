using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen :Inhabiters, ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name,int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
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

        public override string ID
        {
            get
            {
                return this.id;
            }
            protected set { this.id = value; }
        }

    }
}
