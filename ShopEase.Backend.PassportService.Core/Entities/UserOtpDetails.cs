using ShopEase.Backend.Common.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// UserOtpDetails Entity Class
    /// </summary>
    [Table("UserOtpDetails", Schema = "Passport")]
    public sealed class UserOtpDetails : Entity, IAudit
    {
        #region Properties

        /// <summary>
        /// Id of User Entity
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// OTP
        /// </summary>
        public string Otp { get; private set; }

        /// <summary>
        /// To check if the OTP is already used
        /// </summary>
        public bool IsUsed { get; private set; }

        /// <summary>
        /// OTP Expires On UTC
        /// </summary>
        public DateTime OtpExpiresOnUtc { get; private set; }

        /// <summary>
        /// CreatedOn DateTime UTC
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// UpdatedOn DateTime UTC
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// RowStatus
        /// </summary>
        public bool RowStatus { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initailize UserOtpDetails entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="otp"></param>
        /// <param name="otpExpiresOnUtc"></param>
        private UserOtpDetails(Guid id, Guid userId, string otp, DateTime otpExpiresOnUtc) 
            : base(id)
        {
            UserId = userId;
            Otp = otp;
            IsUsed = false;
            OtpExpiresOnUtc = otpExpiresOnUtc;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Create New UserOtpDetails
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="otp"></param>
        /// <param name="otpExpiresOnUtc"></param>
        /// <returns></returns>
        public static UserOtpDetails Create(Guid userId, string otp, DateTime otpExpiresOnUtc)
        {
            return new UserOtpDetails(Guid.NewGuid(), userId, otp, otpExpiresOnUtc);
        }

        #endregion
    }
}
