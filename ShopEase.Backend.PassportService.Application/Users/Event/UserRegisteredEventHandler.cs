using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Core.Events;

namespace ShopEase.Backend.PassportService.Application.Users.Event
{
    internal sealed class UserRegisteredEventHandler : IDomainEventHandler<UserRegisteredEvent>
    {
        public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
