using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Motorcycle : Vehicle

    {
        public int CylinderCapacity { get; set; }
        public bool IsTrike { get; set; }

        public Motorcycle(string regNr, uint nrOfWheels, string color, string fuelType, int cylinderCapacity, bool isTryke):base(regNr,nrOfWheels,color,fuelType)
        {
            CylinderCapacity = cylinderCapacity;
            IsTrike = isTryke;
        }
        public override string Print()
        {
            return "The Motorcycle\n" + base.Print() +
                "\ncC:\t\t\t" + CylinderCapacity +
                "\nIs it a trike?:\t" + IsTrike;
        }
    }
}
