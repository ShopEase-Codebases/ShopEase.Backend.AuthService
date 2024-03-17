using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Core.Errors;

namespace ShopEase.Backend.PassportService.Core.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public const int MaxLength = 50;

        private Email(string value) => Value = value;

        public string Value { get; }

        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Email>(DomainErrors.Email.Empty);
            }

            if (value.Split('@').Length != 2)
            {
                return Result.Failure<Email>(DomainErrors.Email.InvalidFormat);
            }

            if (value.Length > MaxLength)
            {
                return Result.Failure<Email>(DomainErrors.Email.TooLong);
            }

            return new Email(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
