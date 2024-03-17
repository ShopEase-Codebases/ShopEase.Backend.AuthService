using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.ValueObjects;
using static ShopEase.Backend.PassportService.Persistence.Constants.TableConstants;

namespace ShopEase.Backend.PassportService.Persistence.Configurations
{
    internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(TableNames.Addresses, schema: TableSchemas.Passport);

            builder.HasKey(address => address.Id);

            builder
                .Property(address => address.Name)
                .HasConversion(name => name.Value, value => Name.Create(value).Value)
                .HasMaxLength(Name.MaxLength);

            builder
                .Property(address => address.ZipCode)
                .HasConversion(zipCode => zipCode.Value, value => ZipCode.Create(value).Value)
                .HasMaxLength(ZipCode.MaxLength);

            builder
                .HasQueryFilter(address => address.RowStatus);
        }
    }
}