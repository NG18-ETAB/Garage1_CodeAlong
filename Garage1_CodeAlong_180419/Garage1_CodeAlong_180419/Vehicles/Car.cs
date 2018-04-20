﻿namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Car : Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public Car(string regNr, uint nrOfWheels, string color, string fuelType, string make, string model) : base(regNr, nrOfWheels, color, fuelType)
        {
            Make = make;
            Model = model;
        }

        public override string Print()
        {
            return $"The Car of {base.Print()}, is the make {Make} and is of model {Model}";
        }
    }
}
