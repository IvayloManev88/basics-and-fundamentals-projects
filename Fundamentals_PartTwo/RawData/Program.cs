namespace RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List <Car> cars = new();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Car currentCar = new(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                cars.Add(currentCar);

            }
            if (Console.ReadLine() == "fragile")
            {
                List<Car> filteredCars = cars.Where(car=> car.Cargo.Type== "fragile" && car.Cargo.Weight<1000).ToList();
                foreach (Car car in filteredCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                List<Car> filteredCars = cars.Where(car => car.Cargo.Type == "flamable" && car.Engine.Power >250).ToList();
                foreach (Car car in filteredCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }

        public class Car
        {
            public Car(string model, int speed, int power, int weight, string type)
            {
                Model = model;
             Engine engine = new(speed, power);
                
               Cargo cargo = new(weight, type);
                this.Engine=engine;
                
                this.Cargo=cargo;
               
                
            }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        }
            public class Engine
            {
           public Engine(int speed, int power)
           {
               Speed = speed;
               Power = power;
           }
                public int Speed { get; set; }
                public int Power { get; set; }
            }
            public class Cargo
            {
           public Cargo(int weight, string type)
           {
               Weight = weight;
               Type = type;
           }
            public int Weight { get; set; }
            public string Type { get; set; }
            }
        
    }   
}
