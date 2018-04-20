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

        public Car(string regNr, uint nrOFWheels, string color, string fuelType, string make, string model) : base(regNr, nrOFWheels, color, fuelType)
        {
            Make = make;
            Model = model;
        }

        public override string Print()
        {
            return "The Car\n" + base.Print() +
                "\nMake:\t\t\t" + Make +
                "\nModel:\t\t\t" + Model;
        }
    }
}
