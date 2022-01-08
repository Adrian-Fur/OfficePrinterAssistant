using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests
{
    public class AddSoftwareRequest : IRequest<AddSoftwareResponse>
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public decimal Price { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PrinterId { get; set; }
    }
}
