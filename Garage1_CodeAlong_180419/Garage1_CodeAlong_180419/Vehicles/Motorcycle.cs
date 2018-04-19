﻿namespace Garage1_CodeAlong_180419.Vehicles
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
    }
}
