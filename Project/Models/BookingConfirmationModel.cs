using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class BookingConfirmationModel
    {
        public double Discount { get; set; }
        public int ServiceId { get; set; }
        public int RequestedServiceId { get; set; }
        public int PaymentId { get; set; }
    }
}
