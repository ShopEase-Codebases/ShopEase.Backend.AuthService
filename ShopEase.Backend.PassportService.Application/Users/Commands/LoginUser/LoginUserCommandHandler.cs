using ShopEase.Backend.Common.Domain;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Application.Abstractions;
using ShopEase.Backend.PassportService.Application.Abstractions.Repositories;
using ShopEase.Backend.PassportService.Application.Shared.Models;
using ShopEase.Backend.PassportService.Core.Errors;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Application.Users.Commands.LoginUser
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, AuthenticationResult>
    {
        private readonly IUserCredentialsRepository _userCredentialsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthServices _authServices;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(
                IUserCredentialsRepository userCredentialsRepository,
                IUserRepository userRepository,
                IAuthServices authServices,
                IUnitOfWork unitOfWork)
        {
            _userCredentialsRepository = userCredentialsRepository;
            _userRepository = userRepository;
            _authServices = authServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            Result<Email> email = Email.Create(command.Email);

            if (email.IsFailure)
            {
                return Result.Failure<AuthenticationResult>(email.Error);
            }

            var user = await _userRepository.GetByEmailAsyncWithCredentials(email.Value, cancellationToken);

            if (user is null)
            {
                return Result.Failure<AuthenticationResult>(DomainErrors.User.UserNotFound);
            }

            var userCredentials = user?.UserCredentials;

            bool isVerified = _authServices.VerifyPasswordHash(
                                                 command.Password,
                                                 userCredentials.PasswordHash,
                                                 userCredentials.PasswordSalt);

            if (isVerified)
            {
                AuthenticationResult authenticationResult = _authServices.CreateToken(user.Id, email.Value.Value);

                userCredentials.AddOrUpdateRefreshToken(
                                    authenticationResult.RefreshToken,
                                    authenticationResult.RefreshTokenExpirationTimeUtc);

                _userCredentialsRepository.Update(userCredentials);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return authenticationResult;
            }

            return Result.Failure<AuthenticationResult>(DomainErrors.UserCredentials.WrongCredentials);
        }
    }
}