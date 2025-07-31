using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private Dough _dough;
        private readonly List<Topping> _toppings;
        

        public string Name { get; }
        public double Calories => this.Dough.Calories + this.Toppings.Sum(t=>t.Calories);
        public Dough? Dough
        {
            get => this._dough;            
            set => this._dough = value ?? throw new ArgumentNullException(nameof(value));
            
        }
        public IReadOnlyCollection <Topping> Toppings { get; set; }

        public Pizza(string name)
        { 
            if (name is null || name.Length<1 || name.Length>15) 
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            this.Name = name;

            this._toppings = new List<Topping>();
            this.Toppings = this._toppings.AsReadOnly();
        }


        public void AddTopping(Topping topping)
        {
            if (this._toppings.Count >= 10)
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            this._toppings.Add(topping);
                

        }


    }
}
