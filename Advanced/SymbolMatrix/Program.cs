namespace SymbolMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < size; row++)
            {
                string inputLine = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = (int)inputLine[col];
                }
            }
            char ch = char.Parse(Console.ReadLine());
            
            bool isFound = false;
            for (int col = 0; col < size; col++)
            {
                
                for (int row = 0; row < size; row++)
                {
                    if (matrix[row, col] == (int)ch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
            }
            if (!isFound) Console.WriteLine($"{ch} does not occur in the matrix");
        }
    }
}
