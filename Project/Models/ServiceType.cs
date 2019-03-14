using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string  ServiceTypeName { get; set; }
        public string  Description { get; set; }

        public ServiceType()
        {

        }
        public ServiceType(string serviceTypeName, string description)
        {
            ServiceTypeName = serviceTypeName;
            Description = description;
        }
    }
}
