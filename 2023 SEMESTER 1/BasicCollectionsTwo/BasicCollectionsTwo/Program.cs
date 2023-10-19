using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCollectionsTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program to show use of List<T>
            //import -- how you declare List T
            //dynamic resizability -->on the fly
            //number of items not needed upon declaration 

            //create a list of int's
            List<int> someList = new List<int>();
            //add items onto list
            someList.Add(34);
            someList.Add(567);
            someList.Add(100);
            someList.Add(-5);
            someList.Add(88);


                //output
            Console.WriteLine("Iterations through basic list's \n");
            foreach (var item in someList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n\n");//space

            //declare a List of T holding some string values 
            List<string> names = new List<string>();
            names.Add("John");
            names.Add("Sue");
            names.Add("Jae");
            names.Add("Henry");

            //output
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }












            Console.ReadLine();

        }
    }
}
