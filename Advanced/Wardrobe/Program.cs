namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new();
            for (int i = 0; i < inputNumber; i++)
            {


                string[] color = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string currentColor = color[0];
                string[] elements = color[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string element in elements)
                {
                    if (!wardrobe.ContainsKey(currentColor))
                    {
                        wardrobe.Add(currentColor, new());
                    }
                    if (!wardrobe[currentColor].ContainsKey(element))
                    {
                        wardrobe[currentColor].Add(element, 0);
                    }
                    wardrobe[currentColor][element]++;
                }
            }
            string[] searchedItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedItems[0];
            string searchedElement = searchedItems[1];
            foreach (string colorInWardrobe in wardrobe.Keys)
            {
                Console.WriteLine($"{colorInWardrobe} clothes:");
                foreach ((string elementInWardrobe, int countInWardrobe) in  wardrobe[colorInWardrobe])
                {
                    Console.Write($"* {elementInWardrobe} - {countInWardrobe}");
                    if (searchedColor == colorInWardrobe && searchedElement == elementInWardrobe) Console.Write(" (found!)");

                    Console.WriteLine();
                }
            }
        }
    }
}
