using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWashBay
{
    // Enum usage for vehicle types.
    enum VehicleType
    {
        Truck,
        MiniVan,
        Saloon,
        Motorbike
    }

    class Car
    {
        public required string PlateNumber { get; set; }
        public VehicleType Type { get; set; }
        public DateTime DateRegistered { get; set; }
    }

    class Washer
    {
        public required string Name { get; set; }
        public List<Car> AssignedCars { get; set; } = new List<Car>();
    }

    class Program
    {
        static readonly Dictionary<VehicleType, int> Prices = new()
        {
            { VehicleType.Truck, 20000 },
            { VehicleType.MiniVan, 15000 },
            { VehicleType.Saloon, 10000 },
            { VehicleType.Motorbike, 5000 }
        };

        static List<Washer> washers = new();
        static List<Car> cars = new();

         static void Main(string[] args)
        {
            Console.WriteLine("=*=*=* CAR WASH BAY TRACKING SYSTEM =*=*=*");

            while (true)
            {
                Console.WriteLine("\n1. Register Washer");
                Console.WriteLine("2. Register Car");
                Console.WriteLine("3. View Washers");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWasher();
                        break;
                    case "2":
                        RegisterCar();
                        break;
                    case "3":
                        ViewWashers();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
            
        static void AddWasher()
        {
            Console.Write("Enter washer name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Washer name cannot be empty.");
                return;
            }

            washers.Add(new Washer { Name = name });
            Console.WriteLine("Washer added successfully.");
        }

        static void RegisterCar()
        {
            if (washers.Count == 0)
            {
                Console.WriteLine("No washers available.");
                return;
            }

            Console.Write("Enter car plate number: ");
            string? plate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(plate))
            {
                Console.WriteLine("Plate number cannot be empty.");
                return;
            }

            bool alreadyRegistered = cars.Any(c =>
                c.PlateNumber == plate &&
                c.DateRegistered.Date == DateTime.Today);

            if (alreadyRegistered)
            {
                Console.WriteLine("This car is already registered today.");
                return;
            }

            Console.WriteLine("Select vehicle type:");
            Console.WriteLine("1. Truck");
            Console.WriteLine("2. MiniVan");
            Console.WriteLine("3. Saloon");
            Console.WriteLine("4. Motorbike");

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int selected) || selected < 1 || selected > 4)
            {
                Console.WriteLine("Invalid vehicle type selection.");
                return;
            }
            VehicleType type = (VehicleType)(selected - 1);

            Washer? washer = washers.FirstOrDefault(w => w.AssignedCars.Count < 2);

            if (washer == null)
            {
                Console.WriteLine("No washer available (all busy with 2 cars).");
                return;
            }

            Car car = new Car
            {
                PlateNumber = plate,
                Type = type,
                DateRegistered = DateTime.Now
            };

            washer.AssignedCars.Add(car);
            cars.Add(car);

            Console.WriteLine($"\nCar assigned to Washer: {washer.Name}");
            Console.WriteLine($"Cost: {Prices[type]} UGX");
        }

        static void ViewWashers()
        {
            Console.WriteLine("\n=*=*=* WASHER STATUS =*=*=*");

            foreach (var washer in washers)
            {
                Console.WriteLine($"Washer: {washer.Name}");

                if (washer.AssignedCars.Count == 0)
                {
                    Console.WriteLine("  No assigned cars.");
                    continue;
                }

                foreach (var car in washer.AssignedCars)
                {
                    Console.WriteLine($"  → {car.PlateNumber} ({car.Type})");
                }
            }
        }
    }
}



