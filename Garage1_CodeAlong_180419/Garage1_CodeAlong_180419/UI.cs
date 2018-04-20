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
        private Garage<Vehicle> _garage;
        public void MainMenu()
        {
            GenerateGarage();
            if (_garage == null)
            {
                return;
            }
            bool quitProgram = false;
            do
            {
                Console.WriteLine("Welcome to the garage");
                Console.WriteLine("1: Park vehicle");
                Console.WriteLine("2: Unpark vehicle");
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
                    case "5":
                        Search();
                        break;
                    case "0":
                        quitProgram = true;
                        break;
                    default: break;
                }

            } while (!quitProgram);

        }

        public void Search()
        {
            bool finishedSearch = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Search\n");
                Console.WriteLine("Please enter the properties and values you wish to search for.");
                Console.WriteLine("e.x:\"RegNr: R\" will find all vehicles with a registration number that contains an R");
                Console.WriteLine("\"RegNr:R,Color:blue\" will find all vehicles with a registration number that contains an R and that is the color blue");
                Console.WriteLine("Please note that in order to search for vehicle specific properties you must also search for the type e.x: \"Type: Car, Male: Saab\" will find all Saabs in the garage");
                string input = Console.ReadLine();
                string[] temp = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> searchPair = new Dictionary<string, string>();
                foreach (string s in temp)
                {
                    string[] temp2 = s.Split(new char[] { ':' });
                    searchPair.Add(temp2[0].Trim(), temp2[1].Trim());
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
                            results = results.Where(x => x.RegNr.ToLower().Contains(v.Value.ToLower())).ToList();
                            break;
                        case "Wheels":
                            results = results.Where(x => x.NrOfWheels.ToString() == v.Value).ToList();
                            break;
                        case "Color":
                            results = results.Where(x => x.Color.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "Fuel":
                            results = results.Where(x => x.FeulType.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "Type":
                            results = results.Where(x => x.GetType().Name.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "Model":
                            
                                results = results.Where(x => x.GetType().Name == "Car" && (x as Car).Model.ToLower() == v.Value.ToLower() ||
                                                             x.GetType().Name == "Airplane" && (x as Airplane).Model.ToLower() == v.Value.ToLower()).ToList();
                                break;
                            
                        case "Make":
                            results = results.Where(x => x.GetType().Name == "Car" && (x as Car).Make.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        default:
                            break;
                    }
                }
                foreach (Vehicle v in results)
                {
                    Console.WriteLine(v.Print());
                }
                Console.ReadKey();
                Console.WriteLine("\n\nWhat do you wish to do next:");
                Console.WriteLine("Any button:New search");
                Console.WriteLine("0:Quit");
                if (Console.ReadLine() == "0")
                {
                    finishedSearch = true;
                }
            } while (!finishedSearch);
        }

        private void ListParkedTypes()
        {

            Console.Clear();
            Console.WriteLine("Currently there are:");
            if (_garage.Count() == 0)
            {
                Console.WriteLine("Nothing in the garage.");
            }
            else
            {
                foreach (var v in _garage.GroupBy(x => x.GetType().Name))
                {
                    Console.WriteLine(v.Key + "s\t" + v.Count());
                }
            }

            Console.ReadKey();
        }

        public void ListParkedVehicles()
        {
            Console.Clear();
            foreach (var v in _garage)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(v.Print());
            }
            Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }

        public void UnparkVehicle()
        {
            bool finishedUnparking = false;
            Vehicle unParkedVehicle;
            do
            {
                Console.Clear();
                Console.WriteLine("Unparking Vehicle\n");
                Console.Write("Regestration number of unparking vehicle (Leave blank to exit):\t");
                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Are you sure you want to return to the main menu");
                    Console.Write("Regestration number of unparking vehicle (Leave blank to exit):\t");
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        break;
                    }
                }
                unParkedVehicle = _garage.UnPark(input);
                if (unParkedVehicle == null)
                {
                    Console.WriteLine("\n No vehicle with the registration number of " + input + " was found");
                }
                else
                {
                    Console.WriteLine(unParkedVehicle.Print());
                }
                Console.ReadKey();
            } while (!finishedUnparking);
        }

        public void GenerateGarage()
        {
            bool incorrectInput = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the garage setup");
                Console.WriteLine("1:Create new garage");
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
                                Console.WriteLine("please enter the size of the garage using numbers only");
                            }
                            Console.Write("Size of the garage: ");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out int temp);
                            _garage = new Garage<Vehicle>(temp, out message);
                        } while (incorrectInput);
                        Console.WriteLine(message);
                        break;
                    case "0":
                        incorrectInput = false;
                        break;
                    default:
                        break;
                }
            } while (incorrectInput);

        }
        public void ParkVehicle()
        {
            bool finishedParking = false, incorrectInput = true;
            string message;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose vehicle typre to park");
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
                        Console.WriteLine("Park a new car:\n");
                        baseVehicle = createBaseVehicle();
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FeulType, make, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Park a new airplane:\n");
                        baseVehicle = createBaseVehicle();
                        int wingSpan = 0;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan);
                        } while (incorrectInput);
                        Console.Write("\nModel:\t");
                        model = Console.ReadLine();

                        _garage.Park(new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FeulType, wingSpan, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "4":
                        break;
                    case "5":
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

        public Vehicle createBaseVehicle()
        {
            bool incorrectInput = true;
            Console.Write("Registeration Number:\t");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\n Number of wheels:\t");
                incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);
            Console.Write("\nColor:\t");
            string color = Console.ReadLine();
            Console.Write("\n Fueltype:\t");
            string fuelType = Console.ReadLine();
            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }
    }
}
