using MediatR;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareResponses;

namespace OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests
{
    public class DeleteSoftwareRequest : IRequest<DeleteSoftwareResponse>
    {
        public int Id { get; set; }
    }
}
