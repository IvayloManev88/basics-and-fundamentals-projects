using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library:IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
           
            this.books = books.ToList();
            this.books.Sort(new BookComparator());
        }
        private List<Book> books=new List<Book>();

        
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()=>this.GetEnumerator();
       
        class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.Reset();
            }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (currentIndex >= this.books.Count)
                {
                    return false;
                }

                
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
