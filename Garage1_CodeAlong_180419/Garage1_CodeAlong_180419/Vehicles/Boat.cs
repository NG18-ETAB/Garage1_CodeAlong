namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Boat : Vehicle
    {
        public uint LengthInFeet { get; set; }
        public bool IsSailBoat { get; set; }

        public Boat(string regNr, uint nrOfWheels, string color, string fuelType, uint lengthInFeet, bool isSailBoat) : base(regNr, nrOfWheels, color, fuelType)
        {
            LengthInFeet = lengthInFeet;
            IsSailBoat = isSailBoat;
        }

        public override string Print()
        {
            return $"The Boat of {base.Print()}, is {LengthInFeet} feet long and is {(IsSailBoat?"not ":"")}a sail boat";
        }
    }
}
