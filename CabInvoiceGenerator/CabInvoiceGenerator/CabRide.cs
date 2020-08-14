using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabRide
    {
        public static readonly CabRide NORMAL = new CabRide(10, 1, 5);
        public static readonly CabRide PREMIUM = new CabRide(15, 2, 20);

        private double costPerKilometer;
        private int costPerMinute;
        private double minimumFar;

        private CabRide(double costPerKilometer,int costPerMinute, double minimumFare)
        {
            this.costPerKilometer = costPerKilometer;
            this.costPerMinute = costPerMinute;
            this.minimumFar = minimumFare;
        }

        public double CalculateCostOfCabRide(MultipleRides ride)
        {
            double totalFare;
            totalFare = ride.distance * costPerKilometer + ride.time * costPerMinute;
            if (totalFare < minimumFar)
                return minimumFar;
            return totalFare;
        }

    }
}
