using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Backend.PassportService.Persistence.Models;
using static ShopEase.Backend.PassportService.Persistence.Constants.TableConstants;

namespace ShopEase.Backend.PassportService.Persistence.Configurations
{
    internal sealed class OtpDetailsConfiguration : IEntityTypeConfiguration<OtpDetails>
    {
        public void Configure(EntityTypeBuilder<OtpDetails> builder)
        {
            builder.ToTable(TableNames.OtpDetails, schema: TableSchemas.Passport);

            builder.HasKey(otp => otp.Id);

            builder
                .Property(otp => otp.Otp)
                .HasMaxLength(OtpDetails.OtpMaxLength);

            builder
                .Property(otp => otp.Email)
                .HasMaxLength(OtpDetails.EmailMaxLength);
        }
    }
}
