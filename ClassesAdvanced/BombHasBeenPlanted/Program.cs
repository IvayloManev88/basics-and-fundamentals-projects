using System.Security.Cryptography.X509Certificates;

namespace BombHasBeenPlanted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];
            char[,] map = new char[row, col];
            int ctRowIndex = -1, ctColIndex = -1, bombRowIndex = -1, bombColIndex = -1;
            for (int i = 0; i < row; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    map[i, j] = input[j];
                    if (map[i, j] == 'C')
                    {
                        ctRowIndex = i; ctColIndex = j;
                    }
                    if (map[i, j] == 'B')
                    {
                        bombRowIndex = i; bombColIndex = j;
                    }
                }
            }
            int currentRowIndex = ctRowIndex;
            int currentColIndex = ctColIndex;
            int secondsCounter = 16;
            bool isKilledByTerrorist = false;
            bool isBombDefused = false;
            bool isBombExploded=false; 
            while (secondsCounter > 0&&!isKilledByTerrorist&&!isBombDefused&&!isBombExploded)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        secondsCounter--;
                        if (IsIndexCorrect(currentRowIndex - 1, currentColIndex, map))
                        {
                            currentRowIndex = currentRowIndex - 1;
                            if (map[currentRowIndex, currentColIndex] == 'T')
                            {
                                map[currentRowIndex, currentColIndex] = '*';
                                isKilledByTerrorist = true;
                                Console.WriteLine("Terrorists win!");
                            }
                        }
                        break;
                    case "down":
                        secondsCounter--;
                        if (IsIndexCorrect(currentRowIndex + 1, currentColIndex, map))
                        {
                            currentRowIndex = currentRowIndex + 1;
                            if (map[currentRowIndex, currentColIndex] == 'T')
                            {
                                map[currentRowIndex, currentColIndex] = '*';
                                isKilledByTerrorist = true;
                                Console.WriteLine("Terrorists win!");
                            }
                        }
                        break;
                    case "left":
                        secondsCounter--;
                        if (IsIndexCorrect(currentRowIndex, currentColIndex-1, map))
                        {
                            currentColIndex = currentColIndex-1;
                            if (map[currentRowIndex, currentColIndex] == 'T')
                            {
                                map[currentRowIndex, currentColIndex] = '*';
                                isKilledByTerrorist = true;
                                Console.WriteLine("Terrorists win!");
                            }
                        }
                        break;
                    case "right":
                        secondsCounter--;
                        if (IsIndexCorrect(currentRowIndex, currentColIndex + 1, map))
                        {
                            currentColIndex = currentColIndex + 1;
                            if (map[currentRowIndex, currentColIndex] == 'T')
                            {
                                map[currentRowIndex, currentColIndex] = '*';
                                isKilledByTerrorist = true;
                                Console.WriteLine("Terrorists win!");


                            }
                        }
                        break;
                    case "defuse":
                        if (currentRowIndex == bombRowIndex && currentColIndex == bombColIndex)
                        {
                            if (secondsCounter>=4)
                            {
                                secondsCounter -= 4;
                                isBombDefused = true;
                                map[currentRowIndex, currentColIndex] = 'D';
                                Console.WriteLine("Counter-terrorist wins!");
                                Console.WriteLine($"Bomb has been defused: {secondsCounter} second/s remaining.");
                            }
                            else
                            {
                                secondsCounter -= 4;
                                isBombExploded = true;
                                map[currentRowIndex, currentColIndex] = 'X';
                                Console.WriteLine("Terrorists win!");
                                Console.WriteLine("Bomb was not defused successfully!");
                                Console.WriteLine($"Time needed: {Math.Abs(secondsCounter)} second/s.");

                            }

                        }
                        else secondsCounter -= 2;
                                                
                        break;


                }
                if (secondsCounter==0 &&!isKilledByTerrorist&&!isBombDefused&&!isBombExploded)
                {
                    Console.WriteLine("Terrorists win!");
                    Console.WriteLine("Bomb was not defused successfully!");
                    Console.WriteLine($"Time needed: {secondsCounter} second/s.");

                }
                

               

            }
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsIndexCorrect(int rowIndex, int colIndex, char[,] map)
        {
            if (colIndex >= 0 && rowIndex >= 0 && rowIndex < map.GetLength(0) && colIndex < map.GetLength(1)) return true;
            return false;
        }

    }
}
