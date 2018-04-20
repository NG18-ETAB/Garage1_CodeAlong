using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Motorcycle: Vehicle
    {
        public Motorcycle(string regNr, uint nrOfWheels, string color, string fuelType, int cylinderCapacity, bool isTrike): base(regNr, nrOfWheels,color,fuelType)
        {
            CylinderCapacity = cylinderCapacity;
            IsTrike = isTrike;
        }

        public int CylinderCapacity { get; set; }
        public bool IsTrike { get; set; }
        public override string Print()
        {
            return "Motorcycle\n" + base.Print() + "\nCyling capacty:\t" + CylinderCapacity + "\nIs it Trike:\t" + IsTrike;
        }
    }
}
 