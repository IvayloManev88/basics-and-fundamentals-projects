namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                
                jaggedArray[row]=Console.ReadLine().Split().Select(int.Parse).ToArray();
                
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowIndex = int.Parse(commands[1]);
                int colIndex = int.Parse(commands[2]);
                if (rowIndex >= 0 && colIndex >= 0 && rowIndex < jaggedArray.Length && colIndex < jaggedArray[rowIndex].Length)
                {
                    int changeAmount = int.Parse(commands[3]);
                    switch (commands[0])
                    {
                        case "Add":
                            jaggedArray[rowIndex][colIndex] += changeAmount;
                            break;
                        case "Subtract":
                            jaggedArray[rowIndex][colIndex] -= changeAmount;
                            break;
                    }
                }
                else Console.WriteLine("Invalid coordinates");
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }

        }
    }
}
