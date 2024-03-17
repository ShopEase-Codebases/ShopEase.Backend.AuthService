using ShopEase.Backend.Common.Domain.Primitives;
using ShopEase.Backend.PassportService.Core.ValueObjects;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// User Entity Class
    /// </summary>
    public sealed class User : AggregateRoot, IAudit
    {
        #region Fields

        /// <summary>
        /// Private field for List of Addresses
        /// </summary>
        private readonly List<Address> _addresses = [];

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
        private User(Guid id, Name name, Email email, MobileNumber mobileNumber, MobileNumber? altMobileNumber)
            : base(id)
        {
            Name = name;
            Email = email;
            MobileNumber = mobileNumber;
            AltMobileNumber = altMobileNumber;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Full Name
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Email address
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public MobileNumber MobileNumber { get; private set; }

        /// <summary>
        /// Alternate Mobile Number
        /// </summary>
        public MobileNumber? AltMobileNumber { get; private set; }

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

        /// <summary>
        /// List of Addresses
        /// </summary>
        public IReadOnlyCollection<Address> Addresses => _addresses;

        /// <summary>
        /// UserCredentials
        /// </summary>
        public UserCredentials? UserCredentials { get; private set; }

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
        public static User CreateUser(Name name, Email email, MobileNumber mobileNumber, MobileNumber? altMobileNumber)
        {
            return new User(Guid.NewGuid(), name, email, mobileNumber, altMobileNumber);
        }

        /// <summary>
        /// To Create New UserCredentials
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        public UserCredentials CreateCredentials(byte[] passwordHash, byte[] passwordSalt)
        {
            var userCredential = new UserCredentials(Guid.NewGuid(), this.Id, passwordHash, passwordSalt, null, null);

            UserCredentials = userCredential;

            return userCredential;
        }

        /// <summary>
        /// To Create a new Address
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="cityId"></param>
        /// <param name="stateId"></param>
        /// <param name="zipCode"></param>
        /// <param name="countryId"></param>
        /// <param name="addressTypeId"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public Address AddAddress(Guid userId, Name name, string address1, string address2,
            int cityId, int stateId, ZipCode zipCode, int countryId, int addressTypeId,
            bool isDefault)
        {
            if (isDefault && 
                Addresses is not null && Addresses.Any(address => address.IsDefault))
            {
                Addresses.FirstOrDefault(address => address.IsDefault)?.SetOrUnsetDefault();
            }

            if (!isDefault &&
                (Addresses is null || !Addresses.Any(address => address.IsDefault)))
            {
                isDefault = true;
            }

            var address = new Address(Guid.NewGuid(), userId, name, address1, address2, cityId, stateId, zipCode, countryId, addressTypeId, isDefault);

            _addresses.Add(address);

            return address;
        }

        #endregion
    }
}
