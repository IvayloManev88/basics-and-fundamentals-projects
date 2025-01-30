namespace ArrayModifierExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            string command= string.Empty;
            int index1 = 0;
            int index2 = 0;
            while ((command=Console.ReadLine())!="end")
            {
                string[] commands = command.Split().ToArray();
                switch (commands[0])
                {
                    case "swap":
                        int helpValue = 0;
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        helpValue=numbers[index1];
                        numbers[index1] = numbers[index2];
                        numbers[index2] = helpValue;

                    break;
                    case "multiply":
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        numbers[index1] *= numbers[index2];
                        break;
                    case "decrease":
                        for (int i =0; i<numbers.Length; i++)
                        {
                            numbers[i] -= 1;
                        }
                        break;


                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
