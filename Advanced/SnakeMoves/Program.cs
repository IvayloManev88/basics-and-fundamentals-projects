namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] snakeMatrix= new char[rows,cols];
            string snake = Console.ReadLine();
            int currentIndex = 0;
            for (int row = 0; row < snakeMatrix.GetLength(0); row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = snakeMatrix.GetLength(1)-1; col >= 0; col--)
                    {
                        snakeMatrix[row, col] = snake[currentIndex];
                        currentIndex++;
                        if (currentIndex == snake.Length) currentIndex = 0;
                    }
                }
                else
                {
                    for (int col = 0; col < snakeMatrix.GetLength(1); col++)
                    {
                        snakeMatrix[row, col] = snake[currentIndex];
                        currentIndex++;
                        if (currentIndex == snake.Length) currentIndex = 0;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(snakeMatrix[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
