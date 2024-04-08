namespace ShopEase.Backend.PassportService.Core.Events
{
    public sealed record UserRegisteredDomainEvent(Guid Id, Guid UserId, string Email) : DomainEvent(Id)
    {
    }
}
