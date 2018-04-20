﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Vehicle
    {
        public string RegNr { get; set; }

        public uint NrOfWheels { get; set; }

        public string Color { get; set; }

        public string FeulType { get; set; }

        public Vehicle(string regNr, uint nrOfWheels, string color, string feulType)
        {
            RegNr = regNr;
            NrOfWheels = nrOfWheels;
            Color = color;
            FeulType = feulType;
        }
        public virtual string Print()
        {
            return "Registration number:\t" + RegNr + "\nNumber of wheels:\t" + NrOfWheels + "\nColor:\t\t\t" + Color + "nFuel type:\t\t" + FeulType;
        }
    }
}
