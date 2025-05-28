using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
       
        public List<T> Elements { get; set; } = new List<T>();

        public void Add(T element)
        {
            Elements.Add(element);
            
        }
        public int Counter(T compareElement)
        {
            int counter = 0;
            foreach (T element in Elements)
            {
                if (element.CompareTo(compareElement) > 0)
                    counter++;
            }
            return counter;
        }
    }
}
