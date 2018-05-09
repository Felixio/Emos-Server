using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Lgm.Emos.Infrastructure.Data
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            // Id Column
            builder.HasKey(c => c.Id);

            // Number Column
            builder.Property(c => c.Number)
                   .IsRequired()
                   .HasMaxLength(50);

            // AdditionalInfo Column
            builder.Property(c => c.AdditionalInfo)
                   .IsRequired()
                   .HasMaxLength(50);
            // DateCreation Column
            builder.Property(c => c.DateCreation)
                   .IsRequired()
                   .HasMaxLength(50);
            // DateExpiration Column
            builder.Property(c => c.DateExpiration)
                   .IsRequired()
                   .HasMaxLength(50);
           
            // CardTypeId Column
            builder.Property(c => c.CardTypeId)
                   .IsRequired()
                   .HasMaxLength(50);

        }
     }
}
