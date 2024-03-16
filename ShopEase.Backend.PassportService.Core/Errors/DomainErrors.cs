using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.PassportService.Core.Errors
{
    public static class DomainErrors
    {
        /// <summary>
        /// Errors Related to Email Value Object
        /// </summary>
        public readonly struct Email
        {
            public static readonly Error Empty = new("Email.Empty", "Email is empty");

            public static readonly Error InvalidFormat = new("Email.InvalidFormat", "Email format is invalid");
        }

        /// <summary>
        /// Errors Related to Name Value Object
        /// </summary>
        public readonly struct Name
        {
            public static readonly Error Empty = new("Name.Empty", "Name is empty");

            public static readonly Error TooLong = new("Name.TooLong", "Name is too long");
        }

        /// <summary>
        /// Errors Related to MobileNumber Value Object
        /// </summary>
        public readonly struct MobileNumber
        {
            public static readonly Error Empty = new("MobileNumber.Empty", "MobileNumber is empty");

            public static readonly Error InvalidFormat = new("MobileNumber.InvalidFormat", "MobileNumber format is invalid");

            public static readonly Error TooLong = new("MobileNumber.TooLong", "MobileNumber is too long");
        }
    }
}
