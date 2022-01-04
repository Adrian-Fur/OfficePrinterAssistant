using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests
{
    public class UpdatePrinterRequest : IRequest<UpdatePrinterResponse>
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int UserId { get; set; }
    }
}
