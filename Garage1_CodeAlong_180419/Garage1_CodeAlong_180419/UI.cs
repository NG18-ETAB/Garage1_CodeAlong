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
            if(_garage == null)
            {
                return;
            }
            bool quitProgram = false;
            do
            {
                Console.WriteLine("Welcom to the Garage");
                Console.WriteLine("1: Park Vehicle ");
                Console.WriteLine("2: Unpark Vehicle ");
                Console.WriteLine("3: Lislt all parked vehicles ");
                Console.WriteLine("4: List all vehicle types currently parked ");
                Console.WriteLine("5: Search for vehicles ");
                Console.WriteLine("0: Quit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ParkVehicle();
                            break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "0":
                        quitProgram = true;
                        break;
                    default:break;
                }
            } while (!quitProgram);
        }

        public void GenerateGarage()
        {
            bool incorrectInput = true;
            do
            { 
                Console.WriteLine("Welcom to the Garage Setup");
                Console.WriteLine("1: Create new Garage");
                Console.WriteLine("0: Quit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case ("1"):
                     string message=null;

                     do
                     {
                            Console.Clear();
                            if(message != null)
                            {
                                Console.WriteLine("Please Enter the size of the Garage using Numbers Only");
                            }
                            Console.Write("Size of the garage: ");
                            int capacity;                                                                           //tem the capacity of the Garage .
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

            }
            while (incorrectInput);  
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
                Console.WriteLine("0: Quit to Main Menue");

                string input = Console.ReadLine();
                Vehicle baseVehicle;

                switch (input)
                {
                    case"1":
                        Console.Clear();
                        Console.WriteLine("Park a new Car:\n");
                        baseVehicle = creatBaseVehicle();
                        Console.Write("\nMake\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                            break;
                    case "2":
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Park a new Airplane:\n");
                        baseVehicle = creatBaseVehicle();

                        int wingSpan;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan);
                        } while (incorrectInput);
                        Console.Write("\nMake\t");
                         make = Console.ReadLine();
                        Console.WriteLine("\nModel:\t");
                        model = Console.ReadLine();

                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "4":break;
                    case "5":break;
                    case "0":
                        
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("INCORRECT INPUT ***** TRY AGIN");
                        break;
                }


            } while (!finishedParking);

        }

        public Vehicle creatBaseVehicle()
        {
            bool incorrectInput = true;
            Console.Write("Registraion Number:\t");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\nNumber of Wheels: ");
                incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);

            Console.Write("\nColor:\t");
            string color = Console.ReadLine();
            Console.Write("\nFuel Type:\t");
            string fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }
    }

}
