namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> children = new(Console.ReadLine().Split());
            int numberOfTosses = int.Parse(Console.ReadLine());
            int currentTossCounter = 1;
            while (children.Count>1)
            {
                
                string currentChild = children.Dequeue();
                if (currentTossCounter == numberOfTosses)
                {
                    Console.WriteLine($"Removed {currentChild}");
                    currentTossCounter = 1;
                }
                else
                {
                    children.Enqueue(currentChild);
                    currentTossCounter++;
                }
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
