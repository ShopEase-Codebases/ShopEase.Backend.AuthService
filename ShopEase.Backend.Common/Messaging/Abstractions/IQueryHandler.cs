using MediatR;
using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.Common.Messaging.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
