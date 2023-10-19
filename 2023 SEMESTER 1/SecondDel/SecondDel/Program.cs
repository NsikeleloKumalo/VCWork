using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondDel
{
    class Program
    {
        public delegate void someTextDel(string text);
        public delegate void someMathDel(int aDel, int bDel);
        static void Main(string[] args)
        {

            someTextDel std = new someTextDel(someText);

            //step 3 -- Invoke
            std("Delegate consuming a function >>>");

            Program p = new Program();
            someMathDel smd = new someMathDel(p.someMath);
            smd.Invoke(5,8);
            Console.ReadLine();
        }
        //method 1
     
public static void someText(string text)
        {
            Console.WriteLine(text);
        }

        //method 2
       
public void someMath(int a, int b)
        { 
Console.WriteLine("The values added: " + (a + b));
}
}

}
