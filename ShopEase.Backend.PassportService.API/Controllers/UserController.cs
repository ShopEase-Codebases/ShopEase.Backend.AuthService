using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Backend.Common.API;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.API.Contracts;
using ShopEase.Backend.PassportService.Application.Users.Queries.GetUserById;

namespace ShopEase.Backend.PassportService.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : BaseApiController
    {
        public UserController(IApiService _apiService) : base(_apiService)
        {
        }

        /// <summary>
        /// To Get a User by UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(string id, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return HandleNullOrEmptyRequest();
            }

            Guid userId = Guid.Parse(id);

            var result = await _apiService.RequestAsync(new GetUserByIdQuery(userId), cancellationToken);

            return result.IsFailure ? 
                        HandleFailure(result) : 
                        Ok(new UserResponse(
                            Id: result.Value.Id,
                            Name: result.Value.Name.Value,
                            Email: result.Value.Email.Value,
                            MobileNumber: result.Value.MobileNumber.Value,
                            AltMobileNumber: result.Value.AltMobileNumber?.Value,
                            CreatedOnUtc: result.Value.CreatedOnUtc,
                            UpdatedOnUtc: result.Value.UpdatedOnUtc)); // Auto Map - ToDo
        }
    }
}
