using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Class taht specifies interactions with database
    /// </summary>
    public class ServiceRepository : IServiceRepository
    {
        private ApplicationDbContext context;
        
        /// <summary>
        /// Innitializes value of a context
        /// </summary>
        /// <param name="ctx"></param>
        public ServiceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        ///<value>
        /// Gets list of Aervices
        ///</value>
        public IQueryable<Service> Services => context.Services;

        ///<value>
        /// Gets list of ServiceType
        ///</value>
        public IQueryable<ServiceType> ServiceTypes => context.ServiceTypes;

        ///<value>
        /// Gets list of Requested Aervices
        ///</value>
        public IQueryable<RequestedService> RequestedServices => context.RequestedServices;

        ///<value>
        /// Gets list of Reviews
        ///</value>
        public IQueryable<Review> Reviews => context.Reviews;

        ///<value>
        /// Gets list of Payments
        ///</value>
        public IQueryable<Payment> Payments => context.Payments;

        /// <summary>
        /// Adds Service 
        /// </summary>
        /// <param name="service">Service</param>
        public void AddService(Service service)
        {
            //if service id == 0 that the service is a new one
            //Adding a new service to the database
            if (service.ServiceId == 0)
            {
                context.Services.Add(service);
            }
            //if the service is an existing one
            else
            {
                //find the service in the database
                Service dbEntry = context.Services
                    .FirstOrDefault(p => p.ServiceId == service.ServiceId);

                if (dbEntry != null)
                {
                    //update all values of the service
                    dbEntry.ServiceName = service.ServiceName;
                    dbEntry.ServiceTypeId = service.ServiceTypeId;
                    dbEntry.PricePerHour = service.PricePerHour;
                    dbEntry.Description = service.Description;
                }
            }
            //update the sevice in the database
            context.SaveChanges();
        }

        /// <summary>
        /// Removes service
        /// </summary>
        /// <param name="id">ServiceID</param>
        public void RemoveService(int id)
        {
            //if the service is an existing one
            if (context.Services.Where(p => p.ServiceId == id).FirstOrDefault() != null)
            {
                context.Services.Remove(context.Services.Where(p => p.ServiceId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds ServiceType
        /// </summary>
        /// <param name="serviceType">ServiceType</param>
        public void AddServiceType(ServiceType serviceType)
        {
            //if service id == 0 that the service type is a new one
            //Adding a new service type to the database
            if (serviceType.ServiceTypeId == 0)
            {
                context.ServiceTypes.Add(serviceType);
            }
            else
            {
                //find the service type in the database
                ServiceType dbEntry = context.ServiceTypes
                    .FirstOrDefault(p => p.ServiceTypeId == serviceType.ServiceTypeId);

                if (dbEntry != null)
                {
                    //update all values of an existing service type
                    dbEntry.ServiceTypeName = serviceType.ServiceTypeName;
                    dbEntry.Description = serviceType.Description;
                }
            }
            //save changes in the database
            context.SaveChanges();
        }

        /// <summary>
        /// Removes ServiceType 
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        public void RemoveServiceType(int id)
        {
            //if service type is an existing one
            if (context.ServiceTypes.Where(p => p.ServiceTypeId == id).FirstOrDefault() != null)
            {
                context.ServiceTypes.Remove(context.ServiceTypes.Where(p => p.ServiceTypeId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds Reqeusted Service
        /// </summary>
        /// <param name="requestedService">Requested Service</param>
        public void AddRequestedService(RequestedService requestedService)
        {
            //if service id == 0 that the RequestedServices is a new one
            //Adding a new RequestedServices to the database
            if (requestedService.RequestedServiceId == 0)
            {
                context.RequestedServices.Add(requestedService);
            }
            else
            {
                //find the RequestedServices ni the database
                RequestedService dbEntry = context.RequestedServices
                    .FirstOrDefault(p => p.RequestedServiceId == requestedService.RequestedServiceId);

                if (dbEntry != null)
                {
                    //Update all values of the RequestedServices
                    dbEntry.ServiceId = requestedService.ServiceId;
                    dbEntry.UserId = requestedService.UserId;
                    dbEntry.FirstName = requestedService.FirstName;
                    dbEntry.LastName = requestedService.LastName;
                    dbEntry.Telephone = requestedService.Telephone;
                    dbEntry.Email = requestedService.Email;
                    dbEntry.Date = requestedService.Date;
                    dbEntry.Apartment = requestedService.Apartment;
                    dbEntry.Street = requestedService.Street;
                    dbEntry.City = requestedService.City;
                    dbEntry.ZIP = requestedService.ZIP;
                    dbEntry.Province = requestedService.Province;
                    dbEntry.NumberOfHours = requestedService.NumberOfHours;
                }
            }
            //save changes in the database
            context.SaveChanges();
        }
        /// <summary>
        /// Removes Requested Service
        /// </summary>
        /// <param name="id">Requested Service ID</param>
        public void RemoveRequestedService(int id)
        {
            //if the RequestedServices is an existing one
            if (context.RequestedServices.Where(p => p.RequestedServiceId == id).FirstOrDefault() != null)
            {
                context.RequestedServices.Remove(context.RequestedServices.Where(p => p.RequestedServiceId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds a Review
        /// </summary>
        /// <param name="review">Review</param>
        public void AddReview(Review review)
        {
            //if service id == 0 that the review is a new one
            //Adding a new review to the database
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                //searing for an existing review
                Review dbEntry = context.Reviews
                    .FirstOrDefault(p => p.ReviewId == review.ReviewId);

                if (dbEntry != null)
                {
                    //updating all values of review
                    dbEntry.ReviewText = review.ReviewText;
                    dbEntry.ServiceId = review.ServiceId;
                    dbEntry.Rating = review.Rating;
                    dbEntry.UserName = review.UserName;
                    dbEntry.Date = review.Date;
                    dbEntry.UserId = review.UserId;
                }
            }
            //saving changes in the database
            context.SaveChanges();
        }

        /// <summary>
        /// Adds Payment
        /// </summary>
        /// <param name="payment">Payment</param>
        public void AddPayment(Payment payment)
        {
            //if service id == 0 that the payment is a new one
            //Adding a new payment to the database
            if (payment.PaymentId == 0)
            {
                context.Payments.Add(payment);
            }
            else
            {
                //searching for an existing paynemt in the database
                Payment dbEntry = context.Payments
                    .FirstOrDefault(p => p.PaymentId == payment.PaymentId);

                if (dbEntry != null)
                {
                    //updating all values of the payment
                    dbEntry.BillingAddress = payment.BillingAddress;
                    dbEntry.CardNumber = payment.CardNumber;
                    dbEntry.CVV = payment.CVV;
                    dbEntry.ExpiryDate = payment.ExpiryDate;
                    dbEntry.NameOnCard = payment.NameOnCard;
                    dbEntry.PostalCode = payment.PostalCode;
                }
            }
            //saving changes in the database
            context.SaveChanges();
        }
    }
}
