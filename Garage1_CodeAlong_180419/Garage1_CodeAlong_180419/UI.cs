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
            bool incorrectInput = true;
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

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Park a new car");
                        baseVehicle = CreateBaseVehicle();
                        Console.Write("\nMake of car:\t");
                        var make = Console.ReadLine();
                        Console.Write("\nModel of car:\t");
                        var modelCar = Console.ReadLine();
                        if (garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, modelCar)))
                        {
                            Console.WriteLine("Your car has been parked");
                        }
                        else
                        {
                            Console.WriteLine("The garage is full");
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Park a new airplane");
                        baseVehicle = CreateBaseVehicle();
                        int wingSpan;
                        do
                        {
                            Console.Write("\nWingspan of airplane:\t");
                        } while (!int.TryParse(Console.ReadLine(), out wingSpan));
                        Console.Write("\nModel of airplane:\t");
                        var modelAP = Console.ReadLine();
                        if (garage.Park(new Airplane(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, wingSpan, modelAP)))
                        {
                            Console.WriteLine("Your airplane has been parked");
                        }
                        else
                        {
                            Console.WriteLine("The garage is full");
                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "0":
                        finishedParking = true;
                        break;
                    default:
                        Console.WriteLine("OMG, like HELLOOO!!!!111oneone1");
                        break;
                }

            } while (!finishedParking);
        }

        public Vehicle CreateBaseVehicle()
        {
            Console.Write("Registration number:");
            var regNr = Console.ReadLine();

            uint nrOfWheels;
            Console.Write("\nNumber of wheels:\t");
            while (!uint.TryParse(Console.ReadLine(), out nrOfWheels))
            {
                Console.Write("\nNUMBER of wheels:\t");
            }

            Console.Write("\nColor:\t");
            var color = Console.ReadLine();

            Console.Write("\nType of fuel:\t");
            var fuelType = Console.ReadLine();

            return new Vehicle(regNr, nrOfWheels, color, fuelType);
        }
    }
}
