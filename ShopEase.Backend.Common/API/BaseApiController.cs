﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Shared;

namespace ShopEase.Backend.Common.API
{
    /// <summary>
    /// Base ApiController with Genric Features
    /// </summary>
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IApiService _apiService;

        protected BaseApiController(IApiService _apiService)
        {
            this._apiService = _apiService;
        }

        /// <summary>
        /// Handles Failure Scenarios to Genarate
        /// Standard Machine-Readabble ProblemDetails
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected IActionResult HandleFailure(Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException();
            }
            if (result is IValidationResult validationResult)
            {
                var modelStateDictionary = new ModelStateDictionary();

                modelStateDictionary.AddModelError(result.Error.Code, result.Error.Message);

                foreach (var error in validationResult.Errors)
                {
                    modelStateDictionary.AddModelError(error.Code, error.Message);
                }

                return ValidationProblem(modelStateDictionary);
            }
            else
            {
                var error = result.Error;

                var statusCode = error.Type switch
                {
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                return Problem(
                        statusCode: statusCode, 
                        type: Enum.GetName(typeof(ErrorType), error.Type), 
                        title: error.Code, 
                        detail: error.Message);
            }
        }

        /// <summary>
        /// Handles Bad Request Situations 
        /// When the Request is Null or Empty
        /// </summary>
        /// <returns></returns>
        protected IActionResult HandleNullOrEmptyRequest()
        {
            var modelStateDictionary = new ModelStateDictionary();
            modelStateDictionary.AddModelError(Error.NullOrEmptyRequest.Code, Error.NullOrEmptyRequest.Message);

            return ValidationProblem(modelStateDictionary);
        }
    }
}
