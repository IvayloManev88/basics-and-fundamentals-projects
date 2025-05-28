namespace Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0] + " "+ input[1];
            string place = input[2];
            string city = input[3];
            if (input.Length > 4)
            {
                city += " " + input[4]; 
            }
            
            Threeuple<string,string,string> firstThreeuple = new(name, place, city);

            input = Console.ReadLine().Split();
            name = input[0];
            int liters = int.Parse(input[1]);
            
            bool isDrunk = (input[2]=="drunk")?true : false;

            Threeuple<string, int, bool> secondThreeuple = new(name, liters, isDrunk);

            input = Console.ReadLine().Split();
            name = input[0];
            double balance = double.Parse(input[1]);
            string bankName = input[2];

            Threeuple<string, double, string> thirdThreeuple = new(name, balance, bankName);

            firstThreeuple.Print();
            secondThreeuple.Print();
            thirdThreeuple.Print();
        }
    }
}
