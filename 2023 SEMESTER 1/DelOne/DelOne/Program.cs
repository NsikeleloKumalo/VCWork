using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelOne
{
    class Program
    {
        //step 1 --> Global declaration of delegate
        //must match the signature 
        public delegate void someTextDel(string msg);
        static void Main(string[] args)
        {
            /*Delagates
             * --they are function points 
             * --NB: Function is a method 
             * Rules for using a delegate 
             * --keyword delegate
             * --global declaration
             * --has to have the SAME SIGNATURE of the function it points to
             * --create an object of the delegate
             * --pass the function AS A PARAMETER 
             * --invoke the delegate 
             *      --using the delegate object
             *          --invoke method - build in           
             */
            //someText("Old method call");
            //Step 2--> create an object of the delegate 
            someTextDel std = new someTextDel(someText);

            //step 3 -- Invoke
            std("Delegate consuming a function >>>");
            std.Invoke("Altrnative to invoking a delegate");

            Console.ReadLine();

            }
        public static void someText (string msg)
        {
            Console.WriteLine(msg);
            //Console.ReadLine();
        }

    }

}
