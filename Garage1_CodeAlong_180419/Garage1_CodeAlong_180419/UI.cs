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
                switch (input) { 

                    case "1":
                        ParkVechile();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
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
                        Console.Clear();
                        Console.WriteLine("Park a new car:\n");
                        BaseVehicle = createBaseVehicle();
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Park a new airplane:\n");
                        BaseVehicle = createBaseVehicle();
                        int wingSpan =0;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan); // continue on becuse we can not parse.
                        } while (incorrectInput);
                        Console.Write("\nModel:\t");
                        model = Console.ReadLine();
                        _garage.Park(new Airplane(BaseVehicle.RegNr, BaseVehicle.NrOfWheels, BaseVehicle.Color, BaseVehicle.FuelType, wingSpan, model), out message);
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
                        Console.WriteLine("Incorrect input try again"); break;
                }

            } while (!finishedParking);
        }
        public Vehicle createBaseVehicle()
        {
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
