using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIteratorNMS
{
    public class ListyIterator<T>
        where T : class
    {
        public ListyIterator()
        {
            Reset();
        }
        private static List<T> list= new List<T>() {null};

        private static int index;

        private void Reset()
        {
            index = 0;
        }

        public void Create(T[] elements)
        {
            list = new List<T>(elements);
        }

        public void Move()
        {
            bool hasNext = HasNext();

            if (hasNext)
            {
                index++;
            }
        }

        public bool HasNext()
        {
            bool hasNext = index+1 < list.Count;
            Console.WriteLine(hasNext ? "True" : "False");
            return hasNext;
        }

        public void Print()
        {
            if (list.Count == 1 && list[0]== null)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index].ToString());
            }
        }

    }
}

