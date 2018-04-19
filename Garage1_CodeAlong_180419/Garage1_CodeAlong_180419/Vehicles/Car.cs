using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Car : Vehicle
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public Car(string regnr, uint nrOfWeels, string color, string fuelType, string make, string model) : base(regnr, nrOfWeels, color, fuelType)
        {
            Make = make;
            Model = model;
        }
    }
}
