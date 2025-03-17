namespace AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse (Console.ReadLine());
            char secondChar = char.Parse (Console.ReadLine());
            int intFirstChar = (int)firstChar;
            int intSecondChar = (int)secondChar;
            if (intFirstChar> intSecondChar)
            {
                intSecondChar= intFirstChar;
                intFirstChar = (int)secondChar;
            }
            string input = Console.ReadLine ();
            int sum = 0;
            for (int i = 0;i<input.Length;i++)
            {
                char currentChar = input [i];
                int intCurrentChar = (int)currentChar;
                if (intCurrentChar > intFirstChar && intCurrentChar < intSecondChar)
                {
                    sum += intCurrentChar;
                }
            }
            Console.WriteLine (sum);
        }
    }
}
