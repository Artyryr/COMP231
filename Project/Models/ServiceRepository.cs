﻿using System;
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
                    dbEntry.UserId = requestedService.UserId;
                    dbEntry.ServiceId = requestedService.ServiceId;
                    dbEntry.Date = requestedService.Date;
                    dbEntry.Address = requestedService.Address;
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
    }
}