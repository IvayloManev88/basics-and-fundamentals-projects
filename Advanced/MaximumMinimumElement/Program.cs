using System.IO.Pipes;

namespace MaximumMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numberOfOperations; i++)
            {
                int[] commands = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                switch (commands[0])
                {
                    case 1:
                        if (commands[1]>=1&& commands[1]<=109)
                            stack.Push(commands[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min());
                        break;

                }
            }
            if (stack.Count > 0) Console.WriteLine(string.Join(", ",stack.ToArray()));
        }
    }
}
