using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Core.Errors;
using System.Text.RegularExpressions;

namespace ShopEase.Backend.PassportService.Core.ValueObjects
{
    public sealed class MobileNumber : ValueObject
    {
        private const string StandardRegex = "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$";

        private const int MaxLength = 17;

        private MobileNumber(string value) => Value = value;

        public string Value { get; }

        public static Result<MobileNumber> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<MobileNumber>(DomainErrors.MobileNumber.Empty);
            }

            if (!Regex.IsMatch(value, StandardRegex))
            {
                return Result.Failure<MobileNumber>(DomainErrors.MobileNumber.InvalidFormat);
            }

            if(value.Length > MaxLength)
            {
                return Result.Failure<MobileNumber>(DomainErrors.MobileNumber.TooLong);
            }

            return new MobileNumber(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
