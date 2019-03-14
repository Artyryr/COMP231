using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class GeneralUser : IdentityUser
    {
        //public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})",
            ErrorMessage = "Please put telephone in format \"647-333-333\" or \"647333333\" ")]
        public string Telephone { get; set; }
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] ?[0-9][a-zA-Z][0-9]", ErrorMessage ="PLease type ZIP in format \"M1G 3T8\'")]
        public string ZIP { get; set; }
        public string Province { get; set; }
        //public List<Service> UserServices { get; set; }

        //public GeneralUser(string email,string firstName, string lastName, string telephone, string apartment, string street, string city, string zip, string province)
        //{
        //    Email =
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Telephone = telephone;
        //    Apartment = apartment;
        //    Street = street;
        //    City = city;
        //    ZIP = zip;
        //    Province = province;
        //}
    }
}
