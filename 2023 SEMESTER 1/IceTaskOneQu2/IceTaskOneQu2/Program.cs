using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTaskOneQu2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            //array 
            int[] tenValue = new int[10];
            //Console.WriteLine("Please enter 10 numbers, please press enter each time ");
            //for (int i = 0; i < tenValue.Length; i++)
            {
                //Console.WriteLine("Enter a value" + (i + 1));
                //tenValue[i] = Int32.Parse(Console.ReadLine());
                //reading elements
                Console.WriteLine("Enter array elements : ");
                for (i = 0; i < tenValue.Length; i++)
                {
                    Console.Write("Element[" + (i + 1) + "]: ");
                    tenValue[i] = int.Parse(Console.ReadLine());
                }
                //checking and printing list of EVEN integers
                Console.WriteLine("List of even numbers : ");
                for (i = 0; i < tenValue.Length; i++)
                {
                    //condition for EVEN number
                    if (tenValue[i] % 2 == 0)
                        Console.Write(tenValue[i] + " ");
                }
                Console.WriteLine();

                Console.ReadLine();

            }
        }
    }
}
