using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests
{
    public class DeleteExtensionRequest : IRequest<DeleteExtensionResponse>
    {
        public int Id { get; set; }
    }
}
