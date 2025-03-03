using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = string.Empty;
            string pattern = @"\%(?<Customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<Product>\w+)\>[^|$%.]*\|(?<Quantity>\d+)\|[^|$%.]*?(?<Price>\d+([.]\d+)?)\$";
            decimal totalAmount = 0;
            while ((input=Console.ReadLine())!= "end of shift")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string customerName = match.Groups["Customer"].Value;
                    decimal currentAmount = int.Parse(match.Groups["Quantity"].Value) * decimal.Parse(match.Groups["Price"].Value);
                    totalAmount += currentAmount;
                    Console.WriteLine($"{match.Groups["Customer"].Value}: {match.Groups["Product"].Value} - {currentAmount:f2}");
                }
            
            }
            Console.WriteLine($"Total income: {totalAmount:f2}");
        }
    }
}
