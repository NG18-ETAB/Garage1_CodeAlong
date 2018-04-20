using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage1_CodeAlong_180419.Vehicles;

namespace Garage1_CodeAlong_180419
{
    public class UI
    {
        Garage<Vehicle> garage;

        public void MainMenu()
        {
            GenerateGarage();
            if (garage == null)
            {
                return;
            }
            bool quitProgram = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Hi and welcome to this awesome garage of magic");
                Console.WriteLine("1: Park");
                Console.WriteLine("2: UnPark");
                Console.WriteLine("3: List");
                Console.WriteLine("4: List types");
                Console.WriteLine("5: Search");
                Console.WriteLine("0: Quit");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        UnParkVehicle();
                        break;
                    case "3":
                        ListParkedVehicles();
                        break;
                    case "4":
                        ListParkedTypes();
                        break;
                    case "5":
                        Search();
                        break;
                    case "0":
                        quitProgram = true;
                        break;
                    default:
                        break;
                }

            } while (!quitProgram);
        }

        private void GenerateGarage()
        {
            bool incorrectInput = true;

            do
            {
                Console.WriteLine("Create the awesome garage of magic?");
                Console.WriteLine("1: Create garage");
                Console.WriteLine("0: Quit");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        int createdSize;
                        do
                        {
                            Console.Write("Enter size of garage: ");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out int cap);
                            if (incorrectInput)
                            {
                                Console.WriteLine("Enter size of garage with number, only");
                            }
                            else
                            {
                                garage = new Garage<Vehicle>(cap, out createdSize);
                                Console.WriteLine($"A garage of size {createdSize} has been created");
                            }
                        } while (incorrectInput);
                        return;

                    case "0":
                        return;

                    default:
                        if (input.Length <= 2)
                            Console.WriteLine("No, don't try to type your IQ");
                        else
                            Console.WriteLine("It's official, AI is now smarter than humans. Not that AI has become smarter or anything...\nI guess you didn't get that.");
                        break;
                }
            } while (true);
        }

        private void ParkVehicle()
        {
            bool finishedParking = false;
            do
            {
                Console.WriteLine("Choose vehicle type");
                Console.WriteLine("1: Car");
                Console.WriteLine("2: Bus");
                Console.WriteLine("3: Airplane");
                Console.WriteLine("4: Boat");
                Console.WriteLine("5: Motorcycle");
                Console.WriteLine("0: Back to main menu");
                var input = Console.ReadLine();
                Console.WriteLine();

                Vehicle baseVehicle;
                Vehicle parkingVehicle = null;

                switch (input)
                {
                    case "1":
                        baseVehicle = CreateBaseVehicle("car");
                        Console.Write("Make of car:\t");
                        var make = Console.ReadLine();
                        Console.Write("Model of car:\t");
                        var modelCar = Console.ReadLine();
                        parkingVehicle = new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, modelCar);
                        break;
                    case "2":
                        baseVehicle = CreateBaseVehicle("bus");
                        bool isDoubleDecker;
                        string inputTemp;
                        do
                        {
                            Console.Write("Is it a double decker (Y/N):\t");
                            inputTemp = Console.ReadLine();
                            isDoubleDecker = inputTemp.Substring(0, 1).ToLower() == "y";
                        } while (!isDoubleDecker && inputTemp.Substring(0, 1).ToLower() != "n");
                        uint nrOfSeats;
                        do
                        {
                            Console.Write("How many seats:\t");
                        } while (!uint.TryParse(Console.ReadLine(), out nrOfSeats));

                        parkingVehicle = new Bus(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, isDoubleDecker, nrOfSeats);
                        break;
                    case "3":
                        baseVehicle = CreateBaseVehicle("airplane");
                        int wingSpan;
                        do
                        {
                            Console.Write("Wingspan of airplane:\t");
                        } while (!int.TryParse(Console.ReadLine(), out wingSpan));
                        Console.Write("Model of airplane:\t");
                        var modelAP = Console.ReadLine();

                        parkingVehicle = new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, wingSpan, modelAP);
                        break;
                    case "4":
                        baseVehicle = CreateBaseVehicle("boat");
                        uint lengthInFeet;
                        do
                        {
                            Console.Write("How long is boat in feets:\t");
                        } while (!uint.TryParse(Console.ReadLine(), out lengthInFeet));
                        bool isSailBoat;
                        do
                        {
                            Console.Write("Is it a sail boat (Y/N):\t");
                            inputTemp = Console.ReadLine();
                            isSailBoat = inputTemp.Substring(0, 1).ToLower() == "y";
                        } while (!isSailBoat && inputTemp.Substring(0, 1).ToLower() != "n");

                        parkingVehicle = new Boat(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, lengthInFeet, isSailBoat);
                        break;
                    case "5":
                        baseVehicle = CreateBaseVehicle("bike");
                        int cylinderCapacity;
                        do
                        {
                            Console.Write("What's the cc:\t");
                        } while (!int.TryParse(Console.ReadLine(), out cylinderCapacity));
                        bool isTrike;
                        do
                        {
                            Console.Write("Is it a trike (Y/N):\t");
                            inputTemp = Console.ReadLine();
                            isTrike = inputTemp.Substring(0, 1).ToLower() == "y";
                        } while (!isTrike && inputTemp.Substring(0, 1).ToLower() != "n");

                        parkingVehicle = new Motorcycle(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, cylinderCapacity, isTrike);
                        break;
                    case "0":
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("OMG, like HELLOOO!!!!111oneone1");
                        break;
                }

                if (parkingVehicle != null)
                {
                    if (garage.Park(parkingVehicle))
                    {
                        Console.WriteLine("Your vehicle has been parked");
                    }
                    else
                    {
                        Console.WriteLine("The garage is full");
                    }
                    parkingVehicle = null;
                }

            } while (!finishedParking);
        }

        private Vehicle CreateBaseVehicle(string vehicleType)
        {
            Console.Write($"Park a new {vehicleType}");

            Console.Write("Registration number:");
            var regNr = Console.ReadLine();

            uint nrOfWheels;
            Console.Write("Number of wheels:\t");
            while (!uint.TryParse(Console.ReadLine(), out nrOfWheels))
            {
                Console.Write("NUMBER of wheels:\t");
            }

            Console.Write("Color:\t");
            var color = Console.ReadLine();

            Console.Write("Type of fuel:\t");
            var fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }

        private void UnParkVehicle()
        {
            Vehicle vehicle = null;
            Console.WriteLine("Unparking vehicle");
            do
            {
                Console.Write("Enter registration number of your vehicle (blank to exit):\t");
                var input = Console.ReadLine();
                if (input == "")
                    break;
                vehicle = garage.UnPark(input);
                if (vehicle != null)
                {
                    Console.WriteLine("Here's your vehicle,");
                    Console.WriteLine(vehicle.Print());
                }
                else
                    Console.WriteLine("Your vehicle isn't in this garage.");
            } while (!((1 < 2) != true));
        }

        private void ListParkedVehicles()
        {
            Console.WriteLine();
            Console.WriteLine("List all vehicles");
            foreach (var v in garage)
            {
                Console.WriteLine(v.Print());
            }
            Console.WriteLine();
        }

        private void ListParkedTypes()
        {
            Console.WriteLine("There is");
            if (garage.Count() > 0)
                foreach (var v in garage.GroupBy(x => x.GetType().Name))
                {
                    Console.WriteLine(v.Key + ": " + v.Count());
                }
            else
                Console.Write("nothing ");
            Console.WriteLine("in the garage");
        }

        private void Search()
        {
            Console.WriteLine();
            Console.WriteLine("Search");
            Console.WriteLine("Enter properties to search for,");
            Console.WriteLine("Ex. \"RegNr: R\" will find all vehicles with RegNr containing an R,");
            Console.WriteLine("Ex. \"RegNr: R, Color: blue\" will find vehicles with RegNr with R and color of blue");
            //Console.WriteLine("For vehicle with specific properties you have to search for the type as well");
            //Console.WriteLine("Ex. \"Type: Car, Make: SAAB\"");
            var input = Console.ReadLine().ToLower();
            try
            {
                var temp = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var searchPairs = new Dictionary<string, string>();
                foreach (var s in temp)
                {
                    var temp2 = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp2.Length != 2)
                    {
                        Console.WriteLine("You so stupid. Go home");
                        return;
                    }
                    searchPairs.Add(temp2[0].Trim(), temp2[1].Trim());
                }
                var result = garage.Where(x => x != null).ToList();
                foreach (var pairs in searchPairs)
                {
                    if (result.Count == 0)
                        break;
                    switch (pairs.Key)
                    {
                        case "regnr":
                            result = result.Where(x => x.RegNr.ToLower().Contains(pairs.Value)).ToList();
                            break;
                        case "wheels":
                            result = result.Where(x => x.NrOfWheels.ToString() == pairs.Value).ToList();
                            break;
                        case "color":
                            result = result.Where(x => x.Color.ToLower() == pairs.Value).ToList();
                            break;
                        case "fueltype":
                            result = result.Where(x => x.FuelType.ToLower() == pairs.Value).ToList();
                            break;
                        case "type":
                            result = result.Where(x => x.GetType().Name.ToLower() == pairs.Value).ToList();
                            break;
                        case "model":
                            result = result.Where(x => x.GetType().Name == "Car" && (x as Car).Model.ToLower() == pairs.Value ||
                                                       x.GetType().Name == "Airplane" && (x as Airplane).Model.ToLower() == pairs.Value).ToList();
                            break;
                        case "make":
                            result = result.Where(x => x.GetType().Name == "Car" && (x as Car).Make.ToLower() == pairs.Value).ToList();
                            break;
                        case "wingspan":
                            result = result.Where(x => x.GetType().Name == "Airplane" && (x as Airplane).WingSpan.ToString() == pairs.Value).ToList();
                            break;
                        case "lengthinfeet":
                            result = result.Where(x => x.GetType().Name == "Boat" && (x as Boat).LengthInFeet.ToString() == pairs.Value).ToList();
                            break;
                        case "issailboat":
                            result = result.Where(x => x.GetType().Name == "Boat" && (x as Boat).IsSailBoat.ToString() == pairs.Value).ToList();
                            break;
                        case "isdoubledecker":
                            result = result.Where(x => x.GetType().Name == "Bus" && (x as Bus).IsDoubleDecker.ToString() == pairs.Value).ToList();
                            break;
                        case "nrofseats":
                            result = result.Where(x => x.GetType().Name == "Bus" && (x as Bus).NrOfSeats.ToString() == pairs.Value).ToList();
                            break;
                        case "cc":
                            result = result.Where(x => x.GetType().Name == "Motorcycle" && (x as Motorcycle).CylinderCapacity.ToString() == pairs.Value).ToList();
                            break;
                        case "istrike":
                            result = result.Where(x => x.GetType().Name == "Motorcycle" && (x as Motorcycle).IsTrike.ToString() == pairs.Value).ToList();
                            break;
                        default:
                            break;
                    }
                }
                foreach (var v in result)
                {
                    Console.WriteLine(v.Print());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("IQ FISKMÅS!!");
            }
        }
    }
}
