using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryChp8
{

    //create an interface

        interface IPerson
    {
       // public void print()
             void print();
        //{
        //    Console.WriteLine("Testing");
        //}

    }

    class Person : IPerson
    {
        public void print()
        {
            Console.WriteLine("Testing");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Abstract classes and abstraction rules
             * -- must contain the keyword abstact
             * --can obtain field --> variables
             * --can have normal methods and abstract methods 
             * --can inherit from an interface and an abstract class
             * --can specify access modifiers 
             * 
             * INTERFACES & IMPLEMENTATION 
             * --must contain keyword interface
             * --cannot have fields 
             * --ONLY INHERIT FROM ANOTHER INTERFACE
             * Access modifiers not allowed --> public by default
             * can only have av=bstract methods
             */

            Person p = new Person();
            p.print();
        }
    }
}
