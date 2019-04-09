using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ServiceRepository : IServiceRepository
    {
        private ApplicationDbContext context;
        
        public ServiceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Service> Services => context.Services;
        public IQueryable<ServiceType> ServiceTypes => context.ServiceTypes;
        public IQueryable<RequestedService> RequestedServices => context.RequestedServices;
        public IQueryable<Review> Reviews => context.Reviews;
        public IQueryable<Payment> Payments => context.Payments;

        public void AddService(Service service)
        {
            if (service.ServiceId == 0)
            {
                context.Services.Add(service);
            }
            else
            {
                Service dbEntry = context.Services
                    .FirstOrDefault(p => p.ServiceId == service.ServiceId);

                if (dbEntry != null)
                {
                    dbEntry.ServiceName = service.ServiceName;
                    dbEntry.ServiceTypeId = service.ServiceTypeId;
                    dbEntry.PricePerHour = service.PricePerHour;
                    dbEntry.Description = service.Description;
                }
            }
            context.SaveChanges();
        }
        public void RemoveService(int id)
        {
            if (context.Services.Where(p => p.ServiceId == id).FirstOrDefault() != null)
            {
                context.Services.Remove(context.Services.Where(p => p.ServiceId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }
        public void AddServiceType(ServiceType serviceType)
        {
            if (serviceType.ServiceTypeId == 0)
            {
                context.ServiceTypes.Add(serviceType);
            }
            else
            {
                ServiceType dbEntry = context.ServiceTypes
                    .FirstOrDefault(p => p.ServiceTypeId == serviceType.ServiceTypeId);

                if (dbEntry != null)
                {
                    dbEntry.ServiceTypeName = serviceType.ServiceTypeName;
                    dbEntry.Description = serviceType.Description;
                }
            }
            context.SaveChanges();
        }
        public void RemoveServiceType(int id)
        {
            if (context.ServiceTypes.Where(p => p.ServiceTypeId == id).FirstOrDefault() != null)
            {
                context.ServiceTypes.Remove(context.ServiceTypes.Where(p => p.ServiceTypeId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }
        public void AddRequestedService(RequestedService requestedService)
        {
            if (requestedService.RequestedServiceId == 0)
            {
                context.RequestedServices.Add(requestedService);
            }
            else
            {
                RequestedService dbEntry = context.RequestedServices
                    .FirstOrDefault(p => p.RequestedServiceId == requestedService.RequestedServiceId);

                if (dbEntry != null)
                {
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
            context.SaveChanges();
        }
        public void RemoveRequestedService(int id)
        {
            if (context.RequestedServices.Where(p => p.RequestedServiceId == id).FirstOrDefault() != null)
            {
                context.RequestedServices.Remove(context.RequestedServices.Where(p => p.RequestedServiceId == id).FirstOrDefault());
            }
            context.SaveChanges();
        }
        public void AddReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews
                    .FirstOrDefault(p => p.ReviewId == review.ReviewId);

                if (dbEntry != null)
                {
                    dbEntry.ReviewText = review.ReviewText;
                    dbEntry.ServiceId = review.ServiceId;
                    dbEntry.Rating = review.Rating;
                    dbEntry.UserName = review.UserName;
                    dbEntry.Date = review.Date;
                    dbEntry.UserId = review.UserId;
                }
            }
            context.SaveChanges();
        }

        public void AddPayment(Payment payment)
        {
            if (payment.PaymentId == 0)
            {
                context.Payments.Add(payment);
            }
            else
            {
                Payment dbEntry = context.Payments
                    .FirstOrDefault(p => p.PaymentId == payment.PaymentId);

                if (dbEntry != null)
                {
                    dbEntry.BillingAddress = payment.BillingAddress;
                    dbEntry.CardNumber = payment.CardNumber;
                    dbEntry.CVV = payment.CVV;
                    dbEntry.ExpiryDate = payment.ExpiryDate;
                    dbEntry.NameOnCard = payment.NameOnCard;
                    dbEntry.PostalCode = payment.PostalCode;
                }
            }
            context.SaveChanges();
        }
    }
}
