namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                switch (inputs[0])
                {
                    case "IN":
                        {
                            parkingLot.Add(inputs[1]);
                            break;
                        }
                    case "OUT":
                        {
                            parkingLot.Remove(inputs[1]);
                            break;
                        }
                }
            }
            if (parkingLot.Count > 0)
            {
                Console.WriteLine(string.Join("\n", parkingLot));
            }
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
