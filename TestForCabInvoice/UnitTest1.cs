using NUnit.Framework;
using Invoice_Generator;
using System;
using Assert = NUnit.Framework.Assert;

namespace TestForCabInvoice
{
    public class Tests
    {
        //Invoice Generator Reference.
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }
        //Step 1:- Calculate Fare
        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            //Creating instance of InvoiceGenerator For Normal Ride. 
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            //Asserting values.
            Assert.AreEqual(expected, fare);
        }
        //Step 2:- Multiple Rides        
        /// <summary>
        /// Givens the multiple ride should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturn_InvoiceSummary()
        {
            //Creating instance of InvoiceGenerator For Normal Ride. 
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            //Generating Summary For Rides.
            ISummary summary = invoiceGenerator.CalculateFare(rides);
            ISummary expectedSummary = new ISummary(2, 35.0);
            //Asserting Values.
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        //Step 3:- Enhanced Invoice        
        /// <summary>
        /// Givens the multiple ride should return total no rides fare average fare per ride.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturn_TotalNoRides_Fare_AverageFarePerRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 3) };
            ISummary enhancedSummary = invoiceGenerator.CalculateFare(rides);
            ISummary expectedEnhancedSummary = new ISummary(2, 30);
            Assert.AreEqual(expectedEnhancedSummary, enhancedSummary);
        }
        //Step 4:- Invoice Service        
        /// <summary>
        /// Givens the user identifier should return ride list and invoice.
        /// </summary>
        [Test]
        public void GivenUserId_ShouldReturn_RideListAndInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] ride1 = { new Ride(2.0, 5), new Ride(0.1, 3) };
            Ride[] ride2 = { new Ride(5.0, 7), new Ride(15.0, 27), };
            string P1 = "Tony";
            string P2 = "Chris";
            RideRepo rideRepository = invoiceGenerator.GetRepo();
            rideRepository.AddRide(P1, ride1);
            rideRepository.AddRide(P2, ride2);
            ISummary invoice_P1 = invoiceGenerator.GetInvoiceSummary(P1);
            ISummary expectedInvoice_P1 = new ISummary(2, 30);
            Assert.AreEqual(invoice_P1, expectedInvoice_P1);
        }
        //Step 5:- Premium Rides(Bonus)        
        /// <summary>
        /// Givens the distance and time for premium should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
    }
}