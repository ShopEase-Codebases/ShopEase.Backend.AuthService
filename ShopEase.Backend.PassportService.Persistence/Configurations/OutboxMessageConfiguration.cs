using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Backend.PassportService.Persistence.Models.Outbox;
using static ShopEase.Backend.PassportService.Persistence.Constants.TableConstants;

namespace ShopEase.Backend.PassportService.Persistence.Configurations
{
    internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable(TableNames.OutboxMessage, schema: TableSchemas.Passport);

            builder.HasKey(om => om.Id);
        }
    }
}
