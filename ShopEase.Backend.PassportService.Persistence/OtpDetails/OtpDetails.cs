﻿namespace ShopEase.Backend.PassportService.Persistence.OtpDetails
{
    /// <summary>
    /// Anemic class for OtpDetails Object
    /// </summary>
    public sealed class OtpDetails
    {
        /// <summary>
        /// Identifier Property for OtpDetails
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// OTP
        /// </summary>
        public string Otp { get; set; } = string.Empty;

        /// <summary>
        /// To check if the OTP is already used
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// OTP Requested On UTC
        /// </summary>
        public DateTime OtpRequestedOnUtc { get; set; }

        /// <summary>
        /// OTP Expires On UTC
        /// </summary>
        public DateTime OtpExpiresOnUtc { get; set; }

        /// <summary>
        /// OTP Used On UTC
        /// </summary>
        public DateTime? OtpUsedOnUtc { get; set; }
    }
}
