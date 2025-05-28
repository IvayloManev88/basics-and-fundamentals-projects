using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    public class Person
    {
        
            public Person()
            {
                Name = "No name";
                Age = 1;
            }
            public Person(int age) : this()
            {
                Name = "No name";
                Age = age;
            }
            public Person(string name, int age) : this(age)
            {
                Name = name;
                Age = age;
            }
            private string name;
            private int age;

            public int Age
            {
                get { return age; }
                set { age = value; }
            }


            public string Name
            {
                get { return name; }
                set { name = value; }
            }

        
    }
}
