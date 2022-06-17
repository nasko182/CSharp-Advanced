using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Exercise

{
    public class Tuple<T,T2>
       
    {
        
        private List<T> first = new List<T>();
        private List<T2> second = new List<T2>();

        public void AddToFirst(T item)
        {
            first.Add(item);
        } 
        public void AddToSecond(T2 item)
        {
            second.Add(item);
        }
        public string Print()
        {
            var sb = new StringBuilder();
            sb.Append(String.Join(" ",first));
            sb.Append(" -> ");
            sb.Append(String.Join(" ", second));
            return sb.ToString();
        }
    }
}
