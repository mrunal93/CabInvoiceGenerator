using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private static readonly int MINIMUM_COST_PER_KILOMETER = 10;
        private static readonly int COST_PER_TIME = 1;
        private static readonly double MINIMUM_FARE = 5;

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_COST_PER_KILOMETER + time * COST_PER_TIME;
            if (totalFare < MINIMUM_FARE)
                return MINIMUM_FARE;
            return totalFare;
        }

        public double CalculateMultipleFare(MultipleRides[] rides)
        {
            double totalFare = 0;
            foreach (MultipleRides ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }

        public EnhancedInvoice CalculateMultipleFareRidesSummary(MultipleRides[] rides)
        {
            double totalFare = 0;
            int numberOfRides = 0;
            foreach(MultipleRides ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
                numberOfRides += 1;
            }
            EnhancedInvoice invoiceSummary = new EnhancedInvoice();
            invoiceSummary.numberOfRides = numberOfRides;
            invoiceSummary.totalFare = totalFare;
            invoiceSummary.AverageFareOfCab();
            return invoiceSummary;
        }
    }
}
