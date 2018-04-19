using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Airplane : Vehicle
    {
        public int WingSpan { get; set; }

        public string Model { get; set; }

        public Airplane(string regnr, uint nrOfWeels, string color, string fuelType, int wingSpan, string model) : base(regnr, nrOfWeels, color, fuelType)
        {
            WingSpan = wingSpan;
            Model = model;
        }
    }
}
