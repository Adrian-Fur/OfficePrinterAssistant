using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests
{
    public class GetSoftwareByIdRequest : IRequest<GetSoftwareByIdResponse>
    {
        public int Id { get; set; }
    }
}
