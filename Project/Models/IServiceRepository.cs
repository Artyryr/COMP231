using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Interface for handeling interactions with database
    /// </summary>
    public interface IServiceRepository
    {
        IQueryable<Service> Services { get; }
        IQueryable<ServiceType> ServiceTypes { get; }
        IQueryable<RequestedService> RequestedServices { get; }
        IQueryable<Review> Reviews { get; }
        IQueryable<Payment> Payments { get; }
        void AddService(Service service);
        void RemoveService(int id);
        void AddServiceType(ServiceType serviceType);
        void RemoveServiceType(int id);
        void AddRequestedService(RequestedService requestedService);
        void RemoveRequestedService(int id);
        void AddReview(Review review);
        void AddPayment(Payment payment);
    }
}
