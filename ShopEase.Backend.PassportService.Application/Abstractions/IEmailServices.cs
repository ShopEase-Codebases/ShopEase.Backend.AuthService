using ShopEase.Backend.PassportService.Application.Shared.Models;

namespace ShopEase.Backend.PassportService.Application.Abstractions
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