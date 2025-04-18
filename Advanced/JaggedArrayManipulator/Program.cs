namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            long[][] jaggedMatrix = new long[numberOfRows][];
            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                long[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                jaggedMatrix[row] = input;
            }
            for (int row = 0;row < jaggedMatrix.Length-1;row++)
            {
                if (jaggedMatrix[row].Length== jaggedMatrix[row+1].Length)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++) jaggedMatrix[row][col] = 2 * jaggedMatrix[row][col];
                    for (int col = 0; col < jaggedMatrix[row+1].Length; col++) jaggedMatrix[row+1][col] = 2 * jaggedMatrix[row+1][col];

                }
                else
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++) jaggedMatrix[row][col] = jaggedMatrix[row][col]/2;
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++) jaggedMatrix[row + 1][col] = jaggedMatrix[row + 1][col]/2;
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commands = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int rowIndex= int.Parse(commands[1]);
                int colIndex= int.Parse(commands[2]);
                if (rowIndex >= 0 && colIndex >= 0 && rowIndex < jaggedMatrix.Length && colIndex < jaggedMatrix[rowIndex].Length)
                {
                    long operation = long.Parse(commands[3]);
                    if (commands[0] == "Add") jaggedMatrix[rowIndex][colIndex] += operation;
                    else if (commands[0] == "Subtract") jaggedMatrix[rowIndex][colIndex] -= operation;
                }
            }
            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }
    }
}
