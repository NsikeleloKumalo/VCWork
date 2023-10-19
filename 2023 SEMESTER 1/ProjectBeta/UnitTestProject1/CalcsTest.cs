using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcsTest
    {
        [TestMethod]
        public void Testaddition()
        {
            //arrange
            int value1 = 5;
            int value2 = 10;
            int expected = 15;


            //act
           int actual =  ProjectBeta.Calcs.addition(value1, value2);


            //assert
            Assert.AreEqual(expected, actual);
                
        }
        /*naming conventions
         * --class test name -- classnameTest
         * ---method test -- testmethodname 
         * 
         * 
         * 
         */
    }
}
