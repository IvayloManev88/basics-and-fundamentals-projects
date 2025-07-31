using System.Text;

namespace CocktailBar
{
    public class Cocktail
    {
        private List<string> _ingredients;
        private string _name;
        private decimal _price;
        private double _volume;

        public Cocktail(string ingredients) 
        {
            this._ingredients = ingredients.Split(", ").ToList();
        }
        public Cocktail(string name, decimal price, double volume, string ingredients) :this(ingredients)
        {
            this._name = name;
            this._price = price;
            this._volume = volume;
        }

        public List<string> Ingredients { get => _ingredients; }
        public string Name { get=> _name; }
        public decimal Price { get => _price; }
        public double Volume { get => _volume; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this._name}, Price: {this._price:f2} BGN, Volume: {this._volume} ml");
            sb.AppendLine($"Ingredients: {string.Join(", ", _ingredients)}");
            return sb.ToString().Trim();
        }
    }
}
