using MediatR;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain
{
    public class AddPrinterRequest : IRequest<AddPrinterResponse>
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Counter { get; set; }
        public int UserId { get; set; }
    }
}
