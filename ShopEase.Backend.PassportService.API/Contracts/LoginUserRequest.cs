namespace ShopEase.Backend.PassportService.API
{
    public sealed record LoginUserRequest(
        string Email,
        string Password
        );
}