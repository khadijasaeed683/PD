using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prob1Task2
{
    internal class Ship
    {
        public string shipName;
        public Angle latitude;
        public Angle longitude;
        public Ship(string name, Angle lat, Angle longi)
        {
            this.shipName = name;
            this.latitude = lat;    
            this.longitude= longi;
        }
    }
}
