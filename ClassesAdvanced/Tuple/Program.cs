namespace Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0] + " " + input[1];
            string address = input[2];
            Tuple<string,string> firstTuple = new Tuple<string, string>(name, address);
            
            string[] input1 = Console.ReadLine().Split();
            string name1 = input1[0];
            int liters = int.Parse(input1[1]);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name1, liters);

            string[] input2 = Console.ReadLine().Split();
            int integer = int.Parse(input2[0]);
            double doubleItem = double.Parse(input2[1]);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(integer, doubleItem);
            firstTuple.Print();
            secondTuple.Print();
            thirdTuple.Print();
            

        }
    }
}
