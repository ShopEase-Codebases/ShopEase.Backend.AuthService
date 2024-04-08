using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Backend.Common.API;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;
using ShopEase.Backend.PassportService.API.Contracts;
using ShopEase.Backend.PassportService.Application.Users.Queries.GetUserById;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopEase.Backend.PassportService.API.Controllers
{
    [Route("api/[controller]")]
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

            Guid userId; 

            try
            {
                userId = Guid.Parse(id);
            }
            catch (Exception ex)
            {
                return Problem(
                        statusCode: StatusCodes.Status400BadRequest,
                        type: nameof(ErrorType.Failure),
                        title: ex.Message,
                        detail: ex.InnerException?.ToString());
            }

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
