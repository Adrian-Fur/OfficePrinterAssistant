﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.ErrorHandling;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState.Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            var userName = this.User.FindFirstValue(ClaimTypes.Name);

            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return HttpStatusCode.TooManyRequests;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
