namespace ShopEase.Backend.PassportService.Application
{
    /// <summary>
    /// Interface for Email Services
    /// </summary>
    public interface IEmailServices
    {
        /// <summary>
        /// To Send Emails Asynchronously
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        Task SendMailAsync(MailRequest mailRequest, CancellationToken cancellationToken);
    }
}