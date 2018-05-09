using System;
using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lgm.Emos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
       
        public DbSet<Function> Functions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserTeam> userTeams { get; set; }
        public DbSet<UserEntity> UserEntitIES { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.ApplyConfiguration(new ToolConfiguration());
          
            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            

        }
	}
}
