using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestForCabInvoiceGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("UC1")]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORAML);
            double distance = 3.9;
            int time = 4;
            //calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double excepted = 43;
            Assert.AreEqual(excepted, fare);
        }
    }
}
