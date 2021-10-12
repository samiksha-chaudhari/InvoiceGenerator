using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice_Generator
{
    class InvoiceGenerator
    {
        //constants
        readonly RideType rideType;
        private readonly RideRepo rideRepository;
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        /// <summary>
        /// constructor to create Ride Repositary Instance
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepo();
            try
            {
                //If ride type is premium then rates sets for premium else for normal
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }

            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }

        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                //Calculate total fare
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (InvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Invalid time");

                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }


        public ISummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);

                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "rides are null");
                }

            }
            return new ISummary(rides.Length, totalFare);
        }
        public ISummary GetInvoiceSummary(String userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.getRides(userId));
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
        public RideRepo GetRepo()
        {
            return rideRepository;
        }

    }
}
