using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //array 
            int[] fiveValue = new int[5];
            Console.WriteLine("Please enter 5 numbers, press enter each time ");
            for (int i = 0; i < fiveValue.Length; i++)
            {
                Console.WriteLine("Enter a value" + (i +1));
                fiveValue[i] = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n\nHere are your values reversed");
            Array.Reverse(fiveValue);
            foreach (var item in fiveValue)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
