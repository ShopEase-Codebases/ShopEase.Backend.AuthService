using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Core.Events;

namespace ShopEase.Backend.PassportService.Application.Users.Event
{
    internal sealed class UserRegisteredDomainEventHandler : IDomainEventHandler<UserRegisteredDomainEvent>
    {
        public Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
