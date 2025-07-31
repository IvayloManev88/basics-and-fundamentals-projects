namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList { "ala", "bala", "portokala" };
            Console.WriteLine( list.RandomString());
        }
    }
}
