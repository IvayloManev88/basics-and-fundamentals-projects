namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new (Console.ReadLine().Split().Select(int.Parse).ToArray());
         
            for (int i = 1; i <= nsx[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0) Console.WriteLine("0");
            else
            {
                if (queue.Contains(nsx[2])) Console.WriteLine("true");
                else
                {

                    Console.WriteLine(queue.Min());
                }
            }
        }


    }
}
