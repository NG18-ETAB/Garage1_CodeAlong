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

        public Airplane(string regNr, uint nrOfWheels, string color, string fuelType, int wingSpan, string model):base(regNr,nrOfWheels,color, fuelType)
        {
            WingSpan = wingSpan;
                Model = model;
        }
        public override string Print()
        {
            return "The Airplane\n" + base.Print() +
                "\nWingspan:\t" + WingSpan +
                "\nModel:\t\t\t" + Model;
        }
    }
}
