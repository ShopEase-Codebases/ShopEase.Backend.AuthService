using MediatR;
using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.Common.Messaging.Abstractions
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
