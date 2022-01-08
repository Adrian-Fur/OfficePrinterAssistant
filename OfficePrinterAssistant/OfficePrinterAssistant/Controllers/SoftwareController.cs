using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareController : ApiControllerBase
    {
        public SoftwareController(IMediator mediator, ILogger<SoftwareController> logger) : base(mediator)
        {
            logger.LogInformation("Software Controller Logs");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllSoftwares([FromQuery] GetSoftwaresRequest request)
        {
            return this.HandleRequest<GetSoftwaresRequest, GetSoftwaresResponse>(request);
        }
        [HttpGet]
        [Route("{softwareId}")]
        public Task<IActionResult> GetSoftwareById([FromRoute] int softwareId)
        {
            var request = new GetSoftwareByIdRequest()
            {
                Id = softwareId
            };

            return this.HandleRequest<GetSoftwareByIdRequest, GetSoftwareByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddSoftware([FromBody] AddSoftwareRequest request)
        {
            return this.HandleRequest<AddSoftwareRequest, AddSoftwareResponse>(request);
        }
        [HttpPut]
        [Route("{softwareId}")]
        public Task<IActionResult> UpdateSoftware([FromBody] UpdateSoftwareRequest request, [FromRoute] int softwareId)
        {
            request.Id = softwareId;
            return this.HandleRequest<UpdateSoftwareRequest, UpdateSoftwareResponse>(request);
        }
        [HttpDelete]
        [Route("{softwareId}")]
        public Task<IActionResult> DeleteSoftware([FromRoute] int softwareId)
        {
            var request = new DeleteSoftwareRequest()
            {
                Id = softwareId
            };
            return this.HandleRequest<DeleteSoftwareRequest, DeleteSoftwareResponse>(request);
        }
    }
}
