using System;
using System.Collections.Generic;
using System.Text;

namespace Generics

{
    public class Box<T>
    {

        private List<T> items { get; set; } = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item.ToString()}");
            }
            return sb.ToString();
        }
    }
}
