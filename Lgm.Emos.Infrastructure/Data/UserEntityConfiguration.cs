using Lgm.Emos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lgm.Emos.Infrastructure.Data
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(ue => new { ue.EntityId , ue.EmosUserId });

            builder.HasOne(ue => ue.User)
                .WithMany(u => u.UserEntities)
                .HasForeignKey(ue => ue.EmosUserId);

            builder.HasOne(ue => ue.Entity)
                .WithMany(e => e.UserEntities)
                .HasForeignKey(ue => ue.EntityId);
        }
    }
}
