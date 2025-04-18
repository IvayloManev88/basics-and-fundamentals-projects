using System.Data;

namespace SquareWitMaximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSizeRow = 2;
            int SquareSizeColumn = 2;
            int[] matrixSize = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];
            int[,] matrix = new int[rows, columns];
            for (int row  = 0; row < rows; row++)
            {
                int[] inputLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col=0; col < columns; col++) 
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            int biggestSum = int.MinValue;
            int rowIndex = -1;
            int columnIndex = -1;
            for (int row = 0; row < (rows- squareSizeRow+1); row++)
            {
                
                for (int col = 0; col < (columns- SquareSizeColumn+1); col++)
                {
                    int sum = 0;
                    for (int i =0; i< squareSizeRow;i++)
                    {
                        for (int j=0; j< SquareSizeColumn;j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }
            for (int row = rowIndex; row < rowIndex + squareSizeRow; row++)
            {

                for (int col = columnIndex; col < (columnIndex + SquareSizeColumn); col++)
                {

                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSum);
        }
    }
}
