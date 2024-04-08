namespace ShopEase.Backend.PassportService.API.Contracts
{
    public sealed record UserResponse(
        Guid Id, 
        string Name, 
        string Email, 
        string MobileNumber, 
        string? AltMobileNumber,
        DateTime CreatedOnUtc,
        DateTime? UpdatedOnUtc
        );
}
