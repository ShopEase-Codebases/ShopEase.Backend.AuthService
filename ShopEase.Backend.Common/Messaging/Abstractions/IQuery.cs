using MediatR;
using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.Common.Messaging.Abstractions
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
