using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
		public Car(string carModel, Engine carEngine, Cargo carCargo, Tire[] carTires)
		{
			model = carModel;
			engine = carEngine;
			cargo=carCargo;
			tires = carTires;
		}
		private string model;
		private Engine engine;
		private	Cargo cargo;
		private Tire[] tires = new Tire[4];

		public Tire[] Tires
		{
			get { return tires ; }
			set { tires = value; }
		}



		public  Cargo Cargo
		{
			get { return cargo; }
			set { cargo = value; }
		}


		public Engine Engine
        {
			get { return engine; }
			set { engine = value; }
		}


		public string Model
		{
			get { return model; }
			set { model = value; }
		}

	}
}
