namespace ShopEase.Backend.PassportService.API
{
    public sealed record LoginUsingOtpRequest(
        string Email,
        string Otp
    );
}