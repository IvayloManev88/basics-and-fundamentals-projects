﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Engine
    {
		private int speed;
		private int power;

		public int Power
		{
			get { return power; }
			set { power = value; }
		}

		public int Speed
        {
			get { return speed; }
			set { speed = value; }
		}
	}
}
