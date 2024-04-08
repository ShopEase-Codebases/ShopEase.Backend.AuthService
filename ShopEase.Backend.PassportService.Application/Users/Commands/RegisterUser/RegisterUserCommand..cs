using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Application.Shared.Models;

namespace ShopEase.Backend.PassportService.Application.Users.Commands.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Name,
        string Email,
        string MobileNumber,
        string? AltMobileNumber,
        string Password
        ) : ICommand<AuthenticationResult>
    {
    }
}
