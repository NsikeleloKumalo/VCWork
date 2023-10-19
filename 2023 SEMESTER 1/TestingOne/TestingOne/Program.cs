using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Admin", "User", "Employer", "Employee", "Tester", "DBAdmin" };

            for (int i = 0; i < names.Count; i++)
            
                print(i, names[i]);
            }
           Console.ReadLine();
        }//main ends

        public static void print (int number, string name)
        {
            Console.WriteLine(number + ": " + name);
        }

        /*Debugging --> methods and rules
           * Step in -->
           * Step over -->
           * Step out -->
           * Breakpoints
           * Pin an item to iterate logic 
           */
    }
}
