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
        public uint NrOfWheels { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }


        public Vehicle (string regNr, uint nrOFWheels, string color, string fuelType)
        {
            RegNr = regNr; // regnumber the property lika med reg nr string in the constructor, that we get when we create a instance of vehicle?
            NrOfWheels = nrOFWheels;
            Color = color;
            FuelType = fuelType;
        }
    }
}
