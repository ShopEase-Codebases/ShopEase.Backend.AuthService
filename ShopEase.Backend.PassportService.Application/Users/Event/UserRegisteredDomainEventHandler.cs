using System.ComponentModel.DataAnnotations;
using System.Text;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Application.Abstractions;
using ShopEase.Backend.PassportService.Application.Abstractions.Repositories;
using ShopEase.Backend.PassportService.Application.Shared.Models;
using ShopEase.Backend.PassportService.Core.Aggregate;
using ShopEase.Backend.PassportService.Core.Events;
using static ShopEase.Backend.PassportService.Application.Shared.Constant.EmailConstants;

namespace ShopEase.Backend.PassportService.Application.Users.Event
{
    internal sealed class UserRegisteredDomainEventHandler : IDomainEventHandler<UserRegisteredDomainEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailServices _emailServices;

        public UserRegisteredDomainEventHandler(IUserRepository userRepository, IEmailServices emailServices)
        {
            _userRepository = userRepository;
            _emailServices = emailServices;
        }

        public async Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(domainEvent.UserId, cancellationToken) ?? 
                        throw (new ValidationException("User Not Found."));
            
            await SendWelcomeEmail(user, cancellationToken);
        }

        #region Private Methods

        /// <summary>
        /// To Send Welcome Email
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendWelcomeEmail(User user, CancellationToken cancellationToken)
        {
            var firstName = GetFirstName(user.Name.Value);

            MailRequest mailRequest = new
            (
                Recipients : [user.Email.Value],
                Subject : Subject.Welcome,
                Body : GenerateEmailBody(firstName)
            );

            await _emailServices.SendMailAsync(mailRequest, cancellationToken);
        }

        /// <summary>
        /// To get the First name form the Full Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetFirstName(string name)
        {
            var nameArray = name.Split(" ");

            return nameArray?[0] ?? string.Empty;
        }

        /// <summary>
        /// TO Prepare the Email Body
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GenerateEmailBody(string name)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<html lang='en'><head><style>body{font-family:Arial,sans-serif;line-height:1.6;background-color:#f4f4f4;margin:0;padding:20px;}");
            stringBuilder.Append(".container{max-width:600px;margin:auto;background:#fff;padding:20px;border-radius:5px;box-shadow:0 0 10px rgba(0,0,0,0.1);}</style>");
            stringBuilder.Append("<body><div class='container'><h2>Welcome to ShopEase, {userName}!</h2>");
            stringBuilder.Append("<p>Thank you for choosing ShopEase for your online shopping needs. We're excited to have you on board.</p>");
            stringBuilder.Append("<p>If you have any questions or need assistance, feel free to contact our support team.</p>");
            stringBuilder.Append("<br/><br/><p>Happy shopping!<br>ShopEase Team</p></div></body></html>");

            var body = stringBuilder.ToString().Replace("{userName}", name);

            return body;
        }

        #endregion
    }
}
