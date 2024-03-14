using ShopEase.Backend.Common.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// UserCredentials Entity Class
    /// </summary>
    [Table("UserCredentials", Schema = "Passport")]
    public sealed class UserCredentials : Entity, IAudit
    {
        #region Properties

        /// <summary>
        /// Id of User Entity
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Password Hash
        /// </summary>
        public byte[] PasswordHash { get; private set; }

        /// <summary>
        /// Password Salt
        /// </summary>
        public byte[] PasswordSalt { get; private set; }

        /// <summary>
        /// Refresh Token
        /// </summary>
        public string? RefreshToken { get; private set; }

        /// <summary>
        /// Refresh Token Expiration Time in UTC
        /// </summary>
        public DateTime? RefreshTokenExpirationTimeUtc { get; private set; }

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
        /// Constructor to initailize UserCredentials entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="refreshToken"></param>
        /// <param name="refreshTokenExpirationTimeUtc"></param>
        private UserCredentials(Guid id, Guid userId, byte[] passwordHash, byte[] passwordSalt, string? refreshToken, DateTime? refreshTokenExpirationTimeUtc)
            : base(id)
        {
            UserId = userId;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            RefreshToken = refreshToken;
            RefreshTokenExpirationTimeUtc = refreshTokenExpirationTimeUtc;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            RowStatus = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Create New UserCredentials
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="refreshToken"></param>
        /// <param name="refreshTokenExpirationTimeUtc"></param>
        /// <returns></returns>
        public static UserCredentials Create(Guid userId, byte[] passwordHash, byte[] passwordSalt, string? refreshToken, DateTime? refreshTokenExpirationTimeUtc)
        {
            return new UserCredentials(Guid.NewGuid(), userId, passwordHash, passwordSalt, refreshToken, refreshTokenExpirationTimeUtc);
        }

        #endregion
    }
}
