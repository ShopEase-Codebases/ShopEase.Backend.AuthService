using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Core.Errors;

namespace ShopEase.Backend.PassportService.Core.ValueObjects
{
    public sealed class Name : ValueObject
    {
        private const int MaxLength = 50;

        private Name(string value) => Value = value;

        public string Value { get; }

        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Name>(DomainErrors.Name.Empty);
            }

            if (value.Length > MaxLength)
            {
                return Result.Failure<Name>(DomainErrors.Name.TooLong);
            }

            return new Name(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
