using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.PassportService.Core.Events
{
    public abstract record DomainEvent(Guid Id) : IDomainEvent
    {
    }
}
