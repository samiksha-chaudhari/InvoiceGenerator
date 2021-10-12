using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice_Generator
{
    class ISummary
    {
        //Variables
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        //parameter Constructor For Settling Data.
        public ISummary(int numberOfRides, double totalFare)
        {
            //Setting data.
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        /// <summary>
        /// overriding Equals Methods.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ISummary)) return false;
            ISummary inputObject = (ISummary)obj;
            return this.numberOfRides == inputObject.numberOfRides && this.totalFare == inputObject.totalFare && this.averageFare == inputObject.averageFare;
        }
        /// <summary>
        /// Overriding GetHashCode Method.
        /// </summary>
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
