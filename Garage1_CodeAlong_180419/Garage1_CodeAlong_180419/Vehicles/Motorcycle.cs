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

        public Motorcycle(string regNr, uint nrOfWheels, string color, string fuelType, int cylinderCapacity, bool isTrike) : base(regNr, nrOfWheels, color, fuelType)
        {
            CylinderCapacity = cylinderCapacity;
            IsTrike = isTrike;
        }
        public override string Print()
        {
            return "Motorcycle\n" + base.Print() + "\nCylinderCapacity:\t\t" + CylinderCapacity + "+\nIt is a tricycle:\t\t\t" + IsTrike;
        }
    }
}
