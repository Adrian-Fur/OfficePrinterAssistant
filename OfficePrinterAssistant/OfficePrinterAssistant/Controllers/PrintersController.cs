using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintersController : ControllerBase
    {
        private readonly IMediator mediator;

        public PrintersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPrinters([FromQuery] GetPrintersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{printerId}")]
        public async Task<IActionResult> GetPrinterById([FromRoute] int printerId)
        {
            var request = new GetPrinterByIdRequest()
            {
                PrinterId = printerId
            };

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPrinter([FromBody] AddPrinterRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{printerId}")]
        public async Task<IActionResult> UpdatePrinter([FromBody] UpdatePrinterRequest request, [FromRoute] int printerId)
        {
          
            request.Id = printerId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{printerId}")]
        public async Task<IActionResult> DeletePrinter([FromRoute] int printerId)
        {
            var printerToDelete = new DeletePrinterRequest()
            {
                PrinterId = printerId
            };
           var response = await this.mediator.Send(printerToDelete);
           return this.Ok(response);
        }
    }
}

