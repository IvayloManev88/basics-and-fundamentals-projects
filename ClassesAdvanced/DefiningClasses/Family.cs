using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> persons = new List<Person>();
        public List<Person> People 
        { 
            get { return persons; } 
            set { persons = value; }
        }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()

        {
            int maxAge = persons.Max(p => p.Age);
            return People.First(p=> p.Age == maxAge);
        }
    }
}
