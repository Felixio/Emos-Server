using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
       
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            // Id Column
            builder.HasKey(u => u.Id);

            // FirstName Column
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(50);

        }

    }
}
