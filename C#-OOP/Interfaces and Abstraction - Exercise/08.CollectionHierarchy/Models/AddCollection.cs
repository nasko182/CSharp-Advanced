using CollectionHierarchy.Models.Intrfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private ICollection<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string text)
        {
            int index = collection.Count;
            collection.Add(text);
            return index;
        }
    }
}
