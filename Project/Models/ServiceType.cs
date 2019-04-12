using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Type of a service
    /// </summary>
    public class ServiceType
    {
        ///<value>
        /// id of a service type
        ///</value>
        [Key]
        public int ServiceTypeId { get; set; }

        ///<value>
        /// Name of a service type
        ///</value>
        public string  ServiceTypeName { get; set; }

        ///<value>
        /// Service type description
        ///</value>
        public string  Description { get; set; }

        /// <summary>
        /// Basic constructor for a service Type
        /// </summary>
        public ServiceType()
        {

        }

        /// <summary>
        /// Service type constructor 
        /// </summary>
        /// <param name="serviceTypeName">Name of type</param>
        /// <param name="description">Description </param>
        public ServiceType(string serviceTypeName, string description)
        {
            ServiceTypeName = serviceTypeName;
            Description = description;
        }
    }
}
