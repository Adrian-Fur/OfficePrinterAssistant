using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintersController : ApiControllerBase
    {
        public PrintersController(IMediator mediator, ILogger<PrintersController> logger) : base(mediator)
        {
            logger.LogInformation("Printer Controller Logs");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllPrinters([FromQuery] GetPrintersRequest request)
        {
            return this.HandleRequest<GetPrintersRequest, GetPrintersResponse>(request);
        }

        [HttpGet]
        [Route("{printerId}")]
        public Task<IActionResult> GetPrinterById([FromRoute] int printerId)
        {
            var request = new GetPrinterByIdRequest()
            {
                PrinterId = printerId
            };

            return this.HandleRequest<GetPrinterByIdRequest, GetPrinterByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddPrinter([FromBody] AddPrinterRequest request)
        {
            return this.HandleRequest<AddPrinterRequest, AddPrinterResponse>(request);
        }

        [HttpPut]
        [Route("{printerId}")]
        public Task<IActionResult> UpdatePrinter([FromBody] UpdatePrinterRequest request, [FromRoute] int printerId)
        {
            request.Id = printerId;
            return this.HandleRequest<UpdatePrinterRequest, UpdatePrinterResponse>(request);
        }

        [HttpDelete]
        [Route("{printerId}")]
        public Task<IActionResult> DeletePrinter([FromRoute] int printerId)
        {
            var request = new DeletePrinterRequest()
            {
                PrinterId = printerId
            };
            return this.HandleRequest<DeletePrinterRequest, DeletePrinterResponse>(request);
        }
    }
}

