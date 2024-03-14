using MediatR;

namespace ShopEase.Backend.Common.Domain.Primitives
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
