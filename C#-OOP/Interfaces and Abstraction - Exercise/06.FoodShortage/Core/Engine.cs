using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ICollection<IBuyer> buyerList = new List<IBuyer>();
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = reader.ReadLine().Split(' ');
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    buyerList.Add(new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyerList.Add(new Rebel(name, age, group));
                }
            }

            string command;
            while ((command=reader.ReadLine())!="End")
            {
                if (buyerList.Any(b=>b.Name==command))
                {
                    var buyer = buyerList.First(b=>b.Name==command);
                    buyer.BuyFood();
                }
            }
            int food = 0;
            foreach (var buyer in buyerList)
            {
                food+=buyer.Food;
            }
            writer.WriteLine(food.ToString());
        }
    }
}
