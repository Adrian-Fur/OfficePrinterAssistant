using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests
{
    public class DeletePrinterRequest : IRequest<DeletePrinterResponse>
    {
        public int PrinterId { get; set; }
    }
}
