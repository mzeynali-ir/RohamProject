using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(i => i.FirstName)
                .HasMaxLength(64);

            builder.Property(i => i.LastName)
                .HasMaxLength(64);

            builder.HasQueryFilter(i => i.IsDeleted == false);

            builder.HasOne(i => i.Creator)
                .WithMany()
                .HasForeignKey(i => i.CreatorId);

            builder.HasOne(i => i.LastModifier)
                .WithMany()
                .HasForeignKey(i => i.LastModifierId);
        }
    }
}
