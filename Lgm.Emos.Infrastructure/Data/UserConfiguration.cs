using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Id Column
            builder.HasKey(u => u.Id);

            // FirstName Column
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // LastName Column
            builder.Property(u => u.LastName)
                    .IsRequired()
                   .HasMaxLength(50);

            // Office Column
            builder.Property(u => u.Office)
                    .IsRequired()
                   .HasMaxLength(50);

            // Team Column
            builder.Property(u => u.Team)
                    .IsRequired()
                   .HasMaxLength(50);

            // Rank Column
            builder.Property(u => u.Rank)
                    .IsRequired()
                   .HasMaxLength(50);

            // Service Column
            builder.Property(u => u.Service)
                    .IsRequired()
                   .HasMaxLength(50);
            // IdBadge Column
            builder.Property(u => u.BadgeCode)
                   .IsRequired()
                  .HasMaxLength(50);
          

        }
    }
}