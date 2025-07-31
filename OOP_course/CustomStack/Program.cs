namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();
            Console.WriteLine(stack.IsEmpty());
          
            stack.AddRange(new Stack<string>(new[] { "1", "2", "3", "5", "6" }) );
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
