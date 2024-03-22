using Microsoft.AspNetCore.Mvc;
using ShopEase.Backend.Common.API;
using ShopEase.Backend.Common.Messaging.Abstractions;

namespace ShopEase.Backend.PassportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(IApiService apiService) : base(apiService)
        {
        }

        public IActionResult GetUser(int id)
        {
            return Problem();
        }
    }
}
