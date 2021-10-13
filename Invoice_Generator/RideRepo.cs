using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice_Generator
{
    public class RideRepo
    {
        //Dictionary to store UserId and Rides int list
        readonly Dictionary<string, List<Ride>> userRides = null;
        /// <summary>
        /// Constructor to create dictionary.
        /// </summary>
        public RideRepo()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// Functions to Adds the ride.
        /// </summary>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
        /// <summary>
        /// Function to Gets the rides as an Array for specifies userId.
        /// </summary>
        public Ride[] getRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }

    }
}
