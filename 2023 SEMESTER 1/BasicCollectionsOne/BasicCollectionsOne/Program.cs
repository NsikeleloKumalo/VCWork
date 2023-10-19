using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCollectionsOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //recap of arrays with old ++ new rules
            string[] someCars = { "Merc", "Audi","Chev","Golf","BMW","Pony" };
            int[] somevalues = { 34,79,-9,124,56,3,1092};

            //iteration of the items in the collection
            Console.WriteLine("The string array items >>>>");
            for (int i = 0; i < someCars.Length; i++)
            {
                Console.WriteLine(someCars[i]);//vericle output
                //Console.Write(someCars[i] + " ");//horizontal output
            }

            Console.WriteLine("\n\n\nPrinting out the int array items ");
            for (int i = 0; i < somevalues.Length; i++)
            {
               Console.WriteLine(somevalues[i]);//vericle output
              //Console.Write(somevalues[i] + " ");//horizontal output
            }

            //C# RULE FOR, FORLOOP
            Console.WriteLine("\n\n\n*******Printing with new rules*******");
            foreach (var i in someCars)
            {
                // Console.WriteLine(someCars[i]); Java method
                Console.WriteLine(i);
            }


            Console.WriteLine("\n\n Printing out the int array >>>");

            foreach (var item in somevalues)

            {Console.WriteLine(item);
            }

            //sorting 
            Console.WriteLine("<<<<<<<<< sorted arrays >>>>>>>>>");
            Array.Sort(someCars);//sorts in ascending order
            Array.Sort(somevalues);//Sorts in ascending order

            for (int i = 0; i < somevalues.Length; i++)
            {
                Console.WriteLine(somevalues[i]);//vericle output
             //Console.Write(somevalues[i] + " ");//horizontal output
            }

            //C# RULE FOR, FORLOOP
            Console.WriteLine("\n\n\n*******Printing with new rules*******");
            foreach (var i in someCars)
            {
                // Console.WriteLine(someCars[i]); Java method
                Console.WriteLine(i);
            }

            Console.WriteLine("\n\nFLIPPED ARRAYS");
            Array.Reverse(somevalues);
            foreach (var item in somevalues)
            {
                Console.WriteLine(item);
            }

            Array.Reverse(someCars);
            foreach (var item in someCars)
            {
                Console.WriteLine(item);
            }














            Console.ReadLine();//open console 
        }
    }
}
