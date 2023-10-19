using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //diferent variables
            //placeholders

            //declare
            string name;
            string city;
            sbyte age; //variables/methods/classes
            //8 bit signed integer -128 ---> 127
            int pin;

            Console.WriteLine("Emter your name");
            name = Console.ReadLine();

            Console.WriteLine("Emter your city >>>");
            city = Console.ReadLine();

            Console.WriteLine("Emter your age >>>");
            age = sbyte.Parse( Console.ReadLine());

            Console.WriteLine("Emter your pin >>>");
            pin = Int32.Parse(Console.ReadLine());
            //Int32 && int 64
            //signed integer


            //output
            //Console.WriteLine("==================================");
           // Console.WriteLine("---Your profile details---");
            //Console.WriteLine("Name:" + name);
           // Console.WriteLine("City:" + city);
            //Console.WriteLine("age:" + age);
            //Console.WriteLine("Pin:" + pin);
            //Console.WriteLine("==================================");

            //output using place holders 
            Console.WriteLine("==================================");
            Console.WriteLine("---Your profile details---\n Name: {0} \nCity: {1} \nAge: {2} \nPin: {3}"
                ,name,city,age,pin);
            
            Console.WriteLine("==================================\n\n");

            Console.ReadLine();//Console open for output

        }
    }
}
