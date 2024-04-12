namespace ShopEase.Backend.PassportService.API;

public sealed record LoginUserResponse(
                            Guid UserId,
                            string AccessToken,
                            string RefreshToken,
                            DateTime RefreshTokenExpirationTimeUtc
                            );