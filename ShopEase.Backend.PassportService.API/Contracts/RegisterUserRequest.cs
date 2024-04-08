namespace ShopEase.Backend.PassportService.API.Contracts
{
    public sealed record RegisterUserRequest(
        string Name,
        string Email,
        string MobileNumber,
        string? AltMobileNumber,
        string Password
        );
}
