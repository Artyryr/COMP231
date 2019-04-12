using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model of requested service
    /// </summary>
    public class RequestedService
    {
        ///<value>
        /// Id of a Requested Service
        ///</value>
        [Key]
        public int RequestedServiceId { get; set; }
        [ForeignKey("ServiceForeignKey")]

        ///<value>
        /// Id of a Service that was requested
        ///</value>
        public int ServiceId { get; set; }

        ///<value>
        /// Id of a User that requested service 
        ///</value>
        public string UserId { get; set; }

        ///<value>
        /// First Name of a User that requested service 
        ///</value>
        [Required(ErrorMessage = "The First Name is required.")]
        public string FirstName { get; set; }

        ///<value>
        /// Last name of a User that requested service 
        ///</value>
        [Required(ErrorMessage = "The Last Name is required.")]
        public string LastName { get; set; }

        ///<value>
        /// Telephone of a User that requested service 
        ///</value>
        [Required(ErrorMessage = "The Telephone is required.")]
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})",
            ErrorMessage = "Please put telephone in format \"647-333-333\" or \"647333333\" ")]
        public string Telephone { get; set; }

        ///<value>
        /// Email of a User that requested service 
        ///</value>
        [Required(ErrorMessage = "The E-mail is required.")]
        public string Email { get; set; }

        ///<value>
        /// Date for a requested service 
        ///</value>
        [Required(ErrorMessage = "The Date is required.")]
        public DateTime Date { get; set; }

        ///<value>
        /// Apartment for a requested service 
        ///</value>
        [Required(ErrorMessage = "The Apartment is required.")]
        public string Apartment { get; set; }

        ///<value>
        /// Street for a requested service 
        ///</value>
        [Required(ErrorMessage = "The Street is required.")]
        public string Street { get; set; }

        ///<value>
        /// City for a requested service 
        ///</value>
        [Required(ErrorMessage = "The City is required.")]
        public string City { get; set; }

        ///<value>
        /// ZIP for a requested service 
        ///</value>
        [Required(ErrorMessage = "The ZIP is required.")]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] ?[0-9][a-zA-Z][0-9]", ErrorMessage = "PLease type ZIP in format \"M1G 3T8\'")]
        public string ZIP { get; set; }

        ///<value>
        /// Province for a requested service 
        ///</value>
        [Required(ErrorMessage = "The Province is required.")]
        public string Province { get; set; }

        ///<value>
        /// Number of hours for a requested service 
        ///</value>
        [Required(ErrorMessage = "The Number of hours is required.")]
        public double NumberOfHours { get; set; }

        ///<value>
        /// Total frice of a requested service 
        ///</value>
        public double TotalPrice { get; set; }

        ///<value>
        /// Payment for a requested service 
        ///</value>
        public Payment Payment { get; set; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        public RequestedService() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="date"></param>
        /// <param name="apartment"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="zip"></param>
        /// <param name="province"></param>
        /// <param name="numberOfHours"></param>
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
        /// <summary>
        /// Method for addign a payment method
        /// </summary>
        /// <param name="payment">Payment</param>
        public void AddPayment(Payment payment)
        {
            Payment = payment;
        }
    }
}
