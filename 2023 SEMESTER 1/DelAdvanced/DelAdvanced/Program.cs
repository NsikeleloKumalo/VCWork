using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelAdvanced
{
    //global del 
    public delegate void someMethodDel(string msgDel);
    public delegate void valuesOneDel(int aDel, int bDel);
    class Program
    {
       
        static void Main(string[] args)
        {
            /*  someMethodDel smd = new someMethodDel(someMethod);
           */
            //LAMBDA EXPRESSIONS
            someMethodDel smd =  msgDel =>
            {
                //AT THIS POINT ITS AN ANNONYMOUS METHHOD 
                Console.WriteLine(msgDel);
            };
            smd.Invoke("Testing consuming a method");

            //anonymous test
            valuesOneDel vod =  ( aDel,  bDel) =>
            {
                int sum = aDel + bDel;
                Console.WriteLine(sum);

            };
            vod(5, 6);
            Console.ReadLine();
        }


        ////ANONYMOUS 

        ///*  someMethodDel smd = new someMethodDel(someMethod);
        // */
        //someMethodDel smd = delegate (string msgDel)
        //    {
        //        //AT THIS POINT ITS AN ANNONYMOUS METHHOD 
        //        Console.WriteLine(msgDel);
        //    };
        //      smd.Invoke("Testing consuming a method");

        //    //anonymous test
        //    valuesOneDel vod = delegate (int aDel, int bDel)
        //    {
        //        int sum = aDel + bDel;
        //        Console.WriteLine(sum);

        //    };
        //    vod(5, 6);
        //    Console.ReadLine();
        //}
        /*Delegates ---> encompasses 3 elements
         * 1 --> delegate--> 3 steps
         * 2 --> Anonymous methods
         *          Is a method without a NAME
         *          Only has a body
         *          Doent need a return type 
         *          Used a delegate parameter
         * 3 --> Lambda expressions
         *      => notation
         *      to go to
         *  Situation --> anonymous method ++ del ++ lambda 
         *              -- further reduce code 
         *              --Delegate keyword  drops 
         *              -- return type drops 
         *              
         *      
        
         */
        //THIS IS NOT ALLOWED 
        //public static void someMethod (string msg)
        //{
        //    Console.WriteLine(msg);
        //}

        //public static void valuesOne(int a , int b)
        //{
        //    int sum = a + b;
        //    Console.WriteLine(sum);
        //}
       
    }
}
