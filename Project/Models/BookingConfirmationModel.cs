using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Represents data needed for booking confirmation
    /// </summary>
    public class BookingConfirmationModel
    {

        /// <value>
        /// Value of discount
        /// </value>
        public double Discount { get; set; }

        /// <value>
        /// Value of ServiceId
        /// </value>
        public int ServiceId { get; set; }

        /// <value>
        /// Value of Requested SErvice Id
        /// </value>
        public int RequestedServiceId { get; set; }

        /// <value>
        /// Value of Payment Id
        /// </value>
        public int PaymentId { get; set; }
    }
}
