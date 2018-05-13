using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class UserConfiguration : IEntityTypeConfiguration<EmosUser>
    {
        public void Configure(EntityTypeBuilder<EmosUser> builder)
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

            // DateOfBearth Column
            builder.Property(u => u.DateOfBirth)
                    .IsRequired()
                    .HasMaxLength(50);
            
            // IdBadge Column
            //builder.Property(u => u.CardCode)
            //       .IsRequired()
            //      .HasMaxLength(50);

        }
    }
}