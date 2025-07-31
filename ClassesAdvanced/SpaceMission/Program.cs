using System.Drawing;

namespace SpaceMission
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] spaceMap = new char[size,size];
            int shipRow = -1;
            int shipCol = -1;
            int fuel = 100;
            for (int rows = 0; rows < size; rows++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray() ;
                for (int cols = 0; cols < size; cols++)
                {
                    spaceMap[rows,cols] = line[cols];
                    if (spaceMap[rows,cols] == 'S')
                    {
                        shipCol = cols;
                        shipRow = rows;
                        
                    }
                }

            }
            bool isOutOfBounds = false;
            bool isMissionAccomplished = false;
            
            
            while (!isOutOfBounds&&fuel>0)
            {
                string command = Console.ReadLine();
                fuel -= 5;
                if (spaceMap[shipRow, shipCol] == 'S') spaceMap[shipRow, shipCol] = '.';
                if (command =="up")
                {
                    if (isNewIndexCorrect(spaceMap,shipRow-1,shipCol))
                    {
                        shipRow--;
                    }
                    else
                    {
                        
                        isOutOfBounds = true;
                        break;
                    }
                }
                if (command == "down")
                {
                    if (isNewIndexCorrect(spaceMap, shipRow + 1, shipCol))
                    {
                        shipRow++;
                    }
                    else
                    {
                        
                        isOutOfBounds = true;
                        break;
                    }
                }
                if (command == "left")
                {
                    if (isNewIndexCorrect(spaceMap, shipRow, shipCol-1))
                    {
                        shipCol--;
                    }
                    else
                    {
                        
                        isOutOfBounds = true;
                        break;
                    }
                }
                if (command == "right")
                {
                    if (isNewIndexCorrect(spaceMap, shipRow, shipCol + 1))
                    {
                        shipCol++;
                    }
                    else
                    {
                        
                        isOutOfBounds = true;
                        break;
                    }
                }
                if (spaceMap[shipRow, shipCol] == 'R')
                {
                    fuel += 10;
                    if (fuel > 100) fuel = 100;
                }
                else if (spaceMap[shipRow, shipCol] == 'M')
                {
                    fuel -= 5;
                    spaceMap[shipRow, shipCol] = '.';
                    if (fuel<5) break;
                }
                else if (spaceMap[shipRow, shipCol] == 'P')
                {
                    isMissionAccomplished = true;
                    Console.WriteLine($"Mission accomplished! The spaceship reached Planet Eryndor with {fuel} resources left.");
                    break;
                }
                else spaceMap[shipRow, shipCol] = 'S';


            }
            if (isOutOfBounds)
            {
                if (spaceMap[shipRow, shipCol] == '.') spaceMap[shipRow, shipCol] = 'S';
                Console.WriteLine("Mission failed! The spaceship was lost in space.");
            }
            else if (fuel <= 0 && !isMissionAccomplished)
            {
                spaceMap[shipRow, shipCol] = 'S';
                Console.WriteLine("Mission failed! The spaceship was stranded in space.");
            }

            PrintMap(spaceMap);
        }
        public static void PrintMap(char[,] map)
        {
            for (int rows = 0; rows < map.GetLength(0); rows++)
            {
                for (int cols = 0; cols < map.GetLength(1); cols++)
                {
                    if (cols < map.GetLength(1) - 1)
                        Console.Write(map[rows, cols] + " ");
                    else Console.Write(map[rows, cols]);
                }
                Console.WriteLine();
            }
        }
        public static bool isNewIndexCorrect(char[,] map, int rows, int cols)
        {
            if (rows < 0 || cols < 0 || rows >= map.GetLength(0) || cols >= map.GetLength(1))
                return false;
            else return true;
        }
    }
}
