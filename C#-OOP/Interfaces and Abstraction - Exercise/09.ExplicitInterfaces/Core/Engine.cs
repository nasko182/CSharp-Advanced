using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Core
{
    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            ICollection<Citizen> citizens = new List<Citizen>();
            string command;
            while ((command=reader.ReadLine())!="End")
            {
                string[] cmdArgs = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;
                writer.WriteLine(person.GetName());
                writer.WriteLine(resident.GetName());
            }
        }
    }
}
