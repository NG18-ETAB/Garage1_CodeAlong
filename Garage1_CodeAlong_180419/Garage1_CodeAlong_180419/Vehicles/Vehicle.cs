using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Vehicle
    {
        public string RegNr { get; set; }

        public uint NrOfWheels { get; set; } // if we don't need to use negative numbers in our code we can use uint

        public string  Color { get; set; }

        public string FuelType { get; set; }

        public Vehicle( string regNr ,uint nrOfWheels, string color, string fuelType)
        {
            RegNr = regNr;

            NrOfWheels = nrOfWheels;

            Color = color;

            FuelType = fuelType;
        }
    }
}
