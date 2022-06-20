using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03Stack
{
    public class MyStack<T> : IEnumerable<T>
        where T : class
    {
        public List<T> List { get; set; } = new List<T>();

        public void Push(T item)
        {
            List.Insert(List.Count, item);
        }

        public T Pop()
        {
            if (List.Count>0)
            {
                T element = List[List.Count - 1];
                List.RemoveAt(List.Count - 1);
                return element;
            }
            else
            {
                Console.WriteLine("No elements");
                T element = null;
                return element;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyReverseEnumeratorLogic<T>(List);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
