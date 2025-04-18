namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string arithmeticExpression = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            for (int i = 0; i<arithmeticExpression.Length; i++)
            {
                if (arithmeticExpression[i] == '(')
                {
                    indexes.Push(i);
                    continue;
                }
                else if (arithmeticExpression[i] == ')')
                {
                    int index = indexes.Pop();
                    Console.WriteLine(arithmeticExpression.Substring(index, i - index + 1));
                }
            }

        }
    }
}
