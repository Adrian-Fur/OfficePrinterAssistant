using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {

        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator)
        {
            logger.LogInformation("User Controller Logs");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };

            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
        
        [HttpPut]
        [Route("{userId}")]
        public Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, [FromRoute] int userId)
        {
            request.Id = userId;
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }

        [HttpDelete]
        [Route("{userId}")]
        public Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var request = new DeleteUserRequest()
            {
                Id = userId
            };
            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }
    }
}
