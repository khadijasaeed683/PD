using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prob1Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            int choice = 0;
            do
            {
                Console.WriteLine("****Ocien Task*****");
                Console.WriteLine("1. Add Ship\r\n2. View Ship Position\r\n3. View Ship Serial Number\r\n4. Change Ship Position\r\n5. Exit");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    AddShip(ships);
                }
                else if (choice == 2)
                {
                    ViewShipPosition(ships);
                }
                else if (choice == 3)
                {
                    ViewShipSerialNumber(ships);
                } 
                else if (choice == 4)
                {
                    ChangeShipPosition(ships);
                } 
                else 
                {
                   Console.WriteLine("WRONG OPTION ENTERED");
                }

                Console.ReadLine();
            } while (choice != 5);
        }
        static void AddShip(List<Ship> ships)
        {
            Console.Write("Enter Ship Number: ");
            string serialNumber = Console.ReadLine();

            Console.WriteLine("Enter Ship Latitude:");
            Angle latitude = ReadAngle();

            Console.WriteLine("Enter Ship Longitude:");
            Console.WriteLine("Enter Longitudes degree: ");
            Angle longitude = ReadAngle();

            Ship ship = new Ship(serialNumber, latitude, longitude);
            ships.Add(ship);
            Console.WriteLine("Ship Added Successfuly:");
        }
        static Angle ReadAngle()
        {
            Console.Write("Enter Latitude/Longitude Degree: ");
            int degree = int.Parse(Console.ReadLine());

            Console.Write("Enter Minute: ");
            float minute = float.Parse(Console.ReadLine());

            Console.Write("Enter Direction (N/S/E/W): ");
            char direction = char.Parse(Console.ReadLine().ToUpper());

            return new Angle(degree, minute, direction);
        }
        static void ViewShipPosition(List<Ship> ships)
        {
            Console.Write("Enter Ship Name: ");
            string shipNm = Console.ReadLine();

            Ship ship = ships.Find(s => s.shipName == shipNm);
            if (ship != null)
            {
                Console.WriteLine($"Ship is at degree: {ship.latitude.degree} and direction: {ship.longitude.direction} and  minutes: {ship.longitude.minutes}");
            }
            else
            {
                Console.WriteLine("Ship with the given serial number not found.");
            }
        }
        static void ChangeShipPosition(List<Ship> ships)
        {
            Console.Write("Enter Ship's Name whose position you want to change: ");
            string serialNumber = Console.ReadLine();

            Ship ship = ships.Find(s => s.shipName == serialNumber);
            if (ship != null)
            {
                Console.WriteLine("Enter New Ship LATITUDE:");
                ship.latitude = ReadAngle();

                Console.WriteLine("Enter New Ship LONGITUDE:");
                ship.longitude = ReadAngle();

                Console.WriteLine("Ship position updated successfully.");
            }
            else
            {
                Console.WriteLine("Ship with the given serial number not found.");
            }
        }
        static void ViewShipSerialNumber(List<Ship> ships)
        {
            Console.Write("Enter Ship Latitude: ");
            Angle latitude = ReadAngle();

            Console.Write("Enter Ship Longitude: ");
            Angle longitude = ReadAngle();

            Ship ship = ships.Find(s => s.latitude.ToString() == latitude.ToString() && s.longitude.ToString() == longitude.ToString());
            if (ship != null)
            {
                Console.WriteLine($"Ship's serial number is {ship.shipName}");
            }
            else
            {
                Console.WriteLine("Ship with the given latitude and longitude not found.");
            }
        }
    }
}
