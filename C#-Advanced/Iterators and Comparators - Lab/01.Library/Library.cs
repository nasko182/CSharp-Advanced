using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
        }
        private IReadOnlyList<Book> Books { get; set; }
    }
}
