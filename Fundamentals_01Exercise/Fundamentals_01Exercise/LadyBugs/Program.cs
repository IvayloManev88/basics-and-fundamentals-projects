namespace LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] inputField = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < inputField.Length; i++) 
            {
                if (inputField[i] >= 0 && inputField[i] < field.Length)
                {
                    field[inputField[i]] = 1;
                }
            }

            string input = "";
            while ((input=Console.ReadLine())!="end")
            {
                string[] commandInput = input.Split().ToArray();
                int index = int.Parse (commandInput[0]);
                string direction = commandInput[1];
                int steps = int.Parse (commandInput[2]);
                
                if (index>=0 && index< field.Length && field[index]==1)
                {
                    field[index] = 0;
                    
                    if (direction == "right")
                    {
                        int landPosition = index + steps;
                        if (landPosition >= 0 && landPosition < field.Length)
                        {
                            while (field[landPosition] == 1)
                            {
                                landPosition += steps;
                                if (landPosition<0 || landPosition> field.Length-1)
                                {
                                    break;
                                }
                            }

                        }
                        else 
                        { 
                            continue; 
                        }
                        if (landPosition >= 0 && landPosition < field.Length && field[landPosition]==0)
                        {
                            field[landPosition] = 1;
                        }
                    }
                    if (direction == "left")
                    {
                        int landPosition = index - steps;
                        if (landPosition >= 0 && landPosition < field.Length)
                        {
                            while (field[landPosition] == 1)
                            {
                                landPosition -= steps;
                                if (landPosition < 0 || landPosition > field.Length - 1)
                                {
                                    break;
                                }
                            }

                        }
                        else
                        {
                            continue;
                        }
                        if (landPosition >= 0 && landPosition < field.Length && field[landPosition] == 0)
                        {
                            field[landPosition] = 1;
                        }
                    }

                }
            }
            Console.WriteLine (string.Join(" ", field));
        }
    }
}
