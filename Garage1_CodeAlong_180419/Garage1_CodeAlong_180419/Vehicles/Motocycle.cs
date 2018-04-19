using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Motocycle : Vehicle
    {
        public int CylinderCapacity { get; set; }

        public bool Istrike { get; set; }

        public Motocycle(string regnr, uint nrOfWeels, string color, string fuelType, int cylinderCapacity, bool istrike) : base(regnr, nrOfWeels, color, fuelType)
        {
            CylinderCapacity = cylinderCapacity;
            Istrike = istrike;
        }
    }
}
