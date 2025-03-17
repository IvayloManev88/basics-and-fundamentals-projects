using System.Text.RegularExpressions;

namespace ExamPreparationFancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int numberOfBarcodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string pattern = @"\@\#+(?<Catch>[A-Z][a-zA-Z0-9]{4,}[A-Z])\@\#+";
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input,pattern);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string productGroup = string.Empty;
                        string currentMatch = match.Groups["Catch"].Value;
                        for (int j = 0; j < currentMatch.Length; j++)
                        {
                            char c = currentMatch[j];
                            if (char.IsDigit(c))
                            {
                                productGroup += c;
                            }
                        }
                        if (productGroup == string.Empty) productGroup = "00";
                        Console.WriteLine($"Product group: {productGroup}");

                    }
                }
                else Console.WriteLine("Invalid barcode");


            }
        }
    }
}
