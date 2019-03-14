using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServiceTypeId { get; set; }
        public double PricePerHour { get; set; }
        public string Description { get; set; }

        public Service()
        {

        }
        public Service(string serviceName, int serviceTypeId, double pricePerHour)
        {
            ServiceName = serviceName;
            ServiceTypeId = serviceTypeId;
            PricePerHour = pricePerHour;
        }
        public Service(string serviceName, int serviceTypeId, double pricePerHour, string description)
        {
            ServiceName = serviceName;
            ServiceTypeId = serviceTypeId;
            PricePerHour = pricePerHour;
            Description = description;
        }
    }
}
