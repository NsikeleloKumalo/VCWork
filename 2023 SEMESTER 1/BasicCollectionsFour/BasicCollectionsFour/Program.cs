using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCollectionsFour
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack
            //imports from the collections class
            Stack stack = new Stack();

            /* --Push --> inserts an object into the stack
             * --Pop --> Removes & returnsz an item at the top
             * --Clear --> removes all items in the stack
             * -- Clone --> creates a shallow copy of the stack
             * -- Contains --> checks if an item exists in the stack 
             *      --> returns a bool --> T/F
             *  --Peek --> returns the top item in the stack
             * -- -- -- -- -- LIFO(Last in First Off) -- -- -- -- --
             */
            stack.Push("First item");
            stack.Push("Second item");
            stack.Push(1000);
            stack.Push(null);
            stack.Push(3.14159);
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
