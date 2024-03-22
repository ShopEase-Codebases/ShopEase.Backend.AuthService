using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.Common.Domain.Primitives
{
    /// <summary>
    /// Interface to Represent an Domain Event
    /// </summary>
    public interface IDomainEvent : IEvent
    {
        public Guid Id { get; init; }
    }
}
