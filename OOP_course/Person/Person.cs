using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
		private int age;
		private string  name;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public string  Name
		{
			get { return name; }
			set { name = value; }
		}


		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public override string ToString()
		{
		
			return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}";
		}

	}
}
