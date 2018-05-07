using System;
using Lgm.Emos.Infrastructure.Identity.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lgm.Emos.Infrastructure.Identity
{
    public class IdentityAppDbContext : IdentityDbContext<IdentityAppUser>
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options)
              : base(options)
        {
        }

        public DbSet<EmosUser> EmosUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmosUserConfiguration());
        }
    }
}
