using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests
{
    public class AddExtensionRequest : IRequest<AddExtensionResponse>
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int PrinterId { get; set; }

    }
}
