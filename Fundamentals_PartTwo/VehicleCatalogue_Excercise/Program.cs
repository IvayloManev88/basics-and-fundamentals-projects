using System;

namespace VehicleCatalogue_Excercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string input = string.Empty;

            List<Vehicle> catalogue = new ();
            while ((input=Console.ReadLine())!= "End")
            {
                List<string> inputs = input.Split().ToList();
                Vehicle currentVehicle = new()
                {
                    Type= inputs[0],
                    Model = inputs[1],
                    Color = inputs[2],
                    Horsepower = double.Parse(inputs[3])
                };
                catalogue.Add(currentVehicle);
            }
            while ((input=Console.ReadLine())!="Close the Catalogue")
            {
                for (int i = 0; i < catalogue.Count; i++)
                {
                    if (catalogue[i].Model== input)
                    {
                        if (catalogue[i].Type == "car") Console.WriteLine("Type: Car");
                        else Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {catalogue[i].Model}");
                        Console.WriteLine($"Color: {catalogue[i].Color}");
                        Console.WriteLine($"Horsepower: {catalogue[i].Horsepower}");
                    }
                }
            }

            double horsePowerCar = 0;
            int countCars = 0;
            double HorsePowerTruck = 0;
            int countTrucs = 0;
            foreach (Vehicle vehicle in catalogue)
            {
                if (vehicle.Type == "car")
                {
                    horsePowerCar += vehicle.Horsepower;
                    countCars++;
                }
                else
                { 
                    HorsePowerTruck += vehicle.Horsepower;
                    countTrucs++;
                }
            }
            if (countCars > 0) Console.WriteLine($"Cars have average horsepower of: {horsePowerCar/(double)countCars:f2}.");
            else Console.WriteLine($"Cars have average horsepower of: 0.00.");
            if (countTrucs>0) Console.WriteLine($"Trucks have average horsepower of: {HorsePowerTruck/(double)countTrucs:f2}.");
            else Console.WriteLine($"Trucks have average horsepower of: 0.00.");
        }
    }
    
    public class Vehicle
    {

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Horsepower { get; set; }

    }
    
}