using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<MultipleRides>> userRide;
        
        public RideRepository()
        {
            this.userRide = new Dictionary<string, List<MultipleRides>>();
        }

        public void AddRides(string UserID,MultipleRides[] rides)
        {
            if (UserID == null)
                throw new CustomException(ExceptionType.NULL_EXCEPTION + "");
            bool checkRide = userRide.ContainsKey(UserID);
            List<MultipleRides> list = new List<MultipleRides>();
            if (checkRide == false)
            {
                list.AddRange(rides);
                userRide.Add(UserID, list);
            }
        }
        public MultipleRides[] GetRides(string userId)
        {
            return userRide[userId].ToArray();
        }
    }
}
