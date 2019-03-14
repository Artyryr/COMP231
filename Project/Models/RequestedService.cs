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
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string Province { get; set; }
        public double NumberOfHours { get; set; }

        //[ForeignKey("ServiceForeignKey")]
        //public Service Service { get; set; }
        //[ForeignKey("UserForeignKey")]
        //public GeneralUser User { get; set; }

        public RequestedService() { }
        public RequestedService(int serviceId, int userId, DateTime date, string apartment,string street, string city, string zip, string province, double numberOfHours)
        {
            ServiceId = serviceId;
            UserId = userId;
            Date = date;
            Apartment = apartment;
            Street = street;
            City = city;
            ZIP = zip;
            Province = province;
            NumberOfHours = numberOfHours;
        }
    }
}
