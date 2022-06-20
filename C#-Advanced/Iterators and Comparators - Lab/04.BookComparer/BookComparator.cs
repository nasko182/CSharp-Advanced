using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book X, Book Y)
        {
            int result = X.Title.CompareTo(Y.Title);
            if (result == 0)
            {
                if (X.Year>Y.Year)
                {
                    result = -1;
                }
                else if (X.Year<Y.Year)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
