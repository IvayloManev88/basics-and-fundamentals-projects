namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double[], double[]> addVat = AddVat;
            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double[] vatPrices = addVat(prices);
            foreach (double vat in vatPrices)
            {
                Console.WriteLine($"{vat:f2}");
            }

        }
        public static double[] AddVat(double[] prices)
        {
            double[] pricesPlusVat = new double[prices.Length];
            for (int i=0;i<prices.Length;i++)
            {
                pricesPlusVat[i] = prices[i] * 1.2;
            }
            return pricesPlusVat;
        }
    }
}
