using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuel, double consumption) 
        {
            Model = model;
            FuelAmount = fuel;
            Consumption= consumption;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double Consumption { get; set; }
        public double Distance { get; set; }

        public void Drive(double distance)
        {
            double currentConsumption = this.Consumption*distance;
            if (this.FuelAmount >= currentConsumption)
            {
                this.Distance += distance;
                this.FuelAmount -= currentConsumption;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
        public void PrintProperties()
        {
            Console.WriteLine($"{this.Model} {this.FuelAmount:f2} {this.Distance}");
        }
    }

}
