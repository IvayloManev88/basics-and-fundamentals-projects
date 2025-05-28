using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 firstItem, T2 secondItem)
        {
            item1 = firstItem;
            item2 = secondItem;
        }
        private T1 item1;

        public T1 Item1
        {
            get { return item1; }
            set { item1 = value; }
        }

        private T2 item2;

        public T2 Item2
        {
            get { return item2; }
            set { item2 = value; }
        }


        public void Print()
        {
            Console.WriteLine($"{this.item1} -> {this.item2}");
        }
    }
}
