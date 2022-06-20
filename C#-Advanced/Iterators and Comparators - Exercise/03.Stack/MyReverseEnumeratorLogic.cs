using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03Stack
{
    internal class MyReverseEnumeratorLogic<T> : IEnumerator<T>
    {
        public MyReverseEnumeratorLogic(List<T> list)
        {
            this.list=list;
            Reset();
        }
        private List<T> list = new List<T>();
        private int index;
        public T Current => list[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index--;
            if (index < 0)
            {
                return false;
            }
            else return true;
        }

        public void Dispose()
        {
        }


        public void Reset()
        {
            index = list.Count;
        }
    }
}
