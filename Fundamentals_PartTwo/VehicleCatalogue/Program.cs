namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Catalog catalogue = new Catalog();
            while ((input = Console.ReadLine())!="end")
            {
                string[] tokens = input.Split("/");
                if (tokens[0]=="Car")
                {
                    Car currentCar = new Car
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        HorsePower = int.Parse(tokens[3])
                    };
                    catalogue.Cars.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = int.Parse(tokens[3])
                    };
                    catalogue.Trucks.Add(currentTruck);
                }
                
            }
            if (catalogue.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogue.Cars.OrderBy(c=>c.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (Car outputCar in orderedCars)
                {
                    Console.WriteLine($"{outputCar.Brand}: {outputCar.Model} - {outputCar.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(t => t.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (Truck outputTruck in orderedTrucks)
                {
                    Console.WriteLine($"{outputTruck.Brand}: {outputTruck.Model} - {outputTruck.Weight}kg");
                }
            }
        }
    }
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    public class Car
    {
        public string Brand { set; get; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    public class Catalog
    {
        public Catalog()
            {
            this.Cars=new List<Car>();
            this.Trucks= new List<Truck>();
            }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
