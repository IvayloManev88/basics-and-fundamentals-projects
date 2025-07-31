namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main()
        {
            Vehicle vehicle = new Vehicle(100, 100);
            vehicle.Drive(100);
            Console.WriteLine(vehicle.Fuel);
            SportCar sportsCar = new SportCar(100,100);
            sportsCar.Drive(100);
            Console.WriteLine(sportsCar.Fuel);
            Motorcycle motorcycle = new Motorcycle(100,100);
            motorcycle.Drive(100);
            Console.WriteLine(motorcycle.Fuel);
            CrossMotorcycle cross = new CrossMotorcycle(100,100);
            cross.Drive(100);
            Console.WriteLine(cross.Fuel);
        }
    }
}
