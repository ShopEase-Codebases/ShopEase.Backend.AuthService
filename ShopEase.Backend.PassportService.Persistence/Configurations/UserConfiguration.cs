using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Backend.PassportService.Core.Aggregate;
using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.ValueObjects;
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
                .Property(user => user.Name)
                .HasConversion(
                    name => name.Value, 
                    value => Name.Create(value).Value)
                .HasMaxLength(Name.MaxLength);

            builder
                .Property(user => user.Email)
                .HasConversion(
                    email => email.Value, 
                    value => Email.Create(value).Value)
                .HasMaxLength(Email.MaxLength);

            builder
                .Property(user => user.MobileNumber)
                .HasConversion(
                    mobileNumber => mobileNumber.Value, 
                    value => MobileNumber.Create(value).Value)
                .HasMaxLength(MobileNumber.MaxLength);

            builder
                .Property(user => user.AltMobileNumber)
                .HasConversion(
                    altMobileNumber => altMobileNumber != null ? altMobileNumber.Value : null, 
                    value => value != null ? MobileNumber.Create(value).Value : null)
                .HasMaxLength(MobileNumber.MaxLength);

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

            builder
                .HasQueryFilter(user => user.RowStatus);
        }
    }
}