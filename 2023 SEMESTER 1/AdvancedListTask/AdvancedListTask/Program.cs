using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            //readline --get the input

            Console.WriteLine("Get the input >>>>");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter emplyees name:");
                Console.ReadLine();
                Console.WriteLine("Enter emplyees age:");
                
            }
            
        }
    }
}
