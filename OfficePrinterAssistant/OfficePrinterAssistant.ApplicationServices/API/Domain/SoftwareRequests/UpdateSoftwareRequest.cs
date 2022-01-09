using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests
{
    public class UpdateSoftwareRequest : IRequest<UpdateSoftwareResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public decimal MonthlyFee { get; set; }
        public int PrinterId { get; set; }
    }
}
