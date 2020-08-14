using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class MultipleRides
    {
        public double distance;
        public int time;
        public CabRide rideType;
        
        public MultipleRides(CabRide rideType,double distance,int time)
        {
            this.distance = distance;
            this.time = time;
            this.rideType = rideType;
        }
    }
}
