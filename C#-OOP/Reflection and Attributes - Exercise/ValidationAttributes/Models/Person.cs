using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Utilyties;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private string fullName;
        private int age;
        private const int minAge = 12;
        private const int maxAge = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get => fullName; private set => fullName = value; }

        [MyRange(minAge,maxAge)]
        public int Age { get => age; private set => age = value; }
    }
}
