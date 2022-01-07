using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtensionController : ApiControllerBase
    {
        public ExtensionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllExtensions([FromQuery] GetExtensionsRequest request)
        {
           return this.HandleRequest<GetExtensionsRequest, GetExtensionsResponse>(request);
        }

        [HttpGet]
        [Route("{extensionId}")]
        public Task<IActionResult> GetExtensionById([FromRoute] int extensionId)
        {
            var request = new GetExtensionByIdRequest()
            {
                Id = extensionId
            };
            return this.HandleRequest<GetExtensionByIdRequest, GetExtensionByIdResponse>(request);
        }
        
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddExtension([FromBody] AddExtensionRequest request)
        {
            return this.HandleRequest<AddExtensionRequest, AddExtensionResponse>(request);
        }

        [HttpPut]
        [Route("{extensionId}")]
        public Task<IActionResult> UpdateExtension([FromBody] UpdateExtensionRequest request, [FromRoute] int extensionId)
        {
            request.Id = extensionId;
            return this.HandleRequest<UpdateExtensionRequest, UpdateExtensionResponse>(request);
        }
        [HttpDelete]
        [Route("{extensionId}")]
        public Task<IActionResult> DeleteExtension([FromRoute] int extensionId)
        {
            var request = new DeleteExtensionRequest()
            {
                Id = extensionId
            };
            return this.HandleRequest<DeleteExtensionRequest, DeleteExtensionResponse>(request);
        }
    }
}
