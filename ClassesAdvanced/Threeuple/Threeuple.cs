using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple
{
    public class Threeuple<T1, T2, T3>
    {


        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            item1 = firstItem;
            item2 = secondItem;
            item3 = thirdItem;
        }
        private T1 item1;
        private T3 item3;

        public T3 Item3
        {
            get { return item3; }
            set { item3 = value; }
        }


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
            Console.WriteLine($"{this.item1} -> {this.item2} -> {this.item3}");
        }

    }
}
