using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests
{
    public class UpdateExtensionRequest : IRequest<UpdateExtensionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int PrinterId { get; set; }
    }
}
