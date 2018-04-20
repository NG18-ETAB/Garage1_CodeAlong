using Garage1_CodeAlong_180419.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419
{
    public class UI
    {
        private Garage<Vehicle> _garage;       // using the garage vehicle. private fields so we have the same garage to work with
        public void MainMenu()
        {
            GenerateGarage(); // cant leave the meny until they do something. 
            if (_garage == null)
            {
                return;
            }
            bool quitProgram = false;

            do
            {
                Console.WriteLine("Welcome to the Garage");
                Console.WriteLine("1: Park Vehicle");
                Console.WriteLine("2: Unpark Vechile");
                Console.WriteLine("3: List all parked Vehicle");
                Console.WriteLine("4: List all Vehicle type currently parked");
                Console.WriteLine("5: Search for Vehicle");
                Console.WriteLine("0: Quit");
                string input = Console.ReadLine();
                switch (input)
                {

                    case "1":
                        ParkVechile();
                        break;

                    case "2":
                        UnparkVehicle();
                        break;

                    case "3":
                        ListParkedVehicles();
                        break;

                    case "4":
                        ListParkedType();
                        break;

                    case "5":
                        break;

                    case "0":
                        quitProgram = true;
                        break;
                    default: break;
                }
            } while (!quitProgram);

        }



        public void GenerateGarage()
        {
            bool incorrectInput = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Garage Setup");
                Console.WriteLine("1: Create new Garage");
                Console.WriteLine("0: Quit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        string message = null;

                        do
                        {
                            Console.Clear();
                            if (message != null)
                            {
                                Console.WriteLine("Please enter the size of the garage using the numbers only");
                            }
                            Console.Write("Size of the garage: ");
                            int temp;
                            incorrectInput = !int.TryParse(Console.ReadLine(), out temp);
                            _garage = new Garage<Vehicle>(temp, out message); // recive from garage
                        } while (incorrectInput);
                        Console.WriteLine(message); // print out what we got from garage
                        break;
                    case "0":
                        incorrectInput = false;
                        break;

                    default:
                        break;
                }
            } while (incorrectInput);
            Console.ReadLine();
        }
        public void ParkVechile()
        {
            bool finishedParking = false;
            bool incorrectInput = true;
            string message;
            do
            {
                Console.WriteLine("Choose vehicle type to park");
                Console.WriteLine("1: Car");
                Console.WriteLine("2: Bus");
                Console.WriteLine("3: Airplane");
                Console.WriteLine("4: Boat");
                Console.WriteLine("5: Motorcycle");
                Console.WriteLine("0: Quit to main menu");

                string input = Console.ReadLine();
                Vehicle BaseVehicle;
                switch (input)
                {
                    case "1":
                        BaseVehicle = createBaseVehicle("Car");
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                        break;

                    case "2":
                        BaseVehicle = createBaseVehicle("Bus");
                        bool isDoubleDecker;
                        do
                        {
                            Console.Write("\nIs it a double decker (true/false):\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isDoubleDecker); // if tryparse succed .. we leave  the loop. When we manage to parse we continue. 
                        } while (incorrectInput);
                        uint nrOfSeats;
                        do
                        {
                            Console.Write("\nHow many numbers of seats:\t");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfSeats);
                        } while (incorrectInput);
                        _garage.Park(new Bus(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, isDoubleDecker, nrOfSeats), out message);
                        Console.WriteLine(message);
                        break;

                    case "3":
                        BaseVehicle = createBaseVehicle("Airplane");
                        int wingSpan = 0;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan); // continue on becuse we can not parse. anything other then numerically value is an incorrect input, can not convert and that wehy we make the user stay and put in a value that we can convert.
                        } while (incorrectInput);
                        Console.Write("\nModel:\t");
                        model = Console.ReadLine();
                        _garage.Park(new Airplane(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, wingSpan, model), out message);
                        Console.WriteLine(message);
                        break;

                    case "4":
                        BaseVehicle = createBaseVehicle("Boat");
                        uint lengthInFeet;
                        do
                        {
                            Console.Write("\nLenght in Feet:\n");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out lengthInFeet);
                        } while (incorrectInput);
                        bool isASailBoat;
                        do
                        {
                            Console.Write("\nIs it a sail boat?(true/false):\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isASailBoat);
                        } while (incorrectInput);
                        _garage.Park(new Boat(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, lengthInFeet, isASailBoat), out message);
                        Console.WriteLine(message);
                        break;

                    case "5":
                        BaseVehicle = createBaseVehicle("Motocycle");
                        int cylinderCapacity;
                        do
                        {
                            Console.Write("\nHow many cylinder:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out cylinderCapacity);
                        } while (incorrectInput);
                        bool isTryke;
                        do
                        {
                            Console.Write("\nIs it a tryke(true/false):\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isTryke);
                        } while (incorrectInput);
                        _garage.Park(new Motorcycle(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, cylinderCapacity, isTryke), out message);
                        Console.WriteLine(message);
                        break;
                    case "0":
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input try again"); break;
                }

            } while (!finishedParking);

        }

        public void UnparkVehicle()
        {
            bool finishedUnParking = false;
            Vehicle unparkedVehicle;
            do
            {
                Console.Clear();
                Console.WriteLine("Unparking vehicle\n");
                Console.Write("Registration number of unparking vehicle (leave blank to exit)\t");
                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("\nAre you sure you want to return to the main menu?\t");
                    Console.Write("\nRegistration number of unparking vehicle(leave blank to exit)\t");

                    if (input == "")
                    {
                        break;
                    }
                }
                unparkedVehicle = _garage.UnPark(input);
                if (unparkedVehicle == null)
                {
                    Console.WriteLine("\nNo vehicle with the registration number of " + input + " was found");            // we are doing this in a loop ao we can ask to keep doing tthis again, but if we finde we gonna land in the else.
                    Console.WriteLine("Please try again");
                }
                else
                {
                    Console.WriteLine(unparkedVehicle.Print()); // Print will return a string, thanks to poly, what happens..
                }
                Console.ReadLine();
            } while (!finishedUnParking);
        }

        public void ListParkedVehicles()
        {
            Console.Clear();
            foreach (Vehicle v in _garage)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(v.Print());
            }
            Console.WriteLine("--------------------------------------");
            Console.ReadLine();
        }

        public void ListParkedType()
        {
            Console.Clear();
            Console.WriteLine("Currently there are");
            if (_garage.Count() == 0)
            {
                Console.WriteLine("Nothing in the garage");
            }
            else
            {
                foreach (var v in _garage.GroupBy(x => x.GetType().Name))
                {
                    Console.WriteLine(v.Key + " " + v.Count());
                }
            }
            Console.ReadLine();
        }

        public void Search()
        {
            bool finishedSearching = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Search\n");
                Console.WriteLine("Please enter the properties and values you wish to search for");
                Console.WriteLine("E.x: \"Regnr: R\" will find all vehicles with a registration number that contains a nr");
                Console.WriteLine("\" RegNr: R,Coor: blue\" will find all vehicles with a registration number that contains an R and that is the color blue");
                Console.WriteLine("Please note tjat in order to search for a vehicle specific properties you must also search for the type e.x: \"Type Car, Make : Saab\" will find all Sabbs in the garage");
                string input = Console.ReadLine().ToLower();

                string[] temp = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries); // No empety slotts in the array. removes all potential null in array.
                Dictionary<string, string> searchPairs = new Dictionary<string, string>(); // group by function creates a grouping. The value of the key must be unice. 
                foreach (String s in temp)
                {
                    string[] temp2 = s.Split(new char[] { ':' },
                        StringSplitOptions.RemoveEmptyEntries);
                    searchPairs.Add(temp2[0].Trim(), temp2[1].Trim().ToLower());
                }
                List<Vehicle> results = _garage.Where(x => x != null).ToList(); // cast the result of the lamba exptrecion to an array/list

                foreach (var v in searchPairs)
                {
                    if(results.Count() == 0)
                    {
                        break;
                    }
                    switch (v.Key)
                    {
                        case "regnr":
                            results = results.Where(x=> x.RegNr.ToLower().Contains(v.Value)).ToList(); // cast it as a list agaian. 
                            break;
                        case "wheels":
                            results = results.Where(x => x.NrOfWheels.ToString() == v.Value).ToList();
                            break;
                        case "color":
                            results = results.Where(x => x.Color == v.Value).ToList();  
                            break;
                        case "fuel":
                            results = results.Where(x => x.FuelType == v.Value).ToList();
                            break;
                        case "type":
                            results = results.Where(x => x.GetType().Name.ToLower() == v.Value).ToList();
                            break;
                        case "model":
                            results = results.Where(x =>

                            x.GetType().Name == "Car" ||
                            x.GetType().Name == "Airplane" &&

                            (x as Car).Model.ToLower() == v.Value).ToList();
                            break;

                        case "make":
                            break;

                    }
                }
                foreach (Vehicle v in results)
                {
                    Console.WriteLine(v.Print());
                }
                Console.ReadLine();
                Console.WriteLine("\n\nWhat do you wish to do next:");
                Console.WriteLine("Any button) New Search");
                Console.WriteLine("0) Quit");
                if(Console.ReadLine() == "0")
                {
                    finishedSearching = true;
                }

            } while (!finishedSearching);
        }
        public Vehicle createBaseVehicle(string vehicleType)
        {
            Console.Clear();
            Console.WriteLine("Park a new " + vehicleType + ":\n");

            bool incorrectInput = true;
            Console.Write("Registration number:\t");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\nNumber of wheels:\t");
                incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);
            Console.Write("\nColor:\t");
            string color = Console.ReadLine();
            Console.Write("\nFueltype:\t");
            string fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);


        }
    }

}
