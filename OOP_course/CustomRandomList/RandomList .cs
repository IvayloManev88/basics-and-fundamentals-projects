using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList :List<string>
    {
       
        public string RandomString()
        {
            int removedIndex = Random.Shared.Next(0,this.Count);
            string removedString = this[removedIndex];
            this.RemoveAt(removedIndex);
            return removedString;
        }
    }
}
