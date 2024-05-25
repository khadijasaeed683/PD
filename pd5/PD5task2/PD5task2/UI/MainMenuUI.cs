using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5task2
{
    internal class MainMenuUI
    {
        public static int Menu()
        {
            int opt;
            Console.WriteLine("1. SignIn\r\n2. SignUp\r\n3. Exit");
            opt=int.Parse(Console.ReadLine());
            return opt;
        }
    }
}
