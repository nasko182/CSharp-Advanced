using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int Age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = Age;
        }
        public string FirstName { get => firstName; private set => firstName = value; }

        public string LastName { get => lastName; private set => lastName = value; }

        public int Age { get => age; private set => age = value; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
