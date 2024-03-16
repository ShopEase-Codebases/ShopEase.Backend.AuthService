using ShopEase.Backend.Common.Domain.Primitives;

namespace ShopEase.Backend.PassportService.Core.Entities
{
    /// <summary>
    /// Address Entity Class
    /// </summary>
    public sealed class Address : Entity, IAudit
    {
        #region Constructor

        /// <summary>
        /// Constructor to initailize Address entity
        /// </summary>
        /// <param name="id"></param>
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
        internal Address(Guid id, Guid userId, string name, string address1, string address2, 
            int cityId, int stateId, string zipCode, int countryId, int addressTypeId, bool isDefault) 
            : base(id)
        {
            UserId = userId;
            Name = name;
            AddressLine1 = address1;
            AddressLine2 = address2;
            CityId = cityId;
            StateId = stateId;
            ZipCode = zipCode;
            CountryId = countryId;
            AddressTypeId = addressTypeId;
            IsDefault = isDefault;
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            RowStatus = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id of User Entity
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Full Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// AddressLine1
        /// </summary>
        public string AddressLine1 { get; private set; }

        /// <summary>
        /// AddressLine2
        /// </summary>
        public string AddressLine2 { get; private set; }

        /// <summary>
        /// City
        /// </summary>
        public int CityId { get; private set; }

        /// <summary>
        /// State
        /// </summary>
        public int StateId { get; private set; }

        /// <summary>
        /// ZipCode
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// Country
        /// </summary>
        public int CountryId { get; private set; }

        /// <summary>
        /// AddressType
        /// </summary>
        public int AddressTypeId { get; private set; }

        /// <summary>
        /// IsDefault
        /// </summary>
        public bool IsDefault { get; private set; }

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

        #region Public Methods

        /// <summary>
        /// To switch an Address as Default
        /// </summary>
        public void SetOrUnsetDefault()
        {
            IsDefault = !IsDefault;
        }

        #endregion
    }
}
