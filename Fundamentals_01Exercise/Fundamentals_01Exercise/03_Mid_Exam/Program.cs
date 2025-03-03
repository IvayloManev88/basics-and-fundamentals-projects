using System.ComponentModel;

namespace _03_Mid_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> items = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int catIndex = int.Parse(Console.ReadLine());
            string typeBreakage = Console.ReadLine();
            List<int> leftItems = items.GetRange(0,catIndex);
            List<int> rightItems = items.GetRange(catIndex+1, items.Count -1 - catIndex);
            int leftsum = 0;
            int rightsum = 0;
            if (typeBreakage== "cheap")
            {
                leftsum = leftItems.Where(x => x < items[catIndex]).Sum();
                rightsum = rightItems.Where(x=> x<items[catIndex]).Sum();
            }
            else
            {
                leftsum = leftItems.Where(x => x >= items[catIndex]).Sum();
                rightsum = rightItems.Where(x => x >= items[catIndex]).Sum();
            }
            if (leftsum>=rightsum)
            {
                Console.WriteLine($"Left - {leftsum}");
            }
            else Console.WriteLine($"Right - {rightsum}");
        }

       
        
    }
}
