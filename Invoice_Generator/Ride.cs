using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice_Generator
{
    class Ride
    // Ride Class To Set Data For Particular Ride
    {
        //Variables.
        public double distance;
        public int time;
        /// <summary>
        /// Parameter Constructor Settling Data.
        /// </summary>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
