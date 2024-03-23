using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.Common.Domain.Primitives
{
    /// <summary>
    /// Base Class for Aggregate Roots
    /// </summary>
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        protected AggregateRoot(Guid id) 
            : base(id)
        {
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => [.. _domainEvents];

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}