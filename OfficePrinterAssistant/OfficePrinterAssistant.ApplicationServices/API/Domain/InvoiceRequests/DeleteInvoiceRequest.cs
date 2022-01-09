using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests
{
    public class DeleteInvoiceRequest : IRequest<DeleteInvoiceResponse>
    {
        public int Id { get; set; }
    }
}
