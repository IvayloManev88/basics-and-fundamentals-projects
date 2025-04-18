namespace SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputDefinitions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = inputDefinitions[0];
            int columns = inputDefinitions[1];
            int[,] matrix = new int[rows, columns];
            for (int row =0; row < rows; row++)
            {
                int[] lineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
               
                for (int col=0; col < columns; col++)
                {
                    matrix[row, col] = lineInput[col];
                   
                }
                
            }
            for (int col=0; col < columns ; col++)
            {
                int sum = 0;
                for (int row=0; row < rows ; row++)
                {
                    sum+= matrix[row, col]; 
                }
                Console.WriteLine(sum);
            }
        }
    }
}
