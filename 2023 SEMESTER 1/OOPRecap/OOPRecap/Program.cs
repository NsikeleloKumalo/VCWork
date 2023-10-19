using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1---Abstraction
             * 2--Inheritance
             * 3 -- Encapsulation
             * 4 -- Polymophism
             * 
             */

            //get the values
            Console.WriteLine("Enter your order id >>>");
            string orderNum = Console.ReadLine();

            Console.WriteLine("Enter your name >>>");
            string customer = Console.ReadLine();

            Console.WriteLine("Enter the number of burgers >>>");
            int burgers =Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of drinks >>>");
            int drinks = Int32.Parse(Console.ReadLine());


            //create an obj of the class 
            Orders orders = new Orders(orderNum, customer, burgers, drinks) ;
            Console.WriteLine(orders.ToString());







            Console.ReadLine();
        }
    }
}
