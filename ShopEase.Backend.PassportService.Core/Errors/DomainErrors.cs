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
            public static readonly Error Empty = Error.Validation("Email.Empty", "Email is empty");

            public static readonly Error InvalidFormat = Error.Validation("Email.InvalidFormat", "Email format is invalid");

            public static readonly Error TooLong = Error.Validation("Email.TooLong", "Email is too long");
        }

        /// <summary>
        /// Errors Related to Name Value Object
        /// </summary>
        public readonly struct Name
        {
            public static readonly Error Empty = Error.Validation("Name.Empty", "Name is empty");

            public static readonly Error TooLong = Error.Validation("Name.TooLong", "Name is too long");
        }

        /// <summary>
        /// Errors Related to MobileNumber Value Object
        /// </summary>
        public readonly struct MobileNumber
        {
            public static readonly Error Empty = Error.Validation("MobileNumber.Empty", "MobileNumber is empty");

            public static readonly Error InvalidFormat = Error.Validation("MobileNumber.InvalidFormat", "MobileNumber format is invalid");

            public static readonly Error TooLong = Error.Validation("MobileNumber.TooLong", "MobileNumber is too long");
        }

        /// <summary>
        /// Errors Related to ZipCode Value Object
        /// </summary>
        public readonly struct ZipCode
        {
            public static readonly Error Empty = Error.Validation("ZipCode.Empty", "ZipCode is empty");

            public static readonly Error InvalidFormat = Error.Validation("ZipCode.InvalidFormat", "ZipCode format is invalid");

            public static readonly Error TooLong = Error.Validation("ZipCode.TooLong", "ZipCode is too long");
        }

        /// <summary>
        /// Errors Related to Otp Value Object
        /// </summary>
        public readonly struct Otp
        {
            public static readonly Error Empty = Error.Validation("Otp.Empty", "Otp is empty");

            public static readonly Error InvalidFormat = Error.Validation("Otp.InvalidFormat", "Otp format is invalid");

            public static readonly Error TooLong = Error.Validation("Otp.TooLong", "Otp is too long");
        }

        /// <summary>
        /// Error related to User Aggreagte Root
        /// </summary>
        public readonly struct User
        {
            public static readonly Error EmailAlreadyInUse = Error.Conflict("User.EmailAlreadyInUse", "The specified Email is already in use.");

            public static readonly Error UserNotFound = Error.NotFound("User.UserNotFound", "The specified UserId doesn't return any User.");
        }

        /// <summary>
        /// Error related to UserCredentials Entity
        /// </summary>
        public readonly struct UserCredentials
        {
            public static readonly Error WrongCredentials = Error.Unauthorized("User.WrongCredentials", "The specified credentials are wrong.");
        }
    }
}
