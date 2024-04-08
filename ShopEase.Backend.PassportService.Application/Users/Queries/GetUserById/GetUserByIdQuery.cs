using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Core.Aggregate;

namespace ShopEase.Backend.PassportService.Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid Id) : IQuery<User>
    {
    }
}
