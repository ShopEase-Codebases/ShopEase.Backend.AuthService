using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Backend.PassportService.Core.Entities;
using static ShopEase.Backend.PassportService.Persistence.Constants.TableConstants;

namespace ShopEase.Backend.PassportService.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.Users, schema: TableSchemas.Passport);

            builder.HasKey(user => user.Id);

            builder
                .HasIndex(user => user.Email)
                .IsUnique();

            builder
                .HasOne(user => user.UserCredentials)
                .WithOne()
                .HasForeignKey<UserCredentials>(userCred => userCred.UserId);

            builder
                .HasMany(user => user.Addresses)
                .WithOne()
                .HasForeignKey(address => address.UserId);
        }
    }
}