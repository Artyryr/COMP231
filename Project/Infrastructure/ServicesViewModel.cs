using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    /// <summary>
    /// Instance for storing database information in tables
    /// </summary>
    public class ServicesViewModel
    {
        /// <value>
        /// List of Services
        /// </value>
        public IEnumerable<Service> Services { get; set; }

        /// <value>
        /// List of Service Types
        /// </value>
        public IEnumerable<ServiceType> ServiceTypes { get; set; }

        /// <value>
        /// List of Requested Services
        /// </value>
        public IEnumerable<RequestedService> RequestedServices { get; set; }
    }
}
