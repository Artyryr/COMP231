using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            if (!context.ServiceTypes.Any())
            {
                context.ServiceTypes.AddRange(
                    new ServiceType("Plumbing", "Plumbing Services"),
                    new ServiceType("Electricity", "Electricity Services"),
                    new ServiceType("Heating", "Heating Services"),
                    new ServiceType("A/C", "A/C Services"));

                context.SaveChanges();
            }
            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service("Leak Repair", 1,70.0),
                    new Service("Drain Cleaning", 1, 70),
                    new Service("Toilet Repair", 1, 70),
                    new Service("Garbage Disposal Repair", 1, 70),
                    new Service("Water Heater Services", 1, 80),
                    new Service("Sewer Repair", 1, 70),
                    new Service("Hydro Jetting", 1, 70),
                    new Service("Dishwasher Installation", 1, 70),
                    new Service("Washing Machine Installation", 1, 70),
                    new Service("Other Services", 1, 70),

                    new Service("Electric Water Heaters", 2, 80.0),
                    new Service("Circuit Breaker Panel Wiring", 2, 80),
                    new Service("Electrical Inspections", 2, 80),
                    new Service("Safety Lighting Installations", 2, 80),
                    new Service("Electric Switch Installations", 2, 80),
                    new Service("Outdoor Lighting Fixture Installations", 2, 80),
                    new Service("Other Services", 2, 80),
                    ////new Service("Other Services", context.ServiceTypes.Where(p => p.ServiceTypeId == 1).First()),

                    new Service("Boiler Installation", 3, 80.0),
                    new Service("Fireplace Installatio", 3, 80),
                    new Service("Gas Line Installation", 3, 80),
                    new Service("Tankless Water Heater", 3, 80),
                    new Service("Air Duct Cleaning", 3, 80),
                    new Service("Maintaince Services", 3, 80),

                    new Service("Air Conditioning Installation", 4, 80.0),
                    new Service("Air Conditioning Repair", 4, 80),
                    new Service("Air Conditioning Service", 4, 80.0)
                    );
                context.SaveChanges();
            }
        }
    }
}
