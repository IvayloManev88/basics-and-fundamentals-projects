namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputs = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string shopName = inputs[0];
                string product = inputs[1];
                double price = double.Parse(inputs[2]);
                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new());
                }
                if (!shops[shopName].ContainsKey(product))
                {
                    shops[shopName].Add(product, 0);
                }
                shops[shopName][product] = price;
            }
            shops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach ((string shop, Dictionary<string,double> products)in shops)
            {
                Console.WriteLine($"{shop}->");
                foreach ((string product, double price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
