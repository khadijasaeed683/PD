using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD5task2
{
    internal class Product
    {
        public string Name;
        public double ProductTax;
        public double Price;
        public string Catagory;
        public int Quantity;

        public Product(string name, double Producttax, double price, string Catag, int quantity) 
        { 
            this.Name = name;
            this.ProductTax = Producttax;
            this.Price = price;
            this.Catagory = Catag;
            this.Quantity = quantity;
        }
        public double CalculateTax()
        {
            if (this.Catagory == "grocery")
            {
                return Price * 0.1;
            }
            else
            {
                return Price * 0.05;
            }
        }
    }
}
