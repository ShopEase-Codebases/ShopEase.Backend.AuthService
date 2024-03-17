using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Core.Errors;
using System.Text.RegularExpressions;

namespace ShopEase.Backend.PassportService.Core.ValueObjects
{
    public sealed class Otp : ValueObject
    {
        public const int OtpMaxLength = 6;

        private const string OtpRegex = "^[0-9]{6}$";

        private Otp(string value) => Value = value;

        public string Value { get; }

        public static Result<Otp> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Otp>(DomainErrors.Otp.Empty);
            }

            if (!Regex.IsMatch(value, OtpRegex))
            {
                return Result.Failure<Otp>(DomainErrors.Otp.InvalidFormat);
            }

            if (value.Length > OtpMaxLength)
            {
                return Result.Failure<Otp>(DomainErrors.Otp.TooLong);
            }

            return new Otp(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
