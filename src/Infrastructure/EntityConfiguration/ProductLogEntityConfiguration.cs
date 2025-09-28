using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class ProductLogEntityConfiguration : IEntityTypeConfiguration<ProductLog>
    {
        public void Configure(EntityTypeBuilder<ProductLog> builder)
        {
            builder.HasOne(i => i.Creator)
                .WithMany()
                .HasForeignKey(i => i.CreatorId);
        }
    }
}
