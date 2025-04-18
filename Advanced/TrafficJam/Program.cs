namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsGoGreen = int.Parse(Console.ReadLine());
            string input = string.Empty;
            Queue<string> cars = new();
            int carCounter = 0;
            while ((input=Console.ReadLine()) != "end")
            {
                if (input=="green")
                {                  
                    int carCanGo= (cars.Count >= carsGoGreen)? carsGoGreen : cars.Count;
                    for (int i = 0; i < carCanGo; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carCounter++;
                    }
                                        
                }
                else cars.Enqueue(input);
            }
            Console.WriteLine($"{carCounter} cars passed the crossroads.");
        }
    }
}
