using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceReponses;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ApiControllerBase
    {
        public InvoicesController(IMediator mediator, ILogger<InvoicesController> logger) : base(mediator)
        {
            logger.LogInformation("Invoices Controller");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllInvoices([FromQuery] GetInvoicesRequest request)
        {
            return this.HandleRequest<GetInvoicesRequest, GetInvoicesResponse>(request);
        }
        [HttpGet]
        [Route("{invoiceId}")]
        public Task<IActionResult> GetInvoiceById([FromRoute] int invoiceId)
        {
            var request = new GetInvoiceByIdRequest()
            {
                Id = invoiceId
            };
            return this.HandleRequest<GetInvoiceByIdRequest, GetInvoiceByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequest request)
        {
            return this.HandleRequest<AddInvoiceRequest, AddInvoiceResponse>(request);
        }
        [HttpPut]
        [Route("{invoiceId}")]
        public Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceRequest request, [FromRoute] int invoiceId)
        {
            request.Id = invoiceId;
            return this.HandleRequest<UpdateInvoiceRequest, UpdateInvoiceResponse>(request);
        }
        [HttpDelete]
        [Route("{invoiceId}")]
        public Task<IActionResult> DeleteInvoice([FromRoute] int invoiceId)
        {
            var request = new DeleteInvoiceRequest()
            {
                Id = invoiceId
            };
            return this.HandleRequest<DeleteInvoiceRequest, DeleteInvoiceResponse>(request);
        }
    }
}
