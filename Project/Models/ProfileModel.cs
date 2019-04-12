using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model of a profile page
    /// </summary>
    public class ProfileModel
    {
        ///<value>
        /// CUrrent user and all information
        ///</value>
        public GeneralUser User { get; set; }

        ///<value>
        /// All requested services made by this user
        ///</value>
        public List<ServiceRequestSummary> RequestedServices { get; set; }

        ///<value>
        /// stored payment method for a user
        ///</value>
        public Payment UserPayment { get; set; }
    }
}
