using System.Text;
using System.Xml.Linq;

namespace CocktailBar
{
    public class Menu
    {
		
		private List<Cocktail> _cocktails;
		private int _barCapacity;
		public Menu (int capacity)
		{
			_barCapacity = capacity;
			_cocktails = new List<Cocktail> ();
		}
		public int BarCapacity
		{
			get { return _barCapacity; }
			set { _barCapacity = value; }
		}


		public List<Cocktail> Cocktails
        {
			get { return _cocktails; }
			set { _cocktails = value; }
		}
		public void AddCocktail(Cocktail cocktail)
		{
			if (_cocktails.Count<_barCapacity)
			{

				if (!_cocktails.Any(c=>c.Name == cocktail.Name))
					_cocktails.Add (cocktail);
			}
		}
		public bool RemoveCocktail(string name)
		{
			Cocktail removedCoctail = _cocktails.FirstOrDefault(c => c.Name == name);
			if (removedCoctail != null)
			{
				_cocktails.Remove(removedCoctail);
				return true;
			}

			else return false;
		}
		public Cocktail GetMostDiverse()
		{
			return _cocktails.OrderByDescending(c=>c.Ingredients.Count).First();
		}
		public string Details(string cocktailName)
		{
            Cocktail detailsCoctail = _cocktails.FirstOrDefault(c => c.Name == cocktailName);
			if (detailsCoctail != null)
			{
				return detailsCoctail.ToString();
			}
			else return string.Empty;
        }
		public string GetAll()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("All Cocktails:");
			foreach (Cocktail cocktail in _cocktails.OrderBy(c=>c.Name))
			{
				sb.AppendLine(cocktail.Name);

			}
			return sb.ToString().Trim();

        }


    }
}
