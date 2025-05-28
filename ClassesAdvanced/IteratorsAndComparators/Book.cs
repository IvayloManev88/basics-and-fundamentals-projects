using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book :IComparable<Book>
    {

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }
        public string Title { get; set; }
        public int Year { get; set; }  
        public List<string> Authors { get; set; } = new List<string>();

        public int CompareTo(Book? other)
        {
            if (other.Year != this.Year) return this.Year.CompareTo(other.Year);
           else
            
            {
                return this.Title.CompareTo(other.Title);
                
            }
            

        }

        public override string ToString() =>  $"{this.Title} - {this.Year}";
        
    }
}
