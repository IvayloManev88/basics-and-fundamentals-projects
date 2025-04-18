namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[size][];
            for (int row = 0; row < size; row++)
            {
                pascalTriangle[row] = new long[row+1];
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col == 0 || col == pascalTriangle[row].Length - 1)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else pascalTriangle[row][col] = pascalTriangle[row-1][col-1] + pascalTriangle[row-1][col];
                }
            }
            foreach (long[] item in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
