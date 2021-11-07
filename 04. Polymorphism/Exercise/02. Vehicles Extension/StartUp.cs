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
            Vehicle bus = GetVehicle();

            List<Vehicle> vehicles = new List<Vehicle>()
            {
               car, truck, bus
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
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Drive(distance);
                        }

                        Console.WriteLine($"{vehicleType} travelled {distance} km");
                    }

                    if (inputLineArgs[0] == "DriveEmpty")
                    {
                        double distance = double.Parse(inputLineArgs[2]);
                        ((Bus)bus).TurnOffAirModifier();
                        bus.Drive(distance);
                        ((Bus)bus).TurnOnAirModifier();

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
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(fuel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            //Printing:
            foreach (var typeVehicle in vehicles)
            {
                Console.WriteLine(typeVehicle);
            }
        }


        public static Vehicle GetVehicle()
        {

            Vehicle vehicle = null;
            string[] vehicleInfoArgs = Console.ReadLine()
               .Split().ToArray();

            string vehicleType = vehicleInfoArgs[0];
            double initialFuel = double.Parse(vehicleInfoArgs[1]);
            double fuelConsumption = double.Parse(vehicleInfoArgs[2]);
            double tankCapacity = double.Parse(vehicleInfoArgs[3]);

            if(initialFuel > tankCapacity)
            {
                initialFuel = 0.0;
            }

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(initialFuel, fuelConsumption, tankCapacity);
            }
            if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(initialFuel, fuelConsumption, tankCapacity);
            }
            if (vehicleType == nameof(Bus))
            {
                vehicle = new Bus(initialFuel, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }


      

    }
}
