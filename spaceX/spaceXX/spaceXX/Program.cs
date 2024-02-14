using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using spaceXX.bl;

namespace spaceXX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            bool running = true;
            while (running)
            {
               
                Console.WriteLine("Ship Management System");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. Add Passenger");
                Console.WriteLine("3. Delete Ship");
                Console.WriteLine("4. Delete Passenger");
                Console.WriteLine("5. View Ships");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShip(ships);
                        break;
                    case "2":
                        addPassenger(ships);
                        break;
                    case "3":
                        DeleteShip(ships);
                        break;
                    case "4":
                        DeletePassenger(ships);
                        break;
                    case "5":
                        ViewShips(ships);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();


            }
         
        }



        private static Ship FindShip(string name, List<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                if (ship.shipName == name)
                {
                    return ship;
                }
            }
            return null;
        }

        private static void addPassenger(List<Ship>ships)
        {
            Console.Write("Enter ship name: ");
            string shipName = Console.ReadLine();
            Ship ship = FindShip(shipName,ships);
            if (ship != null)
            {
                Console.Write("Enter passenger name: ");
                string passengerName = Console.ReadLine();
                ship.addPassenger(passengerName);
                Console.WriteLine("Passenger added to ship.");
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }

    
        static void DeletePassenger(List<Ship> ships)
        {
            Console.Write("Enter ship name: ");
            string shipName = Console.ReadLine();
            Ship ship = FindShip(shipName,ships);
            if (ship != null)
            {
                Console.Write("Enter passenger name to delete: ");
                string passengerName = Console.ReadLine();
                if (ship.removePassenger(passengerName))
                {
                    Console.WriteLine("Passenger deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Passenger not found on the ship.");
                }
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }


        private static void AddShip(List<Ship> ships)
        {
            Console.Write("Enter ship name: ");
            string name = Console.ReadLine();
            Ship newShip = new Ship(name);
            ships.Add(newShip);
            Console.WriteLine("Ship added successfully.");
        }
        static void DeleteShip(List<Ship> ships)
        {
            Console.Write("Enter ship name to delete: ");
            string name = Console.ReadLine();
            Ship ship = FindShip(name,ships);
            if (ship != null)
            {
                ships.Remove(ship);
                Console.WriteLine("Ship deleted successfully.");
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
        }
        static void ViewShips(List<Ship>ships)
        {
            Console.WriteLine("List of Ships:");
            foreach (Ship ship in ships)
            {
                Console.WriteLine($"Ship Name: {ship.shipName}");
                /*Console.WriteLine("Passengers:");
                foreach (string passenger in ship.Passengers)
                {
                    Console.WriteLine($"- {passenger}");
                }*/
                Console.WriteLine();
            }
        }




    }
}
