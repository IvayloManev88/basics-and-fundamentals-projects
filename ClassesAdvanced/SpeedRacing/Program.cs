namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> carList = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Car newCar = new(inputs[0], double.Parse(inputs[1]), double.Parse(inputs[2]));
                carList.Add(newCar);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carName = inputs[1];
                double distance = double.Parse(inputs[2]);
                Car currentCar = carList.First(c => c.Model == carName);
                currentCar.Drive(distance);
            }
            foreach (Car car in carList)
               car.PrintProperties();
            
        }
    }
}
