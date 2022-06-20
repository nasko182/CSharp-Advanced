using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                string town = cmdArgs[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());
            var currentPerson = people[n-1];
            int mathes = 0;
            int different = 0;
            foreach (Person person in people)
            {
                if (person.CompareTo(currentPerson)==0)
                {
                    mathes++;
                }
                else
                {
                    different++;
                }
            }

            if (mathes!=1)
            {
                Console.WriteLine($"{mathes} {different} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}
