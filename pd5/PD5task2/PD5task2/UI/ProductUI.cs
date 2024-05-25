using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5task2
{
    internal class ProductUI
    {
        public static Product TakeInputFromAdmin()
        {
            Console.WriteLine("ADD PRODUCT");
            Console.WriteLine("product name ");
            string name= Console.ReadLine();
             Console.WriteLine("product tax ");
            double tx=double.Parse(Console.ReadLine());
             Console.WriteLine("product price ");
            double prs=double.Parse(Console.ReadLine());
             Console.WriteLine("product catagory ");
            string cat= Console.ReadLine();
            Console.WriteLine("product quantity ");
            int quan=int.Parse(Console.ReadLine());
            Product product = new Product( name, tx,  prs,cat,quan);
            return product;


        }
    }
}
