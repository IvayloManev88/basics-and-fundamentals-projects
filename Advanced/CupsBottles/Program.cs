namespace CupsBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Stack<int> bottles = new(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int wastedWater = 0;
            while (cups.Count > 0)
            {
                if (bottles.Count == 0) break;
                int currentCup = cups.Dequeue();
               while (bottles.Count > 0)
                {
                    int currentBottle = bottles.Pop();
                    if (currentCup >= currentBottle) currentCup -= currentBottle;
                    else
                    {
                        wastedWater += currentBottle - currentCup;
                        currentCup = 0;
                        
                    }
                    if (currentCup == 0) break;
                    
                }

            }
            if (bottles.Count > 0)
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            else Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
