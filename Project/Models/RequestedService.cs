using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class RequestedService
    {
        [Key]
        public int RequestedServiceId { get; set; }
        [ForeignKey("ServiceForeignKey")]
        public int ServiceId { get; set; }
        [ForeignKey("UserForeignKey")]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

        //[ForeignKey("ServiceForeignKey")]
        //public Service Service { get; set; }
        //[ForeignKey("UserForeignKey")]
        //public GeneralUser User { get; set; }

        public RequestedService(int serviceId, int userId, DateTime date, string address)
        {
            ServiceId = serviceId;
            UserId = userId;
            Date = date;
            Address = address;
        }
    }
}
