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
        public string Telephone { get; set; }
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
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
