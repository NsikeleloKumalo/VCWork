using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* --var data type
             * --used to type implicitly typed local variables
             * --must be initialized at declaration
             * --once it sets data type 
             * --CANNOT BE CHANGED
             */

            var age = 30;
            age = "six";
            Console.WriteLine(age);
            Console.WriteLine(age.GetType());

            var ageText = "five";
            Console.WriteLine(ageText);
            Console.WriteLine(ageText.GetType());

            //Limitations




            Console.ReadLine();
             }
    }
}
