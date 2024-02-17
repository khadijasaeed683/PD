using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prob1Task2
{
    internal class Angle
    {
        public int degree;
        public float minutes;
        public char direction;
        public Angle(int degree, float minutes, char direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }
        
    }
}
