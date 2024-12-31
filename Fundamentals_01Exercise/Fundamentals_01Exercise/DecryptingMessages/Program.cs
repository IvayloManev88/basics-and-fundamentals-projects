namespace DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            string message = "";
            for (int i = 0; i < rows; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int helpNumber = (int)symbol + key;
                char helpChar = (char)helpNumber;
                message += helpChar.ToString();
            }
            Console.WriteLine(message);
        }
    }
}
