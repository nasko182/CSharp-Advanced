using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    internal class Box<T>
    {
        private Stack<T> stack = new Stack<T>();

        public void Add(T element)
        {
            stack.Push(element);
        }
        public T Remove()
        {
            return stack.Pop();
        }
        public int Count 
        { 
            get
            {
                return stack.Count;
            } 
        }
    }
}
