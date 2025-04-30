using System;
using System.Diagnostics.Contracts;
using System.Net;


namespace CarRental
{
    public class Principal
    {
        public static void Main(string[] args)
        {
            string? line;
            RentalStore store = new RentalStore();
            do
            {
                Console.WriteLine("Welcome to the Car Rental Store!");
                Console.WriteLine("Press enter to continue or type 'exit' in any moment to quit.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                WelcomeStore(store);
                Console.WriteLine("Press any key to continue...");
            } while((line = Console.ReadLine()) != "exit");
        }

        public static void WelcomeStore(RentalStore rStore)
        {
            Console.WriteLine("You are admin or user ? (a/u)?");
            string? userType = Console.ReadLine();
            if (userType == "a")
            {
                Console.WriteLine("Enter your username:");
                string? user = Console.ReadLine();
                Console.WriteLine("Enter your password:");
                string? password = Console.ReadLine();
                Admin(user ?? string.Empty, password ?? string.Empty, rStore);
            }
            else if (userType == "u")
            {
                User(rStore);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }   
        }

        public static void User(RentalStore store)
        {
            Console.WriteLine("Welcome to the Car Rental Store!");
            Console.WriteLine("this are the available cars:");
            List<Car> availableCars = store.GetAvailableCars();
            Console.WriteLine(availableCars.Count);
            foreach (var car in availableCars)
            {
                Console.WriteLine("###########################################################################");
                Console.WriteLine($"\nModel: {car.Model},\nType: {car.Type},\nYear: {car.Year},\nSpeed: {car.Speed},\nDoors: {car.Doors},\nRental Price: {car.RentalPrice}");
                Console.WriteLine("\n###########################################################################");
            }

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("You really want to rent this car? (y/n)");
                Console.WriteLine("Or use 'exit' to quit.");
                string? confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    try
                    {
                        Console.WriteLine("Enter the model and type of the car you want to rent:");
                        Console.WriteLine("Model:");
                        string? model = Console.ReadLine();
                        Console.WriteLine("Type:");
                        string? type = Console.ReadLine();
                        store.RentCar(model ?? string.Empty, type ?? string.Empty);
                        Console.WriteLine("Congratulations! You have rented the car.");
                        Console.WriteLine("Car rented successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (confirm == "n")
                {
                    Console.WriteLine("You have not rented the car.");
                }
                else if (confirm == "exit")
                {
                    Console.WriteLine("Exiting the program. Goodbye user!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        public static void Admin(string user, string password, RentalStore store)
        {
            if (user == "admin" && password == "admin")
            {
                Console.WriteLine("Welcome to the Car Rental Store, ADMIN!");
                Console.WriteLine("You can add, remove, or view cars.");
                while(true)
                {
                    Console.WriteLine("Type add to add a car, remove to remove a car, view to see available cars or exit to quit.");
                    string? actionCar = Console.ReadLine();
                    if (actionCar == "add")
                    {
                        try
                        {
                            Console.WriteLine("Enter car model:");
                            string? model = Console.ReadLine();
                            Console.WriteLine("Enter car type:");
                            string? type = Console.ReadLine();
                            Console.WriteLine("Enter car year:");
                            int year = int.Parse(Console.ReadLine() ?? "0");
                            Console.WriteLine("Enter car speed:");
                            int speed = int.Parse(Console.ReadLine() ?? "0");
                            Console.WriteLine("Enter car rental price:");
                            double price = double.Parse(Console.ReadLine() ?? "0");
                            Car car = new Car(model ?? string.Empty, type ?? string.Empty, year, speed, price);
                            store.AddCar(car);
                            Console.WriteLine($"Car {type} added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else if (actionCar == "remove")
                    {
                        try
                        {
                            Console.WriteLine("Enter car model and car type to remove:");
                            Console.WriteLine("Model:");
                            string? model = Console.ReadLine();
                            Console.WriteLine("Type:");
                            string? type = Console.ReadLine();
                            store.RemoveCar(model, type);
                            Console.WriteLine($"Car {model} removed successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else if (actionCar == "view")
                    {
                        List<Car> availableCars = store.GetAvailableCars();
                        foreach (var car in availableCars)
                        {
                            Console.WriteLine("###########################################################################");
                            Console.WriteLine($"\nModel: {car.Model},\nType: {car.Type},\nYear: {car.Year},\nSpeed: {car.Speed},\nDoors: {car.Doors},\nRental Price: {car.RentalPrice}");
                            Console.WriteLine("\n###########################################################################");
                        }
                    }
                    else if (actionCar == "exit")
                    {
                        Console.WriteLine("Exiting the program. Goodbye admin!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid action. Please try again.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
            }
        }
    }
}
