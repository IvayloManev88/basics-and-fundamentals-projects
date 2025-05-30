﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    internal class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this (make, model, year,  fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Tire[] Tires
        {
              get { return tires; }
              set { tires = value; }
        }



        public string Make 
        { 
            get { return make; }
            set {make = value;}        
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double usedFuel = distance * fuelConsumption / 100;
            if (fuelQuantity - usedFuel > 0)
            {
                fuelQuantity-= usedFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }

        }
        
        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.make}");
            result.AppendLine($"Model: {this.model}");
            result.AppendLine($"Year: {this.year}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            
            result.AppendLine($"FuelQuantity: {this.fuelQuantity}");
            return result.ToString().TrimEnd();
        }
    }
}
