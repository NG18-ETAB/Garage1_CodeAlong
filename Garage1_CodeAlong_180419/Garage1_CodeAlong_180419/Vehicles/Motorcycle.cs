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

        public Motorcycle(string regNr, uint nrOfWheels, string color, string feulType,int cylinderCapacity,bool isTrike) : base(regNr, nrOfWheels, color, feulType)
        {
            CylinderCapacity = cylinderCapacity;
            IsTrike = isTrike;
        }
        public override string Print()
        {
            return "Motorcycle\n" + base.Print() + "\nCylinder Capacity:\t" + CylinderCapacity + "\nIt is a Trike:\t" + IsTrike;
        }
    }
}
