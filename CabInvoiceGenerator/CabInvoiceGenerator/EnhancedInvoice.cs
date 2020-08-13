using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class EnhancedInvoice
    {
        public int numberOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFarePerRide { get; set; }
        
        public void AverageFareOfCab()
        {
            averageFarePerRide = totalFare / numberOfRides;
        }
    }
}
