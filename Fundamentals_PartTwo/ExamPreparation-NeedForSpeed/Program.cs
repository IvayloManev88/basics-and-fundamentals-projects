namespace ExamPreparation_NeedForSpeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> garage  = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i =0; i<numberOfCars;i++)
            {
                string[] inputCars = Console.ReadLine().Split("|");
                Car inputCar = new (inputCars[0], int.Parse(inputCars[1]), int.Parse(inputCars[2]));
                garage.Add(inputCar);
            }
            string command=string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commands = command.Split(" : ");
                switch (commands[0])
                {
                    case "Drive":
                        Car currentCar = garage.FirstOrDefault(car=> car.Name ==commands[1]);
                        if (currentCar.Fuel < int.Parse(commands[3])) Console.WriteLine("Not enough fuel to make that ride");
                        else
                        {
                            int distance = int.Parse(commands[2]);
                            int fuel = int.Parse(commands[3]);
                            currentCar.Fuel -= fuel;
                            currentCar.Mileage += distance;
                            Console.WriteLine($"{currentCar.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (currentCar.Mileage>=100000)
                            {
                                Console.WriteLine($"Time to sell the {currentCar.Name}!");
                                garage.Remove(currentCar);
                            }
                        }
                        break;
                    case "Refuel":
                        int refuel = int.Parse(commands[2]);
                        Car refuelCar = garage.FirstOrDefault(car => car.Name == commands[1]);
                        if (refuel+refuelCar.Fuel>75)
                        {
                            refuel = 75-refuelCar.Fuel;
                        }
                        refuelCar.Fuel += refuel;
                        Console.WriteLine($"{refuelCar.Name} refueled with {refuel} liters");
                        break;
                    case "Revert":
                        int decreaseKms = int.Parse(commands[2]);
                        Car decreaseKmsCar = garage.FirstOrDefault(car => car.Name == commands[1]);
                        if (decreaseKmsCar.Mileage - decreaseKms >= 10000)
                        {
                            decreaseKmsCar.Mileage -= decreaseKms;
                            Console.WriteLine($"{decreaseKmsCar.Name} mileage decreased by {decreaseKms} kilometers");
                        }
                        else decreaseKmsCar.Mileage = 10000;
                        break;
                }
            }
            foreach (Car car in garage)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            } 

        }
    }
    public class Car
    {
        public Car(string name, int miles, int fuel)
        {
            Name = name;
            Mileage = miles;
            Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
