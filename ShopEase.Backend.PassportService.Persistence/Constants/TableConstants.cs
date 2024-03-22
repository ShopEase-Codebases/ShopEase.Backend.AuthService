namespace ShopEase.Backend.PassportService.Persistence.Constants
{
    internal static class TableConstants
    {
        internal struct TableNames
        {
            internal const string Users = nameof(Users);

            internal const string UserCredentials = nameof(UserCredentials);

            internal const string Addresses = nameof(Addresses);

            internal const string OtpDetails = nameof(OtpDetails);

            internal const string OutboxMessage = nameof(OutboxMessage);
        }

        internal struct TableSchemas
        {
            internal const string Passport = nameof(Passport);
        }
    }
}
