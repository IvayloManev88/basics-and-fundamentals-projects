using System.Text.RegularExpressions;
using System.Threading;


namespace ExamPreparation_AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\#\|])(?<ProductName>[A-Za-z\ ]+)\1(?<Date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<Calories>[0-9]+)\1";
            string input = Console.ReadLine();
            List<Products> products = new List<Products>();
            int totalCalories = 0;
            int dailyCalories = 2000;
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Products inputProduct = new(match.Groups["ProductName"].Value, match.Groups["Date"].Value, int.Parse(match.Groups["Calories"].Value));
                totalCalories += inputProduct.Nutrition;
                products.Add(inputProduct);
            }
            //tuk
            int days = totalCalories / dailyCalories;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Products product in products)
            {
                Console.WriteLine($"Item: {product.Name}, Best before: {product.BestBefore}, Nutrition: {product.Nutrition}");
            }
        }
    }
    public class Products
    { 
        public Products(string name, string bestBefore, int nutrition)
        {
            Name=name;
            BestBefore=bestBefore;
            Nutrition=nutrition;
        }

    
        public string Name { get; set; }
        public string BestBefore { get; set; }
        public int Nutrition { get; set; }
    }
}
