using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    public class ServicesViewModel
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public IEnumerable<RequestedService> RequestedServices { get; set; }
    }
}
