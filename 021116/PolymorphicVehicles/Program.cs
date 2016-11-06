using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolymorphicVehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get car
            Car car;
            while (true)
            {
                Console.WriteLine("Please, enter a car. Format: Car <fuel> <litres per km>");
                string carInput = Console.ReadLine().ToLower();

                car = (Car)GetValidVehicleEntered(carInput, typeof(Car));
                if (car != null)
                    break;
            }

            // Get truck
            Truck truck;            
            while (true)
            {
                Console.WriteLine("Please, enter a truck. Format: Truck <fuel> <litres per km>");
                string truckInput = Console.ReadLine().ToLower();
                truck = (Truck)GetValidVehicleEntered(truckInput, typeof(Truck));

                if (truck != null)
                    break;
            }

            //Save the vehicles in list
            List<Vehicle> vehiclesList = new List<Vehicle>();
            vehiclesList.Add(car);
            vehiclesList.Add(truck);

            //Commands on both vehicles
            Console.Write("\nNumber of commands: ");
            int numberOfCommands = int.TryParse(Console.ReadLine(), out numberOfCommands) ? numberOfCommands : 0;

            Regex commandPattern = new Regex(@"^(drive|refuel)\s(car|truck)\s(\d+|\d+[.,]\d{1,2})$");

            for (int i = 0; i < numberOfCommands; i++)
            {
                Console.Write($"{i+1}): ");
                string command = Console.ReadLine().ToLower();

                if(commandPattern.IsMatch(command))
                {
                    string[] commandParts = command.Split(' ');

                    double number = Double.TryParse(commandParts[2], out number) ? number : 0;

                    if(commandParts[0].Equals("drive"))
                    {
                        switch(commandParts[1])
                        {
                            case "car": car.Drive((float)number); break;
                            case "truck": truck.Drive((float)number); break;
                        }                                                

                    } else if (commandParts[0].Equals("refuel"))
                    {
                        switch (commandParts[1])
                        {
                            case "car": car.Refuel((float)number); break;
                            case "truck": truck.Refuel((float)number); break;
                        }                  

                    } else
                    {
                        Console.WriteLine("Action command error, try again!");
                        i--;
                    }

                } else
                {
                    Console.WriteLine("Wrong format of command. Use 'Drive|Refuel' 'Car|Truck' <number>\n");
                    i--;
                }

            }

            PrintVehicleInfo(vehiclesList);
        }

        static void PrintVehicleInfo(List<Vehicle> vehicles)
        {
            Console.WriteLine("\nVehicle results: ----------- ");

            vehicles.ForEach(delegate(Vehicle v) {
                Console.WriteLine($"{v.GetType().Name}: {v.FuelInLitres.ToString("0.00")}");
            });
        }

        static Vehicle GetValidVehicleEntered(string vehicleInput, Type type)
        {            
            Regex carInputPattern = new Regex(@"^car\s(\d{1,2}|\d{1,2}[.,]\d{1,2})\s(\d{1,2}|\d{1,2}[.,]\d{1,2})$");
            Regex truckInputPattern = new Regex(@"^truck\s(\d{1,2}|\d{1,2}[.,]\d{1,2})\s(\d{1,2}|\d{1,2}[.,]\d{1,2})$");

            if (carInputPattern.IsMatch(vehicleInput) && type == typeof(Car))
            {
                string[] carInfos = vehicleInput.Split(' ');

                double carFuel;
                if (Double.TryParse(carInfos[1], out carFuel))
                {
                    double carLitresPerKm;
                    if (Double.TryParse(carInfos[2], out carLitresPerKm))
                    {
                        Car car = new Car(true, (float)carFuel, (float)carLitresPerKm);
                        return car;
                    }
                    else
                    {
                        Console.WriteLine("Wrong format of Car: litres per km!");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format of Car: fuel!");
                    return null;
                }

            } else if (truckInputPattern.IsMatch(vehicleInput) && type == typeof(Truck))
            {
                string[] truckInfos = vehicleInput.Split(' ');

                double truckFuel;
                if (Double.TryParse(truckInfos[1], out truckFuel))
                {
                    double truckLitresPerKm;
                    if (Double.TryParse(truckInfos[2], out truckLitresPerKm))
                    {
                        Truck truck = new Truck(true, (float)truckFuel, (float)truckLitresPerKm);
                        return truck;
                    }
                    else
                    {
                        Console.WriteLine("Wrong format of Truck: litres per km!");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format of Truck: fuel!");
                    return null;
                }

            } else
            {
                Console.WriteLine("Format error!");
                return null;
            }
        }
    }
}
