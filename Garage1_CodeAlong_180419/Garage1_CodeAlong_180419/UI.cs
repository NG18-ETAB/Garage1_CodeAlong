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
                    case "2":
                        UnparkVehicle();
                        break;
                    case "3":
                        ListParkedVehicle();
                        break;
                    case "4":
                        ListParkedTypes();
                        break;
                    case "5":
                        Search();
                        break;
                    case "0": 
                        quitprogram = true;
                        break;
                    default: break;
                }

            } while (!quitprogram);
        }

        private void Search()
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
                    string[] temp2 = s.Split(new char[] { ':' },StringSplitOptions.RemoveEmptyEntries );
                   
                    if(temp2.Length == 2)
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
                        case "regNr":
                            results = results.Where(x => x.RegNr.ToLower().Contains(v.Value.ToLower())).ToList();
                            break;
                        case "wheels":
                            results = results.Where(x => x.NrOfWheels.ToString() == v.Value).ToList();
                            break;
                        case "color":
                            results = results.Where(x => x.Color.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "fuel":
                            results = results.Where(x => x.FuelType.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "type":
                            results = results.Where(x => x.GetType().Name.ToLower() == v.Value.ToLower()).ToList();
                            break;
                        case "model":
                            
                                if(searchPair["type"] == "car")
                            {
                                results = results.Where(x => x.GetType().Name == "Car" && (x as Car).Model.ToLower() == v.Value.ToLower()).ToList();
                            }                               
                               
                                break;
                            
                        case "make":
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
            Console.WriteLine("Currently there is :");
            if (_garage.Count() == 0)
            {
                Console.WriteLine("Nothing in the garage");
            }
            else
            {
                foreach (var v in _garage.GroupBy(x => x.GetType().Name))
                {
                    Console.WriteLine(v.Count() + "   " + v.Key);
                }
            }
        }

        private void ListParkedVehicle()
        {
            Console.Clear();

            foreach (Vehicle v in _garage)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(v.Print());
            }
            Console.WriteLine("------------------------------------------------");
            Console.ReadLine();
        }

        public void UnparkVehicle()
        {
            bool finishedUnparking = false;
            Vehicle unparkedVehicle;
            do
            {
                Console.Clear();
                Console.WriteLine("Unparking vehicle\n");
                Console.Write("Registration number of unparking vehicle(leave blank to exit):\t");
                string input = Console.ReadLine();
                if(input=="")
                {
                    Console.WriteLine("Are yo sure you want to return to the main menu");
                    Console.Write("Registration number of unparking vehicle(leave blank to exit):\t");
                    input = Console.ReadLine();
                    if(input =="")
                    {
                        break;
                    }
                }

                unparkedVehicle = _garage.UnPark(input);
                if(unparkedVehicle == null)
                {
                    Console.WriteLine("\nNo vehicle with the registration number" + input + "   was found.");
                    Console.WriteLine("Plese try again");
                }
                else
                {
                    Console.WriteLine(unparkedVehicle.Print());
                   

                }
                Console.ReadLine();


            } while (!finishedUnparking);
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
                #region case1

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
                #endregion
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
                        //Console.Clear();
                        //Console.WriteLine("Park anew car: \n");
                        baseVehicle = createBaseVehicle("Car");
                        Console.Write("\nMake:\t");
                        string make = Console.ReadLine();
                        Console.Write("\n Model: \t");
                        string model = Console.ReadLine();
                        _garage.Park(new Car(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, make, model), out message);
                        Console.WriteLine(message);
                        break;
                    case "2":
                        //Console.Clear();
                        //Console.WriteLine("Park a new bus:\n");
                        baseVehicle = createBaseVehicle("Bus");
                        bool isDoubleDecker;
                        do
                        {
                            Console.WriteLine("\nIs it a double decker:\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isDoubleDecker);
                           

                        } while (incorrectInput);
                        uint nrOfSeats;
                        do
                        {
                            Console.Write("\nNo of seats:\t");
                            incorrectInput =! uint.TryParse(Console.ReadLine(), out nrOfSeats);
                        } while (incorrectInput);
                        _garage.Park(new Bus(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType,isDoubleDecker, nrOfSeats), out message);

                        break;
                    case "3":
                        //Console.Clear();
                        //Console.WriteLine("Park a new airplane:\n");
                        baseVehicle = createBaseVehicle("Airplane");
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
                        
                    case "4":
                       
                        baseVehicle = createBaseVehicle("Boat");
                        uint lengthInFeet;
                        do
                        {
                            Console.Write("\nLength in feet:\t");
                            incorrectInput = !uint.TryParse(Console.ReadLine(), out lengthInFeet);

                        } while (incorrectInput);

                        bool isSailBoat;
                        do
                        {
                            Console.Write("\n is it a sail boat:\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isSailBoat);

                        } while (incorrectInput);
                        _garage.Park(new Boat(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType,lengthInFeet, isSailBoat), out message);
                        break;
                    case "5":
                        //Console.Clear();
                        //Console.WriteLine("Park a new Motorcycle:\t");
                        baseVehicle = createBaseVehicle("Motorcycle");
                        int cC;
                        do
                        {
                            Console.Write("\nWhat is the cC:\t");
                            incorrectInput = !int.TryParse(Console.ReadLine(), out cC);

                        } while (incorrectInput);
                        bool isTrike;
                        do
                        {
                            Console.Write("\nIs it a tricycle:\t");
                            incorrectInput = !bool.TryParse(Console.ReadLine(), out isTrike);

                        } while (incorrectInput);
                        _garage.Park(new Motorcycle(baseVehicle.RegNr, baseVehicle.NrOfWheels, baseVehicle.Color, baseVehicle.FuelType, cC, isTrike ), out message);


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
        public Vehicle createBaseVehicle(string vehicleType)
        {
            Console.Clear();
            Console.WriteLine("Park a " + vehicleType+ " :\n");
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
