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
            builder.HasKey(u => u.UserId);

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

            // Rank Column
            builder.Property(u => u.Number)
                    .IsRequired()
                   .HasMaxLength(50);
            
          
            builder.HasMany<Team>(u => u.Teams);
            builder.HasMany<Entity>(u => u.Entities);

            builder.HasOne<Function>(u => u.Function);
            builder.HasOne<Grade>(u => u.Grade);
            builder.HasOne<Card>(u => u.Card);








        }
    }
}