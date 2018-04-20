using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
   public class Vehicle
   {
           public string RegNr { get; set; }
          
           public uint NrOfWheels { get; set; }

          public string Color { get; set; }

          public string FuelType { get; set; }

          public Vehicle (string regNr, uint nrOfWheels,string color,string fuelType)
          {
            RegNr = regNr;
            NrOfWheels = nrOfWheels;
            Color = color;
            FuelType = fuelType;
          }
        public virtual string Print()
        {
            return "Registration number:\t" + RegNr + "\n Number of wheels:\t" + NrOfWheels + "\nColor:\t\t" + Color + "\nFuelType:\t " + FuelType;
        }
   }
}
