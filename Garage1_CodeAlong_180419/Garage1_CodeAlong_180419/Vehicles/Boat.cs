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
        public bool IsSailBoat { get; set; }
        public Boat(string regNr , uint nrOfWheels , string color , string fuelType , uint lengthInFeet , bool isSailBoat): 
            base(regNr, nrOfWheels , color, fuelType)
        {
            LengthInFeet = lengthInFeet;
            IsSailBoat = isSailBoat;
        }
        public override string Print()
        {
            return "Boat\n" + base.Print() + "\nLength in Feet:\t\t\t" + LengthInFeet + " \nIs it a Sail Boat:\t\t\t" + IsSailBoat;
        }
    }
}
