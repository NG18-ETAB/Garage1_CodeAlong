namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Vehicle
    {
        public string RegNr { get; protected set; }
        public uint NrOfWheels { get; protected set; }
        public string Color { get; set; }
        public string FuelType { get; set; }

        public Vehicle(string regNr, uint nrOfWheels, string color, string fuelType)
        {
            RegNr = regNr;
            NrOfWheels = nrOfWheels;
            Color = color;
            FuelType = fuelType;
        }

        public virtual string Print()
        {
            return $"registration number {RegNr}, {NrOfWheels} wheels, is of color {Color}, runs on {FuelType}";
        }
    }
}
