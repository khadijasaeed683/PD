using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceXX.bl
{
    internal class Ship
    {
        public string shipName;
        List<string> Passengers;
        public Ship(string name) 
        { 
            this.shipName = name;
            Passengers = new List<string>();
        }
        public void addPassenger(string name) { 
            Passengers.Add(name);
        }
        public bool removePassenger(string name)
        {
            return Passengers.Remove(name);
        }
    }
}
