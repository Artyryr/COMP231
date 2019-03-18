using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class IdentitySeedData
    {
        private const string artur = "ArtyryrF@gmail.com";
        private const string user1Password = "Password123!";
        private const string testUser = "Test@gmail.com";
        private const string testPassword = "Password123!";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<GeneralUser> userManager = app.ApplicationServices
               .GetRequiredService<UserManager<GeneralUser>>();

                GeneralUser user = await userManager.FindByEmailAsync(artur);
            if (user == null)
            {
                user = new GeneralUser {Email = artur, UserName = artur, FirstName = "Artur", LastName = "Fundukyan", Telephone = "6473337777", Apartment = "640A", Street = "647 Progress Ave", City = "Scarborough", ZIP = "M1G 3T8", Province = "ON" };
                await userManager.CreateAsync(user, user1Password);
            }

            GeneralUser test = await userManager.FindByEmailAsync(testUser);

            if (test == null)
            {
                test = new GeneralUser {Email = testUser, UserName = testUser, FirstName = "Test", LastName = "Last Test", Telephone = "TEST", Apartment = "TEST", Street = "TEST Ave", City = "TEST", ZIP = "M1G 3T8", Province = "TEST" };

                await userManager.CreateAsync(test, testPassword);
            }

            SeedData.EnsurePopulated(app);
        }
    }
}
