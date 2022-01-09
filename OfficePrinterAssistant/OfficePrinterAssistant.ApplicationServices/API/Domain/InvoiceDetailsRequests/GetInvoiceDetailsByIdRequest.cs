using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests
{
    public class GetInvoiceDetailsByIdRequest : IRequest<GetInvoiceDetailsByIdResponse>
    {
        public int Id { get; set; }
    }
}
