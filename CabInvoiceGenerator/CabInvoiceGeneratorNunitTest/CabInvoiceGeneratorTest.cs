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
            double DISTANCE = 2.0;
            int TIME = 5;
            double fare = invoiceGenerator.CalculateFare(DISTANCE, TIME);
            Assert.AreEqual(25, fare);
        }
    }
}