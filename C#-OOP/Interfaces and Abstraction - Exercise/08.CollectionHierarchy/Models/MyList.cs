using CollectionHierarchy.Models.Intrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemovable, IUseable
    {
        ICollection<string> collection;
        private int used;

        public MyList()
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
        public int Used
        {
            get
            {
                this.Used = 0;
                return this.used;
            }
            private set 
            { 
                this.used = collection.Count;
            }
        }

        public string Remove()
        {
            string[] contentOfCollection = new string[collection.Count];
            collection.CopyTo(contentOfCollection, 0);
            string element = "";
            foreach (var item in contentOfCollection.Reverse())
            {
                element = item;
            }
            collection.Remove(element);
            return element ;
        }
    }
}
