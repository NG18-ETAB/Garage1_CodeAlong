using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage1_CodeAlong_180419.Vehicles
{
    public class UI
    {
        private Garage<Vehicle> _garage;
        public void MainMenu()
        {
            GenarateGarage();
            if (_garage == null)
            {
                return;
            }
            bool quitprogram = false;
            do
            {
                Console.WriteLine("Welcome to the Garage");
                Console.WriteLine("1: Park Vehicles");
                Console.WriteLine("2: UnPark Vehicles");
                Console.WriteLine("3: List all parked vehicles");
                Console.WriteLine("4: List all vehicles types currently");
                Console.WriteLine("5: search for vehicles ");
                Console.WriteLine("0: Quit");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "0": 
                        quitprogram = true;
                        break;
                    default: break;
                }

            } while (!quitprogram);
        }
        public void GenarateGarage()
        {
            //Console.Clear();
            bool incorrectInput = true;
            Console.WriteLine("Welcome to the Garage Setup");
            Console.WriteLine("1) Create new garage:");
            Console.WriteLine("0: Quit");


            string input = Console.ReadLine();


            switch(input)
            {
                         
                case ("1"):
                    string message = null;
               do
               {
                        Console.Clear();
                        if (message != null)
                        {
                            Console.WriteLine("Plese enter the size of the garage using numbers only");
                        }
                        Console.Write("Size of the garage:");
                        int temp;
                        incorrectInput = !int.TryParse(Console.ReadLine(), out  temp);

                        _garage = new Garage<Vehicle>(temp, out message);
               } while (incorrectInput);

                    Console.WriteLine(message);
                    
                    break;
                case ("0"):
                    incorrectInput = false;

                    break;
                default:
                    break;
            }
            while (incorrectInput) ;
            Console.ReadLine();
        }   

        public void ParkVehicle()
        {
            bool finishedParking = false,  incorrectInput = true;
            string message;
            do
            {
                Console.WriteLine("choce vehicle type to park");
                Console.WriteLine("1: Car");
                Console.WriteLine("2: Bus");
                Console.WriteLine("3: Airplane");
                Console.WriteLine("4: Boat");
                Console.WriteLine("5: Motorcycle");
                Console.WriteLine("0: Quit");

                string input = Console.ReadLine();

                Vehicle baseVehicle;

                switch (input)
                {

                    case "1":
                        Console.Clear();
                        Console.WriteLine("Park anew car: \n");
                        baseVehicle = createBaseVehicle();
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\n Model: \t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "2": break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Park a new airplane:\n");
                        baseVehicle = createBaseVehicle();
                        int winSpan = 0;
                        do
                        {
                            Console.Write("\nWingspan:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out winSpan);

                        } while (incorrectInput);
                                                                        
                        Console.Write("\nModel: \t");
                         model = Console.ReadLine();
                        _garage.Park(new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, winSpan, model), out message);
                        break;
                        
                    case "4": break;
                    case "5": break;
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
            Console.Write("Registration nNumber:  ");
            string regNr = Console.ReadLine();
            uint nrOfWheels;
            do
            {
                Console.Write("\nNumber of wheels: ");
                incorrectInput = !uint.TryParse(Console.ReadLine(), out nrOfWheels);
            } while (incorrectInput);
            Console.Write("\nColor: ");
            string color = Console.ReadLine();
            Console.Write("\nFuel type: \t");
            string fuelType = Console.ReadLine();
            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }

    }
}
