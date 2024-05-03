using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04
{
    internal class Interest
    {
        public virtual double TrueBank(double amount, double rate)
        {
            return amount + (amount * rate);
        }

    }
}
