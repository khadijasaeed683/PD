using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03
{
    internal class Interest
    {
        public double TrueBank(double amount, double rate)
        {
            return amount + (amount * rate);
        }
        public double TrueBank(double amount, double rate, string holdertype)
        {
            if (holdertype.ToLower() == "prime")
            {
                return amount + (amount * rate) + 2000;
            }
            else
            {
                return TrueBank(amount, rate);
            }
        }
        
    }
}
