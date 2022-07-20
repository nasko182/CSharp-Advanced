using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            ICollection<IBirthable> birthables = new List<IBirthable>();
            string input;
            while ((input=reader.ReadLine())!="End")
            {
                string[] inputArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length==5)
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string ID = inputArgs[3];
                    string birthdate = inputArgs[4];
                    birthables.Add(new Citizen(name,age,ID, birthdate));
                }
                else if (inputArgs[0]=="Pet")
                {
                    string name = inputArgs[1];
                    string birthdate = inputArgs[2];
                    birthables.Add(new Pet(name,birthdate));
                }
            }
            string nums = reader.ReadLine();
            foreach (var inhabiter in birthables)
            {
                string year = inhabiter.Birthdate.Split('/')[2];
                if (year==nums)
                {
                    writer.WriteLine(inhabiter.Birthdate.ToString());
                }
            }
        }
    }
}
