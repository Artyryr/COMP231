using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ServiceRequestModel
    {
        public RequestedService RequestedService { get; set; }
        public GeneralUser User { get; set; }
        public int ServiceId { get; set; }
        public Payment Payment { get; set; }
        public double Discount { get; set; }
    }
}
