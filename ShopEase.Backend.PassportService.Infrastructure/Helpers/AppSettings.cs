namespace ShopEase.Backend.PassportService.Infrastructure.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string TokenExpirationTime { get; set; } = string.Empty;
        public string RefreshTokenExpirationTimeInDays { get; set; } = string.Empty;
        public string ResetPasswordTokenExpirationTimeInMin { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }
}
