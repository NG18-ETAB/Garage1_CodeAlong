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
        public Car(string regNr, uint nrOfWheels, string color, string feulType, string make, string model) : base(regNr, nrOfWheels, color, feulType)
        {
            Make = make;
            Model = model;
        }
    }
}
