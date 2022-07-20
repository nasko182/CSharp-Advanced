using CollectionHierarchy.IO.Interfaces;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
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
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            string[] input = reader.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int amount = int.Parse(reader.ReadLine());
            StringBuilder output = new StringBuilder();
            foreach (string inputItem in input)
            {
                output.Append(addCollection.Add(inputItem).ToString()+" ");
            }
            writer.WriteLine(output.ToString().TrimEnd());
            output.Clear();
            foreach (string inputItem in input)
            {
                output.Append(addRemoveCollection.Add(inputItem).ToString() + " ");
            }
            writer.WriteLine(output.ToString().TrimEnd());
            output.Clear();
            foreach (string inputItem in input)
            {
                output.Append(myList.Add(inputItem).ToString() + " ");
            }
            writer.WriteLine(output.ToString().TrimEnd());
            output.Clear();
            for (int i = 0; i < amount; i++)
            {
                output.Append(addRemoveCollection.Remove()+" ");
            }
            writer.WriteLine(output.ToString().TrimEnd());
            output.Clear();
            for (int i = 0; i < amount; i++)
            {
                output.Append(myList.Remove()+" ");
            }
            writer.WriteLine(output.ToString().TrimEnd());
            output.Clear();


        }
    }
}
