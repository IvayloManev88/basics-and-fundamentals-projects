using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(params T[] input)
        {
            _list = new List<T>(input);
            _index = 0;
        }
        private readonly List<T> _list;
        private int _index;

        public IEnumerator<T> GetEnumerator()
        {
           return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
       
       
        public bool Move()
        {
            if (HasNext())
            {
                ++_index;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return (_index < _list.Count-1);
        }
        public void Print()
        {
            if (_list.Count > 0) Console.WriteLine(_list[_index]);
            else Console.WriteLine("Invalid Operation!");

        }
    }
}
