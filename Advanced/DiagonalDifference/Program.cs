namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            for (int row = 0; row < size; row++)
            {
                int[] lineInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();  
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = lineInput[col];
                    if (row==col)
                    {
                        firstDiagonalSum += matrix[row, col];
                    }


                }
            }
            for (int i = 0; i < size; i++)
            {
                secondDiagonalSum += matrix[i,size-i-1];
            }
            
            Console.WriteLine(Math.Abs(firstDiagonalSum-secondDiagonalSum));

        }
    }
}
