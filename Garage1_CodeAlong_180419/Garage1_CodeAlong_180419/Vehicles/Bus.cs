using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Bus : Vehicle
    {
        public bool IsDubleDecker { get; set; }
        public uint NrOfSeats { get; set; }

        public Bus(string regNr, uint nrOfWheels, string color, string fuelType, bool isDubleDecker, uint nrOfSeats) : base(regNr, nrOfWheels, color, fuelType)
        {
            IsDubleDecker = isDubleDecker;
            NrOfSeats = nrOfSeats;
        }

    }
}
