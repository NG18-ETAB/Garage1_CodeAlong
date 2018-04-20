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
                    case "2":
                        UnparkVehicle();
                            break;
                    case "3": break;
                    case "4":
                        ListParkedTypes();
                            break;
                    case "5": break;
                    case "0":
                        quitProgram = true;
                        break;
                    default:break;
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
                Console.WriteLine("Unparking Vehicle \n");
                Console.Write("Registration Number of Unparking Vehicle(Leav blank to exit):\t");
                string input = Console.ReadLine();
                if(input=="")
                {
                    Console.WriteLine("\nAre you Sure you want to return to main maenu ");
                    Console.Write("Registration Number of Unparking Vehicle(Leav blank to exit):\t");
                     input = Console.ReadLine();
                    if(input == "")
                    {
                        break;
                    }

                }

                unparkedVehicle = _garage.UnPark(input);
                if(unparkedVehicle == null)
                {
                    Console.WriteLine("\n No Vehicle with the registration number of "+ input + "was found.");
                    Console.WriteLine("Please Try Again");
                }
                else
                {
                    Console.WriteLine(unparkedVehicle.Print());
                   
                }
                Console.Read();

            } while (!finishedUnparking);
        }

        public void ListParkedVehicles()
        {
            Console.Clear();
            foreach (Vehicle v in _garage)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(v.Print());
                 
            }
            Console.WriteLine("-------------------------------------------");
            Console.ReadLine();
        }

        public void ListParkedTypes()
        {
            Console.Clear();
            Console.WriteLine("Currently there are :");
            if (_garage.Count() == 0)
            {
                Console.WriteLine("Nothing in the Garage");
            }
            foreach (var v in _garage.GroupBy(x => x.GetType().Name))
            {
                Console.WriteLine(v.Count() + " " + v.Key);
                
            }
            Console.ReadLine();
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
                        
                        baseVehicle = creatBaseVehicle("Car");
                        Console.Write("\nMake\t");
                        string make = Console.ReadLine();
                        Console.Write("\nModel:\t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                            break;


                    case "2":
                            //Console.Clear();
                            //Console.WriteLine("Park a new Bus:\n");
                            baseVehicle = creatBaseVehicle("Bus");
                            bool isDoubleDecker;
                        do
                        {
                            Console.Write("\n:Is it double decker (true/false):\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isDoubleDecker);
                        } while (incorrectInput);
                        uint nrOfSeats;
                        do
                        {
                            Console.Write("\nNumber of seats:\t");
                            incorrectInput = !uint.TryParse(Console.ReadLine(),out nrOfSeats);
                        } while (incorrectInput);
                        _garage.Park(new Bus(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType,isDoubleDecker, nrOfSeats), out message);
                        break;


                    case "3":
                        //Console.Clear();
                        //Console.WriteLine("Park a new Airplane:\n");
                        baseVehicle = creatBaseVehicle("Airplane");

                        int wingSpan=0;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out wingSpan);
                        } while (incorrectInput);
                   
                        Console.WriteLine("\nModel:\t");
                        model = Console.ReadLine();

                        _garage.Park(new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType,wingSpan ,  model), out message);
                        Console.WriteLine(message);
                        break;


                    case "4":
                        //Console.Clear();
                        //Console.WriteLine("Park a new Boat:\n");
                        baseVehicle = creatBaseVehicle("Boat");
                        uint lengthInFeet;
                            do
                        {
                            Console.Write("\nLength in Feet:");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out lengthInFeet);

                        } while (incorrectInput);
                        bool isSailboat;
                        do
                        {
                            Console.Write("\nIs a Sail boat");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isSailboat);
                        } while (incorrectInput);
                        _garage.Park(new Boat(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType,lengthInFeet, isSailboat), out message);
                        Console.WriteLine(message);

                        break;


                    case "5":
                        //Console.Clear();
                        //Console.WriteLine("Park new Motorcycle");
                        baseVehicle = creatBaseVehicle("Motorcycle");
                        int cC;
                            
                            do
                        {
                            Console.Write("\nWhat is the CC:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out cC);

                        } while (incorrectInput);
                        bool isTrike;
                        do
                        {
                            Console.WriteLine("\nIs it a tricycle:\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isTrike);
                        } while (incorrectInput);
                        _garage.Park(new Motorcycle(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, cC, isTrike), out message);
                        Console.WriteLine(message);
                        break;



                    case "0":
                        
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("INCORRECT INPUT ***** TRY AGIN");
                        break;
                }


            } while (!finishedParking);

        }





        public Vehicle creatBaseVehicle(string vehicleType)
        {
            Console.Clear();
            Console.WriteLine("Park a new "+ vehicleType+ ":\n");
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
