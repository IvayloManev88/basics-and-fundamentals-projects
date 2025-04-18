

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string[] inputs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = inputs.Length - 1; i >= 0; i--)
            {
                stack.Push(inputs[i]);
            }
            int sum = int.Parse(stack.Pop());
            while (stack.Count >= 2)
            {
                sum = (stack.Pop() == "+") ? (sum + int.Parse(stack.Pop())) : (sum - int.Parse(stack.Pop()));
            }
            Console.WriteLine(sum);
        }
    }
}
