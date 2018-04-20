using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Boat :Vehicle
    {
        public uint LenghtInFeet { get; set; }
        public bool IsSailBoat { get; set; }

        public Boat(string regNr, uint nrOfWheels, string color, string fuelType, uint lenghtInFeet, bool isSailBoat):base(regNr,nrOfWheels,color,fuelType)
        {
            LenghtInFeet = lenghtInFeet;
            IsSailBoat = isSailBoat;
        }

        public override string Print()
        {
            return "The Boat\n" + base.Print() +
                "\nLengt in Feet:\t" + LenghtInFeet +
                "\nIs it a Sailboat?:\t" + IsSailBoat;
        }
    }
}
