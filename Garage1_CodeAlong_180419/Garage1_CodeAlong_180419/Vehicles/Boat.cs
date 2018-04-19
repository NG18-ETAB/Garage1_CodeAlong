using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Boat : Vehicle
    {
        public uint LengthInFeet { get; set; }

        public bool IsSailboat { get; set; }

        public Boat(string regnr, uint nrOfWeels, string color, string fuelType, uint lengthInFeet, bool isSailboat) : base(regnr, nrOfWeels, color, fuelType)
        {
            LengthInFeet = lengthInFeet;
            IsSailboat = isSailboat;
        }
    }
}
