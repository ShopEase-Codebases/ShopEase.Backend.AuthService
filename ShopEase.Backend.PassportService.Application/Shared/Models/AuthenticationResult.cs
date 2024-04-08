namespace ShopEase.Backend.PassportService.Application.Shared.Models
{
    public sealed record AuthenticationResult(
                                Guid UserId,
                                string AccessToken,
                                string RefreshToken,
                                DateTime RefreshTokenExpirationTimeUtc
                                );
}
