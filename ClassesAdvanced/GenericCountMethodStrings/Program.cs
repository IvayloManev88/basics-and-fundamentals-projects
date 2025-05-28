namespace GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> listString = new();
            for (int i = 0; i < n; i++)
            {

                listString.Add(double.Parse(Console.ReadLine()));
                

                
            }

            Console.WriteLine(listString.Counter(double.Parse(Console.ReadLine())));
        }
    }
}
