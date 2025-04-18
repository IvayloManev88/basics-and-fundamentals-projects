using System.Security.Cryptography.X509Certificates;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRack = rackCapacity;
            int rackCount = 1;
            while (clothes.Count > 0)
            {
                if (currentRack == 0)
                {
                    UpdateRack(ref rackCount, ref currentRack,rackCapacity);
                }
                int currentItem = clothes.Pop();
                if (currentRack>=currentItem)
                {
                    currentRack-=currentItem;
                    
                }
                else
                {
                    UpdateRack(ref rackCount, ref currentRack, rackCapacity);
                    currentRack -= currentItem;
                }
            }
            Console.WriteLine(rackCount);
            

        }
        public static void UpdateRack(ref int rackCount, ref int currentRack, int rackCapacity)
        {
            rackCount++;
            currentRack = rackCapacity;
        }
    }
}
