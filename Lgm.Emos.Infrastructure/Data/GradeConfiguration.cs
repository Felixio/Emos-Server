using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lgm.Emos.Infrastructure.Data
{
    internal class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
      
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Id Column
            builder.HasKey(u => u.Id);

            // FirstName Column
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Rank Column
            builder.Property(u => u.Rank)
                   .IsRequired()
                   .HasMaxLength(50);

            // IdPicture Column
            builder.Property(u => u.IdPicture)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
 }
