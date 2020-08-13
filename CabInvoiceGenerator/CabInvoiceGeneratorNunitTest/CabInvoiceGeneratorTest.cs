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
            MultipleRides[] rides = { new MultipleRides(2.0, 5), new MultipleRides(3.0, 6) };
            double fare = invoiceGenerator.CalculateMultipleFare(rides);
            Assert.AreEqual(61, fare,0.0);
        }

        [Test]
        public void GivenMultipleRides_ThenCalculateFare_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            MultipleRides[] rides = { new MultipleRides(2.0, 5), new MultipleRides(3.0, 6) };
            EnhancedInvoice invoiceSummary = invoice.CalculateMultipleFareRidesSummary(rides);
            EnhancedInvoice expected = new EnhancedInvoice { numberOfRides = 2, totalFare = 61, averageFarePerRide = 30.5 };
            object.Equals(expected, invoiceSummary);

        }
    }
}