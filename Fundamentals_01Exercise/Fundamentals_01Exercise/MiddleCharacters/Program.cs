namespace MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddle(input);
        }
        static void PrintMiddle (string input)
        {
            char[] chars = input.ToCharArray();
            if (input.Length % 2 == 0)
            {
                Console.Write(chars[(input.Length / 2 - 1)]);
                Console.Write(chars[input.Length / 2]);
            }
            else Console.WriteLine(chars[input.Length / 2]);
        }
    }
}
