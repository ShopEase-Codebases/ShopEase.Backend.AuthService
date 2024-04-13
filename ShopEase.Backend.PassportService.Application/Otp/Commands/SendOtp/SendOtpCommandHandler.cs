using Microsoft.Extensions.Options;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Application.Abstractions;
using ShopEase.Backend.PassportService.Application.Helpers;

namespace ShopEase.Backend.PassportService.Application.Otp.Commands.SendOtp
{
    internal sealed class SendOtpCommandHandler : ICommandHandler<SendOtpCommand>
    {
        private readonly IEmailServices _emailServices;
        private readonly int _otpLifeSpan;


        public SendOtpCommandHandler(IEmailServices emailServices, IOptions<EmailSettings> options)
        {
            _emailServices = emailServices;
            _otpLifeSpan = options.Value.OtpLifeSpanInMinutes;
        }

        public Task<Result> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}