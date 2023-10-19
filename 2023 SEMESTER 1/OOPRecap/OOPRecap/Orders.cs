using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPRecap
{
    class Orders
    {
        //objects
        private string orderId;
        private string custName;
        private int noOfBurgers;
        private int noOfDrinks;

        /*public Orders()
        {
            //this is the default constructor 
            // type ctor then press tab
        }
        */
        public Orders(string orderId, string custName, int noOfBurgers, int noOfDrinks)
        {
            this.orderId = orderId;
            this.custName = custName;
            this.noOfBurgers = noOfBurgers;
            this.noOfDrinks = noOfDrinks;
        }
        //gets and sets
        // highlight your selected code
        // rigt click on the highlighted code 
        //select Quick actions and refactoring (Ctrl+)
        //Encapsulate field

        public string OrderId { get => orderId; set => orderId = value; }
        public string CustName { get => custName; set => custName = value; }
        public int NoOfBurgers { get => noOfBurgers; set => noOfBurgers = value; }
        public int NoOfDrinks { get => noOfDrinks; set => noOfDrinks = value; }


        //overide 
        /*Right click on an empty space or where you want to place your code 
         * select Quick actions and refactoring (Ctrl+)
         * Generate overides 
         * 
         */
        public override string ToString()
        {

            Console.WriteLine("Your order details are >>>");
            return this.orderId + "\n" +
                this.custName + "\n" +
                this.noOfBurgers + "\n" +
                this.noOfDrinks;
               
        }




        /* --how to gain access to these objects 
         * method 1 --> gets and sets
         * method 2 --> Constructors
         * constructors -- 2 types 
         *                  --paramatized
         *                  --default
         * output -- string output
         * built in methods --> overide ToString
         */
    }
}
