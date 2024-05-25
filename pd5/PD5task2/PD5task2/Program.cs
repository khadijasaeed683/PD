using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            while (true)
            {
                option = MainMenuUI.Menu();
                if (option == 1)
                {
                    ProductUI.TakeInputFromAdmin();
                }               
                if(option == 3) 
                {
                    break;
                }

            }
        }
    }
}
