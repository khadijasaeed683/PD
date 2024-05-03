using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interest interestCalculator = new Interest();

            double amount = 5000;
            double rate = 0.10; 

            double regularInterest = interestCalculator.TrueBank(amount, rate);
            Console.WriteLine($"Normal interest for a holder: ${regularInterest:F2}");

            double primeInterest = interestCalculator.TrueBank(amount, rate, "prime");
            Console.WriteLine($"Prime interest for a holder: ${primeInterest:F2}");
            Console.ReadKey();
        }
    }
}
