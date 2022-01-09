using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests
{
    public class DeleteInvoiceDetailsRequest : IRequest<DeleteInvoiceDetailsResponse>
    {
        public int Id { get; set; }
    }
}
