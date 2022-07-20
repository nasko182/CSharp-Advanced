using BorderControl.Models;
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
            ICollection<Inhabiters> inhabiters = new List<Inhabiters>();
            string input;
            while ((input=reader.ReadLine())!="End")
            {
                string[] inputArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length==3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string ID = inputArgs[2];
                    inhabiters.Add(new Citizen(name,age,ID));
                }
                else
                {
                    string model = inputArgs[0];
                    string ID = inputArgs[1];
                    inhabiters.Add(new Robot(model,ID));
                }
            }
            string nums = reader.ReadLine();
            foreach (var inhabiter in inhabiters)
            {
                if (inhabiter.ID.Substring(inhabiter.ID.Length-nums.Length)==nums)
                {
                    writer.WriteLine(inhabiter.ID);
                }
            }
        }
    }
}
