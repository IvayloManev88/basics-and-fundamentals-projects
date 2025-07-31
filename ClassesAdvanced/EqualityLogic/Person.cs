using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person :IComparable<Person>, IEquatable<Person>
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person? other)
        {
            int nameComparisson = Comparer<string>.Default.Compare(this.name,other.name);
            if (nameComparisson != 0)
            return nameComparisson;
            
                int ageComparisson = Comparer<int>.Default.Compare(this.age, other.age);
                return ageComparisson;
            
        }

        public bool Equals(Person? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<string>.Default.Equals(this.name, other.name) && EqualityComparer<int>.Default.Equals(this.age, other.age);
        }

        public override bool Equals(object? obj) => obj is Person p && Equals(p);
        
          
        

        public override int GetHashCode()
        {
            return HashCode.Combine(name, age);
        }

        public static bool operator ==(Person left, Person right)=>EqualityComparer<Person>.Default.Equals(left, right);
        
            
        

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public static bool operator <(Person left, Person right) => Comparer<Person>.Default.Compare(left, right) < 0;


        public static bool operator <=(Person left, Person right) => Comparer<Person>.Default.Compare(left, right) <= 0;
        


        public static bool operator >(Person left, Person right) => Comparer<Person>.Default.Compare(left, right) > 0;
        

        public static bool operator >=(Person left, Person right) => Comparer<Person>.Default.Compare(left, right) >= 0;
        

    }
}
