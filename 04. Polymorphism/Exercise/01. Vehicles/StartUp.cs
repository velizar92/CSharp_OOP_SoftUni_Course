using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {



            Vehicle car = GetVehicle();
            Vehicle truck = GetVehicle();

            List<Vehicle> vehicles = new List<Vehicle>()
            {
               car, truck
            };

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    string[] inputLineArgs = Console.ReadLine()
                   .Split().ToArray();

                    string typeCommand = inputLineArgs[0];
                    string vehicleType = inputLineArgs[1];

                    if (inputLineArgs[0] == "Drive")
                    {
                        double distance = double.Parse(inputLineArgs[2]);
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(distance);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(distance);
                        }

                        Console.WriteLine($"{vehicleType} travelled {distance} km");
                    }

                    if (typeCommand == "Refuel")
                    {
                        double fuel = double.Parse(inputLineArgs[2]);
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(fuel);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(fuel);
                        }

                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            //Printing:
            foreach (var typeCar in vehicles)
            {
                Console.WriteLine(typeCar);
            }
        }


        public static Vehicle GetVehicle()
        {

            Vehicle vehicle = null;
            string[] vehicleInfoArgs = Console.ReadLine()
               .Split().ToArray();

            string vehicleType = vehicleInfoArgs[0];
            double fuel = double.Parse(vehicleInfoArgs[1]);
            double fuelConsumption = double.Parse(vehicleInfoArgs[2]);

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuel, fuelConsumption);
            }

            if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuel, fuelConsumption);
            }

            return vehicle;
        }


    }
}
