using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class ApplicationGroupConfiguration : IEntityTypeConfiguration<ApplicationGroup>
    {
        public void Configure(EntityTypeBuilder<ApplicationGroup> builder)
        {
            // Id Column
            builder.HasKey(ag => ag.Id);

            // FirstName Column
            builder.Property(ag => ag.Name)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
