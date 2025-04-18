using System.Runtime.Serialization.Formatters;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsToSum = 3;
            int colsToSum = 3;
            int[] sizes = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows =sizes[0];
            int cols =sizes[1];
            int[,] matrix = new int[rows,cols];
            for (int row=0; row < rows; row++)
            {
                int[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col=0; col < cols; col++)
                {
                    matrix[row,col] = inputLine[col];
                }
            }
            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < rows- rowsToSum+1; row++)
            {
                
                for (int col = 0; col < cols- colsToSum+1; col++)
                {
                    int sum = 0;
                    for (int i =0; i< rowsToSum;i++)
                    {
                        for (int j =0; j< colsToSum;j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxCol = col;
                        maxRow = row;
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row< maxRow + rowsToSum; row++)
            {
                for ( int col = maxCol; col < maxCol+colsToSum;col++)
                {
                    Console.Write(matrix[row,col]+ " ");
                }
                Console.WriteLine();
            }

        }
    }
}
