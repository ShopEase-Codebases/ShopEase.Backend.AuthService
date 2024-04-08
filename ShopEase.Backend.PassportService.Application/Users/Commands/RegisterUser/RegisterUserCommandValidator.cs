using FluentValidation;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Application.Users.Commands.RegisterUser
{
    internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x).NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(Name.MaxLength);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(Email.MaxLength);

            RuleFor(x => x.MobileNumber)
                .NotEmpty()
                .MaximumLength(MobileNumber.MaxLength);

            RuleFor(x => x.AltMobileNumber)
                .Must(x => 
                    string.IsNullOrWhiteSpace(x) || 
                    x.Length <= MobileNumber.MaxLength);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(30);
        }
    }
}
