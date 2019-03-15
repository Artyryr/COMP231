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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})",
            ErrorMessage = "Please put telephone in format \"647-333-333\" or \"647333333\" ")]
        public string Telephone { get; set; }
        public string Email { get; set; }
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
        public RequestedService(int serviceId, string firstName, string lastName, string telephone, string email, DateTime date, string apartment,string street, string city, string zip, string province, double numberOfHours)
        {
            ServiceId = serviceId;
            Date = date;
            Apartment = apartment;
            Street = street;
            City = city;
            ZIP = zip;
            Province = province;
            NumberOfHours = numberOfHours;
            FirstName =firstName;
            LastName = lastName;
            Telephone = telephone;
            Email = email;
        }
    }
}
