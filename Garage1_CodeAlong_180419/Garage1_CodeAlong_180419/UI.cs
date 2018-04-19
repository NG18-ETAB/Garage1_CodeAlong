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
            

            if (_garage == null)
            {
                return;
            }

            bool quitProgram = false;
            do
            {
                Console.WriteLine("Welcome to the Garage");
                Console.WriteLine("1:Park Vehicle");
                Console.WriteLine("2:Unpark Vehicle");
                Console.WriteLine("3:List all parked vehicles");
                Console.WriteLine("4: List all vehicle types currently parked in the Garage");
                Console.WriteLine("5:Search for vehicles");
                Console.WriteLine("0:Quit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":ParkVehicle();
                            break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "0":

                        break;
                    default: break;

                }





            } while (!quitProgram);
            Console.WriteLine("Welcome to the Garage");
        }
        public void GenerateGarage()
        {
            bool incorrectInput = true;

            do
            {

                Console.WriteLine("Welcome to the Garage Setup");
                Console.WriteLine(" 1 : Create new  Garage");
                Console.WriteLine(" 0: Quit ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case ("1"):
                        string message = null;

                        do
                        {
                            Console.Clear();
                            if (message != null)
                            {
                                Console.WriteLine("Please enter the size of " + "the garage using numbers only");
                            }

                            Console.Write("Size of the garage");

                            int capacity;

                            incorrectInput = !int.TryParse(Console.ReadLine(), out capacity);

                            _garage = new Garage<Vehicle>(capacity, out message);

                        } while (incorrectInput);

                        Console.WriteLine(message);
                        break;

                    case ("0"):
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
                Console.WriteLine("choose vehicle type to park");
                Console.WriteLine("1: Car");
                Console.WriteLine("2: Bus");
                Console.WriteLine("3:Airplane");
                Console.WriteLine("4:Boat");
                Console.WriteLine("5:Motorcycle");
                Console.WriteLine("0:Quit to main menu");

                string input = Console.ReadLine();
                Vehicle baseVehicle;

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Park a new car:\n");
                        baseVehicle = createBaseVehicle();
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\nMode:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(make, model, baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType), out message);
                        Console.WriteLine(message);
                        break;
                    case "2": break;
                    case "3":
                        Console.Clear();
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
                        _garage.Park(new Airplane( baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, wingSpan, model), out message);
                        Console.WriteLine(message);

                        break;
                    case "4": break;
                    case "5": break;
                    case "0":

                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input try again");
                        break;


                }
            } while (!finishedParking);
        }

        public Vehicle createBaseVehicle()
        {
            bool incorrectInput = true;
            Console.Write("Registration Number:\t");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\nNumber of Wheels:\t");
                incorrectInput = uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);
            Console.Write("\nColor:\t");
            string color = Console.ReadLine();
            Console.Write("\nFuel type:\t");
            string fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);

        }
      }
}


