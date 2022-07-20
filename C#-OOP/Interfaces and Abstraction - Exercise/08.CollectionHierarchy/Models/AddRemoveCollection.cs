using CollectionHierarchy.Models.Intrfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        ICollection<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string text)
        {
            string[] contentOfCollection = new string[collection.Count];
            collection.CopyTo(contentOfCollection, 0);
            collection.Clear();
            collection.Add(text);
            foreach (var item in contentOfCollection)
            {
                collection.Add(item);
            }
            return 0;
        }

        public string Remove()
        {
            string element="";
            foreach (var item in collection)
            {
                element = item;
            }
            collection.Remove(element);
            return element;
        }
    }
}
