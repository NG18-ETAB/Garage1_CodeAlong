using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Bus : Vehicle
    {
        public bool IsDoubleDecker { get; set; }
        public uint NrOfseats { get; set; }

        public Bus(string regNr, uint nrOfWheels , string color , string  fuelType , bool isDoubleDecker , uint nrOfSeats ):
            base (regNr, nrOfWheels, color, fuelType)

        {
            IsDoubleDecker = isDoubleDecker;
            NrOfWheels = nrOfWheels; //suppose to be number of seats not number of Wheels
        }
        public override string Print()
        {
            return "Bus\n" + base.Print() + "\nIt is a Double Decker:\t" + IsDoubleDecker + " \nNumber of Wheels :\t\t\t" + NrOfWheels;
        }


    }
}
