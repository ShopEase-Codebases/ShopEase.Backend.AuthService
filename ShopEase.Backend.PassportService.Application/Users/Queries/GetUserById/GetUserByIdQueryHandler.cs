using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Application.Abstractions.Repositories;
using ShopEase.Backend.PassportService.Core.Aggregate;
using ShopEase.Backend.PassportService.Core.Errors;

namespace ShopEase.Backend.PassportService.Application.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            return user ?? Result.Failure<User>(DomainErrors.User.UserNotFound);
        }
    }
}
