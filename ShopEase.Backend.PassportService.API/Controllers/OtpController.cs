using Microsoft.AspNetCore.Mvc;
using ShopEase.Backend.Common.API;
using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.PassportService.API
{
    [Route("api/[controller]")]
    public class OtpController : BaseApiController
    {
        public OtpController(IApiService _apiService) : base(_apiService)
        {
        }

        #region Public Endpoints

        public async Task<IActionResult> SendOtpForEmailVerification(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                return HandleNullOrEmptyRequest();
            }

            return Ok();
        }

        #endregion
    }
}