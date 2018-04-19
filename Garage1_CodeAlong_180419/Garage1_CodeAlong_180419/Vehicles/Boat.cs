using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Boat : Vehicle
    {
        public uint LenghtInFeet { get; set; }

        public bool IsSailBoat { get; set; }

        public Boat(string regNr, uint nrOfWheels, string color, string feulType,uint lenghtInFeet,bool isSailBoat) : base(regNr, nrOfWheels, color, feulType)
        {
            LenghtInFeet = lenghtInFeet;
            IsSailBoat = isSailBoat;
        }
    }
}
