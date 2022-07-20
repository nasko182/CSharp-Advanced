using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Rebel : IRebel,IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = food;
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

        public string Group
        {
            get
            {
                return this.group;
            }
            private set { this.group = value; }
        }

        public int Food
        {
            get
            {
                return this.food;
            }
            private set { this.food = value; }
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
