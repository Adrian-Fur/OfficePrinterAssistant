using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtensionController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExtensionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllExtensions([FromQuery] GetExtensionsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
