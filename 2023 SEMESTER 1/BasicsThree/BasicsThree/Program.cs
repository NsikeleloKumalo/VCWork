using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsThree
{
    class Program
    {
        static void Main(string[] args)
        {
            //07-03-2023
            /* --Dynamic Data Type
             * --static type
             * --figures it out LATE compared to the var
             */

            dynamic age = 15;
            Console.WriteLine(age);
            Console.WriteLine(age.GetType());

            age = "seven";
            Console.WriteLine(age);
            Console.WriteLine(age.GetType());




            Console.ReadLine();

        }
    }
}
