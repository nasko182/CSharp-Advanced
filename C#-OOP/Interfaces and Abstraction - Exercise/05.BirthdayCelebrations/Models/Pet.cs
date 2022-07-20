using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Models.Interfaces;
namespace BorderControl.Models
{
    public class Pet : IPet
    {
        private string birthdate;
        private string name;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
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

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            private set { this.birthdate = value; }
        }
    }
}
