using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
   public class Buss:Vehicle
    {
        public bool IsDoubleDecker { get; set;}
        public uint NrOfSeats { get; set; }

        public Buss(string regNr,uint nrOfWheels,string color,string fuelType,bool isDoubleDecker,uint nrOfSeats):base(regNr,nrOfWheels,color,fuelType)
        {
            IsDoubleDecker = isDoubleDecker;
            NrOfSeats = nrOfSeats;
        }
        public override string Print()
        {
            return "Buss\n" + base.Print() + "\nIt is a double decker:\t\t" + IsDoubleDecker + "+\nNumber of Seats:\t\t\t" + NrOfSeats;
        }
    }
}
