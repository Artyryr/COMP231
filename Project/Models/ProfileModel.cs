using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ProfileModel
    {
        public GeneralUser User { get; set; }
        public List<ServiceRequestSummary> RequestedServices { get; set; }
        public Payment UserPayment { get; set; }
    }
}
