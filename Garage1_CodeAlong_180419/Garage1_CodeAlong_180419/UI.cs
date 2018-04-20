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
        private Garage<Vehicle> _garage;
        public void MainMenu()
        {
            GenerateGarage();
            if(_garage == null) { return; }
            bool quitProgram = false;
            do
            {
                Console.WriteLine("Welcome to the Garage");
                Console.WriteLine("1: Park Vehicle");
                Console.WriteLine("2: Unpark Vehicle");
                Console.WriteLine("3: List all parked vehicles");
                Console.WriteLine("4: List all vehicle types currently parked");
                Console.WriteLine("5: Search for vehicles");
                Console.WriteLine("0: Quit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        UnparkVehicle();
                        break;
                    case "3":
                        ListParkedVehicles();
                        break;
                    case "4":
                        ListParkedTypes();
                        break;
                    case "5": break;
                    case "0":
                        quitProgram = true;
                        break; 
                    default:
                        break;
                }
            } while (!quitProgram);

        }

        public void UnparkVehicle()
        {
            bool finishedUnparking = false;
            Vehicle unparkedVehicle;
            do
            {
                Console.Clear();
                Console.WriteLine("Unparking vehicle\n");
                Console.Write("Registration number of unparking vehicle (leave blank to exit):\t");
                string input = Console.ReadLine();
                if(input == "")
                {
                    Console.WriteLine("\nAre you sure you wanna return to the main menu");
                    Console.Write("Reigistration number of "+ "unparking vehicle (leave blank to exit):\t");
                    input = Console.ReadLine();
                    if (input == "") { break; }

                }

                unparkedVehicle = _garage.Unpark(input);
                if(unparkedVehicle == null)
                {
                    Console.WriteLine("\nNo vehicle with the registration number " + input + " was found." );
                    Console.WriteLine("Please try again");
                }
                else
                {
                    Console.WriteLine(unparkedVehicle.Print());
                    Console.ReadLine();
                }
            } while (!finishedUnparking);
        }

        public void GenerateGarage()
        {
            bool incorrectInput = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Garage Setup");
                Console.WriteLine("1: Creat new Garage");
                Console.WriteLine("0: Quit;");
                string input = Console.ReadLine();
                switch (input)
                {
                    case ("1"):
                        string message = null;
                        do
                        {
                            Console.Clear();
                            if(message != null)
                            {
                                Console.WriteLine("Please enter the size of the garage using numbers only");
                            }
                            Console.Write("Size of the garage: ");
                            int temp;
                            incorrectInput = !int.TryParse(Console.ReadLine(), out temp);
                            _garage = new Garage<Vehicle>(temp, out message);
                        } while (incorrectInput);
                        Console.WriteLine(message);
                        break;

                    case ("0"):incorrectInput = false;
                        break;
                    default:
                        break;
                }
            } while (incorrectInput);
            Console.ReadLine();
        }

        public void ParkVehicle()
        {
            bool finishedParking = false, incorrectInput = true;
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
                Vehicle baseVehicle;
                switch (input)
                {
                    case "1":

                baseVehicle = CreateBaseVehicle("car");
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        break;
                
                    case "2":
                       
                        baseVehicle = CreateBaseVehicle("bus");
                        bool isDoubleDecker;
                        do
                        {
                            Console.Write("\nIs it a double decker (true/false):\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isDoubleDecker);
                        } while (incorrectInput);
                        uint nrOfSeats;
                        do
                        {
                            Console.Write("\nNumber of Seats:\t");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfSeats);
                        } while (incorrectInput);
                        _garage.Park(new Bus(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, isDoubleDecker, nrOfSeats), out message);
                        break;
                    case "3":
                        
                        baseVehicle = CreateBaseVehicle("airplane");
                        int wingSpan;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan);
                        } while (incorrectInput);
                        Console.Write("\nModel:\t");
                        model = Console.ReadLine();
                        _garage.Park(new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, wingSpan, model), out message);
                        break;
                    case "4":
                      
                        baseVehicle = CreateBaseVehicle("boat");
                        uint lengthInFeet;
                        do
                        {
                            Console.Write("\nLength in feet:\t");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out lengthInFeet);
                        } while (incorrectInput);
                        bool isSailboat;

                        do
                        {
                            Console.Write("\nIs it sailboat (true/false)");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isSailboat);
                        } while (incorrectInput);
                        _garage.Park(new Boat(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, lengthInFeet, isSailboat), out message);
                        break;
                    case "5":
                        
                        baseVehicle = CreateBaseVehicle("motorcycle");
                        int cC;
                        do
                        {
                            Console.Write("\nHow big is the CC:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out cC);
                        } while (incorrectInput);
                        bool isTrike;
                        do
                        {
                            Console.Write("\nIs it a tricycle:\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isTrike);
                        } while (incorrectInput);
                        _garage.Park(new Motorcycle(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, cC, isTrike), out message);
                        break;
                    case "0":
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("INCORRECT INPUT TRY AGAIN");
                        break;
                }
            } while (!finishedParking);
        }

        public void ListParkedVehicles()
        {
            Console.Clear();
            foreach (Vehicle v in _garage)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(v.Print());

            }
            Console.WriteLine("-------------------------------");
            Console.ReadLine();
        }

        public void ListParkedTypes()
        {
            Console.Clear();
            Console.WriteLine("Currently there are ");
           
            foreach(var v in _garage.GroupBy(x => x.GetType().Name))
            {
                Console.WriteLine(v.Count()+ " " + v.Key);
            }
        }
        public void Search()
        {
            bool finishedSearching = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Search");
                Console.WriteLine("Please enter the properties and values you wish to search for.");
                Console.WriteLine("e.x:\"RegNr: R\" will find all vehicles with a registration number that contains an R");
                Console.WriteLine("\"RegNr: R, Color: ble\" will find all vehicles with a registration number that contains an R and that is the color blue");
                Console.WriteLine("Please note that in order to search for vehicle specific properties you must also search for the type e.x \"Type: Car, Make: Saab\" will find all Saabs in the garage");
                string input = Console.ReadLine();
                string[] temp = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> searchPair = new Dictionary<string, string>();
                foreach (string s in temp)
                {
                    string[] temp2 = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp2.Length == 2)
                    {
                        searchPair.Add(temp2[0].Trim(), temp2[1].Trim());
                    }
                }
                List<Vehicle> results = _garage.Where(x => x != null).ToList();
                foreach (var v in searchPair)
                {
                    if (results.Count == 0)
                    {
                        break;
                    }
                    switch (v.Key)
                    {
                        case "RegNr":
                            results = results.Where(x => x.RegNr.ToLower().Contains(v.Value)).ToList();
                            break;
                        case "Wheels":
                            results = results.Where(x => x.NrOfWheels.ToString() == v.Value).ToList();
                            break;
                        case "Color":
                            results = results.Where(x => x.Color.ToLower() == v.Value).ToList();
                            break;
                        case "Type":
                            results = results.Where(x => x.GetType().Name.ToLower() == v.Value).ToList();
                            break;
                        case "Fuel":
                            results = results.Where(x => x.FuelType.ToLower() == v.Value).ToList();
                            break;
                        case "Model":
                            results = results.Where(x => x.GetType().Name == "Car" && (x as Car).Model.ToLower() == v.Value).ToList();
                            break;
                        case "Make":
                           
                            results = results.Where(x => x.GetType().Name == "Car" && (x as Car).Make.ToLower() == v.Value).ToList();
                            break;
                            // shall do the properties as above
                    }
                }

                foreach (Vehicle v in results)
                {
                    Console.WriteLine(v.Print());
                }
                Console.ReadLine();
                Console.WriteLine("\n\nWhat do you wish to do next:");
                Console.WriteLine("Any button: New Search");
                Console.WriteLine("0: Quit");
                if (Console.ReadLine() == "0")
                {
                    finishedSearching = true;
                }
            } while (!finishedSearching);
        }

        public Vehicle CreateBaseVehicle(string vehicleType)
        {
            Console.Clear();
            Console.WriteLine("Park a " + vehicleType + ":\n");
            bool incorrectInput = true;
            Console.Write("Registration Number:\t");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\nNumber of Wheels:\t");
                incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);
            Console.Write("\nColor:\t" );
            string color = Console.ReadLine();
            Console.Write("\nFuel Type:\t");
            string fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }
    }
}
 