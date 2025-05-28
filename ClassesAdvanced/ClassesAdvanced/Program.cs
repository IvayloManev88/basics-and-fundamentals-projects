namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;
            List <Car> carList = new List <Car> ();
            List<Tire[]> tiresList = new List <Tire[]> ();
            List<Engine> engineList = new List <Engine> ();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputs = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Tire[] tire = new Tire[4]
                {
                   new Tire (int.Parse(inputs[0]), double.Parse(inputs[1])),
                   new Tire (int.Parse(inputs[2]), double.Parse(inputs[3])),
                   new Tire (int.Parse(inputs[4]), double.Parse(inputs[5])),
                   new Tire (int.Parse(inputs[6]), double.Parse(inputs[7]))
                };
                tiresList.Add(tire);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new(int.Parse(inputs[0]), double.Parse(inputs[1]));

                engineList.Add(currentEngine);
            }
            
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] inputs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Car currentCar = new Car(inputs[0], inputs[1], int.Parse(inputs[2]), double.Parse (inputs[3]), double.Parse(inputs[4]), engineList[int.Parse(inputs[5])], tiresList[int.Parse(inputs[6])]);
                carList.Add(currentCar);
                
            }
            List <Car> specialCars = carList
                .Where(car=> car.Year>=2017
                &&car.Engine.HorsePower>330 
                &&car.Tires.Sum(t=>t.Pressure)>9
                && car.Tires.Sum(t => t.Pressure) < 10).ToList();
            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());

            }
        }
    }
}
