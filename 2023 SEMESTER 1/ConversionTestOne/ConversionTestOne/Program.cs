using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionTestOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1 --> Task 2
            //arrays, arrayslist --List<T>
            //remove for loops make foreach loops

            //basic arrays 
            var someArray = new int[] { 234,4564,678};

            //Version 1--> ToList Method
            var someLiist = someArray.ToList();


            //foreach
            Console.WriteLine("List using tolist method");
            foreach (var item in someLiist)
            {
                Console.WriteLine(item);
            }

            //version 2 --> conversions --> List constructor 
            //array is passed as a parameter 

            var someArrayTwo = new int[] { 1213, 543, 45 };
            var someListTwo = new List<int>();
            someListTwo.AddRange(someArrayTwo);
            foreach (var item in someListTwo)
            {
                Console.WriteLine(item);
            }

            //version 3 --> create a new object of List<T>
            int[] arrayThree = { 234, 456, 678};
            List<int> newListThree = new List<int>();
            newListThree.AddRange(arrayThree);
            foreach (var item in newListThree)
            {
                Console.WriteLine(item);
            }
                               

            Console.ReadLine();
        }
    
    }
}
