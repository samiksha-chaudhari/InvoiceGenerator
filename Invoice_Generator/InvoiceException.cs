using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice_Generator
{
    class InvoiceException : Exception
    {
        /// <summary>
        /// enum for exception type
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }

        ExceptionType type;
        /// <summary>
        /// parameter constructor For settling exception type and throwing exception.
        /// </summary>
        public InvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
