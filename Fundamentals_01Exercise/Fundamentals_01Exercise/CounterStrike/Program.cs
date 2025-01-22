namespace CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int enempyCount = 0;
            while ((input=Console.ReadLine())!= "End of battle")
            {
                int distance = int.Parse(input);
                if (energy>=distance)
                {
                    energy -= distance;
                    enempyCount++;
                    if (enempyCount % 3 == 0) energy += enempyCount;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {enempyCount} won battles and {energy} energy");
                    return;
                }
            }
            Console.WriteLine($"Won battles: {enempyCount}. Energy left: {energy}");
        }
    }
}
