using Lgm.Emos.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lgm.Emos.Infrastructure.Identity
{
    public class IdentityAppDbContextSeedData
    {
        public static async Task SeedAsync(UserManager<IdentityAppUser> userManager, IdentityAppDbContext appDbContext)
        {
            Random rnd = new Random();
            
            if (!appDbContext.EmosUsers.Any(u => u.Identity.Email == "admin@lgm.fr"))
            {
                try
                {
                    var userIdentity = new IdentityAppUser
                    {
                        UserName = "admin@lgm.fr",
                        Email = "admin@lgm.fr",
                        FirstName = "Admin",
                        LastName = "Admin",
                    };
                    await userManager.CreateAsync(userIdentity, "password");

                    await appDbContext.EmosUsers.AddAsync(new EmosUser
                    {
                        IdentityId = userIdentity.Id,
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        //Service = "Mécanique",
                        //Office = "13",
                        //Team = "Bests",
                        //Rank = "Top",
                        //BadgeCode = rnd.Next(1,9).ToString()

                });

                    IdentityAppUser[] identityUsers = new IdentityAppUser[120];

                    for (int i = 1; i < 120; i++)
                    {
                        identityUsers[i] = new IdentityAppUser
                        {
                            UserName = $"user{i}@lgm.fr",
                            Email = $"user{i}@lgm.fr",
                            FirstName = $"prenom{i}",
                            LastName = $"nom{i}",
                        };

                        await userManager.CreateAsync(identityUsers[i], "password");

                        appDbContext.EmosUsers.Add(new EmosUser
                        {
                            IdentityId = identityUsers[i].Id,
                            FirstName = identityUsers[i].FirstName,
                            LastName = identityUsers[i].LastName,
                            //Service = $"Service{i%5}",
                            //Office = $"bureau{i%5}",
                            //Team = $"Equipe{i%10}",
                            //Rank = $"Grade{i%4}",
                            //BadgeCode = rnd.Next(1, 9).ToString()

                        });
                        appDbContext.SaveChanges();
                    }
                    
                    

                }
                catch (System.Exception ex)
                {
                }
            }


        }
    }
}