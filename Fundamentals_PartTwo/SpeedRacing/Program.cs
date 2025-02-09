namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars= int.Parse(Console.ReadLine());
            List <Car> cars = new List<Car>();
            string token= string.Empty;
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Car currentCar = new Car(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
                cars.Add(currentCar);
            }
            while ((token=Console.ReadLine())!= "End")
            {
                string[] tokens = token.Split();
                string modelName = tokens[1];
                double kmToTravel = double.Parse(tokens[2]);
                Car carToMove = cars.FirstOrDefault(c => c.Model == modelName);
                carToMove.MoveCar(kmToTravel);
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelDistance} ");
            }

        }
        public class Car
        {
            public Car(string model, double fuelAmount, double fuelConsumption)
            {
                Model = model;
                FuelAmount = fuelAmount;
                FuelConsumption = fuelConsumption;
                TravelDistance = 0;
            }
            public string Model { get; set; }
            public double FuelAmount { get; set; }
            public double FuelConsumption { get; set; }
            public double TravelDistance { get; set; }

            public void MoveCar(double kmToTravel)
            {
                double fuelAmountNeeded = kmToTravel * FuelConsumption;
                if (FuelAmount >= fuelAmountNeeded)
                {
                    FuelAmount -= fuelAmountNeeded;
                    TravelDistance += kmToTravel;
                }
                else Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
