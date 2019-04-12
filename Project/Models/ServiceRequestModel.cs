using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model for service request handling 
    /// </summary>
    public class ServiceRequestModel
    {
        ///<value>
        /// Reqeusted Service
        ///</value>
        public RequestedService RequestedService { get; set; }

        ///<value>
        /// User that has made a request
        ///</value>
        public GeneralUser User { get; set; }

        ///<value>
        /// Id of a service
        ///</value>
        public int ServiceId { get; set; }

        ///<value>
        /// Payment information
        ///</value>
        public Payment Payment { get; set; }

        ///<value>
        /// Discount information
        ///</value>
        public double Discount { get; set; }

        ///<value>
        /// Service itself
        ///</value>
        public Service Service{ get; set; }
    }
}
