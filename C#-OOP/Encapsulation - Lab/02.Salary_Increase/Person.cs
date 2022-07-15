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

        public Person(string firstName, string lastName, int Age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = Age;
            this.Salary = salary;
        }
        public string FirstName { get => firstName; private set => firstName = value; }

        public string LastName { get => lastName; private set => lastName = value; }

        public int Age { get => age; private set => age = value; }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal procentage)
        {
            if (this.Age<30)
            {
                this.Salary += (this.Salary*(procentage/100)/2);
            }
            else
            {
                this.Salary += this.Salary * (procentage / 100);
            }
        }
    }
}
