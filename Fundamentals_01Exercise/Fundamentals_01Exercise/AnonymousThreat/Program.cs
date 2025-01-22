using System.ComponentModel.Design;

namespace AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split()
                .ToList();
            string command=string.Empty;
            while ((command=Console.ReadLine())!="3:1")
            {
                List<string> commands = command
                .Split()
                .ToList();
                if (commands[0] == "merge")
                {
                    int startIndex = 0;
                    if (int.Parse(commands[1]) > 0) startIndex = int.Parse(commands[1]);
                    if (startIndex >= list.Count) continue;
                    int endIndex = 0;
                    if (int.Parse(commands[2]) >= list.Count) endIndex = list.Count - 1;
                    else endIndex = int.Parse(commands[2]);
                    string concatenatedString = string.Empty;
                    int count = 0;
                    for (int i= startIndex; i<=endIndex;i++)
                    {
                        concatenatedString += list[i];
                        
                        count++;
                    }
                    for (int i = 1; i <= count; i++)
                    {
                        list.RemoveAt(startIndex);
                    }
                    list.Insert(startIndex, concatenatedString);
                }

                if (commands[0] == "divide")
                {
                    int index = int.Parse (commands[1]);
                    int positions = int.Parse(commands[2]);
                    string toDivide = list[index];
                    list.RemoveAt(index);
                    int elementsLength = (int)toDivide.Length / positions;
                    for (int i = 0; i < positions; i++)
                    {
                        if ((i + 1) != positions)
                        {
                            list.Insert(index + i, toDivide.Substring(0, elementsLength));
                            toDivide = toDivide.Substring(elementsLength);
                        }
                        else list.Insert(index + i, toDivide);

                    }
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
