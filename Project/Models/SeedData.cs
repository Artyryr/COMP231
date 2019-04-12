using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Class that populates tables of the database with initial values.
    /// </summary>
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
                    new Service { ServiceName = "Leak Repair", ServiceTypeId = 1, PricePerHour = 70.0, Description = "As soon as you detect a water leak in your home, it is critical to get it repaired as soon as possible to avoid damage to your belongings and expensive water bills. The most obvious household plumbing leaks include dripping faucets and leaking water heaters. Have a water leak in your basement?"},
                    new Service("Drain Cleaning", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Toilet Repair", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Garbage Disposal Repair", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Water Heater Services", 1, 80, "Some Generic Description of a service should be written here."),
                    new Service("Sewer Repair", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Hydro Jetting", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Dishwasher Installation", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Washing Machine Installation", 1, 70, "Some Generic Description of a service should be written here."),
                    new Service("Other Services", 1, 70, "Some Generic Description of a service should be written here."),

                    new Service("Electric Water Heaters", 2, 80.0, "Some Generic Description of a service should be written here."),
                    new Service("Circuit Breaker Panel Wiring", 2, 80, "Some Generic Description of a service should be written here."),
                    new Service("Electrical Inspections", 2, 80, "Some Generic Description of a service should be written here."),
                    new Service("Safety Lighting Installations", 2, 80, "Some Generic Description of a service should be written here."),
                    new Service("Electric Switch Installations", 2, 80, "Some Generic Description of a service should be written here."),
                    new Service("Outdoor Lighting Fixture Installations", 2, 80, "Some Generic Description of a service should be written here."),
                    new Service("Other Services", 2, 80, "Some Generic Description of a service should be written here."),

                    new Service("Boiler Installation", 3, 80.0, "Some Generic Description of a service should be written here."),
                    new Service("Fireplace Installatio", 3, 80, "Some Generic Description of a service should be written here."),
                    new Service("Gas Line Installation", 3, 80, "Some Generic Description of a service should be written here."),
                    new Service("Tankless Water Heater", 3, 80, "Some Generic Description of a service should be written here."),
                    new Service("Air Duct Cleaning", 3, 80, "Some Generic Description of a service should be written here."),
                    new Service("Maintaince Services", 3, 80, "Some Generic Description of a service should be written here."),

                    new Service("Air Conditioning Installation", 4, 80.0, "Some Generic Description of a service should be written here."),
                    new Service("Air Conditioning Repair", 4, 80, "Some Generic Description of a service should be written here."),
                    new Service("Air Conditioning Service", 4, 80.0, "Some Generic Description of a service should be written here.")
                    );
                context.SaveChanges();
            }
            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(
                    new Review { ServiceId = 1,UserId = "ArtyryrF@gmail.com", Rating = 5, UserName = "Artur Fundukyan", ReviewText = "The problem was solved much faster that I have expected", Date = DateTime.Now },
                    new Review { ServiceId = 2,UserId = "ArtyryrF@gmail.com", Rating = 2, UserName = "Sharang Verma", ReviewText = "Caution: Don't try this at home", Date = DateTime.Now },
                    new Review { ServiceId = 1,UserId = "Test@gmail.com", Rating = 5, UserName = "Quang", ReviewText = "It was amazingly great!", Date = DateTime.Now });
                context.SaveChanges();
            }
        }
    }
}
