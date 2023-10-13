using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager) {
            //Check if users have been created yet
            if(!userManager.Users.Any()) {
                var user = new AppUser 
                {
                    DisplayName="Pebble",
                    Email = "pebble@catmeow.com",
                    UserName = "pebble@catmeow.com",
                    Address = new Address {
                        FirstName = "Pebble",
                        LastName = "Meow",
                        Street = "703 Tuna Dr",
                        City = "Catsville",
                        State = "MI",
                        ZipCode = "48827"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}