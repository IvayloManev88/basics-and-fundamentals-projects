using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private readonly string _name;
        private readonly string _town;
        private readonly int _age;
        public Person(string name, string town, int age)
        {
            this._name = name;
            this._town = town;
            this._age = age;
        }
        public int CompareTo(Person? other)
        {
            if (other == null) return 1;
            int nameComparison = Comparer<string>.Default.Compare(this._name, other._name);
            if (nameComparison != 0 ) return nameComparison;
            int ageComparison= Comparer<int>.Default.Compare(this._age, other._age);
            if (ageComparison != 0) return ageComparison;
            int townComparison = Comparer<string>.Default.Compare(this._town, other._town);
            return townComparison;
        }
    }
}
