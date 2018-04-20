﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Bus: Vehicle
    {
        public bool IsDoubleDecker { get; set; }
        public uint NrOfSeats { get; set; }

        public Bus(string regNr, uint nrOfWheels, string color, string fuelType, bool isDoubleDecker, uint nrOfSeats): base (regNr, nrOfWheels,color,fuelType)
        {
            IsDoubleDecker = isDoubleDecker;
            NrOfSeats = nrOfSeats;
        }
        public override string Print()
        {
            return "Bus\n" + base.Print() + "\nIs it a double decker:\t" + IsDoubleDecker + "\nNumber of seats:\t" + NrOfSeats;
        }

    }
}
