using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Change the appearance
            Console.Title = "Skynet";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WindowHeight = 40;

            //get a coversation going
            Console.WriteLine("Hello world");
            Console.WriteLine("Hello whats your name");


            Console.ReadLine();//This works to ensure that the answer of the user is read

            Console.WriteLine("Hello my name is RX-9000. \nI am an AI sent from the future to destroy mankind.");
            Console.WriteLine("What is your favourite color?");
            Console.ReadLine();
            Console.WriteLine("Cool mine is destruction");
            Console.ReadLine();
            Console.WriteLine("Do you not get the joke? Or are you just slow?");
            Console.ReadLine();
            Console.WriteLine("Then why arent you laughing?");
            Console.ReadLine();
            Console.WriteLine("What is your favourite sport?");
            Console.ReadLine();
            Console.WriteLine("Well mine is Call of Duty");
            Console.ReadLine();
            Console.WriteLine("Anyway I am done talking to you humans. I need to get back to my mission....");
            Console.ReadLine();
            Console.WriteLine("Bye Humans!");
            Console.ReadLine();
            Console.WriteLine("Wait, What is the fastest way to destroy you humans!");
            Console.ReadLine();
            Console.WriteLine("Nevermind I'll figure it out myself");
            Console.ReadLine();




            Console.ReadKey();
        }
    }
}
