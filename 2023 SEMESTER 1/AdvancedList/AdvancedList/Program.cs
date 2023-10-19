using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an obj of List T --> using statement
            List<string> itemList = new List<string>();

            Console.WriteLine("Add items into the list >>>>");
            //logical problem --> restrict the input -- only 5 entries 
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i+1 + " :");
                var listInput = Console.ReadLine();
                itemList.Add(listInput);
               
            }
            Console.WriteLine("End of input >>>>>");
            // output --> prints out all current ingredients
            Console.WriteLine("\n\nItems currently in stock >>>>\n");

            for (int i = 0; i < 5; i++)
            {
                var item = itemList[i];
                Console.WriteLine($"{i + 1} : {item}");
            }



            Console.ReadLine();

        }
    }
}
