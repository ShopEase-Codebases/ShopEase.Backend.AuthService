using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.Core.Errors;
using System.Text.RegularExpressions;

namespace ShopEase.Backend.PassportService.Core.ValueObjects
{
    public sealed class ZipCode : ValueObject
    {
        private const string IndiaStandardZipCodeRegex = "^[1-9]{1}[0-9]{2}[-\\s]?[0-9]{3}$";

        private ZipCode(string value) => Value = value;

        public string Value { get; }

        public static Result<ZipCode> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<ZipCode>(DomainErrors.ZipCode.Empty);
            }

            if(!Regex.IsMatch(value, IndiaStandardZipCodeRegex))
            {
                return Result.Failure<ZipCode>(DomainErrors.ZipCode.InvalidFormat);
            }

            return new ZipCode(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
