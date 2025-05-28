using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            if (x == null && y == null) return 0;
            if (x ==null) return 1;
            if (y ==null) return -1;
            if (x.Title==y.Title)
            {
                return -1*x.Year.CompareTo(y.Year);
            }
            else return x.Title.CompareTo(y.Title);
            
        }
    }
}
