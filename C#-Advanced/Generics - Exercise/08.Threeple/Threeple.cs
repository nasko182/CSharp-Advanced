using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Exercise

{
    public class Threeple<T, T2, T3>

    {
        public Threeple(T item1, T2 item2, T3 item3)
        {
            first = item1;
            second = item2;
            third = item3;

        }

        private T first;
        private T2 second;
        private T3 third;
        public string Print()
        {
            var sb = new StringBuilder();
            sb.Append(first);
            sb.Append(" -> ");
            sb.Append(second);
            sb.Append(" -> ");
            sb.Append(third);
            return sb.ToString();
        }
    }
}
