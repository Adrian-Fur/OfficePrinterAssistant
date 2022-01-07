using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests
{
    public class GetExtensionByIdRequest : IRequest<GetExtensionByIdResponse>
    {
        public int Id { get; set; }
    }
}
