using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            // Id Column
            builder.HasKey(e => e.Id);

            // Name Column
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Description Column
            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(50);

            // idPicture Column
            builder.Property(e => e.idPicture)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
