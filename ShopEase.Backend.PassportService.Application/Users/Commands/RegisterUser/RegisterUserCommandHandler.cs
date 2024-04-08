using ShopEase.Backend.Common.Domain;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Application.Abstractions;
using ShopEase.Backend.PassportService.Application.Abstractions.Repositories;
using ShopEase.Backend.PassportService.Application.Shared.Models;
using ShopEase.Backend.PassportService.Core.Aggregate;
using ShopEase.Backend.PassportService.Core.Entities;
using ShopEase.Backend.PassportService.Core.Errors;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Application.Users.Commands.RegisterUser
{
    internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;

        private readonly IUserCredentialsRepository _userCredentialsRepository;

        private readonly IAuthServices _authServices;

        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserCredentialsRepository userCredentialsRepository, IUnitOfWork unitOfWork, IAuthServices authServices)
        {
            _userRepository = userRepository;
            _userCredentialsRepository = userCredentialsRepository;
            _unitOfWork = unitOfWork;
            _authServices = authServices;
        }

        public async Task<Result<AuthenticationResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            Result<Name> name = Name.Create(command.Name);
            Result<Email> email = Email.Create(command.Email);
            Result<MobileNumber> mobileNumber = MobileNumber.Create(command.MobileNumber);
            Result<MobileNumber>? altMobileNumber = string.IsNullOrWhiteSpace(command.AltMobileNumber) ?
                                                            null : MobileNumber.Create(command.AltMobileNumber);

            bool isEmailUnique = await _userRepository.IsEmailUniqueAsync(email.Value, cancellationToken);

            if (!isEmailUnique)
            {
                return Result.Failure<AuthenticationResult>(DomainErrors.User.EmailAlreadyInUse);
            }

            User newUser = User.CreateUser(
                                    name: name.Value,
                                    email: email.Value,
                                    mobileNumber: mobileNumber.Value,
                                    altMobileNumber: altMobileNumber?.Value);

            _userRepository.Add(newUser);

            var (passwordHash, passwordSalt) = _authServices.CreatePasswordHashAndSalt(command.Password);

            UserCredentials newUserCredentials = UserCredentials.Create(
                                                                    userId: newUser.Id,
                                                                    passwordHash: passwordHash,
                                                                    passwordSalt: passwordSalt);

            AuthenticationResult authResult = _authServices.CreateToken(newUser.Id, email.Value.Value);

            newUserCredentials.AddOrUpdateRefreshToken(authResult.RefreshToken, authResult.RefreshTokenExpirationTimeUtc);

            _userCredentialsRepository.Add(newUserCredentials);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return authResult;
        }
    }
}
