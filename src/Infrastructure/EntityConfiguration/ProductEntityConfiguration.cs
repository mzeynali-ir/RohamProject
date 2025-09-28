using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(i => i.Title)
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
