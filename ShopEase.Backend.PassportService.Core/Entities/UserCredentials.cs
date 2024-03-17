﻿using ShopEase.Backend.Common.Domain.Primitives;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// UserCredentials Entity Class
    /// </summary>
    public sealed class UserCredentials : Entity, IAudit
    {
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
        internal UserCredentials(Guid id, Guid userId, byte[] passwordHash, byte[] passwordSalt, string? refreshToken, DateTime? refreshTokenExpirationTimeUtc)
            : base(id)
        {
            UserId = userId;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            RefreshToken = refreshToken;
            RefreshTokenExpirationTimeUtc = refreshTokenExpirationTimeUtc;
        }

        #endregion

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
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// RowStatus
        /// </summary>
        public bool RowStatus { get; set; }

        #endregion

        #region Public Methods



        #endregion
    }
}
