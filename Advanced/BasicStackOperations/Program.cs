namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack <int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int minElement = int.MaxValue;
            for (int i = 1; i<= nsx[1];i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0) Console.WriteLine("0");
            else
            {
                if (stack.Contains(nsx[2])) Console.WriteLine("true");
                else
                {
                    
                    Console.WriteLine(stack.Min());
                }
            }


        }
    }
}
