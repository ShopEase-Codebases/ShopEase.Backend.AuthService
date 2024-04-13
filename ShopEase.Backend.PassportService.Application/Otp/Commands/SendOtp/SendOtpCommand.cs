using ShopEase.Backend.Common.Messaging.Abstractions;
using static ShopEase.Backend.PassportService.Application.Shared.Constant.EmailConstants;

namespace ShopEase.Backend.PassportService.Application.Otp.Commands.SendOtp
{
    public sealed record SendOtpCommand(
        string Email, OTPType OtpType
    ) : ICommand
    {
    }
}