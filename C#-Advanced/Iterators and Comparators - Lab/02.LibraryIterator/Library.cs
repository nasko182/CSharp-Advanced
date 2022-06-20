using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.Reset();
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
                currentIndex = -1;
            }
            public void Dispose()
            {
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
