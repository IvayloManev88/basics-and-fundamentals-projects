namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> carList = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string carName = carInfo[0];
                Engine carEngine = new Engine()
                {
                    Speed = int.Parse(carInfo[1]),
                    Power = int.Parse(carInfo[2]),
                };
                Cargo carCargo = new Cargo()
                {
                    Type = carInfo[4],
                    Weight = int.Parse(carInfo[3])
                };
                Tire[] carTires = new Tire[4]
                {
                    new Tire(float.Parse(carInfo[5]),int.Parse(carInfo[6])),
                    new Tire(float.Parse(carInfo[7]),int.Parse(carInfo[8])),
                    new Tire(float.Parse(carInfo[9]),int.Parse(carInfo[10])),
                    new Tire(float.Parse(carInfo[11]),int.Parse(carInfo[12]))
                };
                Car currentCar = new(carName,carEngine,carCargo,carTires);
                carList.Add(currentCar);
            }
            string command = Console.ReadLine();
            List<Car> resultCars = new List<Car>();
            if (command == "fragile")
            {
               resultCars = carList.Where(c=>c.Cargo.Type==command&&c.Tires.Any(t=>t.Pressure<1)).ToList();
            }
            else if (command == "flammable")
            {
                resultCars = carList.Where(c => c.Cargo.Type == command && c.Engine.Power>250).ToList();
            }
            foreach (Car car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
