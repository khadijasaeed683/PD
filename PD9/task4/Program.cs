using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interest interest = new Interest();
            SimpleInterest simpleInterest = new SimpleInterest();
            FixedInterest fixedInterest = new FixedInterest();
            double amount = 5000;
            double rate = 0.10;
            double regularInterest = interest.TrueBank(amount, rate);
            Console.WriteLine($"Normal interest for a holder: ${regularInterest}");

            // Calculate and display interest for a simple deposit account
            double simpleAccountInterest = simpleInterest.TrueBank(amount, rate);
            Console.WriteLine($"Simple interest for a holder: ${simpleAccountInterest}");

            // Calculate and display interest for a fixed deposit account
            double fixedAccountInterest = fixedInterest.TrueBank(amount, rate);
            Console.WriteLine($"Fixed interest for a holder: ${fixedAccountInterest}");
            Console.ReadKey();
        }
    }
}
