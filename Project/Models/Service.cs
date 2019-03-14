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
        [ForeignKey("ServiceTypeForeignKey")]
        public int ServiceTypeId { get; set; }

        public Service(string serviceName, int serviceTypeId)
        {
            ServiceName = serviceName;
            ServiceTypeId = serviceTypeId;
        }
    }
}
