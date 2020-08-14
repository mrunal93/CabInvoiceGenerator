using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorNunitTest
{
    public class CabInvoiceGeneratorTest
    {
        [Test]
        public void GivenDistanceAndTime_ThenCalculateFare_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double DISTANCE = 3.0;
            int TIME = 5;
            double fare = invoiceGenerator.CalculateFare(DISTANCE, TIME);
            Assert.AreEqual(35, fare);
        }

        [Test]
        public void GivenMultipleRides_ThenCalculateFare_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            MultipleRides[] rides = { new MultipleRides(CabRide.NORMAL,2.0, 5), new MultipleRides(CabRide.NORMAL,3.0, 6) };
            double fare = invoiceGenerator.CalculateMultipleFare(rides);
            Assert.AreEqual(61, fare);
        }

        [Test]
        public void GivenMultipleRides_ThenCalculateFare_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            MultipleRides[] rides = { new MultipleRides(CabRide.NORMAL,2.0, 5), new MultipleRides(CabRide.NORMAL,3.0, 6) };
            double invoiceSummary = invoice.CalculateMultipleFare(rides);
            EnhancedInvoice expected = new EnhancedInvoice(2,61);
            object.Equals(expected, invoiceSummary);
        }

        [Test]
        public void GivenUserIdAndMultipleRides_ThenCalculateFare_shouldReturnNullUserException()
        {
            string userId = null;
            MultipleRides[] rides = { new MultipleRides(CabRide.NORMAL,2, 5), new MultipleRides(CabRide.NORMAL,3, 6) };
            RideRepository rideRepository = new RideRepository();
            CustomException exception = Assert.Throws<CustomException>(() => rideRepository.AddRides(userId, rides));
            Assert.AreEqual("NULL_EXCEPTION", exception.message);
        }

        [Test]
        public void GivenUerIDAndListOfRides_WhenCalculated_ThenShouldReturnPremiumInvoice()
        {
            string userId1 = "Mrunal";
            string userId2 = "Agentnas";
            MultipleRides[] rides1 = { new MultipleRides(CabRide.PREMIUM, 2, 5), new MultipleRides(CabRide.PREMIUM, 0.1, 1) };
            MultipleRides[] rides2 = { new MultipleRides(CabRide.PREMIUM, 2, 5), new MultipleRides(CabRide.PREMIUM, 0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId1, rides1);
            rideRepository.AddRides(userId2, rides2);
            InvoiceGenerator invoice = new InvoiceGenerator();
            var totalFareOne = invoice.CalculateMultipleFare(rideRepository.GetRides(userId1));
            var totalFareTwo = invoice.CalculateMultipleFare(rideRepository.GetRides(userId2));
            Assert.AreEqual(30.0, totalFareTwo);
        }
    }
}