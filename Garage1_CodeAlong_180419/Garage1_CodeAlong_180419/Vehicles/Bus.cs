namespace Garage1_CodeAlong_180419.Vehicles
{
    public class Bus : Vehicle
    {
        public bool IsDoubleDecker { get; set; }
        public uint NrOfSeats { get; set; }

        public Bus(string regNr, uint nrOfWheels, string color, string fuelType, bool isDoubleDecker, uint nrOfSeats) : base(regNr, nrOfWheels, color, fuelType)
        {
            IsDoubleDecker = isDoubleDecker;
            NrOfSeats = nrOfSeats;
        }

        public override string Print()
        {
            return $"The Bus of {base.Print()}, is {(IsDoubleDecker ? "not ":"")}a double decker and has {NrOfSeats} seats";
        }
    }
}
