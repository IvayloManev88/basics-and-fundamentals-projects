namespace DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            char[,] map = new char[rows, cols];
            int currentRow = -1;
            int currentCol = -1;
            int initialRow = -1;
            int initialCol = -1;
            char[] specialSymbols = new char[] { 'B', 'P', 'R', 'A' };
            for (int row = 0; row < map.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = line[col];
                    if (map[row, col] =='B')
                    {
                        currentRow = row;
                        currentCol = col;
                        initialCol = col;
                        initialRow = row;
                    }
                }
               
            }
            bool isOutOfMap=false;
            bool isPizzaRetrieved=false;
            while (true)
            {
                if (map[currentRow, currentCol] == '-') map[currentRow, currentCol] = '.';
                if (isOutOfMap)
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    map[initialRow, initialCol] = ' ';
                    break;
                }
                
                string command = Console.ReadLine();
                switch (command)
                {
                    
                    case "up":
                        if (IsIndexCorrect(currentRow - 1,currentCol,map))
                        {
                            if (!(map[currentRow - 1, currentCol] == '*'))
                            {
                                

                                currentRow--;
                            }
                        }
                        else isOutOfMap = true;
                        break;
                    case "down":
                        if (IsIndexCorrect(currentRow + 1, currentCol, map))
                        {
                            if (!(map[currentRow +1, currentCol] == '*'))
                            {

                                
                                currentRow++;
                            }
                            
                        }
                        else isOutOfMap = true;
                        break;
                    case "left":
                        if (IsIndexCorrect(currentRow, currentCol-1, map))
                        {

                            if (!(map[currentRow, currentCol-1] == '*'))
                            {
                               
                                currentCol--;
                            }
                            
                        }
                        else isOutOfMap = true;
                        break;
                    case "right":
                        if (IsIndexCorrect(currentRow, currentCol +1, map))
                        {
                            if (!(map[currentRow, currentCol + 1] == '*'))
                            {
                                
                                currentCol++;
                            }
                        }
                        else isOutOfMap = true;
                        break;
                }
                if (map[currentRow,currentCol]=='P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    isPizzaRetrieved = true;
                    map[currentRow, currentCol] = 'R';
                }
                if (map[currentRow,currentCol]=='A'&&isPizzaRetrieved)
                {
                    map[currentRow, currentCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }

            }

            PrintCurrentMap(map);

        }
        public static void PrintCurrentMap(char[,] map)
        {
            for (int row = 0; row<map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    Console.Write(map[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsIndexCorrect(int row, int col, char[,] map)
        {
            if (row>=0&&col>=0&&row<map.GetLength(0)&&col<map.GetLength(1)) return true;
            else return false;
        }
    }
   
}
