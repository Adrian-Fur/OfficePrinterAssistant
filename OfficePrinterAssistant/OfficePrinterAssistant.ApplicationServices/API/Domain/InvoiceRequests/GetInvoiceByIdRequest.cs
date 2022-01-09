using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests
{
    public class GetInvoiceByIdRequest : IRequest<GetInvoiceByIdResponse>
    {
        public int Id { get; set; }
    }
}
