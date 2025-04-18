namespace SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowColumnCount = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowColumnCount[0];
            int columns = rowColumnCount[1];
            int[,] matrix = new int [rows, columns];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] lineInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col<columns;col++)
                {
                    matrix[row,col] = lineInput[col];
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);


        }
    }
}
