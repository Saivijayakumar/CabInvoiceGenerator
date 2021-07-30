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
        [TestMethod]
        [TestCategory("UC 2")]
        public void GivenMultipleRidesShouldReturnTotalFareSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORAML);
            Ride[] rides = { new Ride(2.0, 4), new Ride(3.9, 4) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 67);
            Assert.AreEqual(summary.totalFare, expectedSummary.totalFare);
        }
        [TestMethod]
        [TestCategory("UC 3")]
        public void GivenMultipleRidesShouldReturnInvoiceSummaryUsingOverrideEqualMethod()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORAML);
            Ride[] rides = { new Ride(2.0, 4), new Ride(3.9, 4) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 67);
            //overiding equals method to check the values in both object are same are not 
            //because both objects are in diffrent address but they belong to same class
            var res = summary.Equals(expectedSummary);
            Assert.IsTrue(res);
        }
        [TestMethod]
        [TestCategory("UC 3")]
        public void GivenMultipleRidesShouldReturnInvoiceSummaryUsingAreequal()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORAML);
            Ride[] rides = { new Ride(2.0, 4), new Ride(3.9, 4) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 67);
            Assert.AreEqual(summary, expectedSummary);
        }
        [TestMethod]
        [TestCategory("UC 4")]
        public void GivenUserIdAndReturnFare()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide(1, rides);
            var rideArray = rideRepository.GetRides(1);
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORAML);

            InvoiceSummary summary = new InvoiceSummary(2, 30.0);
            InvoiceSummary expected = invoice.CalculateFare(rideArray);
            Assert.AreEqual(summary, expected);
        }

    }
}
