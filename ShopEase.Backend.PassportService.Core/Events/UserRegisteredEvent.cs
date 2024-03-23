using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.PassportService.Core.Events
{
    public class UserRegisteredEvent : IDomainEvent
    {
        public Guid Id { get; init; }
    }
}
