using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<MultipleRides>> userRideObject;
        
        public RideRepository()
        {
            this.userRideObject = new Dictionary<string, List<MultipleRides>>();
        }

        public void AddRides(string UserID,MultipleRides[] rides)
        {
            if (UserID == null)
                throw new CustomException(ExceptionType.NULL_EXCEPTION + "");
            bool checkRide = userRideObject.ContainsKey(UserID);
            List<MultipleRides> list = new List<MultipleRides>();
            if (checkRide == false)
            {
                list.AddRange(rides);
                userRideObject.Add(UserID, list);
            }
        }
    }
}
