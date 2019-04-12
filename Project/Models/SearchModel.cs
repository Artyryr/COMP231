using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model for the search page
    /// </summary>
    public class SearchModel
    {
        ///<value>
        /// Search criteria
        ///</value>
        public string SearchName{ get; set; }

        ///<value>
        /// List of found Services
        ///</value>
        public List<Service> Services { get; set; }

        ///<value>
        /// Applied Filters
        ///</value>
        public string Filter { get; set; }
    }
}
