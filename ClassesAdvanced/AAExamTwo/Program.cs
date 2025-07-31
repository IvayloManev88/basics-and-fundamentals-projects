namespace AAExamTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] map = new char[size,size];
            int spyRow = -1;
            int spyCol = -1;

            Dictionary<string, (int nextRow, int nextCol)> change = new Dictionary<string, (int nextRow, int nextCol)>
            {
                ["up"] = (-1, 0),
                ["down"] = (1, 0),
                ["left"] = (0, -1),
                ["right"] = (0, 1),
            };

            for (int rows = 0; rows < size; rows++)
            {
                string line = Console.ReadLine();
                for (int cols = 0; cols < size; cols++)
                {
                    map[rows, cols] = line[cols];
                    if (map[rows, cols] == 'S')
                    {
                        spyCol = cols;
                        spyRow = rows;
                        map[rows, cols] = '.';
                    }
                }

            }

            int stealthPoints = 100;
            bool isExtracted = false;
            bool isCompromized = false;
            while (!isExtracted &&!isCompromized)
            {
                string command = Console.ReadLine();
                (int changeRow, int changeCol) = change[command];
                int newRow = spyRow + changeRow;
                int newCol = spyCol + changeCol;
                if (newRow>=0 && newCol>=0 && newRow<size && newCol<size)
                {
                    spyRow = newRow;
                    spyCol = newCol;
                }
                else continue;
                if (map[spyRow, spyCol] == 'G')
                {
                    stealthPoints -= 40;
                    map[spyRow, spyCol] = '.';
                    if (stealthPoints<=0) isCompromized = true;
                }
                else if (map[spyRow, spyCol] == 'B')
                {
                    stealthPoints = Math.Min(100, stealthPoints + 15);
                    map[spyRow, spyCol] = '.';
                }
                else if (map[spyRow, spyCol] =='E')
                {
                    isExtracted = true;
                }
            }
            if (isExtracted)
            {
                Console.WriteLine("Mission accomplished. Spy extracted successfully.");

            }
            else
            {
                Console.WriteLine("Mission failed. Spy compromised");
                map[spyRow, spyCol] = 'S';
            }
            Console.WriteLine($"Stealth level: {stealthPoints} units");
            PrintMap(map);


        }
        public static void PrintMap(char[,] map)
        {
            for (int rows = 0; rows < map.GetLength(0); rows++)
            {
                for (int cols = 0; cols < map.GetLength(1); cols++)
                {
                    if (cols < map.GetLength(1) - 1)
                        Console.Write(map[rows, cols]);
                    else Console.Write(map[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
