using MediatR;
using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.Common.Messaging.Abstractions
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
       where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
