

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> fuelPumps = new();
           
            
       
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                fuelPumps.Enqueue(input);

            }
            bool willReach = false;
            for (int i = 0; i < n; i++)
            {
                int fuel = 0;
                foreach (int[] input in fuelPumps)
                {
                    fuel += input[0];
                    fuel -= input[1];
                    if (fuel < 0)
                    {
                        willReach = false;
                        break;
                        
                    }
                    else willReach = true;
                }
                if (willReach)
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    int[] helpArray = fuelPumps.Dequeue();
                    fuelPumps.Enqueue(helpArray);
                }
            }
            
            
           
        }
    }
}
