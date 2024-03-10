using ShopEase.Backend.PassportService.Core.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// User Entity Class
    /// </summary>
    [Table("User", Schema = "Passport")]
    public sealed class User : Entity
    {
        #region Properties

        /// <summary>
        /// Full Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public string MobileNumber { get; private set; }

        /// <summary>
        /// Alternate Mobile Number
        /// </summary>
        public string AltMobileNumber { get; private set; }

        /// <summary>
        /// CreatedOn DateTime UTC
        /// </summary>
        public DateTime CreatedOnUtc { get; private set; }

        /// <summary>
        /// UpdatedOn DateTime UTC
        /// </summary>
        public DateTime UpdatedOnUtc { get; private set; }

        /// <summary>
        /// RowStatus
        /// </summary>
        public bool RowStatus { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initailize User entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="altMobileNumber"></param>
        private User(Guid id, string name, string email, string mobileNumber, string altMobileNumber) 
            : base(id)
        {
            Name = name;
            Email = email;
            MobileNumber = mobileNumber;
            AltMobileNumber = altMobileNumber;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            RowStatus = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Create New Users
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="altMobileNumber"></param>
        /// <returns></returns>
        public static User Create(string name, string email, string mobileNumber, string altMobileNumber)
        {
            return new User(Guid.NewGuid(), name, email, mobileNumber, altMobileNumber);
        }

        #endregion
    }
}
