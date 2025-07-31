using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (string.IsNullOrWhiteSpace(name) || age <0 || string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentException("Invalid input!");
            }
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual string ProduceSound()
        {
            throw new InvalidOperationException("Every animal should make a sound");
        }
        
            
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            return sb.ToString().Trim();
        }
    }
}
