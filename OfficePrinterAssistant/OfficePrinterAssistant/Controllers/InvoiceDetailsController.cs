using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceDetailsController : ApiControllerBase
    {
        public InvoiceDetailsController(IMediator mediator, ILogger<InvoiceDetailsController> logger) : base(mediator)
        {
            logger.LogInformation("Invoice Details Controller");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllInvoiceDetails([FromQuery] GetInvoiceDetailsRequest request)
        {
            return this.HandleRequest<GetInvoiceDetailsRequest, GetInvoiceDetailsResponse>(request);
        }
        [HttpGet]
        [Route("{invoiceDetailsId}")]
        public Task<IActionResult> GetInvoiceDetailsById([FromRoute] int invoiceDetailsId)
        {
            var request = new GetInvoiceDetailsByIdRequest()
            {
                Id = invoiceDetailsId
            };
            return this.HandleRequest<GetInvoiceDetailsByIdRequest, GetInvoiceDetailsByIdResponse>(request);
        }
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInvoiceDetails([FromBody] AddInvoiceDetailsRequest request)
        {
            return this.HandleRequest<AddInvoiceDetailsRequest, AddInvoiceDetailsResponse>(request);
        }
        [HttpPut]
        [Route("{invoiceDetailsId}")]
        public Task<IActionResult> UpdateInvoiceDetails([FromBody] UpdateInvoiceDetailsRequest request, [FromRoute] int invoiceDetailsId)
        {
            request.Id = invoiceDetailsId;
            return this.HandleRequest<UpdateInvoiceDetailsRequest, UpdateInvoiceDetailsResponse>(request);
        }
        [HttpDelete]
        [Route("{invoiceDetailsId}")]
        public Task<IActionResult> DeleteInvoiceDetails([FromRoute] int invoiceDetailsId)
        {
            var request = new DeleteInvoiceDetailsRequest()
            {
                Id = invoiceDetailsId
            };
            return this.HandleRequest<DeleteInvoiceDetailsRequest, DeleteInvoiceDetailsResponse>(request);
        }
    }
}
