using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class MyEnumeratorLogic : IEnumerator<Book>
    {
        public MyEnumeratorLogic(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }
        private List<Book> books;
        private int currentIndex = -1;

        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < this.books.Count;
        }
        public void Reset()
        {
            currentIndex= -1;
        }
        public void Dispose()
        {
        }
    }
}
