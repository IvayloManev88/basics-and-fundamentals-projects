using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
		public Tire(float tirePressure, int tireAge)
		{
			age = tireAge;
			pressure = tirePressure;
		}
		private int age;
		private float  pressure;

		public float Pressure
        {
			get { return pressure; }
			set { pressure = value; }
		}


		public int Age
		{
			get { return age; }
			set { age = value; }
		}

	}
}
