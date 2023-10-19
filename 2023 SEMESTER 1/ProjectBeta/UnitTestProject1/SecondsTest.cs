using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{

    [TestClass]
    public class SecondsTest
    {

        [TestMethod]
        public void Testdivision()
        {
            //arrange
            int values1 = 10;
            int values2 = 2;
            int expected = 5;

            //act
            int actual = ProjectBeta.Seconds.division(values1, values2);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    }
