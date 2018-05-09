using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Id Column
            builder.HasKey(t => t.TeamId);

            // Name Column
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            // Description Column
            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(50);
           
            // ApplyScheduleAccessRule Column
            builder.Property(t => t.ApplyScheduleAccessRule)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne<Team>(u => u.TeamLeader);

            builder.HasOne<Entity>(u => u.Entity);

            builder.HasMany<User>(u => u.Users);
        }
    }
}
