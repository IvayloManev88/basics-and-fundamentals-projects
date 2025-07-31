using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Private:Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(string id, string firstName, string lastNamedecimal, decimal salary):base( id,  firstName,  lastNamedecimal)
        {
            Salary = salary;
        }
        public override string ToString() => $"{base.ToString()} Salary: {this.Salary:f2}";


    }
}
