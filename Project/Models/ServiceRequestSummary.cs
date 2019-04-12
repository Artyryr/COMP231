using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model for a request summary page
    /// </summary>
    public class ServiceRequestSummary
    {
        ///<value>
        /// Name of the reqeusted service
        ///</value>
        public string ServiceName { get; set; }

        ///<value>
        /// Price Per Hour of a specific service
        ///</value>
        public double PricePerHour { get; set; }
        ///<value>
        /// Number of hours requested
        ///</value>
        public double NumberOfHours { get; set; }

        ///<value>
        /// Requested date
        ///</value>
        public DateTime Date { get; set; }

        ///<value>
        /// Total resulterd price
        ///</value>
        public double TotalPrice { get; set; }
    }
}
