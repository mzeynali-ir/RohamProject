using Domain.Entities.Users;
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

            builder.HasData(new User()
            {
                Id=1,
                FirstName="مصطفی",
                LastName="زینلی",
            });
        }
    }
}
