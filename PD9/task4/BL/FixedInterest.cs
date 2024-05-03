using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04
{
    internal class FixedInterest : Interest
    {
        public override double TrueBank(double amount, double rate)
        {
            return base.TrueBank(amount, rate) + 1500;
        }
    }
}
